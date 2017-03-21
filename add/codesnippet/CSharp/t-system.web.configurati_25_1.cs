using System;
using System.Configuration;
using System.Web;
using System.Web.Configuration;

namespace WebContextTest01cs
{
  class UsingWebContext
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

        // Get the context.
        WebContext webContext = (WebContext)config.EvaluationContext.HostingContext;

        // Display title.
        Console.WriteLine("ASP.NET WebContext Info");
        Console.WriteLine("");

        // WebContext - Application Level.
        Console.WriteLine("ApplicationLevel: {0}", 
          webContext.ApplicationLevel.ToString());
        // WebContext - Application Path.
        Console.WriteLine("ApplicationPath: {0}", 
          webContext.ApplicationPath.ToString());
        // WebContext - Path.
        Console.WriteLine("Path: {0}", webContext.Path.ToString());
        // WebContext - Site.
        Console.WriteLine("Site: {0}", webContext.Site.ToString());
      }
      catch (Exception ex)
      {
        // Unknown error.
        Console.WriteLine(ex.ToString());
      }

      // Display and wait.
      Console.ReadLine();
    }
  }
}