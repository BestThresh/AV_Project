// ConsoleApplication1.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "ConsoleApplication1.h"


// This is an example of an exported variable
CONSOLEAPPLICATION1_API int nConsoleApplication1=0;

// This is an example of an exported function.
CONSOLEAPPLICATION1_API int fnConsoleApplication1(void)
{
    return 42;
}

// This is the constructor of a class that has been exported.
// see ConsoleApplication1.h for the class definition
CConsoleApplication1::CConsoleApplication1()
{
    return;
}
