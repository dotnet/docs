
//<Snippet2>
// Example of the Decimal::Round method. 
using namespace System;
#define dataFmt "{0,26}{1,8}{2,26}"

// Display Decimal::Round parameters and the result.
void ShowDecimalRound( Decimal Argument, int Digits )
{
   Decimal rounded = Decimal::Round( Argument, Digits );
   Console::WriteLine( dataFmt, Argument, Digits, rounded );
}

int main()
{
   Console::WriteLine( "This example of the "
   "Decimal::Round( Decimal, Integer ) \n"
   "method generates the following output.\n" );
   Console::WriteLine( dataFmt, "Argument", "Digits", "Result" );
   Console::WriteLine( dataFmt, "--------", "------", "------" );
   
   // Create pairs of Decimal objects.
   ShowDecimalRound( Decimal::Parse( "1.45" ), 1 );
   ShowDecimalRound( Decimal::Parse( "1.55" ), 1 );
   ShowDecimalRound( Decimal::Parse( "123.456789" ), 4 );
   ShowDecimalRound( Decimal::Parse( "123.456789" ), 6 );
   ShowDecimalRound( Decimal::Parse( "123.456789" ), 8 );
   ShowDecimalRound( Decimal::Parse( "-123.456" ), 0 );
   ShowDecimalRound( Decimal(1230000000,0,0,true,7), 3 );
   ShowDecimalRound( Decimal(1230000000,0,0,true,7), 11 );
   ShowDecimalRound( Decimal::Parse( "-9999999999.9999999999" ), 9 );
   ShowDecimalRound( Decimal::Parse( "-9999999999.9999999999" ), 10 );
}

/*
This example of the Decimal::Round( Decimal, Integer )
method generates the following output.

                  Argument  Digits                    Result
                  --------  ------                    ------
                      1.45       1                       1.4
                      1.55       1                       1.6
                123.456789       4                  123.4568
                123.456789       6                123.456789
                123.456789       8                123.456789
                  -123.456       0                      -123
              -123.0000000       3                  -123.000
              -123.0000000      11              -123.0000000
    -9999999999.9999999999       9    -10000000000.000000000
    -9999999999.9999999999      10    -9999999999.9999999999
*/
//</Snippet2>
