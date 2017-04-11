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


    protected void Button1_Click1(object sender, EventArgs e)
    {
        ObjectCache cache = MemoryCache.Default;
        string fileContents = cache["filecontents"] as string;
       
        if (fileContents == null)
        {
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration =
                DateTimeOffset.Now.AddSeconds(10.0);

            List<string> filePaths = new List<string>();
            string cachedFilePath = Server.MapPath("~") +
                "\\cacheText.txt";

            filePaths.Add(cachedFilePath);

            policy.ChangeMonitors.Add(new
                HostFileChangeMonitor(filePaths));

            // Fetch the file contents.
            fileContents = File.ReadAllText(cachedFilePath) + "\n"
                + DateTime.Now.ToString();

            cache.Set("filecontents", fileContents, policy);

        }

        Label1.Text = fileContents;
    }
}
//</Snippet1>
