
// <snippet50>
using namespace System;
using namespace System::Runtime::Remoting;

int main()
{
   // Set up a remoting server.
   RemotingConfiguration::Configure( "Server.config" );

   // Wait for method calls.
   Console::WriteLine( "Listening..." );
   Console::ReadLine();
}
// </snippet50>
