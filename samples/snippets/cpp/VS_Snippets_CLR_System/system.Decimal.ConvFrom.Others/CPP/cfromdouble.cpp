
//<Snippet2>
// Example of the explicit conversion from double to Decimal.
using namespace System;
#define formatter "{0,25:E16}{1,33}"

// Get the exception type name; remove the namespace prefix.
String^ GetExceptionType( Exception^ ex )
{
   String^ exceptionType = ex->GetType()->ToString();
   return exceptionType->Substring( exceptionType->LastIndexOf( '.' ) + 1 );
}


// Convert the double argument; catch exceptions that are thrown.
void DecimalFromDouble( double argument )
{
   Object^ decValue;
   
   // Convert the double argument to a Decimal value.
   try
   {
      decValue = (Decimal)argument;
   }
   catch ( Exception^ ex ) 
   {
      decValue = GetExceptionType( ex );
   }

   Console::WriteLine( formatter, argument, decValue );
}

int main()
{
   Console::WriteLine( "This example of the explicit conversion from double "
   "to Decimal \ngenerates the following output.\n" );
   Console::WriteLine( formatter, "double argument", "Decimal value" );
   Console::WriteLine( formatter, "---------------", "-------------" );
   
   // Convert double values and display the results.
   DecimalFromDouble( 1.234567890123E-30 );
   DecimalFromDouble( 1.2345678901234E-25 );
   DecimalFromDouble( 1.23456789012345E-20 );
   DecimalFromDouble( 1.234567890123456E-10 );
   DecimalFromDouble( 1.2345678901234567 );
   DecimalFromDouble( 1.23456789012345678E+12 );
   DecimalFromDouble( 1.234567890123456789E+28 );
   DecimalFromDouble( 1.234567890123456789E+30 );
}

/*
This example of the explicit conversion from double to Decimal
generates the following output.

          double argument                    Decimal value
          ---------------                    -------------
  1.2345678901230000E-030                                0
  1.2345678901233999E-025   0.0000000000000000000000001235
  1.2345678901234499E-020   0.0000000000000000000123456789
  1.2345678901234560E-010       0.000000000123456789012346
  1.2345678901234567E+000                 1.23456789012346
  1.2345678901234568E+012                 1234567890123.46
  1.2345678901234568E+028    12345678901234600000000000000
  1.2345678901234569E+030                OverflowException
*/
//</Snippet2>
