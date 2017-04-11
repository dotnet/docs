' <Snippet1>

Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Web.Configuration

Partial Class _Default
    Inherits System.Web.UI.Page

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Try
      ' Set the path of the config file.
      Dim configPath As String = ""

      ' Get the Web application configuration object.
      Dim config As Configuration = WebConfigurationManager.OpenWebConfiguration(configPath)

      ' <Snippet2>
      ' Get the section related object.
      Dim configSection As System.Web.Configuration.HttpRuntimeSection = _
       CType(config.GetSection("system.web/httpRuntime"), _
       System.Web.Configuration.HttpRuntimeSection)
      ' </Snippet2>

      ' Display title and info.
      Response.Write("<b>ASP.NET Configuration Info</b>" & "<br>")

      ' Display Config details.
      Response.Write("File Path: " & config.FilePath & "<br>")
      Response.Write("Section Path: " & _
        configSection.SectionInformation.Name & "<p>")

      ' <Snippet3>
      ' Get the current EnableKernelOutputCache property value.
      Response.Write("EnableKernelOutputCache: " & _
        configSection.EnableKernelOutputCache & "<br>")

      ' Set the EnableKernelOutputCache property to true.
      configSection.EnableKernelOutputCache = True
      ' </Snippet3>

      ' <Snippet4>
      ' Get the current MaxWaitChangeNotification property value.
      Response.Write("MaxWaitChangeNotification: " & _
        configSection.MaxWaitChangeNotification & "<br>")

      ' Set the MaxWaitChangeNotification property value to 10 seconds.
      configSection.MaxWaitChangeNotification = 10
      ' </Snippet4>

      ' <Snippet5>
      ' Get the MinLocalRequestFreeThreads property value.
      Response.Write("MinLocalRequestFreeThreads: " & _
        configSection.MinLocalRequestFreeThreads & "<br>")

      ' Set the MinLocalRequestFreeThreads property value to 8.
      configSection.MinLocalRequestFreeThreads = 8
      ' </Snippet5>

      ' <Snippet6>
      ' Get the ShutdownTimeout property value.
      Response.Write("ShutdownTimeout: " & _
        configSection.ShutdownTimeout.ToString() & "<br>")

      ' Set the ShutdownTimeout property value to 2 minutes.
      configSection.ShutdownTimeout = TimeSpan.FromMinutes(2)
      ' </Snippet6>

      ' <Snippet7>
      ' Get the RequireRootedSaveAsPath property value.
      Response.Write("RequireRootedSaveAsPath: " & _
        configSection.RequireRootedSaveAsPath & "<br>")

      ' Set the RequireRootedSaveAsPath property value to true.
      configSection.RequireRootedSaveAsPath = True
      ' </Snippet7>

      ' <Snippet8>
      ' Get the MinFreeThreads property value.
      Response.Write("MinFreeThreads: " & _
        configSection.MinFreeThreads & "<br>")

      ' Set the MinFreeThreads property value to 16
      configSection.MinFreeThreads = 16
      ' </Snippet8>

      ' <Snippet10>
      ' Get the ExecutionTimeout property value.
      Response.Write("ExecutionTimeout: " & _
        configSection.ExecutionTimeout.ToString() & "<br>")

      ' Set the ExecutionTimeout property value to 2 minutes.
      configSection.ExecutionTimeout = TimeSpan.FromMinutes(2)
      ' </Snippet10>

      ' <Snippet11>
      ' Get the DelayNotificationTimeout property value.
      Response.Write("DelayNotificationTimeout: " & _
        configSection.DelayNotificationTimeout.ToString() & "<br>")

      ' Set the DelayNotificationTimeout property value to 10 seconds.
      configSection.DelayNotificationTimeout = TimeSpan.FromSeconds(10)
      ' </Snippet11>

      ' <Snippet12>
      ' Get the RequestLengthDiskThreshold property value.
      Response.Write("RequestLengthDiskThreshold: " & _
        configSection.RequestLengthDiskThreshold & "<br>")

      ' Set the RequestLengthDiskThreshold property value to 512 bytes.
      configSection.RequestLengthDiskThreshold = 512
      ' </Snippet12>

      ' <Snippet13>
      ' Get the RequestPriority property value.
      'Response.Write("RequestPriority: " & _
        'configSection.RequestPriority & "<br>")

      ' Set the RequestPriority property value to critical.
      'configSection.RequestPriority = HttpRequestPriority.Critical
      ' </Snippet13>

      ' <Snippet14>
      ' Get the Enable property value.
      Response.Write("Enable: " & _
        configSection.Enable & "<br>")

      ' Set the Enable property value to true.
      configSection.Enable = True
      ' </Snippet14>

      ' <Snippet15>
      ' Get the UseFullyQualifiedRedirectUrl property value.
      Response.Write("UseFullyQualifiedRedirectUrl: " & _
        configSection.UseFullyQualifiedRedirectUrl & "<br>")

      ' Set the UseFullyQualifiedRedirectUrl property value set to true.
      configSection.UseFullyQualifiedRedirectUrl = True
      ' </Snippet15>

      ' <Snippet16>
      ' Get the AppRequestQueueLimit property value.
      Response.Write("AppRequestQueueLimit: " & _
        configSection.AppRequestQueueLimit & "<br>")

      ' Set the AppRequestQueueLimit property value to 4500.
      configSection.AppRequestQueueLimit = 4500
      ' </Snippet16>

      ' <Snippet17>
      ' Get the EnableVersionHeader property value.
      Response.Write("EnableVersionHeader: " & _
        configSection.EnableVersionHeader & "<br>")

      ' Set the EnableVersionHeader property value to false
      configSection.EnableVersionHeader = False
      ' </Snippet17>

      ' <Snippet18>
      ' Get the WaitChangeNotification property value.
      Response.Write("WaitChangeNotification: " & _
        configSection.WaitChangeNotification & "<br>")

      ' Set the WaitChangeNotification property value to 10 seconds.
      configSection.WaitChangeNotification = 10
      ' </Snippet18>

      ' <Snippet19>
      ' Get the MaxRequestLength property value.
      Response.Write("MaxRequestLength: " & _
        configSection.MaxRequestLength & "<br>")

      ' Set the MaxRequestLength property value to 2048 kilobytes.
      configSection.MaxRequestLength = 2048
      ' </Snippet19>

      ' <Snippet20>
      ' Get the EnableHeaderChecking property value.
      Response.Write("EnableHeaderChecking: " & _
        configSection.EnableHeaderChecking & "<br>")

      ' Set the EnableHeaderChecking property value to true.
      configSection.EnableHeaderChecking = True
      ' </Snippet20>
    Catch ex As Exception
      ' Unknown error.
      HttpContext.Current.Response.Write("Error: " & ex.ToString())
    End Try

  End Sub
End Class
' </Snippet1>