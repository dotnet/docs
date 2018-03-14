using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Configuration;

public partial class _Default : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    try
    {
      // Set the path of the config file.
      string configPath = "";

      // Get the Web application configuration object.
      Configuration config = WebConfigurationManager.OpenWebConfiguration(configPath);

      // <Snippet2>
      // Get the section related object.
      HttpRuntimeSection configSection =
        (HttpRuntimeSection)config.GetSection("system.web/httpRuntime");
      // </Snippet2>

      // Display title and info.
      Response.Write("<b>ASP.NET Configuration Info</b>" + "<br>");

      // Display Config details.
      Response.Write("File Path: " + config.FilePath + "<br>");
      Response.Write("Section Path: " +
        configSection.SectionInformation.Name + "<p>");

      // <Snippet3>
      // Get the current EnableKernelOutputCache property value.
      Response.Write("EnableKernelOutputCache: " +
        configSection.EnableKernelOutputCache + "<br>");

      // Set the EnableKernelOutputCache property to true.
      configSection.EnableKernelOutputCache = true;
      // </Snippet3>

      // <Snippet4>
      // Get the current MaxWaitChangeNotification property value.
      Response.Write("MaxWaitChangeNotification: " +
        configSection.MaxWaitChangeNotification + "<br>");

      // Set the MaxWaitChangeNotification property value to 10 seconds.
      configSection.MaxWaitChangeNotification = 10;
      // </Snippet4>

      // <Snippet5>
      // Get the MinLocalRequestFreeThreads property value.
      Response.Write("MinLocalRequestFreeThreads: " +
        configSection.MinLocalRequestFreeThreads + "<br>");

      // Set the MinLocalRequestFreeThreads property value to 8.
      configSection.MinLocalRequestFreeThreads = 8;
      // </Snippet5>

      // <Snippet6>
      // Get the ShutdownTimeout property value.
      Response.Write("ShutdownTimeout: " +
        configSection.ShutdownTimeout.ToString() + "<br>");

      // Set the ShutdownTimeout property value to 2 minutes.
      configSection.ShutdownTimeout = TimeSpan.FromMinutes(2);
      // </Snippet6>

      // <Snippet7>
      // Get the RequireRootedSaveAsPath property value.
      Response.Write("RequireRootedSaveAsPath: " +
        configSection.RequireRootedSaveAsPath + "<br>");

      // Set the RequireRootedSaveAsPath property value to true.
      configSection.RequireRootedSaveAsPath = true;
      // </Snippet7>

      // <Snippet8>
      // Get the MinFreeThreads property value.
      Response.Write("MinFreeThreads: " +
        configSection.MinFreeThreads + "<br>");

      // Set the MinFreeThreads property value to 16
      configSection.MinFreeThreads = 16;
      // </Snippet8>

      // <Snippet10>
      // Get the ExecutionTimeout property value.
      Response.Write("ExecutionTimeout: " +
        configSection.ExecutionTimeout.ToString() + "<br>");

      // Set the ExecutionTimeout property value to 2 minutes.
      configSection.ExecutionTimeout = TimeSpan.FromMinutes(2);
      // </Snippet10>

      // <Snippet11>
      // Get the DelayNotificationTimeout property value.
      Response.Write("DelayNotificationTimeout: " +
        configSection.DelayNotificationTimeout.ToString() + "<br>");

      // Set the DelayNotificationTimeout property value to 10 seconds.
      configSection.DelayNotificationTimeout = TimeSpan.FromSeconds(10);
      // </Snippet11>

      // <Snippet12>
      // Get the RequestLengthDiskThreshold property value.
      Response.Write("RequestLengthDiskThreshold: " +
        configSection.RequestLengthDiskThreshold + "<br>");

      // Set the RequestLengthDiskThreshold property value to 512 bytes.
      configSection.RequestLengthDiskThreshold = 512;
      // </Snippet12>

      // <Snippet13>
      // Get the RequestPriority property value.
      // Response.Write("RequestPriority: " +
      //  configSection.RequestPriority + "<br>");

      // Set the RequestPriority property value to critical.
      // configSection.RequestPriority = HttpRequestPriority.Critical;
      // </Snippet13>

      // <Snippet14>
      // Get the Enable property value.
      Response.Write("Enable: " +
        configSection.Enable + "<br>");

      // Set the Enable property value to true.
      configSection.Enable = true;
      // </Snippet14>

      // <Snippet15>
      // Get the UseFullyQualifiedRedirectUrl property value.
      Response.Write("UseFullyQualifiedRedirectUrl: " +
        configSection.UseFullyQualifiedRedirectUrl + "<br>");

      // Set the UseFullyQualifiedRedirectUrl property value set to true.
      configSection.UseFullyQualifiedRedirectUrl = true;
      // </Snippet15>

      // <Snippet16>
      // Get the AppRequestQueueLimit property value.
      Response.Write("AppRequestQueueLimit: " +
        configSection.AppRequestQueueLimit + "<br>");

      // Set the AppRequestQueueLimit property value to 4500.
      configSection.AppRequestQueueLimit = 4500;
      // </Snippet16>

      // <Snippet17>
      // Get the EnableVersionHeader property value.
      Response.Write("EnableVersionHeader: " +
        configSection.EnableVersionHeader + "<br>");

      // Set the EnableVersionHeader property value to false
      configSection.EnableVersionHeader = false;
      // </Snippet17>

      // <Snippet18>
      // Get the WaitChangeNotification property value.
      Response.Write("WaitChangeNotification: " +
        configSection.WaitChangeNotification + "<br>");

      // Set the WaitChangeNotification property value to 10 seconds.
      configSection.WaitChangeNotification = 10;
      // </Snippet18>

      // <Snippet19>
      // Get the MaxRequestLength property value.
      Response.Write("MaxRequestLength: " +
        configSection.MaxRequestLength + "<br>");

      // Set the MaxRequestLength property value to 2048 kilobytes.
      configSection.MaxRequestLength = 2048;
      // </Snippet19>

      // <Snippet20>
      // Get the EnableHeaderChecking property value.
      Response.Write("EnableHeaderChecking: " +
        configSection.EnableHeaderChecking + "<br>");

      // Set the EnableHeaderChecking property value to true.
      configSection.EnableHeaderChecking = true;
      // </Snippet20>
    }
    catch (Exception ex)
    {
      // Unknown error.
      HttpContext.Current.Response.Write("Error: " + ex.ToString());
    }
  }
}


