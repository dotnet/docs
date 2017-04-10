
//<Snippet1>
// Example of the Decimal::Negate, Decimal::Floor, and 
// Decimal::Truncate methods. 
using namespace System;

// Display Decimal parameters and the method results.
void ShowDecimalFloorNegTrunc( Decimal Argument )
{
   String^ dataFmt = "{0,-30}{1,26}";
   Console::WriteLine();
   Console::WriteLine( dataFmt, "Decimal Argument", Argument );
   Console::WriteLine( dataFmt, "Decimal::Negate( Argument )", Decimal::Negate( Argument ) );
   Console::WriteLine( dataFmt, "Decimal::Floor( Argument )", Decimal::Floor( Argument ) );
   Console::WriteLine( dataFmt, "Decimal::Truncate( Argument )", Decimal::Truncate( Argument ) );
}

int main()
{
   Console::WriteLine( "This example of the \n"
   "  Decimal::Negate( Decimal ), \n"
   "  Decimal::Floor( Decimal ), and \n"
   "  Decimal::Truncate( Decimal ) \n"
   "methods generates the following output." );
   
   // Create pairs of Decimal objects.
   ShowDecimalFloorNegTrunc( Decimal::Parse( "0" ) );
   ShowDecimalFloorNegTrunc( Decimal::Parse( "123.456" ) );
   ShowDecimalFloorNegTrunc( Decimal::Parse( "-123.456" ) );
   ShowDecimalFloorNegTrunc( Decimal(1230000000,0,0,true,7) );
   ShowDecimalFloorNegTrunc( Decimal::Parse( "-9999999999.9999999999" ) );
}

/*
This example of the
  Decimal::Negate( Decimal ),
  Decimal::Floor( Decimal ), and
  Decimal::Truncate( Decimal )
methods generates the following output.

Decimal Argument                                       0
Decimal::Negate( Argument )                            0
Decimal::Floor( Argument )                             0
Decimal::Truncate( Argument )                          0

Decimal Argument                                 123.456
Decimal::Negate( Argument )                     -123.456
Decimal::Floor( Argument )                           123
Decimal::Truncate( Argument )                        123

Decimal Argument                                -123.456
Decimal::Negate( Argument )                      123.456
Decimal::Floor( Argument )                          -124
Decimal::Truncate( Argument )                       -123

Decimal Argument                            -123.0000000
Decimal::Negate( Argument )                  123.0000000
Decimal::Floor( Argument )                          -123
Decimal::Truncate( Argument )                       -123

Decimal Argument                  -9999999999.9999999999
Decimal::Negate( Argument )        9999999999.9999999999
Decimal::Floor( Argument )                  -10000000000
Decimal::Truncate( Argument )                -9999999999
*/
//</Snippet1>
