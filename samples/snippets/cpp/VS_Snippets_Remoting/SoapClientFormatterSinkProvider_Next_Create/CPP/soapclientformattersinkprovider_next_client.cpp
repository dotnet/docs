

// System.Runtime.Remoting.Channels.SoapClientFormatterSinkProvider
// System.Runtime.Remoting.Channels.SoapClientFormatterSinkProvider.Next
/*
   The following program demonstrates the 'SoapClientFormatterSinkProvider' class
   and 'Next' property of 'SoapClientFormatterSinkProvider' class ,'CreateSink'
   method and 'Next' property of 'ServerFormatterSinkProvider' class.
   Custom client and server formatter provider are created by implementing
   the interfaces IClientChannelSinkProvider and IServerChannelSinkProvider.
   In the client side the custom client provider is assigned to 'Next' property
   of 'SoapClientFormatterSinkProvider'. In the server side, the
   'BinaryServerFormatterSinkProvider' is assigned to 'Next' property of
   'SoapServerFormatterSinkProvider'. The 'CreateSink' method is used to return a
   sink to the caller and form the sink chain which is used to process the message
   being passed through it.
*/
// <Snippet1>
#using <System.Runtime.Remoting.dll>
#using <System.dll>
#using <soapclientformattersinkprovider_customprovider.dll>
#using <SoapClientFormatterSinkProvider_Next_Shared.dll>

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels::Tcp;
using namespace System::Runtime::Remoting::Channels;
int main()
{
   try
   {
      // <Snippet2>
      IClientChannelSinkProvider^ mySoapProvider = gcnew SoapClientFormatterSinkProvider;
      IClientChannelSinkProvider^ myClientProvider = gcnew MyClientProvider;

      // Set the custom provider as the next 'IClientChannelSinkProvider' in the sink chain.
      mySoapProvider->Next = myClientProvider;
      // </Snippet2>

      TcpChannel^ myTcpChannel = gcnew TcpChannel( nullptr,mySoapProvider,nullptr );
      ChannelServices::RegisterChannel( myTcpChannel );
      RemotingConfiguration::RegisterWellKnownClientType( HelloService::typeid, "tcp://localhost:8082/HelloServiceApplication/MyUri" );
      HelloService ^ myService = gcnew HelloService;
      Console::WriteLine( myService->HelloMethod( "Welcome to .Net" ) );
   }
   catch ( Exception^ ex ) 
   {
      Console::WriteLine( "The following  exception is raised at client side :{0}", ex->Message );
   }
}
// </Snippet1>
