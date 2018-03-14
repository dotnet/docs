
//<Snippet1>
// Example of the Decimal( float ) constructor.
using namespace System;

// Get the exception type name; remove the namespace prefix.
String^ GetExceptionType( Exception^ ex )
{
   String^ exceptionType = ex->GetType()->ToString();
   return exceptionType->Substring( exceptionType->LastIndexOf( '.' ) + 1 );
}


// Create a Decimal object and display its value.
void CreateDecimal( float value, String^ valToStr )
{
   
   // Format and display the constructor.
   Console::Write( "{0,-27}", String::Format( "Decimal( {0} )", valToStr ) );
   try
   {
      
      // Construct the Decimal value.
      Decimal decimalNum = Decimal(value);
      
      // Display the value if it was created successfully.
      Console::WriteLine( "{0,31}", decimalNum );
   }
   catch ( Exception^ ex ) 
   {
      
      // Display the exception type if an exception was thrown.
      Console::WriteLine( "{0,31}", GetExceptionType( ex ) );
   }

}

int main()
{
   Console::WriteLine( "This example of the Decimal( float ) "
   "constructor \ngenerates the following output.\n" );
   Console::WriteLine( "{0,-27}{1,31}", "Constructor", "Value or Exception" );
   Console::WriteLine( "{0,-27}{1,31}", "-----------", "------------------" );
   
   // Construct Decimal objects from float values.
   CreateDecimal( 1.2345E+5, "1.2345E+5" );
   CreateDecimal( 1.234567E+15, "1.234567E+15" );
   CreateDecimal( 1.23456789E+25, "1.23456789E+25" );
   CreateDecimal( 1.23456789E+35, "1.23456789E+35" );
   CreateDecimal( 1.2345E-5, "1.2345E-5" );
   CreateDecimal( 1.234567E-15, "1.234567E-15" );
   CreateDecimal( 1.23456789E-25, "1.23456789E-25" );
   CreateDecimal( 1.23456789E-35, "1.23456789E-35" );
   CreateDecimal( 1.0 / 7.0, "1.0 / 7.0" );
}

/*
This example of the Decimal( float ) constructor
generates the following output.

Constructor                             Value or Exception
-----------                             ------------------
Decimal( 1.2345E+5 )                                123450
Decimal( 1.234567E+15 )                   1234567000000000
Decimal( 1.23456789E+25 )       12345680000000000000000000
Decimal( 1.23456789E+35 )                OverflowException
Decimal( 1.2345E-5 )                           0.000012345
Decimal( 1.234567E-15 )            0.000000000000001234567
Decimal( 1.23456789E-25 )   0.0000000000000000000000001235
Decimal( 1.23456789E-35 )                                0
Decimal( 1.0 / 7.0 )                             0.1428571
*/
//</Snippet1>
