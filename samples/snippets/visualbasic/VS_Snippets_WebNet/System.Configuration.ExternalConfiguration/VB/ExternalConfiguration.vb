'<Snippet1>
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Configuration
Imports System.Web.Configuration

Namespace Samples.AspNet


    Public Class ExternalConfiguration


        ' Instantiate the ExternalConfiguration type.
        Public Sub New()
            ' Access the root Web.config file.
            Dim config As System.Configuration.Configuration = _
            WebConfigurationManager.OpenWebConfiguration("/configTarget")

            ' Get the custom MyAppSettings section.
            Dim appSettings As AppSettingsSection = _
            CType(config.GetSection("MyAppSettings"), AppSettingsSection)

            ' Perform the first update.
            UpdateAppSettings()

        End Sub 'New



        ' Update the custom MyAppSettings section.
        ' Note , if the section restartOnExternalChanges attribute 
        ' is set to true, every update of the external 
        ' configuration file will cause the application 
        ' to restart.
        Public Sub UpdateAppSettings()

            Dim config As System.Configuration.Configuration = _
            WebConfigurationManager.OpenWebConfiguration("/configTarget")

            Dim appSettings As AppSettingsSection = _
            CType(config.GetSection("MyAppSettings"), AppSettingsSection)

            Dim count As Integer = appSettings.Settings.Count

            appSettings.Settings.Add("key_" + count.ToString(), _
            "value_" + count.ToString())

            config.Save()

        End Sub 'UpdateAppSettngs

    End Class 'ExternalConfiguration 

End Namespace
'</Snippet1>