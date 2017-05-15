Imports System.Web.Security
Imports System.Web.ClientServices
Imports System.Web.ClientServices.Providers
Imports System.Windows.Forms

Public Class Misc

    '<snippet110>
    Public Class Login
        Implements IClientFormsAuthenticationCredentialsProvider
        '</snippet110>

        Public Function GetCredentials() As ClientFormsAuthenticationCredentials _
            Implements IClientFormsAuthenticationCredentialsProvider.GetCredentials
            Return New ClientFormsAuthenticationCredentials(Nothing, Nothing, False)
        End Function
    End Class

    Public Sub ValidateWithFixedStrings()

        '<snippet300>
        If Not Membership.ValidateUser("manager", "manager!") Then

            MessageBox.Show("Unable to authenticate.", "Not logged in", _
                MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()

        End If
        '</snippet300>            

    End Sub

    '<snippet301>
    Private Sub SetAuthenticationServiceLocation()
        CType(System.Web.Security.Membership.Provider,  _
            ClientFormsAuthenticationMembershipProvider).ServiceUri = _
            "http://localhost:55555/AppServices/Authentication_JSON_AppService.axd"
    End Sub
    '</snippet301>

    '<snippet302>
    Private Sub SetRolesServiceLocation()
        CType(System.Web.Security.Roles.Provider,  _
            ClientRoleProvider).ServiceUri = _
            "http://localhost:55555/AppServices/Role_JSON_AppService.axd"
    End Sub
    '</snippet302>

    '<snippet303>
    Private Sub SetWebSettingsServiceLocation()
        ClientSettingsProvider.ServiceUri = _
            "http://localhost:55555/AppServices/Profile_JSON_AppService.axd"
    End Sub
    '</snippet303>

    '<snippet304>
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
    '</snippet304>

    Public Property Text() As String
        Get
            Return String.Empty
        End Get
        Set(ByVal value As String)
            Throw New NotImplementedException
        End Set
    End Property

    '<snippet305>
    Private WithEvents formsMembershipProvider As  _
        ClientFormsAuthenticationMembershipProvider = _
        System.Web.Security.Membership.Provider

    Private appName As String = "ClientAppServicesDemo"

    Private Sub Form1_UserValidated(ByVal sender As Object, _
        ByVal e As UserValidatedEventArgs) _
        Handles formsMembershipProvider.UserValidated

        ' Set the form's title bar to the application name and the user name.
        Me.Text = String.Format("{0} ({1})", appName, e.UserName)

    End Sub
    '</snippet305>

    '<snippet306>
    Private Function ValidateUsingCredentialsProvider() As Boolean

        Dim isAuthorized As Boolean = False

        Try

            Dim authProvider As ClientFormsAuthenticationMembershipProvider = _
                CType(System.Web.Security.Membership.Provider,  _
                ClientFormsAuthenticationMembershipProvider)

            ' Call ValidateUser with empty strings in order to display the 
            ' login dialog box configured as a credentials provider.
            isAuthorized = authProvider.ValidateUser(String.Empty, String.Empty)

        Catch ex As System.Net.WebException

            MessageBox.Show("Unable to access the authentication service.", _
                "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End Try

        If Not isAuthorized Then

            MessageBox.Show("Unable to authenticate.", "Not logged in", _
                MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()

        End If

        Return isAuthorized

    End Function
    '</snippet306>

    Private usernameTextBox As TextBox
    Private passwordTextBox As TextBox
    Private rememberMeCheckBox As CheckBox

    '<snippet307>
    Private Function ValidateUsingLoginControls() As Boolean

        Dim isAuthorized As Boolean = False

        Try

            Dim authProvider As ClientFormsAuthenticationMembershipProvider = _
                CType(System.Web.Security.Membership.Provider,  _
                ClientFormsAuthenticationMembershipProvider)

            ' Call ValidateUser with credentials retrieved from login controls.
            isAuthorized = authProvider.ValidateUser(usernameTextBox.Text, _
                passwordTextBox.Text, rememberMeCheckBox.Checked)

        Catch ex As System.Net.WebException

            MessageBox.Show("Unable to access the authentication service.", _
                "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End Try

        If Not isAuthorized Then

            MessageBox.Show("Unable to authenticate.", "Not logged in", _
                MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()

        End If

        Return isAuthorized

    End Function
    '</snippet307>

    '<snippet308>
    Private Function ValidateUsingServiceUri(ByVal serviceUri As String) As Boolean

        Dim isAuthorized As Boolean = False

        Try

            ' Call the Shared overload of ValidateUser. Specify credentials 
            ' retrieved from login controls and the service location.
            isAuthorized = _
                ClientFormsAuthenticationMembershipProvider.ValidateUser( _
                usernameTextBox.Text, passwordTextBox.Text, serviceUri)

        Catch ex As System.Net.WebException

            MessageBox.Show("Unable to access the authentication service.", _
                "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End Try

        If Not isAuthorized Then

            MessageBox.Show("Unable to authenticate.", "Not logged in", _
                MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()

        End If

        Return isAuthorized

    End Function
    '</snippet308>

    '<snippet309>
    Private Function ValidateUsingWindowsAuthentication() As Boolean

        Dim authProvider As ClientWindowsAuthenticationMembershipProvider = _
            CType(System.Web.Security.Membership.Provider,  _
            ClientWindowsAuthenticationMembershipProvider)

        ' Call ValidateUser and pass Nothing for the parameters.
        ' This call always returns true.
        Return authProvider.ValidateUser(Nothing, Nothing)

    End Function
    '</snippet309>

    '<snippet310>
    Private Sub LogoutUsingWindowsAuthentication()

        Dim authProvider As ClientWindowsAuthenticationMembershipProvider = _
            CType(System.Web.Security.Membership.Provider,  _
            ClientWindowsAuthenticationMembershipProvider)

        authProvider.Logout()

    End Sub
    '</snippet310>

    '<snippet311>
    Private Sub LogoutUsingFormsAuthentication()

        Dim authProvider As ClientFormsAuthenticationMembershipProvider = _
            CType(System.Web.Security.Membership.Provider,  _
            ClientFormsAuthenticationMembershipProvider)

        authProvider.Logout()

    End Sub
    '</snippet311>

    '<snippet312>
    Private Sub SaveSettings()

        Dim identity As System.Security.Principal.IIdentity = _
            System.Threading.Thread.CurrentPrincipal.Identity

        ' Return if the user is not authenticated.
        If identity Is Nothing OrElse Not identity.IsAuthenticated Then Return

        ' Return if the authentication type is not "ClientForms". This indicates
        ' that the user is not authenticated for client application services.
        If Not identity.AuthenticationType.Equals("ClientForms") Then Return

        Try

            My.Settings.Save()

        Catch ex As System.Net.WebException

            MessageBox.Show("Unable to access the Web settings service. " & _
                "Settings were not saved on the remote service.", _
                "Not logged in", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End Try

    End Sub
    '</snippet312>

    Private managerOnlyButton As Button

    '<snippet313>
    Private Sub DisplayButtonForManagerRole()

        Try

            Dim rolePrincipal As ClientRolePrincipal = TryCast( _
                System.Threading.Thread.CurrentPrincipal, ClientRolePrincipal)

            If rolePrincipal IsNot Nothing And _
                rolePrincipal.IsInRole("manager") Then

                managerOnlyButton.Visible = True

            End If

        Catch ex As System.Net.WebException

            MessageBox.Show("Unable to access the role service.", _
                "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End Try

    End Sub
    '</snippet313>

    '<snippet314>
    Private Sub ResetRolesCache()
        CType(System.Web.Security.Roles.Provider, ClientRoleProvider).ResetCache()
    End Sub
    '</snippet314>

    Private WithEvents workOfflineCheckBox As CheckBox

    '<snippet315>
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

            Catch ex As System.Net.WebException

                MessageBox.Show( _
                    "Unable to access the authentication service. " & _
                    Environment.NewLine + "Staying in offline mode.", _
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                workOfflineCheckBox.Checked = True

            End Try

        End If
    End Sub
    '</snippet315>

    Private Sub DisplayButtonForManagerRolePlain()

        '<snippet316>
        If System.Threading.Thread.CurrentPrincipal.IsInRole("manager") Then

            managerOnlyButton.Visible = True

        End If
        '</snippet316>

    End Sub

    Private Sub ValidateUserPlain()

        '<snippet317>
        If Not System.Web.Security.Membership.ValidateUser( _
            String.Empty, String.Empty) Then

            MessageBox.Show("Unable to authenticate.", "Not logged in", _
                MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()

        End If
        '</snippet317>

        '<snippet318>
        If Not System.Web.Security.Membership.ValidateUser( _
            usernameTextBox.Text, passwordTextBox.Text) Then

            MessageBox.Show("Unable to authenticate.", "Not logged in", _
                    MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()

        End If
        '</snippet318>            

        '<snippet319>
        System.Web.Security.Membership.ValidateUser( _
            String.Empty, String.Empty)
        '</snippet319>

    End Sub

    Private WithEvents checkBox1 As CheckBox

    '<snippet320>
    Private Sub checkBox1_CheckedChanged( _
        ByVal sender As Object, ByVal e As EventArgs) _
        Handles checkBox1.CheckedChanged

        ConnectivityStatus.IsOffline = checkBox1.Checked

    End Sub
    '</snippet320>

    Private Sub PerformManagerTask()

    End Sub

    '<snippet321>
    Private Sub AttemptManagerTask()

        Dim identity As System.Security.Principal.IIdentity = _
            System.Threading.Thread.CurrentPrincipal.Identity

        ' Return if the authentication type is not "ClientForms". 
        ' This indicates that the user is logged out.
        If Not identity.AuthenticationType.Equals("ClientForms") Then Return

        Try

            Dim provider As ClientRoleProvider = _
                CType(System.Web.Security.Roles.Provider, ClientRoleProvider)
            Dim userName As String = identity.Name

            ' Determine whether the user login has expired by attempting
            ' to retrieve roles from the service. Call the ResetCache method
            ' to ensure that the roles are retrieved from the service. If no 
            ' roles are returned, then the login has expired. This assumes 
            ' that every valid user has been assigned to one or more roles.
            provider.ResetCache()
            Dim roles As String() = provider.GetRolesForUser(userName)
            If roles.Length = 0 Then

                MessageBox.Show( _
                    "Your login has expired. Please log in again to access " & _
                    "the roles service.", "Attempting to access user roles...")

                ' Call ValidateUser with empty strings in order to 
                ' display the login dialog box configured as a 
                ' credentials provider.
                If Not System.Web.Security.Membership.ValidateUser( _
                    String.Empty, String.Empty) Then

                    MessageBox.Show("Unable to authenticate. " & _
                        "Cannot retrieve user roles.", "Not logged in", _
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return

                End If

            End If

            If provider.IsUserInRole(userName, "manager") Then
                PerformManagerTask()
            End If

        Catch ex As System.Net.WebException

            MessageBox.Show( _
                "Unable to access the remote service. " & _
                "Cannot retrieve user roles.", "Warning", _
                MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End Try

    End Sub
    '</snippet321>

    Dim webSettingsTestTextBox As TextBox
    Dim myLabel As Label

    Private Sub SimpleWebSettings()

        '<snippet322>
        webSettingsTestTextBox.Text = My.Settings.WebSettingsTestText
        '</snippet322>

        '<snippet323>
        My.Settings.MySetting = "test"
        myLabel.Text = My.Settings.MySetting
        '</snippet323>

        '<snippet324>
        My.Settings.Save()
        '</snippet324>

    End Sub



End Class