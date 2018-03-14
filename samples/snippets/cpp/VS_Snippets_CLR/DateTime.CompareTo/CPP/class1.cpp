// <Snippet1>
using namespace System;
void main()
{
   

   System::DateTime theDay(System::DateTime::Today.Year,7,28);
   int compareValue;
   try
   {
      compareValue = theDay.CompareTo( System::DateTime::Today );
   }
   catch ( ArgumentException^ ) 
   {
      System::Console::WriteLine( "Value is not a DateTime" );
      return;
   }

   if ( compareValue < 0 )
   {
      System::Console::WriteLine( "{0:d} is in the past.", theDay );
   }
   else
   if ( compareValue == 0 )
   {
      System::Console::WriteLine( "{0:d} is today!", theDay );
   }
   else
   // compareValue > 0 
   {
      System::Console::WriteLine( "{0:d} has not come yet.", theDay );
   }
}
// </Snippet1>
