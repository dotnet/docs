Imports System.Web.Security

'<snippet601>
Public Class TestRoleProvider
    Inherits RoleProvider
    '</snippet601>

    Public Overrides Sub AddUsersToRoles(ByVal usernames() As String, ByVal roleNames() As String)

    End Sub

    Public Overrides Property ApplicationName() As String
        Get

        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Public Overrides Sub CreateRole(ByVal roleName As String)

    End Sub

    Public Overrides Function DeleteRole(ByVal roleName As String, ByVal throwOnPopulatedRole As Boolean) As Boolean

    End Function

    Public Overrides Function FindUsersInRole(ByVal roleName As String, ByVal usernameToMatch As String) As String()

    End Function

    Public Overrides Function GetAllRoles() As String()

    End Function

    Public Overrides Function GetUsersInRole(ByVal roleName As String) As String()

    End Function

    Public Overrides Sub RemoveUsersFromRoles(ByVal usernames() As String, ByVal roleNames() As String)

    End Sub

    Public Overrides Function RoleExists(ByVal roleName As String) As Boolean

    End Function

    '<snippet602>
    Friend Shared ManagerRoleName As String = _
        "Manager".ToLowerInvariant()
    Friend Shared EmployeeRoleName As String = _
        "Employee".ToLowerInvariant()

    Public Overrides Function IsUserInRole(ByVal username As String, _
        ByVal roleName As String) As Boolean

        Dim roles As String() = GetRolesForUser(username)

        For Each role As String In roles
            If String.Compare(role, roleName, True) = 0 Then
                Return True
            End If
        Next

        Return False

    End Function

    Public Overrides Function GetRolesForUser( _
        ByVal username As String) As String()

        If String.Compare(username, _
            TestMembershipProvider.ManagerUserName, True) = 0 Then
            Return New String() {ManagerRoleName}
        ElseIf String.Compare(username, _
            TestMembershipProvider.EmployeeUserName, True) = 0 Then
            Return New String() {EmployeeRoleName}
        Else
            Return New String() {}
        End If

    End Function
    '</snippet602>

End Class
