// <Snippet1> 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ReadWriteCache : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            Label1.Text = "Application Cache goes here.";
       
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        // Get the application configuration file.
        System.Configuration.Configuration config =
          System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");


        // <Snippet2>
        System.Web.Configuration.CacheSection cacheSection =
            (System.Web.Configuration.CacheSection)config.GetSection(
                "system.web/caching/cache");
        // </Snippet2>

        // <Snippet6>
        // Increase the PrivateBytesLimit property to 0.
        cacheSection.PrivateBytesLimit = 
            cacheSection.PrivateBytesLimit + 10;
        // </Snippet6>

      
        // <Snippet7>
        // Increase memory limit.
        cacheSection.PercentagePhysicalMemoryUsedLimit = 
            cacheSection.PercentagePhysicalMemoryUsedLimit + 1;
        // </Snippet7>

        // <Snippet8>
        // Increase poll time.
        cacheSection.PrivateBytesPollTime =
            cacheSection.PrivateBytesPollTime + TimeSpan.FromMinutes(1);
        // </Snippet8>
       

        // <Snippet3>
        // Enable or disable memory collection.
        cacheSection.DisableMemoryCollection = 
                !cacheSection.DisableMemoryCollection;
        // </Snippet3>

        // <Snippet4>
        // Enable or disable cache expiration.
        cacheSection.DisableExpiration =
            !cacheSection.DisableExpiration;
        // </Snippet4>

        // Save the configuration file.
        config.Save(System.Configuration.ConfigurationSaveMode.Modified);      

    }

    protected void Button2_Click(object sender, EventArgs e)
    {

        // Get the application configuration file.
        System.Configuration.Configuration config =
          System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");


        System.Web.Configuration.CacheSection cacheSection =
            (System.Web.Configuration.CacheSection)config.GetSection(
                "system.web/caching/cache");

        // Read the cache section.
        System.Text.StringBuilder buffer = new System.Text.StringBuilder();

        string currentFile = cacheSection.CurrentConfiguration.FilePath;
        bool dExpiration = cacheSection.DisableExpiration;
        bool dMemCollection = cacheSection.DisableMemoryCollection;
        TimeSpan pollTime = cacheSection.PrivateBytesPollTime;
        int phMemUse = cacheSection.PercentagePhysicalMemoryUsedLimit;
        long pvBytesLimit = cacheSection.PrivateBytesLimit;

        string cacheEntry = String.Format("File: {0} <br/>", currentFile);
        buffer.Append(cacheEntry);
        cacheEntry = String.Format("Expiration Disabled: {0} <br/>", dExpiration);
        buffer.Append(cacheEntry);
        cacheEntry = String.Format("Memory Collection Disabled: {0} <br/>", dMemCollection);
        buffer.Append(cacheEntry);
        cacheEntry = String.Format("Poll Time: {0} <br/>", pollTime.ToString());
        buffer.Append(cacheEntry);
        cacheEntry = String.Format("Memory Limit: {0} <br/>", phMemUse.ToString());
        buffer.Append(cacheEntry);
        cacheEntry = String.Format("Bytes Limit: {0} <br/>", pvBytesLimit.ToString());
        buffer.Append(cacheEntry);

        Label1.Text = buffer.ToString();
    }
}
// </Snippet1> 
