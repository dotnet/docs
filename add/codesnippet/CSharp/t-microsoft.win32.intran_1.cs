         public static void UseIntranetCredentialPolicy()
        {
            IntranetZoneCredentialPolicy  policy = new IntranetZoneCredentialPolicy();
            AuthenticationManager.CredentialPolicy = policy;
        }