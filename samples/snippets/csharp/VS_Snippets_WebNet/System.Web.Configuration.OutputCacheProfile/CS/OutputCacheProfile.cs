using System;
using System.Configuration;
using System.Web.Configuration;

namespace Samples.Aspnet.SystemWebConfiguration
{
    // Accesses the System.Web.Configuration.OutputCacheProfile
    // members selected by the user.
    class UsingOutputCacheProfile
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

        // Get the profile at zero index.
        System.Web.Configuration.OutputCacheProfile outputCacheProfile = 
          outputCacheSettings.OutputCacheProfiles[0];

// </Snippet1>

// <Snippet2>

      // Get the current VaryByHeader.
      String varyByHeaderValue = 
          outputCacheProfile.VaryByHeader;

      // Set the VaryByHeader.
      outputCacheProfile.VaryByHeader = 
          string.Empty;

// </Snippet2>
                
// <Snippet3>

      // Get the current VaryByControl.
      String varyByControlValue = 
          outputCacheProfile.VaryByControl;

      // Set the VaryByControl.
      outputCacheProfile.VaryByControl = 
          string.Empty;

// </Snippet3>
                
// <Snippet4>

      // Get the current NoStore.
      Boolean noStoreValue = 
          outputCacheProfile.NoStore;

      // Set the NoStore.
      outputCacheProfile.NoStore = false;

// </Snippet4>
                
// <Snippet5>

      // Get the current Location.
      System.Web.UI.OutputCacheLocation locationValue = 
          outputCacheProfile.Location;

      // Set the Location property to null.
      outputCacheProfile.Location = 
          System.Web.UI.OutputCacheLocation.Server;

// </Snippet5>
                

                
// <Snippet7>

      // Get the current SqlDependency.
      String sqlDependencyValue = 
          outputCacheProfile.SqlDependency;

      // Set the SqlDependency.
      outputCacheProfile.SqlDependency = 
          string.Empty;

// </Snippet7>
                
// <Snippet8>

      // Get the current VaryByParam.
      String varyByParamValue = 
          outputCacheProfile.VaryByParam;

      // Set the VaryByParam.
      outputCacheProfile.VaryByParam = 
          string.Empty;

// </Snippet8>
                
// <Snippet9>

      // Get the current VaryByCustom.
      String varyByCustomValue = 
          outputCacheProfile.VaryByCustom;

      // Set the VaryByCustom.
      outputCacheProfile.VaryByCustom = 
          string.Empty;

// </Snippet9>
                
// <Snippet10>

      // Get the current Duration.
      Int32 durationValue = 
          outputCacheProfile.Duration;

      // Set the Duration property to 0.
      outputCacheProfile.Duration = 0;

// </Snippet10>
                
// <Snippet11>

      // Get the current Name.
      String nameValue = 
          outputCacheProfile.Name;

      // Set the Name.
      outputCacheProfile.Name = 
          string.Empty;

// </Snippet11>
                
// <Snippet12>

    // Get the current Enabled.
   Boolean enabledValue = 
       outputCacheProfile.Enabled;

    // Set the Enabled.
    outputCacheProfile.Enabled = 
        false;

// </Snippet12>
          
 
        }
    } // UsingOutputCacheProfile class end.
    
} // Samples.Aspnet.SystemWebConfiguration namespace end.

