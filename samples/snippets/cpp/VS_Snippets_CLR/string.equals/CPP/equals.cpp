
//<snippet1>
// Sample for String::Equals(Object)
//            String::Equals(String)
//            String::Equals(String, String)
using namespace System;
using namespace System::Text;
int main()
{
   StringBuilder^ sb = gcnew StringBuilder( "abcd" );
   String^ str1 = "abcd";
   String^ str2 = nullptr;
   Object^ o2 = nullptr;
   Console::WriteLine();
   Console::WriteLine( " *  The value of String str1 is '{0}'.", str1 );
   Console::WriteLine( " *  The value of StringBuilder sb is '{0}'.", sb );
   Console::WriteLine();
   Console::WriteLine( "1a) String::Equals(Object). Object is a StringBuilder, not a String." );
   Console::WriteLine( "    Is str1 equal to sb?: {0}", str1->Equals( sb ) );
   Console::WriteLine();
   Console::WriteLine( "1b) String::Equals(Object). Object is a String." );
   str2 = sb->ToString();
   o2 = str2;
   Console::WriteLine( " *  The value of Object o2 is '{0}'.", o2 );
   Console::WriteLine( "    Is str1 equal to o2?: {0}", str1->Equals( o2 ) );
   Console::WriteLine();
   Console::WriteLine( " 2) String::Equals(String)" );
   Console::WriteLine( " *  The value of String str2 is '{0}'.", str2 );
   Console::WriteLine( "    Is str1 equal to str2?: {0}", str1->Equals( str2 ) );
   Console::WriteLine();
   Console::WriteLine( " 3) String::Equals(String, String)" );
   Console::WriteLine( "    Is str1 equal to str2?: {0}", String::Equals( str1, str2 ) );
}

/*
This example produces the following results:

 *  The value of String str1 is 'abcd'.
 *  The value of StringBuilder sb is 'abcd'.

1a) String::Equals(Object). Object is a StringBuilder, not a String.
    Is str1 equal to sb?: False

1b) String::Equals(Object). Object is a String.
 *  The value of Object o2 is 'abcd'.
    Is str1 equal to o2?: True

 2) String::Equals(String)
 *  The value of String str2 is 'abcd'.
    Is str1 equal to str2?: True

 3) String::Equals(String, String)
    Is str1 equal to str2?: True
*/
//</snippet1>
