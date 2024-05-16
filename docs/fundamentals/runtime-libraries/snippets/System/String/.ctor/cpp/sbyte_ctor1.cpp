// SByte_Ctor1.cpp : Defines the entry point for the console application.
//

//#include "stdafx.h"

// <Snippet4>
using namespace System;

void main()
{
      char chars[] = { 'a', 'b', 'c', 'd', '\x00' };
      
      char* charPtr = chars;
      String^ value = gcnew String(charPtr);

      Console::WriteLine(value);
}
// The example displays the following output:
//      abcd
// </Snippet4>