
//<Snippet1>
// Example of the Decimal::Multiply, Decimal::Divide, and 
// Decimal::Remainder methods. 
using namespace System;

// Display Decimal parameters and their product, quotient, and 
// remainder.
void ShowDecimalProQuoRem( Decimal Left, Decimal Right )
{
   String^ dataFmt = "{0,-35}{1,31}";
   Console::WriteLine();
   Console::WriteLine( dataFmt, "Decimal Left", Left );
   Console::WriteLine( dataFmt, "Decimal Right", Right );
   Console::WriteLine( dataFmt, "Decimal::Multiply( Left, Right )", Decimal::Multiply( Left, Right ) );
   Console::WriteLine( dataFmt, "Decimal::Divide( Left, Right )", Decimal::Divide( Left, Right ) );
   Console::WriteLine( dataFmt, "Decimal::Remainder( Left, Right )", Decimal::Remainder( Left, Right ) );
}

int main()
{
   Console::WriteLine( "This example of the \n"
   "  Decimal::Multiply( Decimal, Decimal ), \n"
   "  Decimal::Divide( Decimal, Decimal ), and \n"
   "  Decimal::Remainder( Decimal, Decimal ) \n"
   "methods generates the following output. It displays "
   "the product, \nquotient, and remainder of several "
   "pairs of Decimal objects." );
   
   // Create pairs of Decimal objects.
   ShowDecimalProQuoRem( Decimal::Parse( "1000" ), Decimal::Parse( "7" ) );
   ShowDecimalProQuoRem( Decimal::Parse( "-1000" ), Decimal::Parse( "7" ) );
   ShowDecimalProQuoRem( Decimal(1230000000,0,0,false,7), Decimal::Parse( "0.0012300" ) );
   ShowDecimalProQuoRem( Decimal::Parse( "12345678900000000" ), Decimal::Parse( "0.0000000012345678" ) );
   ShowDecimalProQuoRem( Decimal::Parse( "123456789.0123456789" ), Decimal::Parse( "123456789.1123456789" ) );
}

/*
This example of the
  Decimal::Multiply( Decimal, Decimal ),
  Decimal::Divide( Decimal, Decimal ), and
  Decimal::Remainder( Decimal, Decimal )
methods generates the following output. It displays the product,
quotient, and remainder of several pairs of Decimal objects.

Decimal Left                                                  1000
Decimal Right                                                    7
Decimal::Multiply( Left, Right )                              7000
Decimal::Divide( Left, Right )      142.85714285714285714285714286
Decimal::Remainder( Left, Right )                                6

Decimal Left                                                 -1000
Decimal Right                                                    7
Decimal::Multiply( Left, Right )                             -7000
Decimal::Divide( Left, Right )     -142.85714285714285714285714286
Decimal::Remainder( Left, Right )                               -6

Decimal Left                                           123.0000000
Decimal Right                                            0.0012300
Decimal::Multiply( Left, Right )                  0.15129000000000
Decimal::Divide( Left, Right )                              100000
Decimal::Remainder( Left, Right )                                0

Decimal Left                                     12345678900000000
Decimal Right                                   0.0000000012345678
Decimal::Multiply( Left, Right )         15241577.6390794200000000
Decimal::Divide( Left, Right )      10000000729000059778004901.796
Decimal::Remainder( Left, Right )                   0.000000000983

Decimal Left                                  123456789.0123456789
Decimal Right                                 123456789.1123456789
Decimal::Multiply( Left, Right )    15241578765584515.651425087878
Decimal::Divide( Left, Right )      0.9999999991899999933660999449
Decimal::Remainder( Left, Right )             123456789.0123456789
*/
//</Snippet1>
