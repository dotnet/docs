// Assignment.cpp : Defines the entry point for the console application.
//

//#include "stdafx.h"
// <Snippet1>
using namespace System;

void main()
{
   String^ value1 = L"This is a string.";
   String^ value2 = value1;
   Console::WriteLine(value1);
   Console::WriteLine(value2);
}
// The example displays the following output:
//    This is a string.
//    This is a string.
// </Snippet1>
