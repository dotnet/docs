// String.Char2.cpp : Defines the entry point for the console application.
//

//#include "stdafx.h"

// <Snippet3>
using namespace System;

void main()
{
   String^ surrogate =  L"\xD800\xDC03" ;
   for (int ctr = 0; ctr < surrogate->Length; ctr++)
      Console::Write("U+{0:X4} ", Convert::ToUInt16(surrogate[ctr]));

   Console::WriteLine();
   Console::WriteLine("   Is Surrogate Pair: {0}", 
                      Char::IsSurrogatePair(surrogate[0], surrogate[1]));
   Console::ReadLine();
}
// The example displays the following output: 
//       U+D800 U+DC03 
//          Is Surrogate Pair: True
// </Snippet3>
