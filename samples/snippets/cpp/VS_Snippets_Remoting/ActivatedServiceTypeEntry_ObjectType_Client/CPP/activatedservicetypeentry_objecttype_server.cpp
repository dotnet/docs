// System.Runtime.Remoting.ActivatedServiceTypeEntry
// System.Runtime.Remoting.ActivatedServiceTypeEntry.ObjectType
// System.Runtime.Remoting.ActivatedServiceTypeEntry.ToString

/*
The following example demonstrates the 'ActivatedServiceTypeEntry' class and 
the 'ObjectType' property ,'ToString' method of 'ActivatedServiceTypeEntry' class.
It registers a 'TcpChannel' object with the channel services. Then registers the 'HelloServer'
object at the service end that can be activated on request from a client.By using the 
'GetRegisteredActivatedServiceTypes' method it gets the registered activated service types
and displays it's information to the console::
*/

// <Snippet1>
#using <System.Runtime.Remoting.dll>
#using <ActivatedServiceTypeEntry_ObjectType_Share.dll>

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Tcp;
void main()
{
   ChannelServices::RegisterChannel( gcnew TcpChannel( 8082 ) );
   
   // Create an instance of 'ActivatedServiceTypeEntry' class
   // which holds the values for 'HelloServer' type.
   ActivatedServiceTypeEntry^ myActivatedServiceTypeEntry =
      gcnew ActivatedServiceTypeEntry( HelloServer::typeid );
   
   // Register an object Type on the service end so that 
   // it can be activated on request from a client.
   RemotingConfiguration::RegisterActivatedServiceType(
      myActivatedServiceTypeEntry );
   
// <Snippet2>
// <Snippet3>
   // Get the registered activated service types.
   array<ActivatedServiceTypeEntry^>^ activatedServiceEntries =
      RemotingConfiguration::GetRegisteredActivatedServiceTypes();
   Console::WriteLine( "Information of first registered activated" +
     " service type :" );
   Console::WriteLine( "Object type: {0}",
      activatedServiceEntries[ 0 ]->ObjectType->ToString() );
   Console::WriteLine( "Description: {0}",
      activatedServiceEntries[ 0 ]->ToString() );
// </Snippet3>
// </Snippet2>

   Console::WriteLine( "Press enter to stop this process" );
   Console::ReadLine();
}
// </Snippet1>
