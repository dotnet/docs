// <Snippet5>
#using <system.dll>
#using <system.runtime.remoting.dll>

using namespace System;
using namespace System::Runtime::Remoting;

int main()
{
   RemotingConfiguration::Configure( "ISponsor_Server.config" );

   Console::WriteLine( "The server is listening. Press Enter to exit...." );
   Console::ReadLine();

   Console::WriteLine( "Garbage Collecting." );
   GC::Collect();
   GC::WaitForPendingFinalizers();
}
// </Snippet5>
