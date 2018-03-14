
//<snippet1>
// Sample for String::Intern(String)
using namespace System;
using namespace System::Text;
int main()
{
   String^ s1 = "MyTest";
   String^ s2 = (gcnew StringBuilder)->Append( "My" )->Append( "Test" )->ToString();
   String^ s3 = String::Intern( s2 );
   Console::WriteLine( "s1 == '{0}'", s1 );
   Console::WriteLine( "s2 == '{0}'", s2 );
   Console::WriteLine( "s3 == '{0}'", s3 );
   Console::WriteLine( "Is s2 the same reference as s1?: {0}", s2 == s1 );
   Console::WriteLine( "Is s3 the same reference as s1?: {0}", s3 == s1 );
}

/*
This example produces the following results:
s1 == 'MyTest'
s2 == 'MyTest'
s3 == 'MyTest'
Is s2 the same reference as s1?: False
Is s3 the same reference as s1?: True
*/
//</snippet1>
