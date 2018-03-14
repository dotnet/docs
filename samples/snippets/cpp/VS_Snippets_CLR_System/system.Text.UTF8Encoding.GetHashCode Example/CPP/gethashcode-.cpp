
// <Snippet1>
using namespace System;
using namespace System::Text;
int main()
{
   
   // Many ways to instantiate a UTF8 encoding.
   UTF8Encoding^ UTF8a = gcnew UTF8Encoding;
   Encoding^ UTF8b = Encoding::UTF8;
   Encoding^ UTF8c = gcnew UTF8Encoding( true,true );
   Encoding^ UTF8d = gcnew UTF8Encoding( false,false );
   
   // But not all are the same.
   Console::WriteLine( UTF8a->GetHashCode() );
   Console::WriteLine( UTF8b->GetHashCode() );
   Console::WriteLine( UTF8c->GetHashCode() );
   Console::WriteLine( UTF8d->GetHashCode() );
}

// </Snippet1>
