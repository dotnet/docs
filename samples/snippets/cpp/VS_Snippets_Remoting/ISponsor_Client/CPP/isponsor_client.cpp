// System::Runtime::Remoting::Lifetime.ISponsor
// System::Runtime::Remoting::Lifetime.ISponsor.Renewal

/*
The following program demonstrates the 'ISponsor' interface and its 'Renewal' method.
It defines 'MyClientSponsor' which implements 'ISponsor' interface. The server and
client is created. The client registers a sponsor that(after the initial lease time)
renews the lease at different time from that specified in the remote type.
*/

// <Snippet3>
#using <system.dll>
#using <system.runtime.remoting.dll>
#using <RemoteType.dll>

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Lifetime;
using namespace System::Security::Permissions;

// <Snippet1>
// <Snippet2>
public ref class MyClientSponsor: public MarshalByRefObject, public ISponsor
{
private:
   DateTime lastRenewal;

public:
   MyClientSponsor()
   {
      lastRenewal = DateTime::Now;
   }

   [SecurityPermissionAttribute(SecurityAction::LinkDemand,Flags=SecurityPermissionFlag::Infrastructure)]
   virtual TimeSpan Renewal( ILease^ /* lease */ )
   {
      Console::WriteLine( "Request to renew the lease time." );
      Console::WriteLine( "Time since last renewal: {0}",
         DateTime::Now - lastRenewal );

      lastRenewal = DateTime::Now;
      return TimeSpan::FromSeconds( 20 );
   }
};
// </Snippet2>
// </Snippet1>

int main()
{
   // Load the configuration file.
   RemotingConfiguration::Configure( "ISponsor_Client.config" );
   ClientActivatedType ^ clientActivatedObject = gcnew ClientActivatedType;

   ILease^ serverLease = (ILease^)( RemotingServices::GetLifetimeService(
      clientActivatedObject ) );
   MyClientSponsor^ sponsor = gcnew MyClientSponsor;
   
   // Note: If you don't pass an initial time, the first request will be taken
   // from the LeaseTime settings specified in the ISponsor_Server.config file.
   serverLease->Register( sponsor );

   Console::WriteLine( "Client-activated Object.\n {0}",
      clientActivatedObject->RemoteMethod() );
   Console::WriteLine( "Press enter to end the client application domain." );
   Console::ReadLine();
   return 0;
}
// </Snippet3>
