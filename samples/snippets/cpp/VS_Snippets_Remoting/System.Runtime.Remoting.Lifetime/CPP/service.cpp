

// <Snippet3>
#using <system.dll>
#using <system.runtime.remoting.dll>

using namespace System;
using namespace System::Runtime::Remoting::Lifetime;

public ref class MyLease: public MarshalByRefObject, public ILease
{
private:
   ILease^ baseLease;

public:
   [System::Security::Permissions::SecurityPermissionAttribute
   (System::Security::Permissions::SecurityAction::LinkDemand,
   Flags=System::Security::Permissions::SecurityPermissionFlag::Infrastructure)]
   MyLease( ILease^ oldLease )
   {
      Console::WriteLine( "Constructing MyLease." );
      if ( oldLease == nullptr )
            Console::WriteLine( "CRUD!" );

      baseLease = oldLease;
   }


   property TimeSpan CurrentLeaseTime 
   {
      [System::Security::Permissions::SecurityPermissionAttribute
      (System::Security::Permissions::SecurityAction::LinkDemand,
      Flags=System::Security::Permissions::SecurityPermissionFlag::Infrastructure)]
      virtual TimeSpan get()
      {
         TimeSpan time = baseLease->CurrentLeaseTime;
         Console::WriteLine( "The CurrentLeaseTime property returned {0}.", time.Milliseconds );
         return time;
      }

   }

   property LeaseState CurrentState 
   {
      [System::Security::Permissions::SecurityPermissionAttribute
      (System::Security::Permissions::SecurityAction::LinkDemand,
      Flags=System::Security::Permissions::SecurityPermissionFlag::Infrastructure)]
      virtual LeaseState get()
      {
         LeaseState state = baseLease->CurrentState;
         Console::WriteLine( "The CurrentState property returned {0}.", state );
         return state;
      }

   }


   property TimeSpan InitialLeaseTime 
   {
      [System::Security::Permissions::SecurityPermissionAttribute
      (System::Security::Permissions::SecurityAction::LinkDemand,
      Flags=System::Security::Permissions::SecurityPermissionFlag::Infrastructure)]
      virtual TimeSpan get()
      {
         TimeSpan time = baseLease->InitialLeaseTime;
         Console::WriteLine( "The InitialLeaseTime property returned {0}.", time.Milliseconds );
         return time;
      }

      [System::Security::Permissions::SecurityPermissionAttribute
      (System::Security::Permissions::SecurityAction::LinkDemand,
      Flags=System::Security::Permissions::SecurityPermissionFlag::Infrastructure)]
      virtual void set( TimeSpan value )
      {
         baseLease->InitialLeaseTime = value;
         Console::WriteLine( "The InitialLeaseTime property was set to {0}.", value.Milliseconds );
      }

   }

   property TimeSpan RenewOnCallTime 
   {
      [System::Security::Permissions::SecurityPermissionAttribute
      (System::Security::Permissions::SecurityAction::LinkDemand,
      Flags=System::Security::Permissions::SecurityPermissionFlag::Infrastructure)]
      virtual TimeSpan get()
      {
         TimeSpan time = baseLease->RenewOnCallTime;
         Console::WriteLine( "The RenewOnCallTime property returned {0}.", time.Milliseconds );
         return time;
      }

      [System::Security::Permissions::SecurityPermissionAttribute
      (System::Security::Permissions::SecurityAction::LinkDemand,
      Flags=System::Security::Permissions::SecurityPermissionFlag::Infrastructure)]
      virtual void set( TimeSpan value )
      {
         Console::WriteLine( "The RenewOnCallTime property was set to {0}.", value.Milliseconds );
         baseLease->RenewOnCallTime = value;
      }

   }

   property TimeSpan SponsorshipTimeout 
   {
      [System::Security::Permissions::SecurityPermissionAttribute
      (System::Security::Permissions::SecurityAction::LinkDemand,
      Flags=System::Security::Permissions::SecurityPermissionFlag::Infrastructure)]
      virtual TimeSpan get()
      {
         TimeSpan time = baseLease->SponsorshipTimeout;
         Console::WriteLine( "The SponsorshipTimeout property returned {0}.", time.Milliseconds );
         return time;
      }

      [System::Security::Permissions::SecurityPermissionAttribute
      (System::Security::Permissions::SecurityAction::LinkDemand,
      Flags=System::Security::Permissions::SecurityPermissionFlag::Infrastructure)]
      virtual void set( TimeSpan value )
      {
         Console::WriteLine( "The SponsorshipTimeout property was set to {0}.", value.Milliseconds );
         baseLease->SponsorshipTimeout = value;
      }

   }

   [System::Security::Permissions::SecurityPermissionAttribute
   (System::Security::Permissions::SecurityAction::LinkDemand,
   Flags=System::Security::Permissions::SecurityPermissionFlag::Infrastructure)]
   virtual void Register( ISponsor^ sponsor )
   {
      Console::WriteLine( "The sponsor {0} has been registered with the current lease.", sponsor );
      baseLease->Register( sponsor );
   }

   [System::Security::Permissions::SecurityPermissionAttribute
   (System::Security::Permissions::SecurityAction::LinkDemand,
   Flags=System::Security::Permissions::SecurityPermissionFlag::Infrastructure)]
   virtual void Register( ISponsor^ sponsor, TimeSpan renewalTime )
   {
      Console::WriteLine( "The sponsor {0} has been registered with the current lease for {0} milliseconds...", sponsor, renewalTime.Milliseconds );
      baseLease->Register( sponsor, renewalTime );
   }

   [System::Security::Permissions::SecurityPermissionAttribute
   (System::Security::Permissions::SecurityAction::LinkDemand,
   Flags=System::Security::Permissions::SecurityPermissionFlag::Infrastructure)]
   virtual TimeSpan Renew( TimeSpan renewalTime )
   {
      Console::WriteLine( "The lease has been renewed for {0} milliseconds...", renewalTime.Milliseconds );
      return baseLease->Renew( renewalTime );
   }

   [System::Security::Permissions::SecurityPermissionAttribute
   (System::Security::Permissions::SecurityAction::LinkDemand,
   Flags=System::Security::Permissions::SecurityPermissionFlag::Infrastructure)]
   virtual void Unregister( ISponsor^ sponsor )
   {
      Console::WriteLine( "The sponsor {0} has been unregistered from the current lease.", sponsor );
      baseLease->Unregister( sponsor );
   }

};


public ref class ClientActivatedType: public MarshalByRefObject
{
public:

   //  the lease settings for this Object*
   [System::Security::Permissions::SecurityPermissionAttribute
   (System::Security::Permissions::SecurityAction::LinkDemand,
   Flags=System::Security::Permissions::SecurityPermissionFlag::Infrastructure)]
   virtual Object^ InitializeLifetimeService() override
   {
      ILease^ lease = gcnew MyLease( dynamic_cast<ILease^>(MarshalByRefObject::InitializeLifetimeService()) );
      return lease;
   }

   String^ RemoteMethod( String^ name )
   {
      
      // announce to the server that we've been called.
      Console::WriteLine( "ClientActivatedType::RemoteMethod called by {0}", name );
      
      // report our client identity name
      return String::Format( "Hello, {0}!", name );
   }

};
// </Snippet3>
