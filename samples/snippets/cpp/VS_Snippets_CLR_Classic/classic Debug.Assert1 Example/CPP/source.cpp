#using <System.dll>
using namespace System;
using namespace System::Diagnostics;

void MyMethod( Object^ obj, Type^ type );

int main( void )
{
   MyMethod( nullptr, nullptr );
   return 0;
}

// <Snippet1>
void MyMethod( Object^ obj, Type^ type )
{
   #if defined(DEBUG)
   Debug::Assert( type != nullptr, "Type paramater is null" );
   #endif
}
// </Snippet1>
