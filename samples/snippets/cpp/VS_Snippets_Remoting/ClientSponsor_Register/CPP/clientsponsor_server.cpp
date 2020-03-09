#using <system.dll>
#using <system.runtime.remoting.dll>

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Tcp;
using namespace System::Runtime::Remoting::Lifetime;

int main()
{
   RemotingConfiguration::Configure( "Server.config" );
   Console::WriteLine( "Server started." );
   Console::WriteLine( "Hit enter to terminate..." );
   Console::Read();
}
