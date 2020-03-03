
// The following code example demonstrates the members of the Calendar class.
// <snippet1>
using namespace System;
using namespace System::Globalization;
void DisplayValues( Calendar^ myCal, DateTime myDT )
{
   Console::WriteLine( "   Era: {0}", myCal->GetEra( myDT ) );
   Console::WriteLine( "   Year: {0}", myCal->GetYear( myDT ) );
   Console::WriteLine( "   Month: {0}", myCal->GetMonth( myDT ) );
   Console::WriteLine( "   DayOfYear: {0}", myCal->GetDayOfYear( myDT ) );
   Console::WriteLine( "   DayOfMonth: {0}", myCal->GetDayOfMonth( myDT ) );
   Console::WriteLine( "   DayOfWeek: {0}", myCal->GetDayOfWeek( myDT ) );
   Console::WriteLine( "   Hour: {0}", myCal->GetHour( myDT ) );
   Console::WriteLine( "   Minute: {0}", myCal->GetMinute( myDT ) );
   Console::WriteLine( "   Second: {0}", myCal->GetSecond( myDT ) );
   Console::WriteLine( "   Milliseconds: {0}", myCal->GetMilliseconds( myDT ) );
   Console::WriteLine();
}

int main()
{
   
   // Sets a DateTime to April 3, 2002 of the Gregorian calendar.
   DateTime myDT = DateTime(2002,4,3,gcnew GregorianCalendar);
   
   // Uses the default calendar of the InvariantCulture.
   Calendar^ myCal = CultureInfo::InvariantCulture->Calendar;
   
   // Displays the values of the DateTime.
   Console::WriteLine( "April 3, 2002 of the Gregorian calendar:" );
   DisplayValues( myCal, myDT );
   
   // Adds 5 to every component of the DateTime.
   myDT = myCal->AddYears( myDT, 5 );
   myDT = myCal->AddMonths( myDT, 5 );
   myDT = myCal->AddWeeks( myDT, 5 );
   myDT = myCal->AddDays( myDT, 5 );
   myDT = myCal->AddHours( myDT, 5 );
   myDT = myCal->AddMinutes( myDT, 5 );
   myDT = myCal->AddSeconds( myDT, 5 );
   myDT = myCal->AddMilliseconds( myDT, 5 );
   
   // Displays the values of the DateTime.
   Console::WriteLine( "After adding 5 to each component of the DateTime:" );
   DisplayValues( myCal, myDT );
}

/*
This code produces the following output.

April 3, 2002 of the Gregorian calendar:
Era:          1
Year:         2002
Month:        4
DayOfYear:    93
DayOfMonth:   3
DayOfWeek:    Wednesday
Hour:         0
Minute:       0
Second:       0
Milliseconds: 0

After adding 5 to each component of the DateTime:
Era:          1
Year:         2007
Month:        10
DayOfYear:    286
DayOfMonth:   13
DayOfWeek:    Saturday
Hour:         5
Minute:       5
Second:       5
Milliseconds: 5

*/
// </snippet1>
