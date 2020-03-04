
//<snippet1>
using namespace System;

int main()
{
   
   // Make an array of strings. Note that we have included spaces.
   array<String^>^s = { "hello ", "and ", "welcome ", "to ",
                        "this ", "demo! "};
   
   // Put all the strings together.
   Console::WriteLine( String::Concat(s) );
   
   // Sort the strings, and put them together.
   Array::Sort( s );
   Console::WriteLine( String::Concat(s));
}
// The example displays the following output:
//       hello and welcome to this demo!
//       and demo! hello this to welcome
//</snippet1>
