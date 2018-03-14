// String.Format1.cpp : Defines the entry point for the console application.
//

//#include "stdafx.h"

// <Snippet8>
using namespace System;
using namespace System::Globalization;

void main()
{
   DateTime^ date = gcnew DateTime(2011, 3, 1);
   array<CultureInfo^>^ cultures = gcnew array<CultureInfo^> { CultureInfo::InvariantCulture, 
                                                               gcnew CultureInfo("en-US"), 
                                                               gcnew CultureInfo("fr-FR") };

   for each (CultureInfo^ culture in cultures)
      Console::WriteLine("{0,-12} {1}", String::IsNullOrEmpty(culture->Name) ?
                        "Invariant" : culture->Name, 
                        date->ToString("d", culture));                                    
}
// The example displays the following output: 
//       Invariant    03/01/2011 
//       en-US        3/1/2011 
//       fr-FR        01/03/2011
// </Snippet8>
