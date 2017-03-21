Imports System
Imports System.Configuration
Imports System.Web
Imports System.Web.Configuration

Namespace Samples.Aspnet.SystemWebConfiguration
  Class UsingWebContext
    Public Shared Sub Main()
      Try
        ' Set the path of the config file.
        Dim configPath As String = "/aspnet"

        ' Get the Web application configuration object.
        Dim config As Configuration = _
         WebConfigurationManager.OpenWebConfiguration(configPath)

        ' Get the context.
        Dim webContext As WebContext = config.EvaluationContext.HostingContext

        ' Display title and info.
        Console.WriteLine("ASP.NET WebContext Info")
        Console.WriteLine()

        ' WebContext - Application Level.
        Console.WriteLine("ApplicationLevel: {0}", _
          webContext.ApplicationLevel.ToString())
        ' WebContext - Application Path.
        Console.WriteLine("ApplicationPath: {0}", _
          webContext.ApplicationPath.ToString())
        ' WebContext - Path.
        Console.WriteLine("Path: {0}", webContext.Path.ToString())
        ' WebContext - Site.
        Console.WriteLine("Site: {0}", webContext.Site.ToString())

      Catch e As Exception
        ' Unknown error.
        Console.WriteLine(e.ToString())
      End Try

      ' Display and wait
      Console.ReadLine()
    End Sub
  End Class
End Namespace
