using System;
using System.Configuration;
using System.Web.Configuration;

namespace SamplesAspNet
{
 
class UsingSqlCacheDependencySection
{
    public static void Main()
    {
          
    // <Snippet1>
        // Get the Web application configuration.
        System.Configuration.Configuration webConfig = 
        WebConfigurationManager.OpenWebConfiguration("/aspnetTest");
                        

        // Get the section.
        string configPath = "system.web/cache/sqlCacheDependency";
        System.Web.Configuration.SqlCacheDependencySection sqlDs = 
        (System.Web.Configuration.SqlCacheDependencySection)webConfig.GetSection(
        configPath);

        
    // </Snippet1>

    // <Snippet2>

        // Get the current Databases collection.
        SqlCacheDependencyDatabaseCollection databasesValue =
            sqlDs.Databases;

    // </Snippet2>
                
    // <Snippet3>

        // Get the current PollTime property value.
        Int32 pollTimeValue = sqlDs.PollTime;

        // Set the PollTime property to 500 milliseconds.
        sqlDs.PollTime = 500;

    // </Snippet3>
                
    // <Snippet4>

        // Get the current Enabled property value.
        Boolean enabledValue = sqlDs.Enabled;

        // Set the Enabled property to false.
        sqlDs.Enabled = false;

    // </Snippet4>

        }
}
    
} 


