
// The following code example demonstrates how to determine the GregorianCalendar 
// version supported by the culture.
// <snippet1>
using namespace System;
using namespace System::Globalization;
using namespace System::Collections;
int main()
{
   
   // Calendar* myOptCals[] = new CultureInfo(S"ar-SA") -> OptionalCalendars;
   CultureInfo^ MyCI = gcnew CultureInfo( "ar-SA" );
   array<Calendar^>^myOptCals = MyCI->OptionalCalendars;
   
   // Checks which ones are GregorianCalendar then determines the GregorianCalendar version.
   Console::WriteLine( "The ar-SA culture supports the following calendars:" );
   IEnumerator^ myEnum = myOptCals->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      Calendar^ cal = safe_cast<Calendar^>(myEnum->Current);
      if ( cal->GetType() == GregorianCalendar::typeid )
      {
         GregorianCalendar^ myGreCal = dynamic_cast<GregorianCalendar^>(cal);
         GregorianCalendarTypes calType = myGreCal->CalendarType;
         Console::WriteLine( " {0} ( {1})", cal, calType );
      }
      else
            Console::WriteLine( " {0}", cal );
   }
}

/*
This code produces the following output.

The ar-SA culture supports the following calendars:
 System.Globalization.HijriCalendar
 System.Globalization.GregorianCalendar ( USEnglish)
 System.Globalization.GregorianCalendar ( MiddleEastFrench)
 System.Globalization.GregorianCalendar ( Arabic)
 System.Globalization.GregorianCalendar ( Localized)
 System.Globalization.GregorianCalendar ( TransliteratedFrench)

*/
// </snippet1>
