// TestDll.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "TestDll.h"


// This is an example of an exported variable
// TESTDLL_API int nTestDll=0;

// This is an example of an exported function.
//TESTDLL_API int fnTestDll(void)
//{
//	return 42;
//}

// <Snippet6>
__declspec(dllexport) int Double(int number)
{
	return number * 2;
}
// </Snippet6>

