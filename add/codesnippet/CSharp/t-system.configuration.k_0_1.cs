using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Web;
using System.Web.Configuration;

namespace Samples.Aspnet.Config
{
  class KeyValueConfigCollection
  {
    static void Main(string[] args)
    {
      try
      {
        // Set the path of the config file.
        string configPath = "/aspnet";

        // Get the Web application configuration object.
        Configuration config =
          WebConfigurationManager.OpenWebConfiguration(configPath);

        // Get the section related object.
        AppSettingsSection configSection =
          (AppSettingsSection)config.GetSection
          ("appSettings");

        // Display title and info.
        Console.WriteLine("ASP.NET Configuration Info");
        Console.WriteLine();

        // Display Config details.
        Console.WriteLine("File Path: {0}",
          config.FilePath);
        Console.WriteLine("Section Path: {0}",
          configSection.SectionInformation.Name.ToString());
        Console.WriteLine();

        // Create the KeyValueConfigurationElement.
        KeyValueConfigurationElement myAdminKeyVal = 
          new KeyValueConfigurationElement(
          "myAdminTool", "admin.aspx");

        // Determine if the configuration contains
        // any KeyValueConfigurationElements.
        KeyValueConfigurationCollection configSettings = 
          config.AppSettings.Settings;
        if (configSettings.AllKeys.Length == 0)
        {
          // Add KeyValueConfigurationElement to collection.
          config.AppSettings.Settings.Add(myAdminKeyVal);

          if (!configSection.SectionInformation.IsLocked)
          {
            config.Save();
            Console.WriteLine("** Configuration updated.");
          }
          else
          {
            Console.WriteLine("** Could not update, section is locked.");
          }
        }

        // Get the KeyValueConfigurationCollection 
        // from the configuration.
        KeyValueConfigurationCollection settings = 
          config.AppSettings.Settings;

        // Display each KeyValueConfigurationElement.
        foreach (KeyValueConfigurationElement keyValueElement in settings)
        {
          Console.WriteLine("Key: {0}", keyValueElement.Key);
          Console.WriteLine("Value: {0}", keyValueElement.Value);
          Console.WriteLine();
        }

      }
      catch (Exception e)
      {
        // Unknown error.
        Console.WriteLine(e.ToString());
      }

      // Display and wait
      Console.ReadLine();
    }
  }
}