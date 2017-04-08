' <Snippet1>
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Text
Imports System.Configuration
Imports System.Web
Imports System.Web.Configuration

Namespace Samples.Aspnet.ConfigurationSample
  Class UsingContextInformation
    Public Shared Sub Main()
      Try
        ' Set the path of the config file.
        Dim configPath As String = ""

        ' Get the Web application configuration object.
        Dim config As Configuration = _
            WebConfigurationManager.OpenWebConfiguration(configPath)

        ' Get the section related object.
        Dim configSection As _
          System.Web.Configuration.HealthMonitoringSection = _
          CType(config.GetSection("system.web/healthMonitoring"), _
          System.Web.Configuration.HealthMonitoringSection)

        ' Display title and info.
        Console.WriteLine("ASP.NET Configuration Info")
        Console.WriteLine()

        ' Display Config details.
        Console.WriteLine("File Path: {0}", _
          config.FilePath)
        Console.WriteLine("Section Path: {0}", _
          configSection.SectionInformation.Name)

        ' <Snippet2>
        ' IsMachineLevel property.
        Console.WriteLine("IsMachineLevel: {0}", _
          config.EvaluationContext.IsMachineLevel)
        ' </Snippet2>

        ' <Snippet3>
        ' Create an object based on HostingContext.
        Dim myWC As WebContext = _
          config.EvaluationContext.HostingContext
        ' Use the WebContext object to determine
        ' the ApplicationLevel.
        Console.WriteLine("ApplicationLevel: {0}", _
          myWC.ApplicationLevel)
        ' </Snippet3>

      Catch e As System.Exception
        ' Error.
        Console.WriteLine(e.ToString())
      End Try
      ' Display and wait.
      Console.ReadLine()
    End Sub
  End Class
End Namespace
' </Snippet1>
