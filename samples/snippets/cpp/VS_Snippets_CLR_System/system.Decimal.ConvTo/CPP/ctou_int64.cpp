
//<Snippet1>
// Example of the explicit conversions from Decimal to __int64 and 
// Decimal to unsigned __int64.
using namespace System;
#define formatter "{0,25}{1,22}{2,22}"

// Get the exception type name; remove the namespace prefix.
String^ GetExceptionType( Exception^ ex )
{
   String^ exceptionType = ex->GetType()->ToString();
   return exceptionType->Substring( exceptionType->LastIndexOf( '.' ) + 1 );
}


// Convert the Decimal argument; catch exceptions that are thrown.
void DecimalToU_Int64( Decimal argument )
{
   Object^ Int64Value;
   Object^ UInt64Value;
   
   // Convert the argument to an __int64 value.
   try
   {
      Int64Value = (__int64)argument;
   }
   catch ( Exception^ ex ) 
   {
      Int64Value = GetExceptionType( ex );
   }

   
   // Convert the argument to an unsigned __int64 value.
   try
   {
      UInt64Value = (unsigned __int64)argument;
   }
   catch ( Exception^ ex ) 
   {
      UInt64Value = GetExceptionType( ex );
   }

   Console::WriteLine( formatter, argument, Int64Value, UInt64Value );
}

int main()
{
   Console::WriteLine( "This example of the explicit conversions from Decimal to "
   "__int64 \nand Decimal to unsigned __int64 generates the "
   "following output. \nIt displays several converted Decimal "
   "values.\n" );
   Console::WriteLine( formatter, "Decimal argument", "__int64", "unsigned __int64" );
   Console::WriteLine( formatter, "----------------", "-------", "----------------" );
   
   // Convert Decimal values and display the results.
   DecimalToU_Int64( Decimal::Parse(  "123" ) );
   DecimalToU_Int64( Decimal(123000,0,0,false,3) );
   DecimalToU_Int64( Decimal::Parse(  "123.999" ) );
   DecimalToU_Int64( Decimal::Parse(  "18446744073709551615.999" ) );
   DecimalToU_Int64( Decimal::Parse(  "18446744073709551616" ) );
   DecimalToU_Int64( Decimal::Parse(  "9223372036854775807.999" ) );
   DecimalToU_Int64( Decimal::Parse(  "9223372036854775808" ) );
   DecimalToU_Int64( Decimal::Parse(  "-0.999" ) );
   DecimalToU_Int64( Decimal::Parse(  "-1" ) );
   DecimalToU_Int64( Decimal::Parse(  "-9223372036854775808.999" ) );
   DecimalToU_Int64( Decimal::Parse(  "-9223372036854775809" ) );
}

/*
This example of the explicit conversions from Decimal to __int64
and Decimal to unsigned __int64 generates the following output.
It displays several converted Decimal values.

         Decimal argument               __int64      unsigned __int64
         ----------------               -------      ----------------
                      123                   123                   123
                  123.000                   123                   123
                  123.999                   123                   123
 18446744073709551615.999     OverflowException  18446744073709551615
     18446744073709551616     OverflowException     OverflowException
  9223372036854775807.999   9223372036854775807   9223372036854775807
      9223372036854775808     OverflowException   9223372036854775808
                   -0.999                     0                     0
                       -1                    -1     OverflowException
 -9223372036854775808.999  -9223372036854775808     OverflowException
     -9223372036854775809     OverflowException     OverflowException
*/
//</Snippet1>
