// <Snippet1>
using namespace System;

void main()
{
   DateTime^ date1 = gcnew DateTime(2008, 6, 1, 7, 47, 0);
   Console::WriteLine(date1->ToString());
   
   // Get date-only portion of date, without its time.
   DateTime dateOnly = date1->Date;
   // Display date using short date string.
   Console::WriteLine(dateOnly.ToString("d"));
   // Display date using 24-hour clock.
   Console::WriteLine(dateOnly.ToString("g"));
   Console::WriteLine(dateOnly.ToString(L"MM/dd/yyyy HH:mm"));   
}
// The example displays the following output to the console:
//       6/1/2008 7:47:00 AM
//       6/1/2008
//       6/1/2008 12:00 AM
//       06/01/2008 00:00
// </Snippet1>
