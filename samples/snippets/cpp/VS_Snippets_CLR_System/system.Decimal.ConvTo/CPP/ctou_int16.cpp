
//<Snippet3>
// Example of the explicit conversions from Decimal to short and 
// Decimal to unsigned short.
using namespace System;
#define formatter "{0,16}{1,19}{2,19}"

// Get the exception type name; remove the namespace prefix.
String^ GetExceptionType( Exception^ ex )
{
   String^ exceptionType = ex->GetType()->ToString();
   return exceptionType->Substring( exceptionType->LastIndexOf( '.' ) + 1 );
}


// Convert the Decimal argument; catch exceptions that are thrown.
void DecimalToU_Int16( Decimal argument )
{
   Object^ Int16Value;
   Object^ UInt16Value;
   
   // Convert the argument to a short value.
   try
   {
      Int16Value = (short)argument;
   }
   catch ( Exception^ ex ) 
   {
      Int16Value = GetExceptionType( ex );
   }

   
   // Convert the argument to an unsigned short value.
   try
   {
      UInt16Value = (unsigned short)argument;
   }
   catch ( Exception^ ex ) 
   {
      UInt16Value = GetExceptionType( ex );
   }

   Console::WriteLine( formatter, argument, Int16Value, UInt16Value );
}

int main()
{
   Console::WriteLine( "This example of the explicit conversions from Decimal to "
   "short \nand Decimal to unsigned short generates the "
   "following output. \nIt displays several converted Decimal "
   "values.\n" );
   Console::WriteLine( formatter, "Decimal argument", "short", "unsigned short" );
   Console::WriteLine( formatter, "----------------", "-----", "--------------" );
   
   // Convert Decimal values and display the results.
   DecimalToU_Int16( Decimal::Parse(  "123" ) );
   DecimalToU_Int16( Decimal(123000,0,0,false,3) );
   DecimalToU_Int16( Decimal::Parse(  "123.999" ) );
   DecimalToU_Int16( Decimal::Parse(  "65535.999" ) );
   DecimalToU_Int16( Decimal::Parse(  "65536" ) );
   DecimalToU_Int16( Decimal::Parse(  "32767.999" ) );
   DecimalToU_Int16( Decimal::Parse(  "32768" ) );
   DecimalToU_Int16( Decimal::Parse(  "-0.999" ) );
   DecimalToU_Int16( Decimal::Parse(  "-1" ) );
   DecimalToU_Int16( Decimal::Parse(  "-32768.999" ) );
   DecimalToU_Int16( Decimal::Parse(  "-32769" ) );
}

/*
This example of the explicit conversions from Decimal to short
and Decimal to unsigned short generates the following output.
It displays several converted Decimal values.

Decimal argument              short     unsigned short
----------------              -----     --------------
             123                123                123
         123.000                123                123
         123.999                123                123
       65535.999  OverflowException              65535
           65536  OverflowException  OverflowException
       32767.999              32767              32767
           32768  OverflowException              32768
          -0.999                  0                  0
              -1                 -1  OverflowException
      -32768.999             -32768  OverflowException
          -32769  OverflowException  OverflowException
*/
//</Snippet3>
