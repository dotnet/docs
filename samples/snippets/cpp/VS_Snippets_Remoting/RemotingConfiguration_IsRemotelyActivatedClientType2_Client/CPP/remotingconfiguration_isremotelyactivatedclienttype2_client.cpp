

// System.Runtime.Remoting.RemotingConfiguration.IsRemotelyActivatedClientType(String,String)
/*
The following example demonstrates the 'IsRemotelyActivatedClientType(String,String)' method
of 'RemotingConfiguration' class. 
It registers a 'TcpChannel' object with the channel services. Then registers the 'MyServerImpl'
object as activated client type which can be activated at the server and displays it's 
properties to the console.
*/
#using <System.Runtime.Remoting.dll>
#using <System.dll>
#using <RemotingConfiguration_IsRemotelyActivatedClientType2_Shared.dll>

using namespace System;
using namespace System::Reflection;
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
         Console::WriteLine( myObject->MyMethod( "invoke the server method " ) );

      // Get the assembly for the 'MyServerImpl' object.
      // <Snippet1>
      Assembly^ myAssembly = Assembly::GetAssembly( MyServerImpl::typeid );
      AssemblyName^ myName = myAssembly->GetName();

      // Check whether the 'MyServerImpl' type is registered as
      // a remotely activated client type.
      ActivatedClientTypeEntry^ myActivatedClientEntry = 
		  RemotingConfiguration::IsRemotelyActivatedClientType( MyServerImpl::typeid->FullName, myName->Name );
      Console::WriteLine( "The Object type : {0}", myActivatedClientEntry->ObjectType );
      Console::WriteLine( "The Application Url : {0}", myActivatedClientEntry->ApplicationUrl );
      if (myActivatedClientEntry)
         Console::WriteLine( "The object is client activated");
      else
	Console::WriteLine("The object is not client activated");
      // </Snippet1>
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( e->Message );
   }
}
