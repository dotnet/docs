
//<snippet1>
using namespace System;
String^ Test( String^ s )
{
   if (String::IsNullOrEmpty(s))
      return "is null or empty";
   else
      return String::Format( "(\"{0}\") is neither null nor empty", s );
}

int main()
{
   String^ s1 = "abcd";
   String^ s2 = "";
   String^ s3 = nullptr;
   Console::WriteLine( "String s1 {0}.", Test( s1 ) );
   Console::WriteLine( "String s2 {0}.", Test( s2 ) );
   Console::WriteLine( "String s3 {0}.", Test( s3 ) );
}
// The example displays the following output:
//       String s1 ("abcd") is neither null nor empty.
//       String s2 is null or empty.
//       String s3 is null or empty.
//</snippet1>
