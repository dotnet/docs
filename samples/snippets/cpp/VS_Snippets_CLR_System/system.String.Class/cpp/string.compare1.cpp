// String.Compare1.cpp : Defines the entry point for the console application.
//

//#include "stdafx.h"

// <Snippet10>
using namespace System;
using namespace System::Globalization;
using namespace System::Threading;

void main()
{
   Thread::CurrentThread->CurrentCulture = CultureInfo::CreateSpecificCulture("en-US");
   Console::WriteLine(String::Compare("A", "a", StringComparison::CurrentCulture));
   Console::WriteLine(String::Compare("A", "a", StringComparison::Ordinal));
}
// The example displays the following output: 
//       1 
//       -32
// </Snippet10>
