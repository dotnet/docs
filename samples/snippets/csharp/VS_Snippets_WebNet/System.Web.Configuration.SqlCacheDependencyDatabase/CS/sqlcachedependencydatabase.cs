using System;
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Web.Configuration;

namespace SamplesAspNet
{
    // Accesses the
    // System.Web.Configuration.SqlCacheDependencyDatabase members
    // selected by the user.
class UsingSqlCacheDependencyDatabase
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

        // Get the databases element at 0 index.
        System.Web.Configuration.SqlCacheDependencyDatabase sqlCdd =
            sqlDs.Databases[0];

// </Snippet1>
              

// <Snippet2>

        // Get the current PollTime property value.
        Int32 pollTimeValue = sqlCdd.PollTime;

        // Set the PollTime property to 1000 milliseconds.
        sqlCdd.PollTime = 1000;

// </Snippet2>

                
// <Snippet3>

        // Get the current Name property value.
        string nameValue = sqlCdd.Name;

        // Set the Name for this configuration element.
        sqlCdd.Name = "ConfigElementName";

// </Snippet3>
        
        
// <Snippet4>

        // Get the current ConnectionStringName property value.
        string connectionNameValue = sqlCdd.ConnectionStringName;

        // Set the ConnectionName property. This is the database name.
        sqlCdd.ConnectionStringName = "DataBaseName";

// </Snippet4>


// <Snippet5>
        SqlCacheDependencyDatabase dbElement0 =
            new SqlCacheDependencyDatabase(
            "dataBase", "dataBaseElement", 500);

// </Snippet5>

// <Snippet6>

        SqlCacheDependencyDatabase dbElement1 =
            new SqlCacheDependencyDatabase(
            "dataBase1", "dataBaseElement1");
        
// </Snippet6>

    }
} 
                                    
} 

