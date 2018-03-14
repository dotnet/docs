
// <Snippet1>
using namespace System;
int main()
{
   Object^ o = nullptr;
   Object^ p = nullptr;
   Object^ q = gcnew Object;
   Console::WriteLine( Object::ReferenceEquals( o, p ) );
   p = q;
   Console::WriteLine( Object::ReferenceEquals( p, q ) );
   Console::WriteLine( Object::ReferenceEquals( o, p ) );
}

/*

This code produces the following output.

True
True
False

*/
// </Snippet1>
