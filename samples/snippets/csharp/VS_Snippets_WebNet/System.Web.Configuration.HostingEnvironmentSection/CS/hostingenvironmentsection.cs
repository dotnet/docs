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
  class UsingHostingEnvironmentSection
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
        HostingEnvironmentSection configSection = 
          (HostingEnvironmentSection)config.GetSection("system.web/hostingEnvironment");

        // Display title and info.
        Console.WriteLine("ASP.NET Configuration Info");
        Console.WriteLine();

        // Display Config details.
        Console.WriteLine("File Path: {0}", config.FilePath);
        Console.WriteLine("Section Path: {0}", configSection.SectionInformation.Name);

// <Snippet2>
        // Display IdleTimout property
        Console.WriteLine("Idle Timeout: {0}", configSection.IdleTimeout);
// </Snippet2>

        // Set IdleTimout property
        configSection.IdleTimeout = TimeSpan.FromMinutes(40);

// <Snippet3>
        // Display ShutdownTimeout property
        Console.WriteLine("Shutdown Timeout: {0}", configSection.ShutdownTimeout);
// </Snippet3>

        // Set ShutdownTimeout property
        configSection.ShutdownTimeout = TimeSpan.FromSeconds(60);

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