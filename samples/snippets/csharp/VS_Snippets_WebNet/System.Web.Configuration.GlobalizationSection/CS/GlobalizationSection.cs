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
  class UsingGlobalizationSection
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
        GlobalizationSection configSection =
          (GlobalizationSection)config.GetSection("system.web/globalization");

        // Display title and info.
        Console.WriteLine("ASP.NET Configuration Info");
        Console.WriteLine();

        // Display Config details.
        Console.WriteLine("File Path: {0}",
          config.FilePath);
        Console.WriteLine("Section Path: {0}",
          configSection.SectionInformation.Name);

// <Snippet2>
        // Display Culture property.
        Console.WriteLine("Culture: {0}",
          configSection.Culture);
// </Snippet2>
        
        // Set Culture property.
        configSection.Culture = 
          System.Globalization.CultureInfo.CurrentCulture.ToString();
         
// <Snippet3>
        // Display EnableClientBasedCulture property.
        Console.WriteLine("EnableClientBasedCulture: {0}", 
          configSection.EnableClientBasedCulture);
// </Snippet3>

        // Set EnableClientBasedCulture property.
        configSection.EnableClientBasedCulture = false;

// <Snippet4>
        // Display FileEncoding property.
        Console.WriteLine("FileEncoding: {0}", 
          configSection.FileEncoding);
// </Snippet4>

        // Set FileEncoding property.
        configSection.FileEncoding = 
          System.Text.Encoding.UTF8;

// <Snippet5>
        // Display RequestEncoding property.
        Console.WriteLine("RequestEncoding: {0}",
          configSection.RequestEncoding);
// </Snippet5>

        // Set RequestEncoding property.
        configSection.RequestEncoding = 
          System.Text.Encoding.UTF8;

// <Snippet6>
        // Display ResponseEncoding property.
        Console.WriteLine("ResponseEncoding: {0}",
          configSection.ResponseEncoding);
// </Snippet6>

        // Set ResponseEncoding property.
        configSection.ResponseEncoding = 
          System.Text.Encoding.UTF8;

// <Snippet7>
        // Display ResponseHeaderEncoding property.
        Console.WriteLine("ResponseHeaderEncoding: {0}", 
          configSection.ResponseHeaderEncoding);
// </Snippet7>

        // Set ResponseHeaderEncoding property.
        configSection.ResponseHeaderEncoding = 
          System.Text.Encoding.UTF8;

// <Snippet8>
        // Display UICulture property.
        Console.WriteLine("UICulture: {0}",
          configSection.UICulture);
// </Snippet8>

        // Set UICulture property.
         configSection.UICulture = 
           System.Globalization.CultureInfo.CurrentUICulture.ToString();

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
