using System;
using System.Configuration;
using System.Web.Configuration;

namespace Samples.Aspnet.SystemWebConfiguration
{
    class UsingOutputCacheSettingsSection
    {
      public static void Main()
      {
          
// <Snippet1>
        // Get the Web application configuration.
          System.Configuration.Configuration webConfig =
            WebConfigurationManager.OpenWebConfiguration("/aspnetTest");

          // Get the section.

          string configPath =
              "system.web/caching/outputCacheSettings";
          System.Web.Configuration.OutputCacheSettingsSection outputCacheSettings =
          (System.Web.Configuration.OutputCacheSettingsSection)webConfig.GetSection(
          configPath);

         
// </Snippet1>

// <Snippet2>

        // Create a OutputCacheSettingsSection object.
        System.Web.Configuration.OutputCacheSettingsSection outCacheSettings = 
            new System.Web.Configuration.OutputCacheSettingsSection();

// </Snippet2>
             
// <Snippet3>
        // Get the current OutputCacheProfiles property value.
        OutputCacheProfileCollection outputCacheProfilesValue =
          outputCacheSettings.OutputCacheProfiles;

// </Snippet3>
      }
  } // UsingOutputCacheSettingsSection class end.
  
} // Samples.Aspnet.SystemWebConfiguration namespace end.

