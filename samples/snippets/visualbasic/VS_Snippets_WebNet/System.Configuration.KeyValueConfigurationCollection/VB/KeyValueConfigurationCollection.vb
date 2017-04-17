' <Snippet1>
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Configuration
Imports System.Web
Imports System.Web.Configuration

Namespace Samples.Aspnet.Config
  Class KeyValueConfigCollection
    Public Shared Sub Main()
      Try
        ' Set the path of the config file.
        Dim configPath As String = "/aspnet"

        ' Get the Web application configuration object.
        Dim config As Configuration = _
          WebConfigurationManager.OpenWebConfiguration(configPath)

        ' Get the section related object.
        Dim configSection As System.Configuration.AppSettingsSection = _
        CType(config.GetSection("appSettings"), System.Configuration.AppSettingsSection)

        '      Dim configSection As AppSettingsSection = _
        '       (AppSettingsSection)config.GetSection("appSettings")

        ' Display title and info.
        Console.WriteLine("ASP.NET Configuration Info")
        Console.WriteLine()

        ' Display Config details.
        Console.WriteLine("File Path: {0}", config.FilePath)
        Console.WriteLine("Section Path: {0}", _
          configSection.SectionInformation.Name.ToString())
        Console.WriteLine()

        ' <Snippet2>
        ' Create the KeyValueConfigurationElement.
        Dim myAdminKeyVal As KeyValueConfigurationElement = _
          New KeyValueConfigurationElement _
          ("myAdminTool", "admin.aspx")
        ' </Snippet2>


        ' Determine if the configuration contains
        ' any KeyValueConfigurationElements.
        Dim configSettings As KeyValueConfigurationCollection = _
        config.AppSettings.Settings()

        If configSettings.AllKeys.Length = 0 Then
          ' <Snippet6>
          ' Add KeyValueConfigurationElement to collection.
          config.AppSettings.Settings.Add(myAdminKeyVal)
          ' </Snippet6>

          If Not configSection.SectionInformation.IsLocked Then
            config.Save()
            Console.WriteLine("** Configuration updated.")
          Else
            Console.WriteLine("** Could not update, section is locked.")
          End If
        End If

        ' <Snippet3>
        ' <Snippet4>
        ' Get the KeyValueConfigurationCollection 
        ' from the configuration.
        Dim settings As KeyValueConfigurationCollection = _
        config.AppSettings.Settings()
        ' </Snippet4>

        ' <Snippet5>
        ' Display each KeyValueConfigurationElement.
        Dim keyValueElement As KeyValueConfigurationElement
        For Each keyValueElement In settings
          Console.WriteLine("Key: {0}", keyValueElement.Key)
          Console.WriteLine("Value: {0}", keyValueElement.Value)
          Console.WriteLine()
        Next
        ' </Snippet5>
        ' </Snippet3>

      Catch e As System.ArgumentException
        ' Unknown error.
        Console.WriteLine(e.ToString())
      End Try
      ' Display and wait
      Console.ReadLine()
    End Sub
  End Class
End Namespace
'</Snippet1>