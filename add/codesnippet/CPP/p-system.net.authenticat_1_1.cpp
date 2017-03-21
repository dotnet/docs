   static void UseIntranetCredentialPolicy()
   {
      IntranetZoneCredentialPolicy^ policy = gcnew IntranetZoneCredentialPolicy;
      AuthenticationManager::CredentialPolicy = policy;
   }