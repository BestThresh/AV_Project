#include "windows.h"
extern "C"
{
	__declspec(dllexport) void WINAPI StartMonitoring(void);
	__declspec(dllexport) void WINAPI StopMonitoring(void);
}