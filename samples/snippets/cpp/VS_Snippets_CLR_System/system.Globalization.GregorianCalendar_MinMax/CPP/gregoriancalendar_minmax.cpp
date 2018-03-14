// The following code example gets the minimum date and the maximum date of the calendar.
// <snippet1>
using namespace System;
using namespace System::Globalization;

int main()
{
   // Create an instance of the calendar.
   GregorianCalendar^ myCal = gcnew GregorianCalendar;
   Console::WriteLine( myCal );
   
   // Display the MinSupportedDateTime.
   DateTime myMin = myCal->MinSupportedDateTime;
   Console::WriteLine( "MinSupportedDateTime: {0:D2}/{1:D2}/{2:D4}", myCal->GetMonth( myMin ), myCal->GetDayOfMonth( myMin ), myCal->GetYear( myMin ) );
   
   // Display the MaxSupportedDateTime.
   DateTime myMax = myCal->MaxSupportedDateTime;
   Console::WriteLine( "MaxSupportedDateTime: {0:D2}/{1:D2}/{2:D4}", myCal->GetMonth( myMax ), myCal->GetDayOfMonth( myMax ), myCal->GetYear( myMax ) );
}

/*
This code produces the following output.

System.Globalization.GregorianCalendar
MinSupportedDateTime: 01/01/0001
MaxSupportedDateTime: 12/31/9999

*/
// </snippet1>
