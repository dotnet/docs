' <Snippet1>
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Configuration
Imports System.Web
Imports System.Web.Configuration

Namespace Samples.Aspnet.SystemWebConfiguration
  Class UsingTrustSection
    Public Shared Sub Main()
      Try
        ' Set the path of the config file.
        Dim configPath As String = ""

        ' Get the Web application configuration object.
        Dim config As System.Configuration.Configuration = _
        System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(configPath)

        ' Get the section related object.
        Dim configSection As System.Web.Configuration.TrustSection = _
        CType(config.GetSection("system.web/trust"), _
        System.Web.Configuration.TrustSection)

        ' Display title and info.
        Console.WriteLine("ASP.NET Configuration Info")
        Console.WriteLine()

        ' Display Config details.
        Console.WriteLine("File Path: {0}", config.FilePath)
        Console.WriteLine("Section Path: {0}", configSection.SectionInformation.Name)

        ' <Snippet2>
        ' Display Level property.
        Console.WriteLine("Level: {0}", configSection.Level)
        ' </Snippet2>

        ' Set Level property.
        configSection.Level = "High"

        ' <Snippet3>
        ' Display OriginUrl property.
        Console.WriteLine("Origin Url: {0}", configSection.OriginUrl)
        ' </Snippet3>

        ' Set OriginUrl property.
        configSection.OriginUrl = ""

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