

// C:\Program Files\Microsoft::NET\FrameworkSDK\Samples\technologies\remoting\advanced\customproxies
//<snippet1>
#using <system.dll>
#using <system.runtime.remoting.dll>

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Messaging;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Reflection;
//</snippet1>

//<snippet4>
using namespace System::Runtime::Remoting::Channels::Tcp;
using namespace System::Runtime::Remoting::Lifetime;
using namespace System::Runtime::Remoting::Proxies;
//</snippet4>

//<snippet5>
using namespace System::Runtime::Remoting::Channels::Http;
using namespace System::Net;
using namespace System::IO;
using namespace System::Security::Permissions;
//</snippet5>

//<snippet2>
public ref class HelloServer: public MarshalByRefObject
{
public:
   HelloServer()
   {
      Console::WriteLine( "HelloServer activated." );
   }

   [OneWay]
   void SayHelloToServer( String^ name )
   {
      Console::WriteLine( "Client invoked SayHelloToServer(\" {0}\").", name );
   }

   //<snippet3> 
   // IsOneWay: Note the lack of the OneWayAttribute adornment on this method.
   [SecurityPermissionAttribute(SecurityAction::Demand, Flags=SecurityPermissionFlag::Infrastructure)]   
   String^ SayHelloToServerAndWait( String^ name )
   {
      Console::WriteLine( "Client invoked SayHelloToServerAndWait(\" {0}\").", name );
      Console::WriteLine( "Client waiting for return? {0}", RemotingServices::IsOneWay( MethodBase::GetCurrentMethod() ) ? (String^)"No" : "Yes" );
      return String::Format( "Hi there, {0}.", name );
   }
   //</snippet3>
};
//</snippet2>

//<snippet6>
// An instance of ClientApp will call an instance of this class remotely.
public ref class TcpServerApp
{
public:
   [SecurityPermissionAttribute(SecurityAction::Demand, Flags=SecurityPermissionFlag::Infrastructure)]   
   TcpServerApp()
   {
      // Register a class over TCP at tcp://localhost:8085/HttpHelloServer.
      const String^ myObjectUri = "TcpHelloServer";
      const int myPort = 8085;
      TcpChannel^ myTcpChannel = gcnew TcpChannel( myPort );
      ChannelServices::RegisterChannel( myTcpChannel );
      RemotingConfiguration::RegisterWellKnownServiceType( HelloServer::typeid, const_cast<String^>(myObjectUri), WellKnownObjectMode::Singleton );
      //</snippet6>

      //<snippet7>
      Console::WriteLine( "Server type: {0}", RemotingServices::GetServerTypeForUri( const_cast<String^>(myObjectUri) ) );
      //</snippet7>

      //<snippet8>
      Console::WriteLine( "Press Enter to stop the demo." );
      Console::ReadLine();
   }

};
//</snippet8>

//<snippet9>
public ref class HttpServerApp
{
public:
   [SecurityPermissionAttribute(SecurityAction::Demand, Flags=SecurityPermissionFlag::Infrastructure)]   
   HttpServerApp()
   {
      // Marshal an Object* over HTTP at http://localhost:8090/HttpHelloServer.
      const String^ myObjectUri = "HttpHelloServer";
      const int myPort = 8090;
      HttpChannel^ myHttpChannel = gcnew HttpChannel( myPort );
      ChannelServices::RegisterChannel( myHttpChannel );
      MarshalByRefObject^ myMbro = dynamic_cast<MarshalByRefObject^>(Activator::CreateInstance( HelloServer::typeid ));
      RemotingServices::SetObjectUriForMarshal( myMbro, const_cast<String^>(myObjectUri) );
      ObjRef^ myObjRef = RemotingServices::Marshal( myMbro );
      Console::WriteLine( "Press Enter to stop the demo." );
      Console::ReadLine();
      HelloServer^ umObj = dynamic_cast<HelloServer^>(RemotingServices::Unmarshal( myObjRef ));
      RemotingServices::Disconnect( myMbro );
  }
};
//</snippet9>

