

// System.Runtime.Remoting.RemotingConfiguration.IsActivationAllowed
// System.Runtime.Remoting.RemotingConfiguration.GetRegisteredActivatedServiceTypes
/*
The following example demonstrates the 'IsActivationAllowed' and
'GetRegisteredActivatedServiceTypes' methods of 'RemotingConfiguration' class. 
It registers a 'TcpChannel' object with the channel services. Then registers the 'MyServerImpl'
object at the service end that can be activated on request from a client.By using the 
'GetRegisteredActivatedClientTypes' method it gets the registered activated service types
and displays it's properties to the console.

*/
#using <System.Runtime.Remoting.dll>
#using <System.dll>
#using <RemotingConfiguration_GetRegisteredActivatedService_Shared.dll>

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Tcp;

int main()
{
   ChannelServices::RegisterChannel( gcnew TcpChannel( 8085 ) );
   RemotingConfiguration::RegisterActivatedServiceType( MyServerImpl::typeid );
   
   // <Snippet1>
   // <Snippet2>
   // Check whether the 'MyServerImpl' object is allowed for 
   // activation or not.
   if ( RemotingConfiguration::IsActivationAllowed( MyServerImpl::typeid ) )
   {
      // Get the registered activated service types .
      array<ActivatedServiceTypeEntry^>^myActivatedServiceEntries = RemotingConfiguration::GetRegisteredActivatedServiceTypes();
      Console::WriteLine( "The Length of the registered activated service type array is {0}", myActivatedServiceEntries->Length );
      Console::WriteLine( "The Object type is:{0}", myActivatedServiceEntries[ 0 ]->ObjectType );
   }
   // </Snippet2>
   // </Snippet1>

   Console::WriteLine( "Press enter to stop this process." );
   Console::ReadLine();
}
