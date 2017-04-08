// <Snippet4>
#using <system.dll>
#using <system.runtime.remoting.dll>

using namespace System;
using namespace System::Runtime::Remoting::Lifetime;
using namespace System::Security::Principal;

public ref class ClientActivatedType: public MarshalByRefObject
{
public:
   // Override the lease settings for this Object.
   [System::Security::Permissions::SecurityPermissionAttribute
   (System::Security::Permissions::SecurityAction::LinkDemand, 
   Flags=System::Security::Permissions::SecurityPermissionFlag::Infrastructure)]
   virtual Object^ InitializeLifetimeService() override
   {
      ILease^ lease = (ILease^)( MarshalByRefObject::InitializeLifetimeService() );
      if ( lease->CurrentState == LeaseState::Initial )
      {
         lease->InitialLeaseTime = TimeSpan::FromSeconds( 3 );
         lease->SponsorshipTimeout = TimeSpan::FromSeconds( 10 );
         lease->RenewOnCallTime = TimeSpan::FromSeconds( 2 );
      }
      return lease;
   }

   String^ RemoteMethod()
   {
      Console::WriteLine( "ClientActivatedType::RemoteMethod called." );
      
      // Report our client identity name.
      return "RemoteMethodCalled. User name : {0}",WindowsIdentity::GetCurrent()->Name;
   }
};
// </Snippet4>
