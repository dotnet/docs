
//<Snippet2>
// Example of the Decimal::Compare and static Decimal::Equals methods.
using namespace System;
const __wchar_t * protoFmt = L"{0,-45}{1}";

// Compare Decimal parameters, and display them with the results.
void CompareDecimals( Decimal Left, Decimal Right, String^ RightText )
{
   String^ dataFmt = gcnew String( protoFmt );
   Console::WriteLine();
   Console::WriteLine( dataFmt, String::Concat( "Right: ", RightText ), Right );
   Console::WriteLine( dataFmt, "Decimal::Equals( Left, Right )", Decimal::Equals( Left, Right ) );
   Console::WriteLine( dataFmt, "Decimal::Compare( Left, Right )", Decimal::Compare( Left, Right ) );
}

int main()
{
   Console::WriteLine( "This example of the Decimal::Equals( Decimal, Decimal "
   ") and \nDecimal::Compare( Decimal, Decimal ) "
   "methods generates the \nfollowing output. It creates "
   "several different Decimal \nvalues and compares them "
   "with the following reference value.\n" );
   
   // Create a reference Decimal value.
   Decimal Left = Decimal(123.456);
   Console::WriteLine( gcnew String( protoFmt ), "Left: Decimal( 123.456 )", Left );
   
   // Create Decimal values to compare with the reference.
   CompareDecimals( Left, Decimal(1.2345600E+2), "Decimal( 1.2345600E+2 )" );
   CompareDecimals( Left, Decimal::Parse( "123.4561" ), "Decimal::Parse( \"123.4561\" )" );
   CompareDecimals( Left, Decimal::Parse( "123.4559" ), "Decimal::Parse( \"123.4559\" )" );
   CompareDecimals( Left, Decimal::Parse( "123.456000" ), "Decimal::Parse( \"123.456000\" )" );
   CompareDecimals( Left, Decimal(123456000,0,0,false,6), "Decimal( 123456000, 0, 0, false, 6 )" );
}

/*
This example of the Decimal::Equals( Decimal, Decimal ) and
Decimal::Compare( Decimal, Decimal ) methods generates the
following output. It creates several different Decimal
values and compares them with the following reference value.

Left: Decimal( 123.456 )                     123.456

Right: Decimal( 1.2345600E+2 )               123.456
Decimal::Equals( Left, Right )               True
Decimal::Compare( Left, Right )              0

Right: Decimal::Parse( "123.4561" )          123.4561
Decimal::Equals( Left, Right )               False
Decimal::Compare( Left, Right )              -1

Right: Decimal::Parse( "123.4559" )          123.4559
Decimal::Equals( Left, Right )               False
Decimal::Compare( Left, Right )              1

Right: Decimal::Parse( "123.456000" )        123.456000
Decimal::Equals( Left, Right )               True
Decimal::Compare( Left, Right )              0

Right: Decimal( 123456000, 0, 0, false, 6 )  123.456000
Decimal::Equals( Left, Right )               True
Decimal::Compare( Left, Right )              0
*/
//</Snippet2>
