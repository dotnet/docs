// <Snippet1>
using namespace System;

int main()
{
   const int July = 7;
   const int Feb = 2;
   
   int daysInJuly = System::DateTime::DaysInMonth( 2001, July );
   Console::WriteLine(daysInJuly);   
   // daysInFeb gets 28 because the year 1998 was not a leap year.
   int daysInFeb = System::DateTime::DaysInMonth( 1998, Feb );
   Console::WriteLine(daysInFeb);
   // daysInFebLeap gets 29 because the year 1996 was a leap year.
   int daysInFebLeap = System::DateTime::DaysInMonth( 1996, Feb );
   Console::WriteLine(daysInFebLeap);
}
// The example displays the following output:
//       31
//       28
//       29
// </Snippet1>
