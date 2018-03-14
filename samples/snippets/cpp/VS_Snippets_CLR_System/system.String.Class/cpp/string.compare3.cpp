// String.Compare3.cpp : Defines the entry point for the console application.
//

//#include "stdafx.h"

// <Snippet13>
using namespace System;

void FindInString(String^ s, String^ substring, StringComparison options);

void main()
{
   // Search for "oe" and "œu" in "œufs" and "oeufs".
   String^ s1 = L"œufs";
   String^ s2 = L"oeufs";
   FindInString(s1, "oe", StringComparison::CurrentCulture);
   FindInString(s1, "oe", StringComparison::Ordinal);
   FindInString(s2, "œu", StringComparison::CurrentCulture);
   FindInString(s2, "œu", StringComparison::Ordinal);
   Console::WriteLine();

   String^ s3 = L"co\x00ADoperative";
   FindInString(s3, L"\x00AD", StringComparison::CurrentCulture);
   FindInString(s3, L"\x00AD", StringComparison::Ordinal);
}

void FindInString(String^ s, String^ substring, StringComparison options)
{
   int result = s->IndexOf(substring, options);
   if (result != -1)
      Console::WriteLine("'{0}' found in {1} at position {2}", 
                        substring, s, result);
   else
      Console::WriteLine("'{0}' not found in {1}", 
                        substring, s);                                                  
}
// The example displays the following output:
//      'oe' found in oufs at position 0
//      'oe' not found in oufs
//      'ou' found in oeufs at position 0
//      'ou' not found in oeufs
//
//      '-' found in co-operative at position 0
//      '-' found in co-operative at position 2
// </Snippet13>
