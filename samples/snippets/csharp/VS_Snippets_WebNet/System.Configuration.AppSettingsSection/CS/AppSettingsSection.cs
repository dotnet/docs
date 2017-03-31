// <Snippet1>
using System;
using System.Collections.Specialized;
using System.Configuration;

namespace ConfigurationSamples
{
    class UsingAppSettingsSection
    {
        static void UsingConfigurationManager_AppSettings()
        {
            // <Snippet2>
            // <Snippet3>
            string[] names = ConfigurationManager.AppSettings.AllKeys;
            // </Snippet3>
            // <Snippet4>
            NameValueCollection appStgs = ConfigurationManager.AppSettings;
            // </Snippet4>
            for (int i = 0; i < appStgs.Count; i++)
            {
                // <Snippet5>
                Console.WriteLine("#{0} Name: {1} Value: {2}",
                  i, names[i], appStgs[i]);
                // </Snippet5>
            }
            // </Snippet2>
        }


        static void Main(string[] args)
        {
           
            // <Snippet8>
            // Get the count of the Application Settings.
            int appStgCnt = ConfigurationManager.AppSettings.Count;
            // </Snippet8>
            string asName = "AppStg" + appStgCnt.ToString();

            // <Snippet9>
            // <Snippet10>
            // Get the configuration file.
            System.Configuration.Configuration config =
              ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            // </Snippet10>

            // <Snippet11>
            // Add an Application Setting.
            config.AppSettings.Settings.Add(asName,
              DateTime.Now.ToLongDateString() + " " +
              DateTime.Now.ToLongTimeString());
            // </Snippet11>

            // <Snippet12>
            // Save the configuration file.
            config.Save(ConfigurationSaveMode.Modified);
            // </Snippet12>
            // </Snippet9>

            // <Snippet13>
            // Force a reload of a changed section.
            ConfigurationManager.RefreshSection("appSettings");
            // </Snippet13>


            Console.WriteLine("Using ConfigurationManager AppSettings:");
            UsingConfigurationManager_AppSettings();

           
            // <Snippet15>
            // Show the value of a named Application Setting.
            Console.WriteLine(
              "The value of application setting {0} is '{1}'.",
              asName, ConfigurationManager.AppSettings[asName]);
            // </Snippet15>

            
        }
    }
}
// </Snippet1>
