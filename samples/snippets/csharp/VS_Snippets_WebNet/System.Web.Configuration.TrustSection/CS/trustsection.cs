// <Snippet1>
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
  class UsingTrustSection
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
        TrustSection configSection = (TrustSection)config.GetSection("system.web/trust");

        // Display title and info.
        Console.WriteLine("ASP.NET Configuration Info");
        Console.WriteLine();

        // Display Config details.
        Console.WriteLine("File Path: {0}", config.FilePath);
        Console.WriteLine("Section Path: {0}", configSection.SectionInformation.Name);

// <Snippet2>
        // Display Level property
        Console.WriteLine("Level: {0}", configSection.Level);
// </Snippet2>

        // Set Level property
        configSection.Level = "Full";

// <Snippet3>
        // Display OriginUrl property
        Console.WriteLine("Origin Url: {0}", configSection.OriginUrl);
// </Snippet3>

        // Set OriginUrl property
        configSection.OriginUrl = "";

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
// </Snippet1>