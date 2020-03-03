

// <Snippet2>
#using <system.dll>
#using <system.runtime.remoting.dll>
#using "service.dll"

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Http;
using namespace System::Runtime::Remoting::Lifetime;

int main()
{
   LifetimeServices::LeaseTime = TimeSpan::FromSeconds( 5 );
   LifetimeServices::LeaseManagerPollTime = TimeSpan::FromSeconds( 3 );
   LifetimeServices::RenewOnCallTime = TimeSpan::FromSeconds( 2 );
   LifetimeServices::SponsorshipTimeout = TimeSpan::FromSeconds( 1 );
   ChannelServices::RegisterChannel( gcnew HttpChannel( 8080 ) );
   RemotingConfiguration::RegisterActivatedServiceType( ClientActivatedType::typeid );
   Console::WriteLine( "The server is listening. Press Enter to exit...." );
   Console::ReadLine();
   Console::WriteLine( "GC'ing." );
   GC::Collect();
   GC::WaitForPendingFinalizers();
   return 0;
}
// </Snippet2>
