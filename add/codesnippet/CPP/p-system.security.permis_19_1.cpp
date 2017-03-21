   // Use the enumeration flags to indicate that this method exposes shared state, 
   // self-affecting threading and the security infrastructure.
   // ApplyIdentity sets the current identity.

   [HostProtection(SharedState=true,SelfAffectingThreading=true,
   SecurityInfrastructure=true)]
   static int ApplyIdentity()
   {
      array<String^>^roles = {"User"};
      try
      {
         AppDomain^ mAD = AppDomain::CurrentDomain;
         GenericPrincipal^ mGenPr = gcnew GenericPrincipal( WindowsIdentity::GetCurrent(),roles );
         mAD->SetPrincipalPolicy( PrincipalPolicy::WindowsPrincipal );
         mAD->SetThreadPrincipal( mGenPr );
         return Success;
      }
      catch ( Exception^ e ) 
      {
         Exit( e->ToString(), 5 );
      }

      return 0;
   }