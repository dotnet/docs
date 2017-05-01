using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.Web.Configuration;
using System.Web;
using System.Web.SessionState;

namespace Samples.AspNet
{
  class UsingSessionStateSection
  {
    public static void Main()
    {
      try
      {
        // <Snippet1>
        // Get the Web application configuration object.
        System.Configuration.Configuration configuration =
          System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/aspnetTest");

        // Get the section related object.
        System.Web.Configuration.SessionStateSection sessionStateSection =
          (System.Web.Configuration.SessionStateSection)
          configuration.GetSection("system.web/sessionState");
        // </Snippet1>

        // <Snippet2>
        // Display the current AllowCustomSqlDatabase property value.
        Console.WriteLine("AllowCustomSqlDatabase: {0}",
          sessionStateSection.AllowCustomSqlDatabase);
        // </Snippet2>

        // <Snippet3>
        // Display the current RegenerateExpiredSessionId property value.
        Console.WriteLine("RegenerateExpiredSessionId: {0}",
          sessionStateSection.RegenerateExpiredSessionId);
        // </Snippet3>

        // <Snippet4>
        // Display the current CustomProvider property value.
        Console.WriteLine("CustomProvider: {0}",
          sessionStateSection.CustomProvider);
        // </Snippet4>

        // <Snippet5>
        // Display the current CookieName property value.
        Console.WriteLine("CookieName: {0}",
          sessionStateSection.CookieName);
        // </Snippet5>

        // <Snippet6>
        // Display the current StateNetworkTimeout property value.
        Console.WriteLine("StateNetworkTimeout: {0}",
          sessionStateSection.StateNetworkTimeout);
        // </Snippet6>

        // <Snippet7>
        // Display the current Cookieless property value.
        Console.WriteLine("Cookieless: {0}",
          sessionStateSection.Cookieless);
        // </Snippet7>

        // <Snippet8>
        // Display the current SqlConnectionString property value.
        Console.WriteLine("SqlConnectionString: {0}",
          sessionStateSection.SqlConnectionString);
        // </Snippet8>

        // <Snippet9>
        // Display the current StateConnectionString property value.
        Console.WriteLine("StateConnectionString: {0}",
          sessionStateSection.StateConnectionString);
        // </Snippet9>

        // <Snippet10>
        // Display elements of the Providers collection property.
        foreach (ProviderSettings providerItem in sessionStateSection.Providers)
        {
          Console.WriteLine();
          Console.WriteLine("Provider Details:");
          Console.WriteLine("Name: {0}", providerItem.Name);
          Console.WriteLine("Type: {0}", providerItem.Type);
        }
        // </Snippet10>

        // <Snippet11>
        // Display the current Timeout property value.
        Console.WriteLine("Timeout: {0}",
          sessionStateSection.Timeout);
        // </Snippet11>

        // <Snippet13>
        // Display the current SqlCommandTimeout property value.
        Console.WriteLine("SqlCommandTimeout: {0}",
          sessionStateSection.SqlCommandTimeout);
        // </Snippet13>

        // <Snippet14>
        // Display the current Mode property value.
        Console.WriteLine("Mode: {0}",
          sessionStateSection.Mode);
        // </Snippet14>
      }
      catch (System.ArgumentException)
      {
        // Unknown error.
        Console.WriteLine("A invalid argument exception detected in " +
          "UsingSessionStateSection Main. Check your command line" +
          "for errors.");
      }
      Console.ReadLine();
    }
  } // UsingSessionStateSection class end.

} // Samples.Aspnet.SystemWebConfiguration namespace end.

