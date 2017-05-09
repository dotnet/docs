// DateTime.TryParse1.cpp : Defines the entry point for the console application.
//

// <Snippet1>
using namespace System;
using namespace System::Globalization;

void main()
{
   array<String^>^ dateStrings = { "05/01/2009 14:57:32.8", "2009-05-01 14:57:32.8", 
                                   "2009-05-01T14:57:32.8375298-04:00", 
                                    "5/01/2008 14:57:32.80 -07:00", 
                                    "1 May 2008 2:57:32.8 PM", "16-05-2009 1:00:32 PM", 
                                    "Fri, 15 May 2009 20:10:57 GMT" };
   DateTime dateValue;

   Console::WriteLine("Attempting to parse strings using {0} culture.", 
                     CultureInfo::CurrentCulture->Name);
   for each (String^ dateString in dateStrings)
   {
      if (DateTime::TryParse(dateString, dateValue)) 
         Console::WriteLine("  Converted '{0}' to {1} ({2}).", dateString, 
                           dateValue, dateValue.Kind);
      else
         Console::WriteLine("  Unable to parse '{0}'.", dateString);
   }
}
// The example displays the following output: 
//    Attempting to parse strings using en-US culture. 
//       Converted '05/01/2009 14:57:32.8' to 5/1/2009 2:57:32 PM (Unspecified). 
//       Converted '2009-05-01 14:57:32.8' to 5/1/2009 2:57:32 PM (Unspecified). 
//       Converted '2009-05-01T14:57:32.8375298-04:00' to 5/1/2009 11:57:32 AM (Local). 
//       Converted '5/01/2008 14:57:32.80 -07:00' to 5/1/2008 2:57:32 PM (Local). 
//       Converted '1 May 2008 2:57:32.8 PM' to 5/1/2008 2:57:32 PM (Unspecified). 
//       Unable to parse '16-05-2009 1:00:32 PM'. 
//       Converted 'Fri, 15 May 2009 20:10:57 GMT' to 5/15/2009 1:10:57 PM (Local).
// </Snippet1>
