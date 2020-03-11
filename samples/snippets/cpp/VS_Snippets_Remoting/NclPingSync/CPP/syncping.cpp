

//NCLPingSync
//<snippet1>
#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Net::NetworkInformation;
using namespace System::Text;

// args[1] can be an IPaddress or host name.
int main()
{
   array<String^>^args = Environment::GetCommandLineArgs();
   
   //<snippet3>
   //<snippet2>
   Ping ^ pingSender = gcnew Ping;
   PingOptions ^ options = gcnew PingOptions;
   
   // Use the default Ttl value which is 128,
   // but change the fragmentation behavior.
   options->DontFragment = true;
   
   //</snippet2>
   // Create a buffer of 32 bytes of data to be transmitted.
   String^ data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
   array<Byte>^buffer = Encoding::ASCII->GetBytes( data );
   int timeout = 120;
   PingReply ^ reply = pingSender->Send( args[ 1 ], timeout, buffer, options );
   
   //</snippet3>
   //<snippet4>
   if ( reply->Status == IPStatus::Success )
   {
      Console::WriteLine( "Address: {0}", reply->Address->ToString() );
      Console::WriteLine( "RoundTrip time: {0}", reply->RoundtripTime );
      Console::WriteLine( "Time to live: {0}", reply->Options->Ttl );
      Console::WriteLine( "Don't fragment: {0}", reply->Options->DontFragment );
      Console::WriteLine( "Buffer size: {0}", reply->Buffer->Length );
   }

   
   //</snippet4>
}

//</snippet1>
