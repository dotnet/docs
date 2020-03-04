
using namespace System;
using namespace System::Runtime::Remoting::Lifetime;

// <Snippet1>
public ref class MyClass: public MarshalByRefObject
{
public:
   
   [System::Security::Permissions::SecurityPermissionAttribute
   (System::Security::Permissions::SecurityAction::Demand,
   Flags=System::Security::Permissions::SecurityPermissionFlag::Infrastructure)]
   virtual Object^ InitializeLifetimeService() override
   {
      ILease^ lease = dynamic_cast<ILease^>(MarshalByRefObject::InitializeLifetimeService());
      if ( lease->CurrentState == LeaseState::Initial )
      {
         lease->InitialLeaseTime = TimeSpan::FromMinutes( 1 );
         lease->SponsorshipTimeout = TimeSpan::FromMinutes( 2 );
         lease->RenewOnCallTime = TimeSpan::FromSeconds( 2 );
      }

      return lease;
   }

};

// </Snippet1>
