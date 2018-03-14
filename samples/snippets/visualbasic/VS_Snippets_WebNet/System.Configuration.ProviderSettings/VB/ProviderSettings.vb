' <Snippet1>
Imports System
Imports System.Collections
Imports System.Collections.Specialized
Imports System.Text
Imports System.Configuration
Imports System.Security.Permissions


' Shows how to use the ProviderSettings.
Namespace Samples.AspNet


    Public Class UsingProviderSettings


        <PermissionSet( _
           SecurityAction.Demand, Name:="FullTrust")> _
           Private Shared Sub GetProviderSettings()
            ' Get the application configuration file.
            Dim config _
            As System.Configuration.Configuration = _
            ConfigurationManager.OpenExeConfiguration( _
            ConfigurationUserLevel.None)

            Dim pSection As _
            ProtectedConfigurationSection = _
            config.GetSection("configProtectedData")

            Dim providerSettings _
            As ProviderSettingsCollection = _
            pSection.Providers

            Dim pSettings As ProviderSettings
            For Each pSettings In providerSettings

                ' <Snippet2>
                Console.WriteLine( _
                "Provider settings name: {0}", _
                pSettings.Name)

                ' </Snippet2>

                ' <Snippet3>
                Console.WriteLine( _
                "Provider settings type: {0}", _
                pSettings.Type)
                ' </Snippet3>

                ' <Snippet4>
                Dim parameters _
                As NameValueCollection = pSettings.Parameters

                Dim pEnum _
                As IEnumerator = parameters.GetEnumerator()

                Dim i As Integer = 0
                While pEnum.MoveNext()
                    Dim pLength As String = _
                    parameters(i).Length.ToString()
                    Console.WriteLine( _
                    "Provider ssettings: {0} has {1} parameters", _
                    pSettings.Name, pLength)
                End While
            Next pSettings
            ' </Snippet4>

        End Sub 'GetProviderSettings


        Public Shared Sub Main(ByVal args() As String)

            GetProviderSettings()
        End Sub 'Main 
    End Class 'UsingProviderSettings

End Namespace

' </Snippet1>