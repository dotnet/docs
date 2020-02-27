
//<Snippet2>
// Example of the Decimal::ToInt32 and Decimal::ToUInt32 methods.
using namespace System;
#define formatter "{0,17}{1,19}{2,19}"

// Get the exception type name; remove the namespace prefix.
String^ GetExceptionType( Exception^ ex )
{
   String^ exceptionType = ex->GetType()->ToString();
   return exceptionType->Substring( exceptionType->LastIndexOf( '.' ) + 1 );
}


// Convert the Decimal argument; catch exceptions that are thrown.
void DecimalToU_Int32( Decimal argument )
{
   Object^ Int32Value;
   Object^ UInt32Value;
   
   // Convert the argument to an int value.
   try
   {
      Int32Value = Decimal::ToInt32( argument );
   }
   catch ( Exception^ ex ) 
   {
      Int32Value = GetExceptionType( ex );
   }

   
   // Convert the argument to an unsigned int value.
   try
   {
      UInt32Value = Decimal::ToUInt32( argument );
   }
   catch ( Exception^ ex ) 
   {
      UInt32Value = GetExceptionType( ex );
   }

   Console::WriteLine( formatter, argument, Int32Value, UInt32Value );
}

int main()
{
   Console::WriteLine( "This example of the \n"
   "  Decimal::ToInt32( Decimal ) and \n"
   "  Decimal::ToUInt32( Decimal ) \nmethods "
   "generates the following output. It \ndisplays "
   "several converted Decimal values.\n" );
   Console::WriteLine( formatter, "Decimal argument", "int/exception", "unsigned int" );
   Console::WriteLine( formatter, "----------------", "-------------", "------------" );
   
   // Convert Decimal values and display the results.
   DecimalToU_Int32( Decimal::Parse(  "123" ) );
   DecimalToU_Int32( Decimal(123000,0,0,false,3) );
   DecimalToU_Int32( Decimal::Parse(  "123.999" ) );
   DecimalToU_Int32( Decimal::Parse(  "4294967295.999" ) );
   DecimalToU_Int32( Decimal::Parse(  "4294967296" ) );
   DecimalToU_Int32( Decimal::Parse(  "2147483647.999" ) );
   DecimalToU_Int32( Decimal::Parse(  "2147483648" ) );
   DecimalToU_Int32( Decimal::Parse(  "-0.999" ) );
   DecimalToU_Int32( Decimal::Parse(  "-1" ) );
   DecimalToU_Int32( Decimal::Parse(  "-2147483648.999" ) );
   DecimalToU_Int32( Decimal::Parse(  "-2147483649" ) );
}

/*
This example of the
  Decimal::ToInt32( Decimal ) and
  Decimal::ToUInt32( Decimal )
methods generates the following output. It
displays several converted Decimal values.

 Decimal argument      int/exception       unsigned int
 ----------------      -------------       ------------
              123                123                123
          123.000                123                123
          123.999                123                123
   4294967295.999  OverflowException         4294967295
       4294967296  OverflowException  OverflowException
   2147483647.999         2147483647         2147483647
       2147483648  OverflowException         2147483648
           -0.999                  0                  0
               -1                 -1  OverflowException
  -2147483648.999        -2147483648  OverflowException
      -2147483649  OverflowException  OverflowException
*/
//</Snippet2>
