' <Snippet1>
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Configuration
Imports System.Web
Imports System.Web.Configuration

Namespace Samples.Aspnet.SystemWebConfiguration
  Class UsingGlobalizationSection
    Public Shared Sub Main()
      Try
        ' Set the path of the config file.
        Dim configPath As String = ""

        ' Get the Web application configuration object.
        Dim config As System.Configuration.Configuration = _
         WebConfigurationManager.OpenWebConfiguration(configPath)

        ' Get the section related object.
        Dim configSection As System.Web.Configuration.GlobalizationSection = _
         CType(config.GetSection("system.web/globalization"), _
         System.Web.Configuration.GlobalizationSection)

        ' Display title and info.
        Console.WriteLine("ASP.NET Configuration Info")
        Console.WriteLine()

        ' Display Config details.
        Console.WriteLine("File Path: {0}", config.FilePath)
        Console.WriteLine("Section Path: {0}", configSection.SectionInformation.Name)

        ' <Snippet2>
        ' Display Culture property.
        Console.WriteLine("Culture: {0}", _
         configSection.Culture)
        ' </Snippet2>

        ' Set Culture property.
        configSection.Culture = _
         System.Globalization.CultureInfo.CurrentCulture.ToString()

        ' <Snippet3>
        ' Display EnableClientBasedCulture property.
        Console.WriteLine("EnableClientBasedCulture: {0}", _
         configSection.EnableClientBasedCulture)
        ' </Snippet3>

        ' Set EnableClientBasedCulture property.
        configSection.EnableClientBasedCulture = False

        ' <Snippet4>
        ' Display FileEncoding property.
        Console.WriteLine("FileEncoding: {0}", _
         configSection.FileEncoding)
        ' </Snippet4>

        ' Set FileEncoding property.
        configSection.FileEncoding = _
         System.Text.Encoding.UTF8

        ' <Snippet5>
        ' Display RequestEncoding property.
        Console.WriteLine("RequestEncoding: {0}", _
         configSection.RequestEncoding)
        ' </Snippet5>

        ' Set RequestEncoding property.
        configSection.RequestEncoding = _
         System.Text.Encoding.UTF8

        ' <Snippet6>
        ' Display ResponseEncoding property.
        Console.WriteLine("ResponseEncoding: {0}", _
         configSection.ResponseEncoding)
        ' </Snippet6>

        ' Set ResponseEncoding property.
        configSection.ResponseEncoding = _
         System.Text.Encoding.UTF8

        ' <Snippet7>
        ' Display ResponseHeaderEncoding property.
        Console.WriteLine("ResponseHeaderEncoding: {0}", _
         configSection.ResponseHeaderEncoding)
        ' </Snippet7>

        ' Set ResponseHeaderEncoding property.
        configSection.ResponseHeaderEncoding = _
         System.Text.Encoding.UTF8

        ' <Snippet8>
        ' Display UICulture property.
        Console.WriteLine("UICulture: {0}", _
         configSection.UICulture)
        ' </Snippet8>

        ' Set UICulture property.
        configSection.UICulture = _
         System.Globalization.CultureInfo.CurrentUICulture.ToString()

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