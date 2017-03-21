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