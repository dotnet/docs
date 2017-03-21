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

        // Display CacheRolesInCookie property.
        Console.WriteLine("CacheRolesInCookie: {0}",
          configSection.CacheRolesInCookie);

        // Set CacheRolesInCookie property.
        configSection.CacheRolesInCookie = false;

        // Display CookieName property.
        Console.WriteLine("CookieName: {0}", configSection.CookieName);

        // Set CookieName property.
        configSection.CookieName = ".ASPXROLES";

        // Display CookiePath property.
        Console.WriteLine("CookiePath: {0}", configSection.CookiePath);

        // Set CookiePath property.
        configSection.CookiePath = "/";

        // Display CookieProtection property.
        Console.WriteLine("CookieProtection: {0}",
          configSection.CookieProtection);

        // Set CookieProtection property.
        configSection.CookieProtection =
          System.Web.Security.CookieProtection.All;

        // Display CookieRequireSSL property.
        Console.WriteLine("CookieRequireSSL: {0}",
          configSection.CookieRequireSSL);

        // Set CookieRequireSSL property.
        configSection.CookieRequireSSL = false;

        // Display CookieSlidingExpiration property.
        Console.WriteLine("CookieSlidingExpiration: {0}",
          configSection.CookieSlidingExpiration);

        // Set CookieSlidingExpiration property.
        configSection.CookieSlidingExpiration = true;

        // Display CookieTimeout property.
        Console.WriteLine("CookieTimeout: {0}", configSection.CookieTimeout);

        // Set CookieTimeout property.
        configSection.CookieTimeout = TimeSpan.FromMinutes(30);

        // Display CreatePersistentCookie property.
        Console.WriteLine("CreatePersistentCookie: {0}",
          configSection.CreatePersistentCookie);

        // Set CreatePersistentCookie property.
        configSection.CreatePersistentCookie = false;

        // Display DefaultProvider property.
        Console.WriteLine("DefaultProvider: {0}",
          configSection.DefaultProvider);

        // Set DefaultProvider property.
        configSection.DefaultProvider = "AspNetSqlRoleProvider";

        // Display Domain property.
        Console.WriteLine("Domain: {0}", configSection.Domain);

        // Set Domain property.
        configSection.Domain = "";

        // Display Enabled property.
        Console.WriteLine("Enabled: {0}", configSection.Enabled);

        // Set Enabled property.
        configSection.Enabled = false;

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