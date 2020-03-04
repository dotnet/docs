
//<Snippet1>
using namespace System;
void main()
{
   Type^ t = int::typeid;
   Console::WriteLine( "{0} inherits from {1}.", t, t->BaseType );
}

//</Snippet1>
