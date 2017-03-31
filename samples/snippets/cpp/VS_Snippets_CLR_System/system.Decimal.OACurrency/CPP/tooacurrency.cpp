
//<Snippet1>
// Example of the Decimal::ToOACurrency method. 
using namespace System;
#define dataFmt "{0,31}{1,27}"

// Get the exception type name; remove the namespace prefix.
String^ GetExceptionType( Exception^ ex )
{
   String^ exceptionType = ex->GetType()->ToString();
   return exceptionType->Substring( exceptionType->LastIndexOf( '.' ) + 1 );
}


// Display the Decimal::ToOACurrency parameter and the result 
// or exception.
void ShowDecimalToOACurrency( Decimal Argument )
{
   
   // Catch the exception if ToOACurrency( ) throws one.
   try
   {
      __int64 oaCurrency = Decimal::ToOACurrency( Argument );
      Console::WriteLine( dataFmt, Argument, oaCurrency );
   }
   catch ( Exception^ ex ) 
   {
      Console::WriteLine( dataFmt, Argument, GetExceptionType( ex ) );
   }

}

int main()
{
   Console::WriteLine( "This example of the "
   "Decimal::ToOACurrency( ) method generates \nthe "
   "following output. It displays the argument as a "
   "Decimal \nand the OLE Automation Currency value "
   "as an __int64.\n" );
   Console::WriteLine( dataFmt, "Argument", "OA Currency or Exception" );
   Console::WriteLine( dataFmt, "--------", "------------------------" );
   
   // Convert Decimal values to OLE Automation Currency values.
   ShowDecimalToOACurrency( Decimal(0) );
   ShowDecimalToOACurrency( Decimal(1) );
   ShowDecimalToOACurrency( Decimal::Parse( "1.0000000000000000000000000000" ) );
   ShowDecimalToOACurrency( Decimal::Parse( "100000000000000" ) );
   ShowDecimalToOACurrency( Decimal::Parse( "100000000000000.00000000000000" ) );
   ShowDecimalToOACurrency( Decimal::Parse( "10000000000000000000000000000" ) );
   ShowDecimalToOACurrency( Decimal::Parse( "0.000000000123456789" ) );
   ShowDecimalToOACurrency( Decimal::Parse( "0.123456789" ) );
   ShowDecimalToOACurrency( Decimal::Parse( "123456789" ) );
   ShowDecimalToOACurrency( Decimal::Parse( "123456789000000000" ) );
   ShowDecimalToOACurrency( Decimal::Parse( "4294967295" ) );
   ShowDecimalToOACurrency( Decimal::Parse( "18446744073709551615" ) );
   ShowDecimalToOACurrency( Decimal::Parse( "-79.228162514264337593543950335" ) );
   ShowDecimalToOACurrency( Decimal::Parse( "-79228162514264.337593543950335" ) );
}

/*
This example of the Decimal::ToOACurrency( ) method generates
the following output. It displays the argument as a Decimal
and the OLE Automation Currency value as an __int64.

                       Argument   OA Currency or Exception
                       --------   ------------------------
                              0                          0
                              1                      10000
 1.0000000000000000000000000000                      10000
                100000000000000        1000000000000000000
 100000000000000.00000000000000        1000000000000000000
  10000000000000000000000000000          OverflowException
           0.000000000123456789                          0
                    0.123456789                       1235
                      123456789              1234567890000
             123456789000000000          OverflowException
                     4294967295             42949672950000
           18446744073709551615          OverflowException
-79.228162514264337593543950335                    -792282
-79228162514264.337593543950335        -792281625142643376
*/
//</Snippet1>
