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
  class UsingRoleManagerSection
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
        RoleManagerSection configSection =
          (RoleManagerSection)config.GetSection("system.web/roleManager");

        // Display title and info.
        Console.WriteLine("ASP.NET Configuration Info");
        Console.WriteLine();

        // Display Config details.
        Console.WriteLine("File Path: {0}",
          config.FilePath);
        Console.WriteLine("Section Path: {0}",
          configSection.SectionInformation.Name);

        // <Snippet2>
        // Display CacheRolesInCookie property.
        Console.WriteLine("CacheRolesInCookie: {0}",
          configSection.CacheRolesInCookie);
        // </Snippet2>

        // Set CacheRolesInCookie property.
        configSection.CacheRolesInCookie = false;

        // <Snippet3>
        // Display CookieName property.
        Console.WriteLine("CookieName: {0}", configSection.CookieName);
        // </Snippet3>

        // Set CookieName property.
        configSection.CookieName = ".ASPXROLES";

        // <Snippet4>
        // Display CookiePath property.
        Console.WriteLine("CookiePath: {0}", configSection.CookiePath);
        // </Snippet4>

        // Set CookiePath property.
        configSection.CookiePath = "/";

        // <Snippet5>
        // Display CookieProtection property.
        Console.WriteLine("CookieProtection: {0}",
          configSection.CookieProtection);
        // </Snippet5>

        // Set CookieProtection property.
        configSection.CookieProtection =
          System.Web.Security.CookieProtection.All;

        // <Snippet6>
        // Display CookieRequireSSL property.
        Console.WriteLine("CookieRequireSSL: {0}",
          configSection.CookieRequireSSL);
        // </Snippet6>

        // Set CookieRequireSSL property.
        configSection.CookieRequireSSL = false;

        // <Snippet7>
        // Display CookieSlidingExpiration property.
        Console.WriteLine("CookieSlidingExpiration: {0}",
          configSection.CookieSlidingExpiration);
        // </Snippet7>

        // Set CookieSlidingExpiration property.
        configSection.CookieSlidingExpiration = true;

        // <Snippet8>
        // Display CookieTimeout property.
        Console.WriteLine("CookieTimeout: {0}", configSection.CookieTimeout);
        // </Snippet8>

        // Set CookieTimeout property.
        configSection.CookieTimeout = TimeSpan.FromMinutes(30);

        // <Snippet9>
        // Display CreatePersistentCookie property.
        Console.WriteLine("CreatePersistentCookie: {0}",
          configSection.CreatePersistentCookie);
        // </Snippet9>

        // Set CreatePersistentCookie property.
        configSection.CreatePersistentCookie = false;

        // <Snippet10>
        // Display DefaultProvider property.
        Console.WriteLine("DefaultProvider: {0}",
          configSection.DefaultProvider);
        // </Snippet10>

        // Set DefaultProvider property.
        configSection.DefaultProvider = "AspNetSqlRoleProvider";

        // <Snippet11>
        // Display Domain property.
        Console.WriteLine("Domain: {0}", configSection.Domain);
        // </Snippet11>

        // Set Domain property.
        configSection.Domain = "";

        // <Snippet12>
        // Display Enabled property.
        Console.WriteLine("Enabled: {0}", configSection.Enabled);
        // </Snippet12>

        // Set Enabled property.
        configSection.Enabled = false;

        // Display the number of Providers
        Console.WriteLine("Providers Collection Count: {0}",
          configSection.Providers.Count);

        // <Snippet13>
        // Display elements of the Providers collection property.
        foreach (ProviderSettings providerItem in configSection.Providers)
        {
          Console.WriteLine();
          Console.WriteLine("Provider Details:");
          Console.WriteLine("Name: {0}", providerItem.Name);
          Console.WriteLine("Type: {0}", providerItem.Type);
        }
        // </Snippet13>

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