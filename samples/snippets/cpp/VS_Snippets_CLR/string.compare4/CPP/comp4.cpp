
//<snippet1>
// Sample for String::Compare(String, Int32, String, Int32, Int32, Boolean)
using namespace System;
int main()
{
   
   //                0123456
   String^ str1 = "MACHINE";
   String^ str2 = "machine";
   String^ str;
   int result;
   Console::WriteLine();
   Console::WriteLine( "str1 = '{0}', str2 = '{1}'", str1, str2 );
   Console::WriteLine( "Ignore case:" );
   result = String::Compare( str1, 2, str2, 2, 2, true );
   str = ((result < 0) ? "less than" : ((result > 0) ? (String^)"greater than" : "equal to"));
   Console::Write( "Substring '{0}' in '{1}' is ", str1->Substring( 2, 2 ), str1 );
   Console::Write( " {0} ", str );
   Console::WriteLine( "substring '{0}' in '{1}'.", str2->Substring( 2, 2 ), str2 );
   Console::WriteLine();
   Console::WriteLine( "Honor case:" );
   result = String::Compare( str1, 2, str2, 2, 2, false );
   str = ((result < 0) ? "less than" : ((result > 0) ? (String^)"greater than" : "equal to"));
   Console::Write( "Substring '{0}' in '{1}' is ", str1->Substring( 2, 2 ), str1 );
   Console::Write( " {0} ", str );
   Console::WriteLine( "substring '{0}' in '{1}'.", str2->Substring( 2, 2 ), str2 );
}

/*
This example produces the following results:

str1 = 'MACHINE', str2 = 'machine'
Ignore case:
Substring 'CH' in 'MACHINE' is equal to substring 'ch' in 'machine'.

Honor case:
Substring 'CH' in 'MACHINE' is greater than substring 'ch' in 'machine'.
*/
//</snippet1>
