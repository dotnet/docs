// Char2_Ctor.cpp : Defines the entry point for the console application.
//

//#include "stdafx.h"

// <Snippet3>
using namespace System;


void main()
{
   wchar_t characters[] = {L'H',L'e',L'l',L'l',L'o',L' ', 
                           L'W',L'o',L'r',L'l',L'd',L'!',L'\x0000'};

   Char* charPtr = characters;
   int length = 0;
   Char* iterator = charPtr;

   while (*iterator != '\x0000')
   {
      if (*iterator == L'!' || *iterator == L'.')
         break;
      *iterator++;
      length++;
   }
   String^ value = gcnew String(charPtr, 0, length);
   Console::WriteLine(value);
}
// The example displays the following output:
//      Hello World
// </Snippet3>

