//<Snippet1>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.Caching;
using System.IO;

public partial class _Default : System.Web.UI.Page
{
   
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        ObjectCache cache = MemoryCache.Default;

        CacheItem fileContents = cache.GetCacheItem("filecontents");

        if (fileContents == null)
        {
            CacheItemPolicy policy = new CacheItemPolicy();

            List<string> filePaths = new List<string>();
            string cachedFilePath = Server.MapPath("~") +
                "\\cacheText.txt";

            filePaths.Add(cachedFilePath);

            policy.ChangeMonitors.Add(new HostFileChangeMonitor(filePaths));

            // Fetch the file contents
            string fileData = File.ReadAllText(cachedFilePath);

            fileContents = new CacheItem("filecontents", fileData);

            cache.Set(fileContents, policy);
        }
        Label1.Text = (fileContents.Value as string);


    }
}
//</Snippet1>