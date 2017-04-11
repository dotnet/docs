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
    // System.Web.Configuration.SqlCacheDependencyDatabaseCollection members
    // selected by the user.
    class UsingSqlCacheDependencyDatabaseCollection
    {
       
        public static void Main(string[] args)
        {
        
// <Snippet1>
        // Get the Web application configuration.
        Configuration webConfig = 
            WebConfigurationManager.OpenWebConfiguration("/aspnetTest");
                
        // Get the section.
        string configPath = "system.web/cache/sqlCacheDependency";
        SqlCacheDependencySection sqlCacheDependencySection =
          (SqlCacheDependencySection)webConfig.GetSection(configPath);

        // Get the database element at the specified index.
        SqlCacheDependencyDatabaseCollection sqlCdds =
            sqlCacheDependencySection.Databases;

// </Snippet1>

// <Snippet2>

        object[] collectionKeys = sqlCdds.AllKeys;
               
// </Snippet2>

// <Snippet3>
        SqlCacheDependencyDatabase dbElement =
            new SqlCacheDependencyDatabase(
            "dataBase", "dataBaseElement", 500);
        sqlCdds.Add(dbElement);

// </Snippet3>

// <Snippet4>
        sqlCdds.Clear();

// </Snippet4>

// <Snippet5>
        SqlCacheDependencyDatabase dbElement1 =
            sqlCdds.Get(0);

// </Snippet5>

// <Snippet6>
        SqlCacheDependencyDatabase dbElement3 =
          sqlCdds.Get("dataBaseElement");

// </Snippet6>

// <Snippet7>
        string thisKey = sqlCdds.GetKey(0).ToString();

// </Snippet7>

// <Snippet8>
        sqlCdds.Remove("dataBaseElement");

// </Snippet8>

// <Snippet9>
        sqlCdds.RemoveAt(0);

// </Snippet9>

// <Snippet10>
        SqlCacheDependencyDatabase dbElement2 =
        new SqlCacheDependencyDatabase(
        "dataBase2", "dataBaseElement2", 500);
        sqlCdds.Set(dbElement2);

// </Snippet10>
  
    }
} 
    
} 


