' <Snippet1>
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Configuration
Imports System.Web
Imports System.Web.Configuration

Namespace Samples.Aspnet.SystemWebConfiguration
  Class UsingSiteMapSection
    Public Shared Sub Main()
      Try
        ' Set the path of the config file.
        Dim configPath As String = ""

        ' Get the Web application configuration object.
        Dim config As System.Configuration.Configuration = _
         System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(configPath)

        ' Get the section related object.
        Dim configSection As System.Web.Configuration.HostingEnvironmentSection = _
         CType(config.GetSection("system.web/hostingEnvironment"), System.Web.Configuration.HostingEnvironmentSection)

        ' Display title and info.
        Console.WriteLine("ASP.NET Configuration Info")
        Console.WriteLine()

        ' Display Config details.
        Console.WriteLine("File Path: {0}", config.FilePath)
        Console.WriteLine("Section Path: {0}", configSection.SectionInformation.Name)

        ' <Snippet2>
        ' Display the IdleTimout property
        Console.WriteLine("Idle Timeout: {0}", configSection.IdleTimeout)
        ' </Snippet2>

        ' Set the IdleTimout property
        configSection.IdleTimeout = TimeSpan.FromMinutes(40)

        ' <Snippet3>
        ' Display the ShutdownTimeout property
        Console.WriteLine("Shutdown Timeout: {0}", configSection.ShutdownTimeout)
        ' </Snippet3>

        ' Set the ShutdownTimeout property
        configSection.ShutdownTimeout = TimeSpan.FromSeconds(60)

        ' Update if not locked.
        If Not configSection.SectionInformation.IsLocked Then
          config.Save()
          Console.WriteLine("** Configuration updated.")
        Else
          Console.WriteLine("** Could not update, section is locked.")
        End If

      Catch e As Exception
        ' Unknown error.
        Console.WriteLine(e.ToString())
      End Try

      ' Display and wait
      Console.ReadLine()
    End Sub
  End Class
End Namespace

' </Snippet1>