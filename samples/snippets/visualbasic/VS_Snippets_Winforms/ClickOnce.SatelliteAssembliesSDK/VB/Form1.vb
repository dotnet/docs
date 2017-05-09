' <SNIPPET1>
Imports System.Deployment.Application
Imports System.Globalization
Imports System.Threading

Public Class Form1
    Shared Sub Main(ByVal args As String())
        Application.EnableVisualStyles()

        Thread.CurrentThread.CurrentUICulture = New CultureInfo("ja-JP")
        GetSatelliteAssemblies(Thread.CurrentThread.CurrentUICulture.ToString())

        Application.Run(New Form1())
    End Sub

    Private Shared Sub GetSatelliteAssemblies(ByVal groupName As String)
        If (ApplicationDeployment.IsNetworkDeployed) Then

            Dim deploy As ApplicationDeployment = ApplicationDeployment.CurrentDeployment

            If (deploy.IsFirstRun) Then
                Try
                    deploy.DownloadFileGroup(groupName)
                Catch de As DeploymentException
                    ' Log error. Do not report error to the user, as there may not be a satellite
                    ' assembly if the user's culture and the application's default culture match.

                End Try
            End If
        End If
    End Sub
End Class
' </SNIPPET1>
