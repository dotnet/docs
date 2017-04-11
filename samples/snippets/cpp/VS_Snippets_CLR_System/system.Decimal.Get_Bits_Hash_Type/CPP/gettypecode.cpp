
//<Snippet3>
// Example of the Decimal::GetTypeCode method. 
using namespace System;
int main()
{
   Console::WriteLine( "This example of the "
   "Decimal::GetTypeCode( ) \nmethod "
   "generates the following output.\n" );
   
   // Create a Decimal object and get its type code.
   Decimal aDecimal = Decimal(1.0);
   TypeCode typCode = aDecimal.GetTypeCode();
   Console::WriteLine( "Type Code:      \"{0}\"", typCode );
   Console::WriteLine( "Numeric value:  {0}", (int)typCode );
}

/*
This example of the Decimal::GetTypeCode( )
method generates the following output.

Type Code:      "Decimal"
Numeric value:  15
*/
//</Snippet3>
