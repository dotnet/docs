
//<snippet1>
using namespace System;
using namespace System::Globalization;
String^ symbol( int r )
{
   String^ s = "=";
   if ( r < 0 )
      s = "<";
   else
   if ( r > 0 )
      s = ">";


   return s;
}

int main()
{
   String^ str1 = "change";
   String^ str2 = "dollar";
   String^ relation = nullptr;
   relation = symbol( String::Compare( str1, str2, false, gcnew CultureInfo( "en-US" ) ) );
   Console::WriteLine( "For en-US: {0} {1} {2}", str1, relation, str2 );
   relation = symbol( String::Compare( str1, str2, false, gcnew CultureInfo( "cs-CZ" ) ) );
   Console::WriteLine( "For cs-CZ: {0} {1} {2}", str1, relation, str2 );
}

/*
This example produces the following results.
For en-US: change < dollar
For cs-CZ: change > dollar
*/
//</snippet1>
