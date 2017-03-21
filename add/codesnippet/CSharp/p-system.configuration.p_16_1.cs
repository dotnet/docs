        [PermissionSet(SecurityAction.Demand, Name="FullTrust")]    
 	 private static void GetProviders()
        {
            // Get the providers' collection.
            ProtectedConfigurationProviderCollection
                providers = ProtectedConfiguration.Providers;

            IEnumerator pEnum =
                providers.GetEnumerator();

            foreach (ProtectedConfigurationProvider provider in
                providers)
            {
                Console.WriteLine
                    ("Provider name: {0}",
                      provider.Name);
                Console.WriteLine
                         ("Provider description: {0}",
                          provider.Description);
           
            }
 
        }