//<snippet11>
// An instance of this class will call an instance of ServerApp remotely.
[SecurityPermissionAttribute(SecurityAction::Demand, Flags=SecurityPermissionFlag::Infrastructure)]   
public ref class TcpClientApp
{
public:
   TcpClientApp()
   {
      const String^ myHelloServerUrl = "tcp://localhost:8085/TcpHelloServer";
      HelloServer^ obj = static_cast<HelloServer^>(RemotingServices::Connect( HelloServer::typeid, const_cast<String^>(myHelloServerUrl) ));
      //</snippet11>

      //<snippet18> 
      //GetRealProxy, GetObjectUri, GetEnvoyChainForProxy
      RealProxy^ proxy = RemotingServices::GetRealProxy( obj );
      Console::WriteLine( "Real proxy type: {0}", proxy->GetProxiedType() );
      Console::WriteLine( "Object URI: {0}", RemotingServices::GetObjectUri( obj ) );
      IMessageSink^ msgSink = RemotingServices::GetEnvoyChainForProxy( obj )->NextSink;
      //</snippet18>

      //<snippet12> 
      //IsTransparentProxy, IsObjectOutOfAppDomain, IsObjectOutOfContext
      Console::WriteLine( "Proxy transparent? {0}", RemotingServices::IsTransparentProxy( obj ) ? (String^)"Yes" : "No" );
      Console::WriteLine( "Object outside app domain? {0}", RemotingServices::IsObjectOutOfAppDomain( obj ) ? (String^)"Yes" : "No" );
      Console::WriteLine( "Object [Out] of* context? {0}", RemotingServices::IsObjectOutOfContext( obj ) ? (String^)"Yes" : "No" );
      //</snippet12>

      //<snippet21> 
      //GetLifetimeService
      ILease^ lease = dynamic_cast<ILease^>(RemotingServices::GetLifetimeService( obj ));
      Console::WriteLine( "Object lease time remaining: {0}.", lease->CurrentLeaseTime );
      //</snippet21>

      //<snippet16>
      String^ twoWayMethodArg = "John";
      Console::WriteLine( "Invoking SayHelloToServerAndWait(\" {0}\").", twoWayMethodArg );
      Console::WriteLine( "Server returned: {0}", obj->SayHelloToServerAndWait( twoWayMethodArg ) );
      //</snippet16>

      //<snippet17>
      String^ oneWayMethodArg = "Mary";
      Console::WriteLine( "Invoking SayHelloToServer(\" {0}\").", oneWayMethodArg );
      obj->SayHelloToServer( oneWayMethodArg );
      //</snippet17>

      //<snippet23>
   }
   //</snippet23>

   //<snippet13>
};
//</snippet13>

//<snippet22>
public ref class HttpClientApp
{
public:
   HttpClientApp()
   {
      const String^ myHelloServerUrl = "http://localhost:8090/HttpHelloServer";

      // Output the WSDL for the marshalled Object*.
      WebClient^ myWebClient = gcnew WebClient;
      Stream^ myStream = myWebClient->OpenRead( String::Format(  "{0}?wsdl", const_cast<String^>(myHelloServerUrl) ) );
      int b = myStream->ReadByte();
      while ( b != -1 )
      {
         char p[2] = {(char)b};
         Console::Write( p );
         b = myStream->ReadByte();
      }
   }

};
//</snippet22>

//<snippet14>
int main()
{
   array<String^>^args = Environment::GetCommandLineArgs();
   //</snippet14>

   bool isServer = false;
   if ( args->Length > 1 )
      if ( args[ 1 ]->ToLower()->Equals( "s" ) )
      isServer = true;

   if (  !isServer )
   {
      Console::WriteLine( "Run this program in another window, \npassing the letter 's' as an argument.\nPress Enter here when the server has been activated." );
      Console::ReadLine();
      Console::WriteLine( "Running TCP client." );
   }

   //<snippet19>
   if ( isServer )
   {
      gcnew TcpServerApp;
   }
   else
   {
      gcnew TcpClientApp;
   }
   //</snippet19>

   if (  !isServer )
   {
      Console::WriteLine( "\nPress Enter in the other window to continue to the next demo.\nThen press Enter here." );
      Console::ReadLine();
   }

   //<snippet20>
   if ( isServer )
   {
      gcnew HttpServerApp;
   }
   else
   {
      gcnew HttpClientApp;
   }
   //</snippet20>

   //<snippet15>
   return 0;
}
//</snippet15>
