' <Snippet1>
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Configuration
Imports System.Web
Imports System.Web.Configuration

Namespace Samples.Aspnet.SystemWebConfiguration
  Class UsingMachineKeySection
    Public Shared Sub Main()
      Try
        ' Set the path of the config file.
        Dim configPath As String = ""

        ' Get the Web application configuration object.
        Dim config As System.Configuration.Configuration = _
         System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(configPath)

        ' Get the section related object.
        Dim configSection As System.Web.Configuration.MachineKeySection = _
         CType(config.GetSection("system.web/machineKey"), _
         System.Web.Configuration.MachineKeySection)

        ' Display title and info.
        Console.WriteLine("ASP.NET Configuration Info")
        Console.WriteLine()

        ' Display Config details.
        Console.WriteLine("File Path: {0}", config.FilePath)
        Console.WriteLine("Section Path: {0}", configSection.SectionInformation.Name)

        ' <Snippet2>
        ' Display ValidationKey property.
        Console.WriteLine("ValidationKey: {0}", _
         configSection.ValidationKey)
        ' </Snippet2>

        ' Set ValidationKey property.
        configSection.ValidationKey = "AutoGenerate,IsolateApps"

        ' <Snippet3>
        ' Display DecryptionKey property.
        Console.WriteLine("DecryptionKey: {0}", configSection.DecryptionKey)
        ' </Snippet3>

        ' Set DecryptionKey property.
        configSection.DecryptionKey = "AutoGenerate,IsolateApps"

        ' <Snippet4>
        ' Display Validation value.
        Console.WriteLine("Validation: {0}", configSection.Validation)
        ' </Snippet4>

        ' <Snippet5>
        ' Set Validation value.
        configSection.Validation = MachineKeyValidation.SHA1
        ' </Snippet5>

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