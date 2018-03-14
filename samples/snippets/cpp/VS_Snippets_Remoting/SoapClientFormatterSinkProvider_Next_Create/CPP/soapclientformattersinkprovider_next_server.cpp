

// System.Runtime.Remoting.Channels.SoapServerFormatterSinkProvider.Next;
#using <System.Runtime.Remoting.dll>
#using <System.dll>
#using <soapclientformattersinkprovider_customprovider.dll>
#using <SoapClientFormatterSinkProvider_Next_Shared.dll>

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Tcp;
using namespace System::Collections;
int main()
{
   try
   {
      IDictionary^ myDictionaryProperty = gcnew Hashtable;
      myDictionaryProperty->Add( "port", 8082 );

      // <Snippet4>
      IServerChannelSinkProvider^ myCustomProvider = gcnew MyServerProvider;
      IServerChannelSinkProvider^ mySoapProvider = gcnew SoapServerFormatterSinkProvider;
      myCustomProvider->Next = mySoapProvider;

      // Set the Binary provider as the next 'IServerChannelSinkProvider' in the
      // sink chain.
      mySoapProvider->Next = gcnew BinaryServerFormatterSinkProvider;
      // </Snippet4>

      TcpChannel^ myTcpChannel = gcnew TcpChannel( myDictionaryProperty,nullptr,myCustomProvider );
      ChannelServices::RegisterChannel( myTcpChannel );
      RemotingConfiguration::ApplicationName = "HelloServiceApplication";
      RemotingConfiguration::RegisterWellKnownServiceType( HelloService::typeid, "MyUri", WellKnownObjectMode::Singleton );
      Console::WriteLine( "Press enter to stop this process." );
      Console::ReadLine();
   }
   catch ( Exception^ ex ) 
   {
      Console::WriteLine( "The following exception is raised at server side: {0}", ex->Message );
   }
}
