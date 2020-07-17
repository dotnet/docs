

#using <system.dll>
#using <system.runtime.remoting.dll>
#using "service.dll"

using namespace System;
using namespace System::Collections;
using namespace System::IO;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Http;
using namespace System::Threading;
using namespace SampleNamespace;

int main()
{
   array<String^>^args = Environment::GetCommandLineArgs();
   String^ serverConfigFile = "basicserver.exe.config";
   if ( (args->Length > 2) && (args[ 1 ]->ToLower()->Equals( "/c" ) | args[ 1 ]->ToLower()->Equals( "-c" )) )
   {
      serverConfigFile = args[ 2 ];
   }

   RemotingConfiguration::Configure( "channels.config" );
   RemotingConfiguration::Configure( serverConfigFile );
   Console::WriteLine( "Listening..." );
   String^ keyState = "";
   while ( String::Compare( keyState, "0", true ) != 0 )
   {
      Console::WriteLine( "***** Press 0 to exit this service *****" );
      keyState = Console::ReadLine();
   }

   return 0;
}
