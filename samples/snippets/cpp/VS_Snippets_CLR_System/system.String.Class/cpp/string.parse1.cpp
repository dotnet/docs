// String.Parse1.cpp : Defines the entry point for the console application.
//

//#include "stdafx.h"

// <Snippet9>
using namespace System;
using namespace System::Globalization;

void main()
{
   String^ dateString = "07/10/2011";
   array<CultureInfo^>^ cultures = gcnew array<CultureInfo^> { CultureInfo::InvariantCulture, 
                                                               CultureInfo::CreateSpecificCulture("en-GB"), 
                                                               CultureInfo::CreateSpecificCulture("en-US") };
   Console::WriteLine("{0,-12} {1,10} {2,8} {3,8}\n", "Date String", "Culture", 
                                                "Month", "Day");
   for each (CultureInfo^ culture in cultures) {
      DateTime date = DateTime::Parse(dateString, culture);
      Console::WriteLine("{0,-12} {1,10} {2,8} {3,8}", dateString, 
                        String::IsNullOrEmpty(culture->Name) ?
                        "Invariant" : culture->Name, 
                        date.Month, date.Day);
   }                      
}
// The example displays the following output: 
//       Date String     Culture    Month      Day 
//        
//       07/10/2011    Invariant        7       10 
//       07/10/2011        en-GB       10        7 
//       07/10/2011        en-US        7       10

// </Snippet9>
