// Char1_Ctor.cpp : Defines the entry point for the console application.
//

//#include "stdafx.h"

// <Snippet2>
using namespace System;

void main()
{
   wchar_t characters[] = {L'H',L'e',L'l',L'l',L'o',L' ', 
                           L'W',L'o',L'r',L'l',L'd',L'!',L'\x0000'};

   Char* charPtr = characters;
   String^ value = gcnew String(charPtr);
   Console::WriteLine(value);
}
// The example displays the following output:
//        Hello world!
// </Snippet2>
