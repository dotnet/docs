// <Snippet1>
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Text;
using System.Configuration;
using System.Security.Permissions;

namespace Samples.AspNet
{

    // Shows how to use the ProviderSettings.
    public class UsingProviderSettings
    {

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        private static void GetProviderSettings()
        {
            // Get the application configuration file.
            System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

            ProtectedConfigurationSection pSection =
                config.GetSection("configProtectedData")
                as ProtectedConfigurationSection;

            ProviderSettingsCollection providerSettings =
              pSection.Providers;

            foreach (ProviderSettings pSettings in
                providerSettings)
            {

                // <Snippet2>

                Console.WriteLine(
                    "Provider settings name: {0}",
                    pSettings.Name);

                // </Snippet2>

                // <Snippet3>
                Console.WriteLine(
                    "Provider settings type: {0}",
                       pSettings.Type);
                // </Snippet3>

                // <Snippet4>
                NameValueCollection parameters =
                    pSettings.Parameters;

                IEnumerator pEnum =
                    parameters.GetEnumerator();

                int i = 0;
                while (pEnum.MoveNext())
                {
                    string pLength =
                        parameters[i].Length.ToString();
                    Console.WriteLine(
                        "Provider ssettings: {0} has {1} parameters",
                        pSettings.Name, pLength);

                }
                // </Snippet4>

            }

        }


        static void Main(string[] args)
        {

            GetProviderSettings();

        }
    }
}
// </Snippet1>
