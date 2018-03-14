'<SNIPPET1>
Imports System.Deployment.Application
Imports System.Globalization
Imports System.Threading
'</SNIPPET1>

Namespace My

    ' The following events are availble for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication

        '<SNIPPET2>
        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            Thread.CurrentThread.CurrentUICulture = New CultureInfo("ja-JP")
            GetSatelliteAssemblies(Thread.CurrentThread.CurrentUICulture.ToString())
        End Sub

        Private Shared Sub GetSatelliteAssemblies(ByVal groupName As String)
            If (ApplicationDeployment.IsNetworkDeployed) Then

                Dim deploy As ApplicationDeployment = ApplicationDeployment.CurrentDeployment

                If (deploy.IsFirstRun) Then
                    Try
                        deploy.DownloadFileGroup(groupName)
                    Catch de As DeploymentException
                        ' Log error. Do not report this error to the user, because a satellite
                        ' assembly may not exist if the user's culture and the application's
                        ' default culture match.
                    End Try
                End If
            End If
        End Sub
        '</SNIPPET2>
    End Class

End Namespace