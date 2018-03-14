

#using <System.DLL>

// <Snippet1>
using namespace System;

int main()
{
   Console::Write( L"Hello " );
   Console::WriteLine( L"World!" );
   Console::Write( L"Enter your name: " );
   String^ name = Console::ReadLine();
   Console::Write( L"Good day, " );
   Console::Write( name );
   Console::WriteLine( L"!" );
}
// The example displays output similar to the following:
//       Hello World!
//       Enter your name: James
//       Good day, James!
// </Snippet1>
