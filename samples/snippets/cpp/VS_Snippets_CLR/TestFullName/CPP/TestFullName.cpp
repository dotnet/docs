
//<Snippet1>
using namespace System;
int main()
{
   Type^ t = Array::typeid;
   Console::WriteLine( "The full name of the Array type is {0}.", t->FullName );
}

/* This example produces the following output:

The full name of the Array type is System.Array.
 */
//</Snippet1>
