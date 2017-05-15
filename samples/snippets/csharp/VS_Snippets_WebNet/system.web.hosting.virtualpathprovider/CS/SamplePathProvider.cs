// <Snippet20>
using System;
using System.Data;
using System.Security.Permissions;
using System.Web;
using System.Web.Caching;
using System.Web.Hosting;

namespace Samples.AspNet.CS
{
  [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Medium)]
  [AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.High)]
  public class SamplePathProvider : VirtualPathProvider
  {
    private string dataFile;

    // <Snippet25>
    public SamplePathProvider()
      : base()
    {
    }
    // </Snippet25>

    // <Snippet26>
    protected override void Initialize()
    {
      //<Snippet27>
      // Set the datafile path relative to the application's path.
      dataFile = HostingEnvironment.ApplicationPhysicalPath + "App_Data\\XMLData.xml";
      //</Snippet27>
    }
    // </Snippet26>

    /// <summary>
    ///   Data set provider for the SampleVirtualDirectory and
    ///   SampleVirtualFile classes. In a production application
    ///   this method would be on a provider class that accesses
    ///   the virtual resource data source.
    /// </summary>
    /// <returns>
    ///   The System.Data.DataSet containing the virtual resources 
    ///   provided by the SamplePathProvider.
    /// </returns>
    public DataSet GetVirtualData()
    {
      // Get the data from the cache.
      DataSet ds = (DataSet)HostingEnvironment.Cache.Get("VPPData");
      if (ds == null)
      {
        // Data not in cache. Read XML file.
        ds = new DataSet();
        ds.ReadXml(dataFile);

        // Make DataSet dependent on XML file.
        CacheDependency cd = new CacheDependency(dataFile);

        // Put DataSet into cache for maximum of 20 minutes.
        HostingEnvironment.Cache.Add("VPPData", ds, cd,
          Cache.NoAbsoluteExpiration,
          new TimeSpan(0, 20, 0),
          CacheItemPriority.Default, null);

        // Set data timestamp.
        DateTime dataTimeStamp = DateTime.Now;
        // Cache it so we can get the timestamp in later calls.
        HostingEnvironment.Cache.Insert("dataTimeStamp", dataTimeStamp, null,
          Cache.NoAbsoluteExpiration,
          new TimeSpan(0, 20, 0),
          CacheItemPriority.Default, null);
      }
      return ds;
    }

    /// <summary>
    ///   Determines whether a specified virtual path is within
    ///   the virtual file system.
    /// </summary>
    /// <param name="virtualPath">An absolute virtual path.</param>
    /// <returns>
    ///   true if the virtual path is within the 
    ///   virtual file sytem; otherwise, false.
    /// </returns>
    private bool IsPathVirtual(string virtualPath)
    {
      String checkPath = VirtualPathUtility.ToAppRelative(virtualPath);
      return checkPath.StartsWith("~/vrdir", StringComparison.InvariantCultureIgnoreCase);
    }

    // <Snippet21>
    public override bool FileExists(string virtualPath)
    {
      if (IsPathVirtual(virtualPath))
      {
        SampleVirtualFile file = (SampleVirtualFile)GetFile(virtualPath);
        return file.Exists;
      }
      else
        return Previous.FileExists(virtualPath);
    }
    // </Snippet21>

    // <Snippet22>
    public override bool DirectoryExists(string virtualDir)
    {
      if (IsPathVirtual(virtualDir))
      {
        SampleVirtualDirectory dir = (SampleVirtualDirectory)GetDirectory(virtualDir);
        return dir.Exists;
      }
      else
        return Previous.DirectoryExists(virtualDir);
    }
    // </Snippet22>

    // <Snippet23>
    public override VirtualFile GetFile(string virtualPath)
    {
      if (IsPathVirtual(virtualPath))
        return new SampleVirtualFile(virtualPath, this);
      else
        return Previous.GetFile(virtualPath);
    }
    // </Snippet23>

    // <Snippet24>
    public override VirtualDirectory GetDirectory(string virtualDir)
    {
      if (IsPathVirtual(virtualDir))
        return new SampleVirtualDirectory(virtualDir, this);
      else
        return Previous.GetDirectory(virtualDir);
    }
    // </Snippet24>

    // <Snippet28>
    public override CacheDependency GetCacheDependency(
      string virtualPath, 
      System.Collections.IEnumerable virtualPathDependencies, 
      DateTime utcStart)
    {
      if (IsPathVirtual(virtualPath))
      {
        System.Collections.Specialized.StringCollection fullPathDependencies = null;

        // Get the full path to all dependencies.
        foreach (string virtualDependency in virtualPathDependencies)
        {
          if (fullPathDependencies == null)
            fullPathDependencies = new System.Collections.Specialized.StringCollection();

          fullPathDependencies.Add(virtualDependency);
        }
        if (fullPathDependencies == null)
          return null;

        // Copy the list of full-path dependencies into an array.
        string[] fullPathDependenciesArray = new string[fullPathDependencies.Count];
        fullPathDependencies.CopyTo(fullPathDependenciesArray, 0);
        // Copy the virtual path into an array.
        string[] virtualPathArray = new string[1];
        virtualPathArray[0] = virtualPath;

        return new CacheDependency(virtualPathArray, fullPathDependenciesArray, utcStart);
      }
      else
        return Previous.GetCacheDependency(virtualPath, virtualPathDependencies, utcStart);
    }
    // </Snippet28>
  }
  
}
//</Snippet20>
