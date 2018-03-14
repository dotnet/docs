
//<Snippet1>
// Example of the Decimal fields.
using namespace System;
int main()
{
   String^ numberFmt = "{0,-25}{1,45:N0}";
   String^ exprFmt = "{0,-55}{1,15}";
   Console::WriteLine( "This example of the fields of the Decimal structure "
   "\ngenerates the following output.\n" );
   Console::WriteLine( numberFmt, "Field or Expression", "Value" );
   Console::WriteLine( numberFmt, "-------------------", "-----" );
   
   // Display the values of the Decimal fields.
   Console::WriteLine( numberFmt, "Decimal::MaxValue", Decimal::MaxValue );
   Console::WriteLine( numberFmt, "Decimal::MinValue", Decimal::MinValue );
   Console::WriteLine( numberFmt, "Decimal::MinusOne", Decimal::MinusOne );
   Console::WriteLine( numberFmt, "Decimal::One", Decimal::One );
   Console::WriteLine( numberFmt, "Decimal::Zero", Decimal::Zero );
   Console::WriteLine();
   
   // Display the values of expressions of the Decimal fields.
   Console::WriteLine( exprFmt, "( Decimal::MinusOne + Decimal::One ) == Decimal::Zero", (Decimal::MinusOne + Decimal::One) == Decimal::Zero );
   Console::WriteLine( exprFmt, "Decimal::MaxValue + Decimal::MinValue", Decimal::MaxValue + Decimal::MinValue );
   Console::WriteLine( exprFmt, "Decimal::MinValue / Decimal::MaxValue", Decimal::MinValue / Decimal::MaxValue );
   Console::WriteLine( "{0,-40}{1,30}", "100000000000000M / Decimal::MaxValue", Convert::ToDecimal( 100000000000000 ) / Decimal::MaxValue );
}

/*
This example of the fields of the Decimal structure
generates the following output.

Field or Expression                                              Value
-------------------                                              -----
Decimal::MaxValue               79,228,162,514,264,337,593,543,950,335
Decimal::MinValue              -79,228,162,514,264,337,593,543,950,335
Decimal::MinusOne                                                   -1
Decimal::One                                                         1
Decimal::Zero                                                        0

( Decimal::MinusOne + Decimal::One ) == Decimal::Zero             True
Decimal::MaxValue + Decimal::MinValue                                0
Decimal::MinValue / Decimal::MaxValue                               -1
100000000000000M / Decimal::MaxValue    0.0000000000000012621774483536
*/
//</Snippet1>
