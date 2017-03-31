Imports System.Deployment.Application
Imports System.ComponentModel

<System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
Class Form1
    Inherits Form

    Private Sub UpdateAppButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles UpdateAppButton.Click
        UpdateApplication()
    End Sub 'UpdateAppButton_Click

    '<SNIPPET1>
    Private sizeOfUpdate As Long = 0

    Dim WithEvents ADUpdateAsync As ApplicationDeployment

    Private Sub UpdateApplication()
        If (ApplicationDeployment.IsNetworkDeployed) Then
            ADUpdateAsync = ApplicationDeployment.CurrentDeployment

            ADUpdateAsync.CheckForUpdateAsync()
        End If
    End Sub

    Private Sub ADUpdateAsync_CheckForUpdateProgressChanged(ByVal sender As Object, ByVal e As DeploymentProgressChangedEventArgs) Handles ADUpdateAsync.CheckForUpdateProgressChanged
        DownloadStatus.Text = [String].Format("{0:D}K of {1:D}K downloaded.", e.BytesCompleted / 1024, e.BytesTotal / 1024)
    End Sub


    Private Sub ADUpdateAsync_CheckForUpdateCompleted(ByVal sender As Object, ByVal e As CheckForUpdateCompletedEventArgs) Handles ADUpdateAsync.CheckForUpdateCompleted
        If (e.Error IsNot Nothing) Then
            MessageBox.Show(("ERROR: Could not retrieve new version of the application. Reason: " + ControlChars.Lf + e.Error.Message + ControlChars.Lf + "Please report this error to the system administrator."))
            Return
        Else
            If (e.Cancelled = True) Then
                MessageBox.Show("The update was cancelled.")
            End If
        End If

        ' Ask the user if they would like to update the application now.
        If (e.UpdateAvailable) Then
            sizeOfUpdate = e.UpdateSizeBytes

            If (Not e.IsUpdateRequired) Then
                Dim dr As DialogResult = MessageBox.Show("An update is available. Would you like to update the application now?", "Update Available", MessageBoxButtons.OKCancel)
                If (System.Windows.Forms.DialogResult.OK = dr) Then
                    BeginUpdate()
                End If
            Else
                MessageBox.Show("A mandatory update is available for your application. We will install the update now, after which we will save all of your in-progress data and restart your application.")
                BeginUpdate()
            End If
        End If
    End Sub

    Private Sub BeginUpdate()
        ADUpdateAsync = ApplicationDeployment.CurrentDeployment
        ADUpdateAsync.UpdateAsync()
    End Sub


    Private Sub ADUpdateAsync_UpdateProgressChanged(ByVal sender As Object, ByVal e As DeploymentProgressChangedEventArgs) Handles ADUpdateAsync.UpdateProgressChanged
        Dim progressText As String = String.Format("{0:D}K out of {1:D}K downloaded - {2:D}% complete", e.BytesCompleted / 1024, e.BytesTotal / 1024, e.ProgressPercentage)
        DownloadStatus.Text = progressText
    End Sub


    Private Sub ADUpdateAsync_UpdateCompleted(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs) Handles ADUpdateAsync.UpdateCompleted
        If (e.Cancelled) Then
            MessageBox.Show("The update of the application's latest version was cancelled.")
            Exit Sub
        Else
            If (e.Error IsNot Nothing) Then
                MessageBox.Show("ERROR: Could not install the latest version of the application. Reason: " + ControlChars.Lf + e.Error.Message + ControlChars.Lf + "Please report this error to the system administrator.")
                Exit Sub
            End If
        End If

        Dim dr As DialogResult = MessageBox.Show("The application has been updated. Restart? (If you do not restart now, the new version will not take effect until after you quit and launch the application again.)", "Restart Application", MessageBoxButtons.OKCancel)
        If (dr = System.Windows.Forms.DialogResult.OK) Then
            Application.Restart()
        End If
    End Sub
    '</SNIPPET1>

    '<SNIPPET3>
    Private Function CheckForUpdateDue() As Boolean
        Dim isUpdateDue As Boolean = False

        If (ApplicationDeployment.IsNetworkDeployed) Then
            Dim AD As ApplicationDeployment = ApplicationDeployment.CurrentDeployment
            Dim updateInterval As TimeSpan = DateTime.Now - AD.TimeOfLastUpdateCheck
            If (updateInterval.Days > 3) Then
                isUpdateDue = True
            End If
        End If

        CheckForUpdateDue = isUpdateDue
    End Function
    '</SNIPPET3>

    '<SNIPPET4>
    Public Function IsNewVersionAvailable() As Boolean
        Dim isRestartRequired As Boolean = False

        If (ApplicationDeployment.IsNetworkDeployed) Then
            Dim AD As ApplicationDeployment = ApplicationDeployment.CurrentDeployment
            If (AD.UpdatedVersion > AD.CurrentVersion) Then
                isRestartRequired = True
            End If
        End If

        IsNewVersionAvailable = isRestartRequired
    End Function
    '</SNIPPET4>

    '<SNIPPET5>
    Private Sub InstallUpdateSync()
        If (ApplicationDeployment.IsNetworkDeployed) Then
            Dim updateAvailable As Boolean = False
            Dim AD As ApplicationDeployment = ApplicationDeployment.CurrentDeployment

            Try
                updateAvailable = AD.CheckForUpdate()
            Catch dde As DeploymentDownloadException
                ' This exception occurs if a network error or disk error occurs
                ' when downloading the deployment.
                MessageBox.Show("The application cannot check for the existence of a new version at this time. " & ControlChars.Lf & ControlChars.Lf & "Please check your network connection, or try again later. Message: " & dde.Message)
                Exit Sub
            Catch ide As InvalidDeploymentException
                MessageBox.Show("The application cannot check for an update. The ClickOnce deployment is corrupt. Please redeploy the application and try again. Message: " & ide.Message)
                Exit Sub
            Catch ioe As InvalidOperationException
                MessageBox.Show("The application cannot check for an update. This most likely happened because the application is already updating. Message: " & ioe.Message)
                Exit Sub
            End Try

            If (updateAvailable) Then
                Try
                    AD.Update()
                    MessageBox.Show("The application has been upgraded, and will now restart.")
                    Application.Restart()
                Catch dde As DeploymentDownloadException
                    MessageBox.Show("Cannot install the latest version of the application. " + ControlChars.Lf + ControlChars.Lf + "Please check your network connection, or try again later.")
                End Try
            End If
        End If
    End Sub
    '</SNIPPET5>

    '<SNIPPET6>
    Private Sub InstallUpdateSyncWithInfo()
        Dim info As UpdateCheckInfo = Nothing

        If (ApplicationDeployment.IsNetworkDeployed) Then
            Dim AD As ApplicationDeployment = ApplicationDeployment.CurrentDeployment

            Try
                info = AD.CheckForDetailedUpdate()
            Catch dde As DeploymentDownloadException
                MessageBox.Show("The new version of the application cannot be downloaded at this time. " + ControlChars.Lf & ControlChars.Lf & "Please check your network connection, or try again later. Error: " + dde.Message)
                Return
            Catch ioe As InvalidOperationException
                MessageBox.Show("This application cannot be updated. It is likely not a ClickOnce application. Error: " & ioe.Message)
                Return
            End Try

            If (info.UpdateAvailable) Then
                Dim doUpdate As Boolean = True

                If (Not info.IsUpdateRequired) Then
                    Dim dr As DialogResult = MessageBox.Show("An update is available. Would you like to update the application now?", "Update Available", MessageBoxButtons.OKCancel)
                    If (Not System.Windows.Forms.DialogResult.OK = dr) Then
                        doUpdate = False
                    End If
                Else
                    ' Display a message that the app MUST reboot. Display the minimum required version.
                    MessageBox.Show("This application has detected a mandatory update from your current " & _
                        "version to version " & info.MinimumRequiredVersion.ToString() & _
                        ". The application will now install the update and restart.", _
                        "Update Available", MessageBoxButtons.OK, _
                        MessageBoxIcon.Information)
                End If

                If (doUpdate) Then
                    Try
                        AD.Update()
                        MessageBox.Show("The application has been upgraded, and will now restart.")
                        Application.Restart()
                    Catch dde As DeploymentDownloadException
                        MessageBox.Show("Cannot install the latest version of the application. " & ControlChars.Lf & ControlChars.Lf & "Please check your network connection, or try again later.")
                        Return
                    End Try
                End If
            End If
            End If
    End Sub
    '</SNIPPET6>

    '<SNIPPET7>
    Dim WithEvents ADLaunchAppUpdate As ApplicationDeployment

    Public Sub LaunchAppUpdate()
        If (ApplicationDeployment.IsNetworkDeployed) Then
            ADLaunchAppUpdate = ApplicationDeployment.CurrentDeployment
        End If
    End Sub


    Private Sub ADLaunchAppUpdate_UpdateCompleted(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs) Handles ADLaunchAppUpdate.UpdateCompleted
        If Not (e.Error Is Nothing) Then
            MessageBox.Show("Could not install application update. Please try again later,  or contact a system administrator.", "Application Update Error")
            Exit Sub
        Else
            If (e.Cancelled) Then
                MessageBox.Show("The application update has been cancelled.", "Application Update Cancelled")
                Exit Sub
            End If
        End If

        ' Process successful update.
        Dim dr As DialogResult = MessageBox.Show("The application has been updated. Restart?", "Restart Application", MessageBoxButtons.OKCancel)
        If (System.Windows.Forms.DialogResult.OK = dr) Then
            Application.Restart()
        End If
    End Sub
    '</SNIPPET7>

    '<SNIPPET8>
    Dim WithEvents ADDownloadHelpFiles As ApplicationDeployment

    Private Sub DownloadHelpFiles(ByVal GroupName As String)
        If (ApplicationDeployment.IsNetworkDeployed) Then
            ADDownloadHelpFiles = ApplicationDeployment.CurrentDeployment

            If ADDownloadHelpFiles.IsFirstRun Then
                Try
                    If Not ADDownloadHelpFiles.IsFileGroupDownloaded(GroupName) Then
                        ADDownloadHelpFiles.DownloadFileGroupAsync(GroupName)
                    End If
                Catch ioe As InvalidOperationException
                    MessageBox.Show("This application is not a ClickOnce application.")
                    Return
                End Try
            End If
        End If
    End Sub

    Private Sub ADDownloadHelpFiles_DownloadFileGroupProgressChanged(ByVal sender As Object, ByVal e As DeploymentProgressChangedEventArgs) Handles ADDownloadHelpFiles.DownloadFileGroupProgressChanged
        DownloadStatus.Text = String.Format("Downloading file group {0}; {1:D}K of {2:D}K completed.", e.Group, e.BytesCompleted / 1024, e.BytesTotal / 1024)
    End Sub

    Private Sub ADDownloadHelpFiles_DownloadFileGroupCompleted(ByVal sender As Object, ByVal e As DownloadFileGroupCompletedEventArgs) Handles ADDownloadHelpFiles.DownloadFileGroupCompleted
        DownloadStatus.Text = String.Format("Download of file group {0} complete.", e.Group)
    End Sub
    '</SNIPPET8>

    '<SNIPPET9>
    Private Sub DownloadFileGroupSync(ByVal fileGroup As String)
        If (ApplicationDeployment.IsNetworkDeployed) Then
            Dim deployment As ApplicationDeployment = ApplicationDeployment.CurrentDeployment

            If (deployment.IsFirstRun) Then
                Try
                    If (deployment.IsFileGroupDownloaded(fileGroup)) Then
                        deployment.DownloadFileGroup(fileGroup)
                    End If
                Catch ioe As InvalidOperationException
                    MessageBox.Show("This application is not a ClickOnce application. Error: " & ioe.Message)
                    Exit Sub
                End Try

                DownloadStatus.Text = String.Format("Download of file group {0} complete.", fileGroup)
            End If
        End If
    End Sub
    '</SNIPPET9>

    '<SNIPPET10>
    Dim WithEvents ADCheckForUpdateAsyncMin As ApplicationDeployment

    Private Sub CheckForUpdateAsyncMin()
        If (ApplicationDeployment.IsNetworkDeployed) Then
            ADCheckForUpdateAsyncMin = ApplicationDeployment.CurrentDeployment

            ADCheckForUpdateAsyncMin.CheckForUpdate()
        End If
    End Sub


    Private Sub ADCheckForUpdateAsyncMin_CheckForUpdateCompleted(ByVal sender As Object, ByVal e As CheckForUpdateCompletedEventArgs) Handles ADCheckForUpdateAsyncMin.CheckForUpdateCompleted
        If Not (e.Error Is Nothing) Then
            MessageBox.Show("Could not install application update. Please try again later,  or contact a system administrator.", "Application Update Error")
            Return
        Else
            If (e.Cancelled) Then
                MessageBox.Show("The application update has been cancelled.", "Application Update Cancelled")
                Return
            End If
        End If

        ADCheckForUpdateAsyncMin = ApplicationDeployment.CurrentDeployment
        If (e.MinimumRequiredVersion > ADCheckForUpdateAsyncMin.CurrentVersion) Then
            ' Launch an install of the minimum required version. 
            ADCheckForUpdateAsyncMin.UpdateAsync()
        End If
    End Sub


    Private Sub ADCheckForUpdateAsyncMin_UpdateCompleted(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs) Handles ADCheckForUpdateAsyncMin.UpdateCompleted
        ' Alert user that update is complete.
        If Not (e.Error Is Nothing) Then
            MessageBox.Show("Could not install application update. We will try and upgrade the application later.", "Application Update Error")
            Return
        Else
            If (e.Cancelled) Then
                MessageBox.Show("The application update has been cancelled.", "Application Update Cancelled")
                Return
            End If
        End If

        MessageBox.Show("The update was successful. Your application will now be restarted.", "Restart Application")
        Application.Restart()
    End Sub
    '</SNIPPET10>

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class