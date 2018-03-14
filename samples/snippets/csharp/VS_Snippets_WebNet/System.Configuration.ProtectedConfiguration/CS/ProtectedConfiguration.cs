// <Snippet1>
using System;
using System.Configuration;
using System.Collections;
using System.Security.Permissions;

namespace Samples.AspNet
{
  
    // Show how to use the ProtectedConfiguration.
    public sealed class UsingProtectedConfiguration
    {
        
       

        // <Snippet3>
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
        // </Snippet3>

       [PermissionSet(SecurityAction.Demand, Name="FullTrust")]    
	private static void GetProviderName()
        {
            // <Snippet4>
            // Get the current provider name.
            string dataProtectionProviderName =
               ProtectedConfiguration.DataProtectionProviderName;
            Console.WriteLine(
                "Data protection provider name: {0}",
                 dataProtectionProviderName);
            // </Snippet4>

            // <Snippet5>
            // Get the Rsa provider name.
            string rsaProviderName =
                ProtectedConfiguration.RsaProviderName;
            Console.WriteLine(
                "Rsa provider name: {0}",
                 rsaProviderName);
            // </Snippet5>

            // <Snippet6>
            // Get the protected section name.
            string protectedSectionName =
                ProtectedConfiguration.ProtectedDataSectionName;
            Console.WriteLine(
                "Protected section name: {0}",
                 protectedSectionName);
            // </Snippet6>


        }


        static void Main(string[] args)
        {

           
            // Get current and Rsa provider names.
            GetProviderName();

            // Get the providers' collection.
            GetProviders();
    

        }
    }    
}
// </Snippet1>
