// <Snippet1>
#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Web;
using System.Web.Configuration;

#endregion

namespace Samples.Aspnet.ConfigurationSample
{
  class UsingContextInformation
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
        HealthMonitoringSection configSection =
          (HealthMonitoringSection)config.GetSection("system.web/healthMonitoring");

        // Display title and info.
        Console.WriteLine("ASP.NET Configuration Info");
        Console.WriteLine();

        // Display Config details.
        Console.WriteLine("File Path: {0}",
          config.FilePath);
        Console.WriteLine("Section Path: {0}",
          configSection.SectionInformation.Name);

          // <Snippet2>
          // IsMachineLevel property.
          Console.WriteLine("IsMachineLevel: {0}",
            config.EvaluationContext.IsMachineLevel);
          // </Snippet2>

          // <Snippet3>
          // Create an object based on HostingContext.
          WebContext myWC =
            (WebContext)config.EvaluationContext.HostingContext;
          // Use the WebContext object to determine
          // the ApplicationLevel.
          Console.WriteLine("ApplicationLevel: {0}",
            myWC.ApplicationLevel);
          // </Snippet3>
        }

      catch (Exception e)
      {
        // Error.
        Console.WriteLine(e.ToString());
      }

      // Display and wait.
      Console.ReadLine();
    }
  }
}
// </Snippet1>
