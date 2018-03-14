'<snippet1>
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Management
Imports System.Configuration
Imports System.Web.Configuration

Namespace SamplesAspNet.Config

    Class GetFullConfig

        Public Shared Sub Main(ByVal args() As String)
            Dim config As Configuration = WebConfigurationManager.OpenWebConfiguration("/MyApp")
            config.SaveAs("c:\MyApp.web.config", ConfigurationSaveMode.Full, True)
        End Sub 'Main 

    End Class 

End Namespace
'</snippet1>