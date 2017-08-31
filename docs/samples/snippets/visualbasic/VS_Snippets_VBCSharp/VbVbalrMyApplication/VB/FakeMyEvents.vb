Namespace My
    'Use the editor window dropdowns in the Application pane of the Project Designer to handle MyApplication Events
    '
    'Startup: Raised when the application starts, before the startup form is created.
    'Shutdown: Raised after all application forms are closed.  This event is not raised if the application is terminating abnormally.
    'UnhandledException: Raised if the application encounters an unhandled exception.
    'StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    'NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.

    Partial Friend Class MyApplication
        '<snippet51>
        Protected Overrides Function OnInitialize( 
            ByVal commandLineArgs As System.Collections.
                ObjectModel.ReadOnlyCollection(Of String) 
        ) As Boolean
            ' Set the display time to 5000 milliseconds (5 seconds). 
            Me.MinimumSplashScreenDisplayTime = 5000
            Return MyBase.OnInitialize(commandLineArgs)
        End Function
        '</snippet51>

        '<snippet9>
        Private Sub MyApplication_NetworkAvailabilityChanged( 
            ByVal sender As Object, 
            ByVal e As Microsoft.VisualBasic.Devices.NetworkAvailableEventArgs 
        ) Handles Me.NetworkAvailabilityChanged
            My.Forms.Form1.SetConnectionStatus(e.IsNetworkAvailable)
        End Sub
        '</snippet9>

        '<snippet13>
        Private Sub MyApplication_Shutdown( 
            ByVal sender As Object, 
            ByVal e As System.EventArgs 
        ) Handles Me.Shutdown
            My.Application.Log.WriteEntry("Application Shut Down.")
        End Sub
        '</snippet13>

        '<snippet14>
        Private Sub MyApplication_Startup( 
            ByVal sender As Object, 
            ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs 
        ) Handles Me.Startup
            ' Get the splash screen.
            Dim splash As SplashScreen1 = CType(My.Application.SplashScreen, SplashScreen1)
            ' Display current status information.
            splash.Status = "Current user: " & My.User.Name
        End Sub
        '</snippet14>

        '  Code to waste time
        '          Dim t As Date = Now.AddSeconds(5)
        '          While t > Now
        '          End While

        '<snippet15>
        Private Sub MyApplication_StartupNextInstance( 
            ByVal sender As Object, 
            ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupNextInstanceEventArgs 
        ) Handles Me.StartupNextInstance
            Dim inputArgument As String = "/input="
            Dim inputName As String = ""

            For Each s As String In e.CommandLine
                If s.ToLower.StartsWith(inputArgument) Then
                    inputName = s.Remove(0, inputArgument.Length)
                End If
            Next

            If inputName = "" Then
                MsgBox("No input name")
            Else
                MsgBox("Input name: " & inputName)
            End If
        End Sub
        '</snippet15>

        '<snippet17>
        Private Sub MyApplication_UnhandledException( 
            ByVal sender As Object, 
            ByVal e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs 
        ) Handles Me.UnhandledException

            My.Application.Log.WriteException(e.Exception, 
                TraceEventType.Critical, 
                "Unhandled Exception.")
        End Sub
        '</snippet17>
    End Class

End Namespace

Class FakeMyApp : Inherits Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase
    '<snippet40>
    '<snippet41>
    Private Sub MyApplication_Startup( 
        ByVal sender As Object, 
        ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs 
    ) Handles Me.Startup
        '</snippet41>
        '<snippet43>
        For Each s As String In My.Application.CommandLineArgs
            If s.ToLower = "/batch" Then
                ' Stop the start form from loading.
                e.Cancel = True
            End If
        Next
        '</snippet43>
        '<snippet44>
        If e.Cancel Then
            ' Call the main routine for windowless operation.
            Dim c As New BatchApplication
            c.Main()
        End If
        '</snippet44>
        '<snippet42>
    End Sub
    '</snippet42>
    Class BatchApplication
        Sub Main()
            ' Insert code to run without a graphical user interface.
        End Sub
    End Class
    '</snippet40>

End Class