using System;
//<Snippet1>
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Web.Configuration;

namespace Samples.AspNet
{

   
    public class ExternalConfiguration
    {
       
        // Instantiate the ExternalConfiguration type.
        public ExternalConfiguration()
        {
            // Access the root Web.config file.
            System.Configuration.Configuration config =
            WebConfigurationManager.OpenWebConfiguration(
                              "/configTarget");

            // Get the custom MyAppSettings section.
            AppSettingsSection appSettings =
                (AppSettingsSection)config.GetSection("MyAppSettings");

            // Perform the first update.
            UpdateAppSettings();
        }


        // Update the custom MyAppSettings section.
        // Note , if the section restartOnExternalChanges attribute 
        // is set to true, every update of the external 
        // configuration file will cause the application 
        // to restart.
        public void UpdateAppSettings()
        {

            System.Configuration.Configuration config =
            WebConfigurationManager.OpenWebConfiguration(
                              "/configTarget");

            AppSettingsSection appSettings =
                (AppSettingsSection)config.GetSection("MyAppSettings");

            int count = appSettings.Settings.Count;

            appSettings.Settings.Add(
                "key_" + count.ToString(), 
                "value_" + count.ToString());

            config.Save();
        }

    }
}
//</Snippet1>