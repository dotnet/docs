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
      SamplePathProvider sampleProvider = new SamplePathProvider();
      HostingEnvironment.RegisterVirtualPathProvider(sampleProvider);
    } 
  }
}