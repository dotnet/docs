
//<snippet1>
// Sample for String.GetTypeCode()
using namespace System;
int main()
{
   String^ str = "abc";
   TypeCode tc = str->GetTypeCode();
   Console::WriteLine( "The type code for '{0}' is {1}, which represents {2}.", str, tc.ToString( "D" ), tc.ToString( "F" ) );
}

/*
This example produces the following results:
The type code for 'abc' is 18, which represents String.
*/
//</snippet1>
