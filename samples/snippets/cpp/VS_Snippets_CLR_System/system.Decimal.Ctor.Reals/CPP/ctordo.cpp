
//<Snippet2>
// Example of the Decimal( double ) constructor.
using namespace System;

// Get the exception type name; remove the namespace prefix.
String^ GetExceptionType( Exception^ ex )
{
   String^ exceptionType = ex->GetType()->ToString();
   return exceptionType->Substring( exceptionType->LastIndexOf( '.' ) + 1 );
}


// Create a Decimal object and display its value.
void CreateDecimal( double value, String^ valToStr )
{
   
   // Format and display the constructor.
   Console::Write( "{0,-34}", String::Format( "Decimal( {0} )", valToStr ) );
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
   Console::WriteLine( "This example of the Decimal( double ) "
   "constructor \ngenerates the following output.\n" );
   Console::WriteLine( "{0,-34}{1,31}", "Constructor", "Value or Exception" );
   Console::WriteLine( "{0,-34}{1,31}", "-----------", "------------------" );
   
   // Construct Decimal objects from double values.
   CreateDecimal( 1.23456789E+5, "1.23456789E+5" );
   CreateDecimal( 1.234567890123E+15, "1.234567890123E+15" );
   CreateDecimal( 1.2345678901234567E+25, "1.2345678901234567E+25" );
   CreateDecimal( 1.2345678901234567E+35, "1.2345678901234567E+35" );
   CreateDecimal( 1.23456789E-5, "1.23456789E-5" );
   CreateDecimal( 1.234567890123E-15, "1.234567890123E-15" );
   CreateDecimal( 1.2345678901234567E-25, "1.2345678901234567E-25" );
   CreateDecimal( 1.2345678901234567E-35, "1.2345678901234567E-35" );
   CreateDecimal( 1.0 / 7.0, "1.0 / 7.0" );
}

/*
This example of the Decimal( double ) constructor
generates the following output.

Constructor                                    Value or Exception
-----------                                    ------------------
Decimal( 1.23456789E+5 )                               123456.789
Decimal( 1.234567890123E+15 )                    1234567890123000
Decimal( 1.2345678901234567E+25 )      12345678901234600000000000
Decimal( 1.2345678901234567E+35 )               OverflowException
Decimal( 1.23456789E-5 )                          0.0000123456789
Decimal( 1.234567890123E-15 )       0.000000000000001234567890123
Decimal( 1.2345678901234567E-25 )  0.0000000000000000000000001235
Decimal( 1.2345678901234567E-35 )                               0
Decimal( 1.0 / 7.0 )                            0.142857142857143
*/
//</Snippet2>
