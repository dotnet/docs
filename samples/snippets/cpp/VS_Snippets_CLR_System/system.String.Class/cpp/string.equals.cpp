// String.Equals.cpp : Defines the entry point for the console application.
//

//#include "stdafx.h"

// <Snippet11>
using namespace System;
using namespace System::Globalization;
using namespace System::Threading;

bool TestForEquality(String^ str, StringComparison cmp);

void main()
{
   Thread::CurrentThread->CurrentCulture = CultureInfo::CreateSpecificCulture("tr-TR");      

   String^ filePath = "file://c:/notes.txt";

   Console::WriteLine("Culture-sensitive test for equality:");
   if (! TestForEquality(filePath, StringComparison::CurrentCultureIgnoreCase))
      Console::WriteLine("Access to {0} is allowed.", filePath);
   else
      Console::WriteLine("Access to {0} is not allowed.", filePath);

   Console::WriteLine("\nOrdinal test for equality:");
   if (! TestForEquality(filePath, StringComparison::OrdinalIgnoreCase))
      Console::WriteLine("Access to {0} is allowed.", filePath);
   else
      Console::WriteLine("Access to {0} is not allowed.", filePath);
}

bool TestForEquality(String^ str, StringComparison cmp)
{
      int position = str->IndexOf("://");
      if (position < 0) return false;

      String^ substring = str->Substring(0, position);  
      return substring->Equals("FILE", cmp);
}
// The example displays the following output: 
//       Culture-sensitive test for equality: 
//       Access to file://c:/notes.txt is allowed. 
//        
//       Ordinal test for equality: 
//       Access to file://c:/notes.txt is not allowed.
// </Snippet11>