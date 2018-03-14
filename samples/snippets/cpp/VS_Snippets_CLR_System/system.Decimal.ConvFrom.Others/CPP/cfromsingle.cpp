
//<Snippet3>
// Example of the explicit conversion from float to Decimal.
using namespace System;
#define formatter "{0,16:E7}{1,33}"

// Get the exception type name; remove the namespace prefix.
String^ GetExceptionType( Exception^ ex )
{
   String^ exceptionType = ex->GetType()->ToString();
   return exceptionType->Substring( exceptionType->LastIndexOf( '.' ) + 1 );
}


// Convert the float argument; catch exceptions that are thrown.
void DecimalFromSingle( float argument )
{
   Object^ decValue;
   
   // Convert the float argument to a Decimal value.
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
   Console::WriteLine( "This example of the explicit conversion from float "
   "to Decimal \ngenerates the following output.\n" );
   Console::WriteLine( formatter, "float argument", "Decimal value" );
   Console::WriteLine( formatter, "--------------", "-------------" );
   
   // Convert float values and display the results.
   DecimalFromSingle( 1.2345E-30F );
   DecimalFromSingle( 1.2345E-26F );
   DecimalFromSingle( 1.23456E-22F );
   DecimalFromSingle( 1.23456E-12F );
   DecimalFromSingle( 1.234567F );
   DecimalFromSingle( 1.234567E+12F );
   DecimalFromSingle( 1.2345678E+28F );
   DecimalFromSingle( 1.2345678E+30F );
}

/*
This example of the explicit conversion from float to Decimal
generates the following output.

  float argument                    Decimal value
  --------------                    -------------
  1.2345000E-030                                0
  1.2345000E-026   0.0000000000000000000000000123
  1.2345600E-022    0.000000000000000000000123456
  1.2345600E-012              0.00000000000123456
  1.2345671E+000                         1.234567
  1.2345670E+012                    1234567000000
  1.2345678E+028    12345680000000000000000000000
  1.2345678E+030                OverflowException
*/
//</Snippet3>
