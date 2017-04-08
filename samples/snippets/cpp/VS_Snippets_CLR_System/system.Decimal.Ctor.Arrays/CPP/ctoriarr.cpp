
//<Snippet1>
// Example of the Decimal( int __gc [ ] ) constructor.
using namespace System;

// Get the exception type name; remove the namespace prefix.
String^ GetExceptionType( Exception^ ex )
{
   String^ exceptionType = ex->GetType()->ToString();
   return exceptionType->Substring( exceptionType->LastIndexOf( '.' ) + 1 );
}


// Create a Decimal object and display its value.
void CreateDecimal( array<int>^bits )
{
   
   // Format the constructor for display.
   String^ ctor = String::Format( "Decimal( {{ 0x{0:X}", bits[ 0 ] );
   String^ valOrExc;
   for ( int index = 1; index < bits->Length; index++ )
      ctor = String::Concat( ctor, String::Format( ", 0x{0:X}", bits[ index ] ) );
   ctor = String::Concat( ctor, " } )" );
   try
   {
      
      // Construct the Decimal value.
      Decimal decimalNum = Decimal(bits);
      
      // Format the Decimal value for display.
      valOrExc = decimalNum.ToString();
   }
   catch ( Exception^ ex ) 
   {
      
      // Save the exception type if an exception was thrown.
      valOrExc = GetExceptionType( ex );
   }

   
   // Display the constructor and Decimal value or exception.
   int ctorLen = 76 - valOrExc->Length;
   
   // Display the data on one line if it will fit.
   if ( ctorLen > ctor->Length )
      Console::WriteLine( "{0}{1}", ctor->PadRight( ctorLen ), valOrExc );
   // Otherwise, display the data on two lines.
   else
   {
      Console::WriteLine( "{0}", ctor );
      Console::WriteLine( "{0,76}", valOrExc );
   }
}

int main()
{
   Console::WriteLine( "This example of the Decimal( int __gc [ ] ) "
   "constructor \ngenerates the following output.\n" );
   Console::WriteLine( "{0,-38}{1,38}", "Constructor", "Value or Exception" );
   Console::WriteLine( "{0,-38}{1,38}", "-----------", "------------------" );
   
   // Construct Decimal objects from integer arrays.
   array<Int32>^zero = {0,0,0,0};
   CreateDecimal( zero );
   array<Int32>^arrayShort = {0,0,0};
   CreateDecimal( arrayShort );
   array<Int32>^arrayLong = {0,0,0,0,0};
   CreateDecimal( arrayLong );
   array<Int32>^word0Data = {1000000000,0,0,0};
   CreateDecimal( word0Data );
   array<Int32>^word1Data = {0,1000000000,0,0};
   CreateDecimal( word1Data );
   array<Int32>^word2Data = {0,0,1000000000,0};
   CreateDecimal( word2Data );
   array<Int32>^word3Data = {0,0,0,1000000000};
   CreateDecimal( word3Data );
   array<Int32>^decMax = { -1,-1,-1,0};
   CreateDecimal( decMax );
   array<Int32>^decMin = { -1,-1,-1,0x80000000};
   CreateDecimal( decMin );
   array<Int32>^fracDig16 = { -1,0,0,0x100000};
   CreateDecimal( fracDig16 );
   array<Int32>^fracDig28 = { -1,0,0,0x1C0000};
   CreateDecimal( fracDig28 );
   array<Int32>^fracDig29 = { -1,0,0,0x1D0000};
   CreateDecimal( fracDig29 );
   array<Int32>^reserved = { -1,0,0,0x1C0001};
   CreateDecimal( reserved );
   array<Int32>^Same4Words = {0xF0000,0xF0000,0xF0000,0xF0000};
   CreateDecimal( Same4Words );
}

/*
This example of the Decimal( int __gc [ ] ) constructor
generates the following output.

Constructor                                               Value or Exception
-----------                                               ------------------
Decimal( { 0x0, 0x0, 0x0, 0x0 } )                                          0
Decimal( { 0x0, 0x0, 0x0 } )                               ArgumentException
Decimal( { 0x0, 0x0, 0x0, 0x0, 0x0 } )                     ArgumentException
Decimal( { 0x3B9ACA00, 0x0, 0x0, 0x0 } )                          1000000000
Decimal( { 0x0, 0x3B9ACA00, 0x0, 0x0 } )                 4294967296000000000
Decimal( { 0x0, 0x0, 0x3B9ACA00, 0x0 } )       18446744073709551616000000000
Decimal( { 0x0, 0x0, 0x0, 0x3B9ACA00 } )                   ArgumentException
Decimal( { 0xFFFFFFFF, 0xFFFFFFFF, 0xFFFFFFFF, 0x0 } )
                                               79228162514264337593543950335
Decimal( { 0xFFFFFFFF, 0xFFFFFFFF, 0xFFFFFFFF, 0x80000000 } )
                                              -79228162514264337593543950335
Decimal( { 0xFFFFFFFF, 0x0, 0x0, 0x100000 } )             0.0000004294967295
Decimal( { 0xFFFFFFFF, 0x0, 0x0, 0x1C0000 } ) 0.0000000000000000004294967295
Decimal( { 0xFFFFFFFF, 0x0, 0x0, 0x1D0000 } )              ArgumentException
Decimal( { 0xFFFFFFFF, 0x0, 0x0, 0x1C0001 } )              ArgumentException
Decimal( { 0xF0000, 0xF0000, 0xF0000, 0xF0000 } )
                                                 18133887298.441562272235520
*/
//</Snippet1>
