using namespace System;
using namespace System::IO;
using namespace System::IO::IsolatedStorage;

void Method( FileStream^ s )
{
   // <Snippet1>
   if ( s->Length == s->Position )
   {
      Console::WriteLine( "End of file has been reached." );
   }
   // </Snippet1>
}
