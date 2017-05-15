

// <Snippet5>
#using <system.dll>
#using <system.runtime.remoting.dll>

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Lifetime;

namespace RemotingSamples
{
   public ref class HelloService: public MarshalByRefObject
   {
   public:
      String^ HelloMethod( String^ name )
      {
         Console::WriteLine( "Hello {0}", name );
         return "Hello {0}",name;
      }

      [System::Security::Permissions::SecurityPermissionAttribute
      (System::Security::Permissions::SecurityAction::LinkDemand, 
      Flags=System::Security::Permissions::SecurityPermissionFlag::Infrastructure)]
      virtual Object^ InitializeLifetimeService() override
      {
         ILease^ baseLease = dynamic_cast<ILease^>(MarshalByRefObject::InitializeLifetimeService());
         if ( baseLease->CurrentState == LeaseState::Initial )
         {
            
            // For demonstration the initial time is kept small.
            // in actual scenarios it will be large.
            baseLease->InitialLeaseTime = TimeSpan::FromSeconds( 15 );
            baseLease->RenewOnCallTime = TimeSpan::FromSeconds( 15 );
            baseLease->SponsorshipTimeout = TimeSpan::FromMinutes( 2 );
         }

         return baseLease;
      }

   };

}

// </Snippet5>
