//<Snippet1>
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

        //<Snippet2>
        // Get the context.
        WebContext webContext = (WebContext)config.EvaluationContext.HostingContext;
        //</Snippet2>

        // Display title.
        Console.WriteLine("ASP.NET WebContext Info");
        Console.WriteLine("");

        //<Snippet3>
        // WebContext - Application Level.
        Console.WriteLine("ApplicationLevel: {0}", 
          webContext.ApplicationLevel.ToString());
        //</Snippet3>
        //<Snippet4>
        // WebContext - Application Path.
        Console.WriteLine("ApplicationPath: {0}", 
          webContext.ApplicationPath.ToString());
        //</Snippet4>
        //<Snippet6>
        // WebContext - Path.
        Console.WriteLine("Path: {0}", webContext.Path.ToString());
        //</Snippet6>
        //<Snippet7>
        // WebContext - Site.
        Console.WriteLine("Site: {0}", webContext.Site.ToString());
        //</Snippet7>
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
//</Snippet1>