using namespace System;

void main()
{
   //<Snippet1>
   Double dNumber = 23.15;

   try
   {
      // Returns 23
      Int32 iNumber = Convert::ToInt32( dNumber );
   }
   catch ( OverflowException^ ) 
   {
      Console::WriteLine(
         "Overflow in Double to Int32 conversion" );
   }
   // Returns True
   Boolean bNumber = Convert::ToBoolean( dNumber );
   
   // Returns "23.15"
   String^ strNumber = Convert::ToString( dNumber );

   try
   {
      // Returns '2'
      Char chrNumber = Convert::ToChar( strNumber->Substring( 0, 1 ) );
   }
   catch ( ArgumentNullException^ ) 
   {
      Console::WriteLine(  "String is null" );
   }
   catch ( FormatException^ ) 
   {
      Console::WriteLine(  "String length is greater than 1" );
   }
   
   // System::Console::ReadLine() returns a string and it
   // must be converted.
   Int32 newInteger = 0;
   try
   {
      Console::WriteLine(  "Enter an integer:" );
      newInteger = Convert::ToInt32( System::Console::ReadLine() );
   }
   catch ( ArgumentNullException^ ) 
   {
      Console::WriteLine(  "String is null" );
   }
   catch ( FormatException^ ) 
   {
      Console::WriteLine(  "String does not consist of an " +
         "optional sign followed by a series of digits" );
   }
   catch ( OverflowException^ ) 
   {
      Console::WriteLine(  "Overflow in string to Int32 conversion" );
   }

   Console::WriteLine( "Your integer as a Double is {0}",
      Convert::ToDouble( newInteger ) );
   //</Snippet1>
}
