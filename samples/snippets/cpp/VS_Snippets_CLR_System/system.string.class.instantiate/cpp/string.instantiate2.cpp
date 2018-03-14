// String.Instantiate2.cpp : Defines the entry point for the console application.
//

// #include "stdafx.h"

// <Snippet2>
using namespace System;

void main()
{
   wchar_t chars[5] = L"word";
   char bytes[6] = { 0x41, 0x42, 0x43, 0x44, 0x45, 0x00 };

   // Create a string from a character array. 
   String^ string1 = gcnew String(chars);
   Console::WriteLine(string1);

   // Create a string that consists of a character repeated 20 times. 
   String^ string2 = gcnew String('c', 20);
   Console::WriteLine(string2);

   String^ stringFromBytes = nullptr;
   String^ stringFromChars = nullptr;

   char * pbytes = &bytes[0];
   // Create a string from a pointer to a signed byte array.
   stringFromBytes = gcnew String(pbytes);

   wchar_t* pchars =  &chars[0];
   // Create a string from a pointer to a character array.
   stringFromChars = gcnew String(pchars);

   Console::WriteLine(stringFromBytes);
   Console::WriteLine(stringFromChars);
   Console::ReadLine();
}
// The example displays the following output: 
//       word 
//       cccccccccccccccccccc 
//       ABCDE 
//       word  
// </Snippet2>

