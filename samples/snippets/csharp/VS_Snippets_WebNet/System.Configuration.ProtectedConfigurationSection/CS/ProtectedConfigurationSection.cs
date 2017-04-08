// <Snippet1>
using System;
using System.IO;
using System.Configuration;

namespace Samples.Aspnet
{
    // Shows how to use ProtectedConfigurationSection.
    class UsingProtectedConfigurationSection
    {

        // <Snippet2>
        static void GetDefaultProvider()
        {
            try
            {
                // Get the application configuration.
                Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

                // Get the protected configuration section.
                ProtectedConfigurationSection pcSection =
                    (System.Configuration.ProtectedConfigurationSection)
                    config.GetSection("configProtectedData");

                // Get the current DefaultProvider.
                Console.WriteLine(
                    "Protected configuration section default provider:");
                Console.WriteLine("  {0}", pcSection.DefaultProvider);

            }
            catch (ConfigurationErrorsException e)
            {
                Console.WriteLine(e.ToString());
            }

        }
        // </Snippet2>


        // <Snippet3>
        static void GetProviderCollection()
        {

            try
            {
                // Get the application configuration.
                Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

                // Get the protected configuration section.
                ProtectedConfigurationSection pcSection =
                    (System.Configuration.ProtectedConfigurationSection)
                    config.GetSection("configProtectedData");

                Console.WriteLine(
               "Protected configuration section providers:");
                foreach (ProviderSettings ps in
                pcSection.Providers)
                {
                    Console.WriteLine("  {0}", ps.Name);
                }

            }
            catch (ConfigurationErrorsException e)
            {
                Console.WriteLine(e.ToString());
            }

        }
        // </Snippet3>

        public static void Main()
        {
            GetDefaultProvider();
            GetProviderCollection();
        }
    }
} 
// </Snippet1>
