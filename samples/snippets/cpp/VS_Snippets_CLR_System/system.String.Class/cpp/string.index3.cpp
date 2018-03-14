// String.Index3.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
// <Snippet6>
using namespace System;
using namespace System::Collections::Generic;
using namespace System::Globalization;

void main()
{
   // First sentence of The Mystery of the Yellow Room, by Leroux. 
   String^ opening = L"Ce n'est pas sans une certaine émotion que "+
                     L"je commence à raconter ici les aventures " +
                     L"extraordinaires de Joseph Rouletabille."; 
  
   // Character counters. 
   int nChars = 0;
   // Objects to store word count.
   List<int>^ chars = gcnew List<int>();
   List<int>^ elements = gcnew List<int>();

   for each (Char ch in opening) {
      // Skip the ' character. 
      if (ch == '\x0027') continue;

      if (Char::IsWhiteSpace(ch) | (Char::IsPunctuation(ch))) {
         chars->Add(nChars);
         nChars = 0;
      }
      else {
         nChars++;
      }
   }

   TextElementEnumerator^ te = StringInfo::GetTextElementEnumerator(opening);
   while (te->MoveNext()) {
      String^ s = te->GetTextElement();   
      // Skip the ' character. 
      if (s == "\x0027") continue;
      if ( String::IsNullOrEmpty(s->Trim()) | (s->Length == 1 && Char::IsPunctuation(Convert::ToChar(s)))) {
         elements->Add(nChars);         
         nChars = 0;
      }
      else {
         nChars++;
      }
   }

   // Display character counts.
   Console::WriteLine("{0,6} {1,20} {2,20}",
                      "Word #", "Char Objects", "Characters"); 
   for (int ctr = 0; ctr < chars->Count; ctr++) 
      Console::WriteLine("{0,6} {1,20} {2,20}",
                         ctr, chars[ctr], elements[ctr]); 
   Console::ReadLine();
}
// The example displays the following output:
//      Word #         Char Objects           Characters
//           0                    2                    2
//           1                    4                    4
//           2                    3                    3
//           3                    4                    4
//           4                    3                    3
//           5                    8                    8
//           6                    8                    7
//           7                    3                    3
//           8                    2                    2
//           9                    8                    8
//          10                    2                    1
//          11                    8                    8
//          12                    3                    3
//          13                    3                    3
//          14                    9                    9
//          15                   15                   15
//          16                    2                    2
//          17                    6                    6
//          18                   12                   12
// </Snippet6>
