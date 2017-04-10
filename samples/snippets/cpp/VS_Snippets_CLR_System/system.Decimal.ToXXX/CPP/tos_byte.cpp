
//<Snippet4>
// Example of the Decimal::ToByte and Decimal::ToSByte methods.
using namespace System;
#define formatter "{0,16}{1,19}{2,19}"

// Get the exception type name; remove the namespace prefix.
String^ GetExceptionType( Exception^ ex )
{
   String^ exceptionType = ex->GetType()->ToString();
   return exceptionType->Substring( exceptionType->LastIndexOf( '.' ) + 1 );
}


// Convert the Decimal argument; catch exceptions that are thrown.
void DecimalToS_Byte( Decimal argument )
{
   Object^ ByteValue;
   Object^ SByteValue;
   
   // Convert the argument to an unsigned char value.
   try
   {
      ByteValue = Decimal::ToByte( argument );
   }
   catch ( Exception^ ex ) 
   {
      ByteValue = GetExceptionType( ex );
   }

   
   // Convert the argument to a signed char value.
   try
   {
      SByteValue = Decimal::ToSByte( argument );
   }
   catch ( Exception^ ex ) 
   {
      SByteValue = GetExceptionType( ex );
   }

   Console::WriteLine( formatter, argument, ByteValue, SByteValue );
}

int main()
{
   Console::WriteLine( "This example of the \n"
   "  Decimal::ToByte( Decimal ) and \n"
   "  Decimal::ToSByte( Decimal ) \nmethods "
   "generates the following output. It \ndisplays "
   "several converted Decimal values.\n" );
   Console::WriteLine( formatter, "Decimal argument", "unsigned char", "(signed) char" );
   Console::WriteLine( formatter, "----------------", "-------------", "-------------" );
   
   // Convert Decimal values and display the results.
   DecimalToS_Byte( Decimal::Parse(  "78" ) );
   DecimalToS_Byte( Decimal(78000,0,0,false,3) );
   DecimalToS_Byte( Decimal::Parse(  "78.999" ) );
   DecimalToS_Byte( Decimal::Parse(  "255.999" ) );
   DecimalToS_Byte( Decimal::Parse(  "256" ) );
   DecimalToS_Byte( Decimal::Parse(  "127.999" ) );
   DecimalToS_Byte( Decimal::Parse(  "128" ) );
   DecimalToS_Byte( Decimal::Parse(  "-0.999" ) );
   DecimalToS_Byte( Decimal::Parse(  "-1" ) );
   DecimalToS_Byte( Decimal::Parse(  "-128.999" ) );
   DecimalToS_Byte( Decimal::Parse(  "-129" ) );
}

/*
This example of the
  Decimal::ToByte( Decimal ) and
  Decimal::ToSByte( Decimal )
methods generates the following output. It
displays several converted Decimal values.

Decimal argument      unsigned char      (signed) char
----------------      -------------      -------------
              78                 78                 78
          78.000                 78                 78
          78.999                 78                 78
         255.999                255  OverflowException
             256  OverflowException  OverflowException
         127.999                127                127
             128                128  OverflowException
          -0.999                  0                  0
              -1  OverflowException                 -1
        -128.999  OverflowException               -128
            -129  OverflowException  OverflowException
*/
//</Snippet4>
