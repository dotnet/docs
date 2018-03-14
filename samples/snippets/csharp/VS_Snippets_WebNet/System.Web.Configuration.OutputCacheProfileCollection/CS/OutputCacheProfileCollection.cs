using System;
using System.Configuration;
using System.Web.Configuration;

namespace Samples.Aspnet.SystemWebConfiguration
{
    // Accesses the
    // System.Web.Configuration.OutputCacheSettingsSection members
    // selected by the user.
    class UsingOutputCacheSettingsSection
    {

      public static void Main(string[] args)
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

        // Get the profile collection.
        System.Web.Configuration.OutputCacheProfileCollection outputCacheProfiles =
          outputCacheSettings.OutputCacheProfiles;
      
// </Snippet1>


// <Snippet2>
        // Execute the Add method.
        System.Web.Configuration.OutputCacheProfile outputCacheProfile0 =
          new System.Web.Configuration.OutputCacheProfile("MyCacheProfile");
        outputCacheProfile0.Location = 
            System.Web.UI.OutputCacheLocation.Any;
        outputCacheProfile0.NoStore = false;

        outputCacheProfiles.Add(outputCacheProfile0);

        // Update if not locked.
        if (!outputCacheSettings.IsReadOnly())
        {
            webConfig.Save();
        }
// </Snippet2>
                        
 
// <Snippet3>
        // Execute the Clear method.
        outputCacheProfiles.Clear();
// </Snippet3>

// <Snippet4>

        // Get the profile with the specified index.
        System.Web.Configuration.OutputCacheProfile outputCacheProfile2 =
          outputCacheProfiles[0];

// </Snippet4>

// <Snippet5>
        // Get the profile with the specified name.
        System.Web.Configuration.OutputCacheProfile outputCacheProfile3 =
          outputCacheProfiles["MyCacheProfile"];

// </Snippet5>
    

// <Snippet6>
        // Get the key with the specified index.
        string theKey = outputCacheProfiles.GetKey(0).ToString();

// </Snippet6>

// <Snippet7>
        // Remove the output profile with the specified index.
        outputCacheProfiles.RemoveAt(0);

// </Snippet7>


// <Snippet8>
        // Remove the output profile with the specified name.
        outputCacheProfiles.Remove("MyCacheProfile");

// </Snippet8>

// <Snippet9>
        // Get the keys.
        object [] keys = outputCacheProfiles.AllKeys;

// </Snippet9>

// <Snippet10>
        // Execute the Set method.
        System.Web.Configuration.OutputCacheProfile outputCacheProfile =
          new System.Web.Configuration.OutputCacheProfile("MyCacheProfile");
        outputCacheProfile.Location = 
            System.Web.UI.OutputCacheLocation.Any;
        outputCacheProfile.NoStore = false;

        outputCacheProfiles.Set(outputCacheProfile);

        // Update if not locked.
        if (!outputCacheSettings.IsReadOnly())
        {
          webConfig.Save();
        }
// </Snippet10>

      // <Snippet11>
      // Get the profile with the specified name.
      System.Web.Configuration.OutputCacheProfile outputCacheProfile4 =
        outputCacheProfiles.Get("MyCacheProfile");

      // </Snippet11>

      // <Snippet12>
      // Get thge profile with the specified index.
      System.Web.Configuration.OutputCacheProfile outputCacheProfile5 =
        outputCacheProfiles.Get(0);
      // </Snippet12>

      }

  } // UsingOutputCacheSettingsSection class end.
    
} // Samples.Aspnet.SystemWebConfiguration namespace end.

