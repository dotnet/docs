Public Class Form1

    Private Sub installButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles installButton.Click
        InstallApplication(Me.deployManifestTextBox.Text)
    End Sub

    '<SNIPPET1>
    '<SNIPPET2>
    Dim WithEvents iphm As InPlaceHostingManager = Nothing

    Public Sub InstallApplication(ByVal deployManifestUriStr As String)
        Try
            Dim deploymentUri As New Uri(deployManifestUriStr)
            iphm = New InPlaceHostingManager(deploymentUri, False)
            MessageBox.Show("Created the object.")
        Catch uriEx As UriFormatException
            MessageBox.Show("Cannot install the application: " & _
                            "The deployment manifest URL supplied is not a valid URL." & _
                            "Error: " & uriEx.Message)
            Return
        Catch platformEx As PlatformNotSupportedException
            MessageBox.Show("Cannot install the application: " & _
                            "This program requires Windows XP or higher. " & _
                            "Error: " & platformEx.Message)
            Return
        Catch argumentEx As ArgumentException
            MessageBox.Show("Cannot install the application: " & _
                            "The deployment manifest URL supplied is not a valid URL." & _
                            "Error: " & argumentEx.Message)
            Return
        End Try

        iphm.GetManifestAsync()
    End Sub
    '</SNIPPET2>

    '<SNIPPET3>
    Private Sub iphm_GetManifestCompleted(ByVal sender As Object, ByVal e As GetManifestCompletedEventArgs) Handles iphm.GetManifestCompleted
        ' Check for an error.
        If (e.Error IsNot Nothing) Then
            ' Cancel download and install.
            MessageBox.Show("Could not download manifest. Error: " & e.Error.Message)
            Return
        End If

        ' Dim isFullTrust As Boolean = CheckForFullTrust(e.ApplicationManifest)

        ' Verify this application can be installed.
        Try
            ' the true parameter allows InPlaceHostingManager
            ' to grant the permissions requested in the application manifest. 
            iphm.AssertApplicationRequirements(True)
        Catch ex As Exception
            MessageBox.Show("An error occurred while verifying the application. " & _
                            "Error text: " & ex.Message)
            Return
        End Try

        ' Use the information from GetManifestCompleted() to confirm 
        ' that the user wants to proceed.
        Dim appInfo As String = "Application Name: " & e.ProductName
        appInfo &= ControlChars.Lf & "Version: " & e.Version.ToString()
        appInfo &= ControlChars.Lf & "Support/Help Requests: "

        If Not (e.SupportUri Is Nothing) Then
            appInfo &= e.SupportUri.ToString()
        Else
            appInfo &= "N/A"
        End If

        appInfo &= ControlChars.Lf & ControlChars.Lf & _
            "Confirmed that this application can run with its requested permissions."

        ' If isFullTrust Then
        '    appInfo &= ControlChars.Lf & ControlChars.Lf & _
        '        "This application requires full trust in order to run."
        ' End If

        appInfo &= ControlChars.Lf & ControlChars.Lf & "Proceed with installation?"

        Dim dr As DialogResult = MessageBox.Show(appInfo, _
            "Confirm Application Install", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If dr <> System.Windows.Forms.DialogResult.OK Then
            Return
        End If

        ' Download the deployment manifest. 
        ' Usually, this shouldn't throw an exception unless 
        ' AssertApplicationRequirements() failed, or you did not call that method
        ' before calling this one.
        Try
            iphm.DownloadApplicationAsync()
        Catch downloadEx As Exception
            MessageBox.Show("Cannot initiate download of application. Error: " & downloadEx.Message)
            Return
        End Try
    End Sub

#If 0 Then
    '<SNIPPET5>
    Private Function CheckForFullTrust(ByVal appManifest As XmlReader) As Boolean
        Dim isFullTrust As Boolean = False

        If (appManifest Is Nothing) Then
            Throw New ArgumentNullException("appManifest cannot be null.")
        End If

        Dim xaUnrestricted As XAttribute
        xaUnrestricted = XDocument.Load(appManifest) _
            .Element("{urn:schemas-microsoft-com:asm.v1}assembly") _
            .Element("{urn:schemas-microsoft-com:asm.v2}trustInfo") _
            .Element("{urn:schemas-microsoft-com:asm.v2}security") _
            .Element("{urn:schemas-microsoft-com:asm.v2}applicationRequestMinimum") _
            .Element("{urn:schemas-microsoft-com:asm.v2}PermissionSet") _
            .Attribute("Unrestricted")  ' Attributes never have a namespace


        If xaUnrestricted Then
            If xaUnrestricted.Value = "true" Then
                Return True
            End If
        End If

        Return False
    End Function
    '</SNIPPET5>
#End If
    '</SNIPPET3>

    '<SNIPPET6>
    Private Sub iphm_DownloadProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs) Handles iphm.DownloadProgressChanged
        ' you can show percentage of task completed using e.ProgressPercentage
    End Sub
    '</SNIPPET6>

    '<SNIPPET7>
    Private Sub iphm_DownloadApplicationCompleted(ByVal sender As Object, ByVal e As DownloadApplicationCompletedEventArgs) Handles iphm.DownloadApplicationCompleted
        ' Check for an error.
        If (e.Error IsNot Nothing) Then
            ' Cancel download and install.
            MessageBox.Show("Could not download and install application. Error: " & e.Error.Message)
            Return
        End If

        ' Inform the user that their application is ready for use. 
        MessageBox.Show("Application installed! You may now run it from the Start menu.")
    End Sub
    '</SNIPPET7>
    '</SNIPPET1>

End Class
