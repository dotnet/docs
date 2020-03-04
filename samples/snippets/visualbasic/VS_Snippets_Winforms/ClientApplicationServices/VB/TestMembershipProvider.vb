Imports System.Web.Security

'<snippet501>
Public Class TestMembershipProvider
    Inherits MembershipProvider
    '</snippet501>

    Public Overrides Property ApplicationName() As String
        Get

        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Public Overrides Function ChangePassword(ByVal username As String, ByVal oldPassword As String, ByVal newPassword As String) As Boolean

    End Function

    Public Overrides Function ChangePasswordQuestionAndAnswer(ByVal username As String, ByVal password As String, ByVal newPasswordQuestion As String, ByVal newPasswordAnswer As String) As Boolean

    End Function

    Public Overrides Function CreateUser(ByVal username As String, ByVal password As String, ByVal email As String, ByVal passwordQuestion As String, ByVal passwordAnswer As String, ByVal isApproved As Boolean, ByVal providerUserKey As Object, ByRef status As System.Web.Security.MembershipCreateStatus) As System.Web.Security.MembershipUser

    End Function

    Public Overrides Function DeleteUser(ByVal username As String, ByVal deleteAllRelatedData As Boolean) As Boolean

    End Function

    Public Overrides ReadOnly Property EnablePasswordReset() As Boolean
        Get

        End Get
    End Property

    Public Overrides ReadOnly Property EnablePasswordRetrieval() As Boolean
        Get

        End Get
    End Property

    Public Overrides Function FindUsersByEmail(ByVal emailToMatch As String, ByVal pageIndex As Integer, ByVal pageSize As Integer, ByRef totalRecords As Integer) As System.Web.Security.MembershipUserCollection

    End Function

    Public Overrides Function FindUsersByName(ByVal usernameToMatch As String, ByVal pageIndex As Integer, ByVal pageSize As Integer, ByRef totalRecords As Integer) As System.Web.Security.MembershipUserCollection

    End Function

    Public Overrides Function GetAllUsers(ByVal pageIndex As Integer, ByVal pageSize As Integer, ByRef totalRecords As Integer) As System.Web.Security.MembershipUserCollection

    End Function

    Public Overrides Function GetNumberOfUsersOnline() As Integer

    End Function

    Public Overrides Function GetPassword(ByVal username As String, ByVal answer As String) As String

    End Function

    Public Overloads Overrides Function GetUser(ByVal providerUserKey As Object, ByVal userIsOnline As Boolean) As System.Web.Security.MembershipUser

    End Function

    Public Overloads Overrides Function GetUser(ByVal username As String, ByVal userIsOnline As Boolean) As System.Web.Security.MembershipUser

    End Function

    Public Overrides Function GetUserNameByEmail(ByVal email As String) As String

    End Function

    Public Overrides ReadOnly Property MaxInvalidPasswordAttempts() As Integer
        Get

        End Get
    End Property

    Public Overrides ReadOnly Property MinRequiredNonAlphanumericCharacters() As Integer
        Get

        End Get
    End Property

    Public Overrides ReadOnly Property MinRequiredPasswordLength() As Integer
        Get

        End Get
    End Property

    Public Overrides ReadOnly Property PasswordAttemptWindow() As Integer
        Get

        End Get
    End Property

    Public Overrides ReadOnly Property PasswordFormat() As System.Web.Security.MembershipPasswordFormat
        Get

        End Get
    End Property

    Public Overrides ReadOnly Property PasswordStrengthRegularExpression() As String
        Get

        End Get
    End Property

    Public Overrides ReadOnly Property RequiresQuestionAndAnswer() As Boolean
        Get

        End Get
    End Property

    Public Overrides ReadOnly Property RequiresUniqueEmail() As Boolean
        Get

        End Get
    End Property

    Public Overrides Function ResetPassword(ByVal username As String, ByVal answer As String) As String

    End Function

    Public Overrides Function UnlockUser(ByVal userName As String) As Boolean

    End Function

    Public Overrides Sub UpdateUser(ByVal user As System.Web.Security.MembershipUser)

    End Sub

    '<snippet502>
    Private users As System.Collections.Hashtable = Nothing
    Friend Shared ManagerUserName As String = _
        "Manager".ToLowerInvariant()
    Friend Shared EmployeeUserName As String = _
        "Employee".ToLowerInvariant()

    Public Overrides Sub Initialize(ByVal name As String, _
        ByVal config As  _
        System.Collections.Specialized.NameValueCollection)

        users = New System.Collections.Hashtable()
        users.Add(ManagerUserName, ManagerUserName)
        users.Add(EmployeeUserName, EmployeeUserName)

        MyBase.Initialize(name, config)

    End Sub

    Public Overrides Function ValidateUser(ByVal username As String, _
        ByVal password As String) As Boolean

        If users.ContainsKey(username.ToLowerInvariant()) Then
            Return password.Equals(CStr(users(username)))
        End If

        Return False

    End Function
    '</snippet502>

End Class
