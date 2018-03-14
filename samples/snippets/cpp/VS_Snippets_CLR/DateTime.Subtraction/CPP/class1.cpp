using namespace System;

int main()
{
   //<Snippet1>
   System::DateTime date1 = System::DateTime( 1996, 6, 3, 22, 15, 0 );
   System::DateTime date2 = System::DateTime( 1996, 12, 6, 13, 2, 0 );
   System::DateTime date3 = System::DateTime( 1996, 10, 12, 8, 42, 0 );
   
   // diff1 gets 185 days, 14 hours, and 47 minutes.
   System::TimeSpan diff1 = date2.Subtract( date1 );
   
   // date4 gets 4/9/1996 5:55:00 PM.
   System::DateTime date4 = date3.Subtract( diff1 );
   
   // diff2 gets 55 days 4 hours and 20 minutes.
   System::TimeSpan diff2 = date2 - date3;
   
   // date5 gets 4/9/1996 5:55:00 PM.
   System::DateTime date5 = date1 - diff2;
   //</Snippet1>

   System::Console::WriteLine( diff1 );
   System::Console::WriteLine( date4 );
   System::Console::WriteLine( diff2 );
   System::Console::WriteLine( date4 );
}
