// <Snippet10>
using System.Web.Hosting;

namespace Samples.AspNet.CS
{
  /// <summary>
  ///   Contains the application initialization method
  ///   for the sample application.
  /// </summary>
  public static class AppStart
  {
    public static void AppInitialize()
    {
      // <Snippet11>
      SamplePathProvider sampleProvider = new SamplePathProvider();
      HostingEnvironment.RegisterVirtualPathProvider(sampleProvider);
      // </Snippet11>
    } 
  }
}
// </Snippet10>
