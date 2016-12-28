// dllmain.cpp : Defines the entry point for the DLL application.
#include "stdafx.h"
#include "stdlib.h"
#include "windows.h"

#define	PROCHOOK_MOV 0x48
#define PROCHOOK_64BITADDR 0xB8
#define PROCHOOK_JMP 0xFF
#define PROCHOOK_REG 0xE0

typedef struct _ProcHook
{
	BYTE byMovCode = PROCHOOK_MOV;
	BYTE byAddrType = PROCHOOK_64BITADDR;
	unsigned __int64 ui64Address;
	BYTE byJmpCode = PROCHOOK_JMP;
	BYTE byRegisterCode = PROCHOOK_REG;
}PROCHOOK, *PPROCHOOK;

typedef struct _SwapProcRec
{
	unsigned __int64	OriginFuncAddr;
	unsigned __int64	FakeFuncAddr;
	PROCHOOK			phOld;
	PROCHOOK			phNew;
}SwapProcRec, *PSwapProcRec;
PSwapProcRec sprTerminateProcess;
HINSTANCE _hdll;
HHOOK hHook;
BOOL isRootApp = false;
BOOL isHook = false;
BOOL WINAPI Fake_TerminateProcess(HANDLE hProcess, UINT exitcode);
void WINAPI InitHook(void);
void WINAPI HookFunction(SwapProcRec phr);
void WINAPI InitHook(void);
LRESULT CALLBACK WINAPI MsgHookingProc(int iCode, WPARAM wParam, LPARAM lParam);
BOOL WINAPI Fake_TerminateProcess(HANDLE hProcess, UINT exitcode)
{
	return true;
}
void WINAPI HookFunction(PSwapProcRec phr)
{

	// copy the jump bytes over top of the function
	memcpy((void *)phr->OriginFuncAddr, (const void *)&phr->phNew, sizeof(PROCHOOK));
	return;
}
void WINAPI UnHook(PSwapProcRec phr)
{
	memcpy((void*)phr->OriginFuncAddr, (const void *)&phr->FakeFuncAddr,
		sizeof(PROCHOOK));
	phr->OriginFuncAddr = 0;
	phr->FakeFuncAddr = 0;
	phr->phNew.ui64Address = 00;
	memset((void*)&phr->phOld, 0, sizeof(PROCHOOK));

}
void WINAPI InitHook(void )
{
	if (isRootApp)
		return;
	if (isHook)
		return;
	isHook = true;
	DWORD old_attr;
	sprTerminateProcess->OriginFuncAddr = (UINT64)TerminateProcess;
	sprTerminateProcess->FakeFuncAddr = (UINT64)Fake_TerminateProcess;
	sprTerminateProcess->phNew.ui64Address = (UINT64)Fake_TerminateProcess;

	if (VirtualProtect((void*)sprTerminateProcess->OriginFuncAddr,
		sizeof(PROCHOOK), PAGE_EXECUTE_READWRITE, &old_attr))
	{

	}
	HookFunction(sprTerminateProcess);

}

LRESULT CALLBACK WINAPI MsgHookingProc(int iCode, WPARAM wParam, LPARAM lParam)
{
	char szKey[2] = "";
	MSG FAR * pMsg;

	// create hooks
	InitHook();

	// pass the message on
	return CallNextHookEx(hHook, iCode, wParam, lParam);
}
void WINAPI StartMonitor(void)
{
	isRootApp = true;
	UnHook(sprTerminateProcess);

	hHook = SetWindowsHookEx(WH_GETMESSAGE, MsgHookingProc, _hdll, 0);
	return;
}
void WINAPI StopMonitor(void)
{
	UnhookWindowsHookEx(hHook);
	return;
}

BOOL APIENTRY DllMain( HMODULE hModule,
                       DWORD  ul_reason_for_call,
                       LPVOID lpReserved
					 )
{
	switch (ul_reason_for_call)
	{
	case DLL_PROCESS_ATTACH:
	{
		_hdll = hModule;
		InitHook();
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
	case DLL_PROCESS_DETACH:
		UnHook(sprTerminateProcess);
		break;
	}
	return TRUE;
}

