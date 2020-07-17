

// <Snippet1>
#using <system.dll>
#using <system.runtime.remoting.dll>
#using "service.dll"

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Lifetime;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Http;
public ref class MyClientSponsor: public MarshalByRefObject, public ISponsor
{
private:
   DateTime lastRenewal;

public:
   MyClientSponsor()
   {
      Console::WriteLine( "Activating client..." );
      lastRenewal = DateTime::Now;
   }

   [System::Security::Permissions::SecurityPermissionAttribute
   (System::Security::Permissions::SecurityAction::LinkDemand,
   Flags=System::Security::Permissions::SecurityPermissionFlag::Infrastructure)]
   virtual TimeSpan Renewal( ILease^ lease )
   {
      Console::WriteLine( "Renewing a lease for 4 seconds." );
      Console::WriteLine( "Time since last renewal: {0}", (DateTime::Now - lastRenewal) );
      lastRenewal = DateTime::Now;
      return TimeSpan::FromSeconds( 4 );
   }
};

int main()
{
   ChannelServices::RegisterChannel( gcnew HttpChannel( 0 ) );
   RemotingConfiguration::RegisterActivatedClientType( ClientActivatedType::typeid, "http://localhost:8080" );
   ClientActivatedType ^ CAObject = gcnew ClientActivatedType;
   ILease^ serverLease = dynamic_cast<ILease^>(RemotingServices::GetLifetimeService( CAObject ));
   MyClientSponsor^ sponsor = gcnew MyClientSponsor;
   serverLease->Register( sponsor );
   
   // Call same method on the Object*
   Console::WriteLine( "Client-activated Object*: {0}", CAObject->RemoteMethod( "Bob" ) );
   Console::WriteLine( "Press Enter to end the client application domain." );
   Console::ReadLine();
   return 0;
}
// </Snippet1>
