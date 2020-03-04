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
  class UsingMembershipSection
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
        MembershipSection configSection =
          (MembershipSection)config.GetSection("system.web/membership");

        // Display title and info.
        Console.WriteLine("ASP.NET Configuration Info");
        Console.WriteLine();

        // Display Config details.
        Console.WriteLine("File Path: {0}",
          config.FilePath);
        Console.WriteLine("Section Path: {0}",
          configSection.SectionInformation.Name);

// <Snippet2>
        // Display Default Provider.
        Console.WriteLine("DefaultProvider: {0}",
          configSection.DefaultProvider);
// </Snippet2>

        // Set Default Provider.
        configSection.DefaultProvider =
          "AspNetSqlRoleProvider";

// <Snippet3>
        // Display HashAlgorithmType value.
        Console.WriteLine("HashAlgorithmType: {0}", 
          configSection.HashAlgorithmType);
// </Snippet3>

        // Set HashAlgorithmType value.
        configSection.HashAlgorithmType = 
          MachineKeyValidation.SHA1.ToString();

// <Snippet4>
        // Display UserIsOnlineTimeWindow value.
        Console.WriteLine("UserIsOnlineTimeWindow: {0}", 
          configSection.UserIsOnlineTimeWindow);
// </Snippet4>

        // Set UserIsOnlineTimeWindow value.
        configSection.UserIsOnlineTimeWindow = 
          TimeSpan.FromMinutes(15) ;

        // Display the number of Providers.
        Console.WriteLine("Providers Collection Count: {0}",
          configSection.Providers.Count);

// <Snippet5>
        // Display elements of the Providers collection property.
        foreach (ProviderSettings providerItem in configSection.Providers)
        {
          Console.WriteLine();
          Console.WriteLine("Provider Details:");
          Console.WriteLine("Name: {0}", providerItem.Name);
          Console.WriteLine("Type: {0}", providerItem.Type);
        }
// </Snippet5>

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

      // Display and wait.
      Console.ReadLine();
    }
  }
}
// </Snippet1>