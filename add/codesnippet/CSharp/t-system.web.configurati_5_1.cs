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
  class UsingMachineKeySection
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
        MachineKeySection configSection = 
          (MachineKeySection)config.GetSection("system.web/machineKey");

        // Display title and info.
        Console.WriteLine("ASP.NET Configuration Info");
        Console.WriteLine();

        // Display Config details.
        Console.WriteLine("File Path: {0}",
          config.FilePath);
        Console.WriteLine("Section Path: {0}",
          configSection.SectionInformation.Name);

        // Display ValidationKey property.
        Console.WriteLine("ValidationKey: {0}",
          configSection.ValidationKey);

        // Set ValidationKey property.
        configSection.ValidationKey = "AutoGenerate,IsolateApps";

        // Display DecryptionKey property.
        Console.WriteLine("DecryptionKey: {0}",
          configSection.DecryptionKey);

        // Set DecryptionKey property.
        configSection.DecryptionKey = "AutoGenerate,IsolateApps";

        // Display Validation property.
        Console.WriteLine("Validation: {0}",
          configSection.Validation);

        // Set Validation property.
        configSection.Validation = MachineKeyValidation.SHA1;

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