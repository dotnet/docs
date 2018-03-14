
//<Snippet1>
using namespace System;
using namespace System::Globalization;
using namespace System::Text;
int main()
{
   
   // Gets the InvariantInfo.
   NumberFormatInfo^ myInv = NumberFormatInfo::InvariantInfo;
   
   // Gets a UnicodeEncoding to display the Unicode value of symbols.
   UnicodeEncoding^ myUE = gcnew UnicodeEncoding( true,false );
   array<Byte>^myCodes;
   
   // Displays the default values for each of the properties.
   Console::WriteLine( "InvariantInfo:\nNote: Symbols might not display correctly on the console, \ntherefore, Unicode values are included." );
   Console::WriteLine( "\tCurrencyDecimalDigits\t\t {0}", myInv->CurrencyDecimalDigits );
   Console::WriteLine( "\tCurrencyDecimalSeparator\t {0}", myInv->CurrencyDecimalSeparator );
   Console::WriteLine( "\tCurrencyGroupSeparator\t\t {0}", myInv->CurrencyGroupSeparator );
   Console::WriteLine( "\tCurrencyGroupSizes\t\t {0}", myInv->CurrencyGroupSizes[ 0 ] );
   Console::WriteLine( "\tCurrencyNegativePattern\t\t {0}", myInv->CurrencyNegativePattern );
   Console::WriteLine( "\tCurrencyPositivePattern\t\t {0}", myInv->CurrencyPositivePattern );
   myCodes = myUE->GetBytes( myInv->CurrencySymbol );
   Console::WriteLine( "\tCurrencySymbol\t\t\t {0}\t(U+ {1:x2} {2:x2})", myInv->CurrencySymbol, myCodes[ 0 ], myCodes[ 1 ] );
   Console::WriteLine( "\tNaNSymbol\t\t\t {0}", myInv->NaNSymbol );
   Console::WriteLine( "\tNegativeInfinitySymbol\t\t {0}", myInv->NegativeInfinitySymbol );
   Console::WriteLine( "\tNegativeSign\t\t\t {0}", myInv->NegativeSign );
   Console::WriteLine( "\tNumberDecimalDigits\t\t {0}", myInv->NumberDecimalDigits );
   Console::WriteLine( "\tNumberDecimalSeparator\t\t {0}", myInv->NumberDecimalSeparator );
   Console::WriteLine( "\tNumberGroupSeparator\t\t {0}", myInv->NumberGroupSeparator );
   Console::WriteLine( "\tNumberGroupSizes\t\t {0}", myInv->NumberGroupSizes[ 0 ] );
   Console::WriteLine( "\tNumberNegativePattern\t\t {0}", myInv->NumberNegativePattern );
   Console::WriteLine( "\tPercentDecimalDigits\t\t {0}", myInv->PercentDecimalDigits );
   Console::WriteLine( "\tPercentDecimalSeparator\t\t {0}", myInv->PercentDecimalSeparator );
   Console::WriteLine( "\tPercentGroupSeparator\t\t {0}", myInv->PercentGroupSeparator );
   Console::WriteLine( "\tPercentGroupSizes\t\t {0}", myInv->PercentGroupSizes[ 0 ] );
   Console::WriteLine( "\tPercentNegativePattern\t\t {0}", myInv->PercentNegativePattern );
   Console::WriteLine( "\tPercentPositivePattern\t\t {0}", myInv->PercentPositivePattern );
   myCodes = myUE->GetBytes( myInv->PercentSymbol );
   Console::WriteLine( "\tPercentSymbol\t\t\t {0}\t(U+ {1:x2} {2:x2})", myInv->PercentSymbol, myCodes[ 0 ], myCodes[ 1 ] );
   myCodes = myUE->GetBytes( myInv->PerMilleSymbol );
   Console::WriteLine( "\tPerMilleSymbol\t\t\t {0}\t(U+ {1:x2} {2:x2})", myInv->PerMilleSymbol, myCodes[ 0 ], myCodes[ 1 ] );
   Console::WriteLine( "\tPositiveInfinitySymbol\t\t {0}", myInv->PositiveInfinitySymbol );
   Console::WriteLine( "\tPositiveSign\t\t\t {0}", myInv->PositiveSign );
}

/*

This code produces the following output.

InvariantInfo:
Note: Symbols might not display correctly on the console,
therefore, Unicode values are included.
CurrencyDecimalDigits           2
CurrencyDecimalSeparator        .
CurrencyGroupSeparator          ,
CurrencyGroupSizes              3
CurrencyNegativePattern         0
CurrencyPositivePattern         0
CurrencySymbol                         (U+00a4)
NaNSymbol                       NaN
NegativeInfinitySymbol          -Infinity
NegativeSign                    -
NumberDecimalDigits             2
NumberDecimalSeparator          .
NumberGroupSeparator            ,
NumberGroupSizes                3
NumberNegativePattern           1
PercentDecimalDigits            2
PercentDecimalSeparator         .
PercentGroupSeparator           ,
PercentGroupSizes               3
PercentNegativePattern          0
PercentPositivePattern          0
PercentSymbol                   %       (U+0025)
PerMilleSymbol                  %       (U+2030)
PositiveInfinitySymbol          Infinity
PositiveSign                    +

*/
//</Snippet1>
