#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Web;
using System.Web.Configuration;

#endregion

namespace Samples.Aspnet.SystemWebConfiguration
{
  class UsingSiteMapSection
  {
    static void Main(string[] args)
    {
      try
      {
        // Set the path of the config file.
        string configPath = "";

        // Get the Web application configuration object.
        Configuration config = WebConfigurationManager.OpenWebConfiguration(configPath);

        // Get the section related object.
        SiteMapSection configSection = 
          (SiteMapSection)config.GetSection("system.web/siteMap");

        // Display title and info.
        Console.WriteLine("ASP.NET Configuration Info");
        Console.WriteLine();

        // Display Config details.
        Console.WriteLine("File Path: {0}", 
          config.FilePath);
        Console.WriteLine("Section Path: {0}",
          configSection.SectionInformation.Name);
        // Display Default Provider.
        Console.WriteLine("Default Provider: {0}",
          configSection.DefaultProvider);

        // Set Default Provider.
        configSection.DefaultProvider = 
          "SiteMapProviderName";

        // Display Enabled value.
        Console.WriteLine("Enabled: {0}", configSection.Enabled);

        // Set Enabled value.
        configSection.Enabled = true;

        // Display the number of Providers
        Console.WriteLine("Providers Collection Count: {0}",
          configSection.Providers.Count);

        // Display elements of the Providers collection property.
        foreach (ProviderSettings providerItem in configSection.Providers)
        {
          Console.WriteLine();
          Console.WriteLine("Provider Details:");
          Console.WriteLine("Name: {0}", providerItem.Name);
          Console.WriteLine("Type: {0}", providerItem.Type);
        }

        // Update if not locked.
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