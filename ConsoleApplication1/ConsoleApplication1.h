// The following ifdef block is the standard way of creating macros which make exporting 
// from a DLL simpler. All files within this DLL are compiled with the CONSOLEAPPLICATION1_EXPORTS
// symbol defined on the command line. This symbol should not be defined on any project
// that uses this DLL. This way any other project whose source files include this file see 
// CONSOLEAPPLICATION1_API functions as being imported from a DLL, whereas this DLL sees symbols
// defined with this macro as being exported.
#ifdef CONSOLEAPPLICATION1_EXPORTS
#define CONSOLEAPPLICATION1_API __declspec(dllexport)
#else
#define CONSOLEAPPLICATION1_API __declspec(dllimport)
#endif

// This class is exported from the ConsoleApplication1.dll
class CONSOLEAPPLICATION1_API CConsoleApplication1 {
public:
	CConsoleApplication1(void);
	// TODO: add your methods here.
};

extern CONSOLEAPPLICATION1_API int nConsoleApplication1;

CONSOLEAPPLICATION1_API int fnConsoleApplication1(void);
