'<snippet000>
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
'<snippet001>
Imports System.Net
Imports System.Threading
Imports System.Web.ClientServices
Imports System.Web.ClientServices.Providers
Imports System.Web.Security
'</snippet001>

Public Class Form1
    Inherits Form

    Private webSettingsTestTextBox As TextBox
    Private managerOnlyButton As Button
    Private WithEvents workOfflineCheckBox As CheckBox
    Private WithEvents logoutButton As Button
    Private label1 As Label
    Private appName As String = "ClientAppServicesDemo"

    Public Sub New()
        InitializeComponent()
    End Sub

    '<snippet010>
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) _
        Handles Me.Load

        '<snippet011>
        MessageBox.Show("Welcome to the Client Application Services Demo.", _
            "Welcome!")

        If Not ValidateUsingCredentialsProvider() Then Return
        '</snippet011>

        '<snippet012>
        DisplayButtonForManagerRole()
        '</snippet012>

        '<snippet013>
        BindWebSettingsTestTextBox()
        '</snippet013>

        '<snippet014>
        workOfflineCheckBox.Checked = ConnectivityStatus.IsOffline
        '</snippet014>

    End Sub
    '</snippet010>

    '<snippet020>
    Private Function ValidateUsingCredentialsProvider() As Boolean

        Dim isAuthorized As Boolean = False

        Try

            ' Call ValidateUser with empty strings in order to display the 
            ' login dialog box configured as a credentials provider.
            isAuthorized = Membership.ValidateUser( _
                String.Empty, String.Empty)

        Catch ex As System.Net.WebException

            If DialogResult.OK = MessageBox.Show( _
                "Unable to access the authentication service." & _
                Environment.NewLine & "Attempt login in offline mode?", _
                "Warning", MessageBoxButtons.OKCancel, _
                MessageBoxIcon.Warning) Then

                ConnectivityStatus.IsOffline = True
                isAuthorized = Membership.ValidateUser( _
                    String.Empty, String.Empty)

            End If

        End Try

        If Not isAuthorized Then

            MessageBox.Show("Unable to authenticate.", "Not logged in", _
                MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()

        End If

        Return isAuthorized

    End Function
    '</snippet020>

    '<snippet030>
    Private Sub DisplayButtonForManagerRole()

        Try

            If Thread.CurrentPrincipal.IsInRole("manager") Then

                managerOnlyButton.Visible = True

            End If

        Catch ex As System.Net.WebException

            MessageBox.Show("Unable to access the roles service.", _
                "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End Try

    End Sub
    '</snippet030>

    '<snippet040>
    Private Sub BindWebSettingsTestTextBox()

        Try

            Me.webSettingsTestTextBox.DataBindings.Add("Text", _
                My.Settings, "WebSettingsTestText")

        Catch ex As WebException

            MessageBox.Show("Unable to access the Web settings service.", _
                "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End Try

    End Sub
    '</snippet040>

    '<snippet050>
    Private Sub Form1_FormClosing(ByVal sender As Object, _
        ByVal e As FormClosingEventArgs) Handles Me.FormClosing

        SaveSettings()

    End Sub

    Private Sub SaveSettings()

        ' Return without saving if the authentication type is not
        ' "ClientForms". This indicates that the user is logged out.
        If Not Thread.CurrentPrincipal.Identity.AuthenticationType _
            .Equals("ClientForms") Then Return

        Try

            My.Settings.Save()

        Catch ex As WebException

            If ex.Message.Contains("You must log on to call this method.") Then

                MessageBox.Show( _
                    "Your login has expired. Please log in again to save " & _
                    "your settings.", "Attempting to save settings...")

                Dim isAuthorized As Boolean = False

                Try

                    ' Call ValidateUser with empty strings in order to 
                    ' display the login dialog box configured as a 
                    ' credentials provider.
                    If Not Membership.ValidateUser( _
                        String.Empty, String.Empty) Then

                        MessageBox.Show("Unable to authenticate. " & _
                            "Settings were not saved on the remote service.", _
                            "Not logged in", MessageBoxButtons.OK, _
                            MessageBoxIcon.Error)

                    Else

                        ' Try again.
                        SaveSettings()

                    End If

                Catch ex2 As System.Net.WebException

                    MessageBox.Show( _
                        "Unable to access the authentication service. " & _
                        "Settings were not saved on the remote service.", _
                        "Not logged in", MessageBoxButtons.OK, _
                        MessageBoxIcon.Warning)

                End Try

            Else

                MessageBox.Show("Unable to access the Web settings service. " & _
                    "Settings were not saved on the remote service.", _
                    "Not logged in", MessageBoxButtons.OK, _
                    MessageBoxIcon.Warning)

            End If

        End Try

    End Sub
    '</snippet050>

    '<snippet070>
    Private Sub logoutButton_Click(ByVal sender As Object, _
        ByVal e As EventArgs) Handles logoutButton.Click

        SaveSettings()

        Dim authProvider As ClientFormsAuthenticationMembershipProvider = _
            CType(System.Web.Security.Membership.Provider,  _
            ClientFormsAuthenticationMembershipProvider)

        Try

            authProvider.Logout()

        Catch ex As WebException

            MessageBox.Show("Unable to access the authentication service." & _
                Environment.NewLine & "Logging off locally only.", _
                "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ConnectivityStatus.IsOffline = True
            authProvider.Logout()
            ConnectivityStatus.IsOffline = False

        End Try

        Application.Restart()

    End Sub
    '</snippet070>

    '<snippet080>
    Private Sub workOfflineCheckBox_CheckedChanged( _
        ByVal sender As Object, ByVal e As EventArgs) _
        Handles workOfflineCheckBox.CheckedChanged

        ConnectivityStatus.IsOffline = workOfflineCheckBox.Checked

        If Not ConnectivityStatus.IsOffline Then

            Try

                ' Silently re-validate the user.
                CType(System.Threading.Thread.CurrentPrincipal.Identity,  _
                    ClientFormsIdentity).RevalidateUser()

                ' If any settings have been changed locally, save the new
                ' new values to the Web settings service.
                SaveSettings()

                ' If any settings have not been changed locally, check 
                ' the Web settings service for updates. 
                My.Settings.Reload()

            Catch ex As WebException

                MessageBox.Show( _
                    "Unable to access the authentication service. " & _
                    Environment.NewLine + "Staying in offline mode.", _
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                workOfflineCheckBox.Checked = True

            End Try

        End If

    End Sub
    '</snippet080>

    '<snippet090>
    Private WithEvents settingsProvider As ClientSettingsProvider = My.Settings _
        .Providers("System.Web.ClientServices.Providers.ClientSettingsProvider")

    Private Sub Form1_SettingsSaved(ByVal sender As Object, _
        ByVal e As SettingsSavedEventArgs) _
        Handles settingsProvider.SettingsSaved

        ' If any settings were not saved, display a list of them.
        If e.FailedSettingsList.Count > 0 Then

            Dim failedSettings As String = String.Join( _
                Environment.NewLine, e.FailedSettingsList.ToArray())

            Dim message As String = String.Format("{0}{1}{1}{2}", _
                "The following setting(s) were not saved:", _
                Environment.NewLine, failedSettings)

            MessageBox.Show(message, "Unable to save settings", _
                MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If

    End Sub
    '</snippet090>

    Private Sub InitializeComponent()

        Me.managerOnlyButton = New System.Windows.Forms.Button()
        Me.workOfflineCheckBox = New System.Windows.Forms.CheckBox()
        Me.webSettingsTestTextBox = New System.Windows.Forms.TextBox()
        Me.logoutButton = New System.Windows.Forms.Button()
        Me.label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        ' 
        ' managerOnlyButton
        ' 
        Me.managerOnlyButton.Location = New System.Drawing.Point(11, 51)
        Me.managerOnlyButton.Name = "managerOnlyButton"
        Me.managerOnlyButton.Size = New System.Drawing.Size(124, 50)
        Me.managerOnlyButton.TabIndex = 1
        Me.managerOnlyButton.Text = "&Manager task"
        Me.managerOnlyButton.UseVisualStyleBackColor = True
        Me.managerOnlyButton.Visible = False
        ' 
        ' workOfflineCheckBox
        ' 
        Me.workOfflineCheckBox.AutoSize = True
        Me.workOfflineCheckBox.Location = New System.Drawing.Point(166, 12)
        Me.workOfflineCheckBox.Name = "workOfflineCheckBox"
        Me.workOfflineCheckBox.Size = New System.Drawing.Size(83, 17)
        Me.workOfflineCheckBox.TabIndex = 2
        Me.workOfflineCheckBox.Text = "&Work offline"
        Me.workOfflineCheckBox.UseVisualStyleBackColor = True
        ' 
        ' webSettingsTestTextBox
        ' 
        Me.webSettingsTestTextBox.Location = New System.Drawing.Point(11, 25)
        Me.webSettingsTestTextBox.Name = "webSettingsTestTextBox"
        Me.webSettingsTestTextBox.Size = New System.Drawing.Size(124, 20)
        Me.webSettingsTestTextBox.TabIndex = 0
        ' 
        ' logoutButton
        ' 
        Me.logoutButton.Location = New System.Drawing.Point(152, 51)
        Me.logoutButton.Name = "logoutButton"
        Me.logoutButton.Size = New System.Drawing.Size(124, 50)
        Me.logoutButton.TabIndex = 3
        Me.logoutButton.Text = "&Log out"
        Me.logoutButton.UseVisualStyleBackColor = True
        ' 
        ' label1
        ' 
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(12, 9)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(110, 13)
        Me.label1.TabIndex = 4
        Me.label1.Text = "WebSettingsTestText"
        ' 
        ' Form1
        ' 
        Me.ClientSize = New System.Drawing.Size(286, 111)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.logoutButton)
        Me.Controls.Add(Me.workOfflineCheckBox)
        Me.Controls.Add(Me.webSettingsTestTextBox)
        Me.Controls.Add(Me.managerOnlyButton)
        Me.Name = "Form1"
        Me.Text = "Client Application Services Demo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

End Class
'</snippet000>