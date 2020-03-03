// <Snippet40>
using System;
using System.Data;
using System.IO;
using System.Security.Permissions;
using System.Web;
using System.Web.Caching;
using System.Web.Hosting;

namespace Samples.AspNet.CS
{
  [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
  [AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
  public class SampleVirtualFile : VirtualFile
  {
    private string content;
    private SamplePathProvider spp;

    public bool Exists
    {
      get { return (content != null); }
    }

    // <Snippet41>
    public SampleVirtualFile(string virtualPath, SamplePathProvider provider)
      : base(virtualPath)
    {
      this.spp = provider;
      GetData();
    }

    protected void GetData()
    {
      // Get the data from the SamplePathProvider
      DataSet ds = spp.GetVirtualData();

      // Get the virtual file from the resource table.
      DataTable files = ds.Tables["resource"];
      DataRow[] rows = files.Select(
        String.Format("(name = '{0}') AND (type='file')", this.Name));

      // If the select returned a row, store the file contents.
      if (rows.Length > 0)
      {
        DataRow row = rows[0];

        content = row["content"].ToString();
      }
    }
    // </Snippet41>

    // <Snippet42>
    private string FormatTimeStamp(DateTime time)
    {
      return String.Format("{0} at {1}",
        time.ToLongDateString(), time.ToLongTimeString());
    }

    public override Stream Open()
    {
      string templateFile = HostingEnvironment.ApplicationPhysicalPath + "App_Data\\template.txt";
      string pageTemplate;
      DateTime now = DateTime.Now;

      // Try to get the page template out of the cache.
      pageTemplate = (string)HostingEnvironment.Cache.Get("pageTemplate");

      if (pageTemplate == null)
      {
        // Get the page template.
        using (StreamReader reader = new StreamReader(templateFile))
        {
          pageTemplate = reader.ReadToEnd();
        }

        // Set template timestamp
        pageTemplate = pageTemplate.Replace("%templateTimestamp%", 
          FormatTimeStamp(now));

        // Make pageTemplate dependent on the template file.
        CacheDependency cd = new CacheDependency(templateFile);

        // Put pageTemplate into cache for maximum of 20 minutes.
        HostingEnvironment.Cache.Add("pageTemplate", pageTemplate, cd,
          Cache.NoAbsoluteExpiration,
          new TimeSpan(0, 20, 0),
          CacheItemPriority.Default, null);
      }

      // Put the page data into the template.
      pageTemplate = pageTemplate.Replace("%file%", this.Name);
      pageTemplate = pageTemplate.Replace("%content%", content);

      // Get the data time stamp from the cache.
      DateTime dataTimeStamp = (DateTime)HostingEnvironment.Cache.Get("dataTimeStamp");
      pageTemplate = pageTemplate.Replace("%dataTimestamp%", 
        FormatTimeStamp(dataTimeStamp));
      pageTemplate = pageTemplate.Replace("%pageTimestamp%", 
        FormatTimeStamp(now));

      // Put the page content on the stream.
      Stream stream = new MemoryStream();
      StreamWriter writer = new StreamWriter(stream);

      writer.Write(pageTemplate);
      writer.Flush();
      stream.Seek(0, SeekOrigin.Begin);

      return stream;
    }
    // </Snippet42>
  }
}
// </Snippet40>