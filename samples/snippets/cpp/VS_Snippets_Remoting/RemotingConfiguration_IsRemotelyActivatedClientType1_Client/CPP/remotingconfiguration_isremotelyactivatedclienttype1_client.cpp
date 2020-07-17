

// System.Runtime.Remoting.RemotingConfiguration.IsRemotelyActivatedClientType(Type)
/*
The following example demonstrates the 'IsRemotelyActivatedClientType(Type)' method
of 'RemotingConfiguration' class. 
It registers a 'TcpChannel' object with the channel services. Then registers the 'MyServerImpl'
object as activated client type which can be activated at the server. By using the above 
method it gets the activated client type registered at the client side and displays it's 
properties to the console.
*/
#using <System.Runtime.Remoting.dll>
#using <System.dll>
#using <RemotingConfiguration_IsRemotelyActivatedClientType1_Shared.dll>

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Tcp;
int main()
{
   try
   {
      ChannelServices::RegisterChannel( gcnew TcpChannel, false );
	  RemotingConfiguration::RegisterActivatedClientType( MyServerImpl::typeid, "tcp://localhost:8085" );
      MyServerImpl ^ myObject = gcnew MyServerImpl;
      for ( int i = 0; i <= 4; i++ )
         Console::WriteLine( myObject->MyMethod( String::Format( "invoke the server method {0} time.", (i + 1) ) ) );

      // <Snippet1>
      // Check whether the 'MyServerImpl' type is registered as
      // a remotely activated client type.
	  ActivatedClientTypeEntry^ myActivatedClientEntry = RemotingConfiguration::IsRemotelyActivatedClientType( MyServerImpl::typeid);
      Console::WriteLine( "The Object type is {0}", myActivatedClientEntry->ObjectType );
      Console::WriteLine( "The Application Url is {0}", myActivatedClientEntry->ApplicationUrl );
      
      // </Snippet1>
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( e->Message );
   }
}
