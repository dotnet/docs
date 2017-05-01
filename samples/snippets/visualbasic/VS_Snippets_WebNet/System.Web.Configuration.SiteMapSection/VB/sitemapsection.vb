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
        Dim configSection As System.Web.Configuration.SiteMapSection = _
         CType(config.GetSection("system.web/siteMap"), _
         System.Web.Configuration.SiteMapSection)

        ' Display title and info.
        Console.WriteLine("ASP.NET Configuration Info")
        Console.WriteLine()

        ' Display Config details.
        Console.WriteLine("File Path: {0}", config.FilePath)
        Console.WriteLine("Section Path: {0}", configSection.SectionInformation.Name)

        ' <Snippet2>
        ' Display Default Provider.
        Console.WriteLine("Default Provider: {0}", _
         configSection.DefaultProvider)
        ' </Snippet2>

        ' Set Default Provider.
        configSection.DefaultProvider = "SiteMapProviderName"

        ' <Snippet3>
        ' Display Enabled value.
        Console.WriteLine("Enabled: {0}", configSection.Enabled)
        ' </Snippet3>

        ' Set Enabled value.
        configSection.Enabled = True

        ' Display the number of Providers
        Console.WriteLine("Providers Collection Count: {0}", _
         configSection.Providers.Count)

        ' <Snippet4>
        ' Display elements of the Providers collection property.
        For Each providerItem As ProviderSettings In configSection.Providers()
          Console.WriteLine()
          Console.WriteLine("Provider Details -")
          Console.WriteLine("Name: {0}", providerItem.Name)
          Console.WriteLine("Type: {0}", providerItem.Type)
        Next
        ' </Snippet4>

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