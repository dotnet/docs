// String.Index2.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

//<Snippet5>
using namespace System;

void main()
{
   String^ s1 = "This string consists of a single short sentence.";
   int nWords = 0;

   s1 = s1->Trim();      
   for each (Char ch in s1)
   {
      if (Char::IsPunctuation(ch) | Char::IsWhiteSpace(ch))
         nWords++;              
   }
   Console::WriteLine("The sentence\n   {0}\nhas {1} words.",
                      s1, nWords);  
   Console::ReadLine();
}
// The example displays the following output: 
//       The sentence 
//          This string consists of a single short sentence. 
//       has 8 words.
// </Snippet5>

