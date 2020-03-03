
//<snippet1>
using namespace System;
int main()
{
   String^ name = "Michelle Violet Banks";
   Console::WriteLine( "The entire name is '{0}'", name );
   
   // remove the middle name, identified by finding the spaces in the middle of the name->->.
   int foundS1 = name->IndexOf( " " );
   int foundS2 = name->IndexOf( " ", foundS1 + 1 );
   if ( foundS1 != foundS2 && foundS1 >= 0 )
   {
      name = name->Remove( foundS1 + 1, foundS2 - foundS1 );
      Console::WriteLine( "After removing the middle name, we are left with '{0}'", name );
   }
}
// The example displays the following output:
//       The entire name is 'Michelle Violet Banks'
//       After removing the middle name, we are left with 'Michelle Banks'
//</snippet1>
