Imports System.Web.Security
Imports System.Security.Permissions
Imports System.Configuration.Provider
Imports System.Collections.Specialized
Imports System
Imports System.Data
Imports System.Data.Odbc
Imports System.Configuration
Imports System.Diagnostics
Imports System.Web
Imports System.Globalization




Namespace Samples.AspNet.Roles
  <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal), _
  AspNetHostingPermission(SecurityAction.InheritanceDemand, Level:=AspNetHostingPermissionLevel.Minimal)> _
  Public NotInheritable Class OdbcRoleProvider
    Inherits RoleProvider

    '
    ' Global OdbcConnection, generated password length, generic exception message, event log info.
    '

    Private conn As OdbcConnection

    Private pConnectionStringSettings As ConnectionStringSettings
    Private connectionString As String



    '
    ' System.Configuration.Provider.ProviderBase.Initialize Method
    '

    Public Overrides Sub Initialize(name As String, config As NameValueCollection) 
      '
      ' Initialize values from web.config.
      '

      If config Is Nothing Then _
        Throw New ArgumentNullException("config")

      If name Is Nothing OrElse name.Length = 0 Then _
        name = "OdbcRoleProvider"

      If String.IsNullOrEmpty(config("description")) Then
        config.Remove("description")
        config.Add("description", "Sample ODBC Role provider")
      End If

      ' Initialize the abstract base class.
      MyBase.Initialize(name, config)


      If config("applicationName") Is Nothing OrElse config("applicationName").Trim() = "" Then
        pApplicationName = System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath
      Else
        pApplicationName = config("applicationName")
      End If


      '
      ' Initialize OdbcConnection.
      '

      pConnectionStringSettings = ConfigurationManager.ConnectionStrings(config("connectionStringName"))

      If pConnectionStringSettings Is Nothing OrElse ConnectionString.Trim() = "" Then
        Throw New ProviderException("Connection string cannot be blank.")
      End If

      connectionString = pConnectionStringSettings.ConnectionString
    End Sub



    '
    ' System.Web.Security.RoleProvider properties.
    '
    

'<Snippet1>
Private pApplicationName As String

Public Overrides Property ApplicationName As String 
  Get
    Return pApplicationName
  End Get
  Set
    pApplicationName = value
  End Set
End Property
'</Snippet1>

    '
    ' System.Web.Security.RoleProvider methods.
    '

    '
    ' RoleProvider.AddUsersToRoles
    '

'<Snippet2>
Public Overrides Sub AddUsersToRoles(usernames As String(), rolenames As String()) 

  For Each rolename As String In rolenames
    If rolename Is Nothing OrElse rolename = "" Then _
      Throw New ProviderException("Role name cannot be empty or null.")
    If Not RoleExists(rolename) Then _
      Throw New ProviderException("Role name not found.")
  Next

  For Each username As String in usernames
    If username Is Nothing OrElse username = "" Then _
      Throw New ProviderException("User name cannot be empty or null.")
    If username.Contains(",") Then _
      Throw New ArgumentException("User names cannot contain commas.")

    For Each rolename As String In rolenames
      If IsUserInRole(username, rolename) Then
        Throw New ProviderException("User is already in role.")
      End If
    Next
  Next


  Dim conn As OdbcConnection = New OdbcConnection(connectionString)
            Dim cmd As OdbcCommand = New OdbcCommand("INSERT INTO UsersInRoles " & _
                                           " (Username, Rolename, ApplicationName) " & _
                                           " Values(?, ?, ?)", conn)

  Dim userParm As OdbcParameter = cmd.Parameters.Add("@Username", OdbcType.VarChar, 255)
  Dim roleParm As OdbcParameter = cmd.Parameters.Add("@Rolename", OdbcType.VarChar, 255)
  cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName

  Try
    conn.Open()

    For Each username As String In usernames
      For Each rolename As String In rolenames
        userParm.Value = username
        roleParm.Value = rolename
        cmd.ExecuteNonQuery()
      Next
    Next
  Catch e As OdbcException
    ' Handle exception.
  Finally
    conn.Close()      
  End Try
End Sub
'</Snippet2>


    '
    ' RoleProvider.CreateRole
    '

'<Snippet3>
Public Overrides Sub CreateRole(rolename As String) 
  If rolename Is Nothing OrElse rolename = "" Then _
    Throw New ProviderException("Role name cannot be empty or null.")
  If rolename.Contains(",") Then _
    Throw New ArgumentException("Role names cannot contain commas.")
  If RoleExists(rolename) Then _
    Throw New ProviderException("Role name already exists.")
  If rolename.Length > 255 Then _
    Throw New ProviderException("Role name cannot exceed 255 characters.")

  Dim conn As OdbcConnection = New OdbcConnection(connectionString)
            Dim cmd As OdbcCommand = New OdbcCommand("INSERT INTO Roles " & _
                                                     " (Rolename, ApplicationName) " & _
                                                     " Values(?, ?)", conn)

            cmd.Parameters.Add("@Rolename", OdbcType.VarChar, 255).Value = rolename
            cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName

            Try
                conn.Open()

                cmd.ExecuteNonQuery()
            Catch e As OdbcException
                ' Handle exception.
            Finally
                conn.Close()
            End Try
        End Sub
        '</Snippet3>


        '
        ' RoleProvider.DeleteRole
        '

        '<Snippet4>
        Public Overrides Function DeleteRole(ByVal rolename As String, ByVal throwOnPopulatedRole As Boolean) As Boolean
            If Not RoleExists(rolename) Then
                Throw New ProviderException("Role does not exist.")
            End If

            If throwOnPopulatedRole AndAlso GetUsersInRole(rolename).Length > 0 Then
                Throw New ProviderException("Cannot delete a populated role.")
            End If

            Dim conn As OdbcConnection = New OdbcConnection(connectionString)
            Dim cmd As OdbcCommand = New OdbcCommand("DELETE FROM Roles " & _
                                                     " WHERE Rolename = ? AND ApplicationName = ?", conn)

            cmd.Parameters.Add("@Rolename", OdbcType.VarChar, 255).Value = rolename
            cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName

            Dim cmd2 As OdbcCommand = New OdbcCommand("DELETE FROM UsersInRoles " & _
                                                      " WHERE Rolename = ? AND ApplicationName = ?", conn)

            cmd2.Parameters.Add("@Rolename", OdbcType.VarChar, 255).Value = rolename
            cmd2.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName

            Try
                conn.Open()

                cmd2.ExecuteNonQuery()
                cmd.ExecuteNonQuery()
            Catch e As OdbcException
                ' Handle exception.

                Return False
            Finally
                conn.Close()
            End Try

            Return True
        End Function
        '</Snippet4>


        '
        ' RoleProvider.GetAllRoles
        '

        '<Snippet5>
        Public Overrides Function GetAllRoles() As String()
            Dim tmpRoleNames As String = ""

            Dim conn As OdbcConnection = New OdbcConnection(connectionString)
            Dim cmd As OdbcCommand = New OdbcCommand("SELECT Rolename FROM Roles " & _
                                                     " WHERE ApplicationName = ?", conn)

            cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName

            Dim reader As OdbcDataReader = Nothing

            Try
                conn.Open()

                reader = cmd.ExecuteReader()

                Do While reader.Read()
                    tmpRoleNames &= reader.GetString(0) & ","
                Loop
            Catch e As OdbcException
                ' Handle exception.
            Finally
                If Not reader Is Nothing Then reader.Close()
                conn.Close()
            End Try

            If tmpRoleNames.Length > 0 Then
                ' Remove trailing comma.
                tmpRoleNames = tmpRoleNames.Substring(0, tmpRoleNames.Length - 1)
                Return tmpRoleNames.Split(CChar(","))
            End If

            Return New String() {}
        End Function
        '</Snippet5>


        '
        ' RoleProvider.GetRolesForUser
        '

        '<Snippet6>
        Public Overrides Function GetRolesForUser(ByVal username As String) As String()
            If username Is Nothing OrElse username = "" Then _
              Throw New ProviderException("User name cannot be empty or null.")

            Dim tmpRoleNames As String = ""

            Dim conn As OdbcConnection = New OdbcConnection(connectionString)
            Dim cmd As OdbcCommand = New OdbcCommand("SELECT Rolename FROM UsersInRoles " & _
                                                     " WHERE Username = ? AND ApplicationName = ?", conn)

            cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username
            cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName

            Dim reader As OdbcDataReader = Nothing

            Try
                conn.Open()

                reader = cmd.ExecuteReader()

                Do While reader.Read()
                    tmpRoleNames &= reader.GetString(0) & ","
                Loop
            Catch e As OdbcException
                ' Handle exception.
            Finally
                If Not reader Is Nothing Then reader.Close()
                conn.Close()
            End Try

            If tmpRoleNames.Length > 0 Then
                ' Remove trailing comma.
                tmpRoleNames = tmpRoleNames.Substring(0, tmpRoleNames.Length - 1)
                Return tmpRoleNames.Split(CChar(","))
            End If

            Return New String() {}
        End Function
        '</Snippet6>


        '
        ' RoleProvider.GetUsersInRole
        '

        '<Snippet7>
        Public Overrides Function GetUsersInRole(ByVal rolename As String) As String()
            If rolename Is Nothing OrElse rolename = "" Then _
              Throw New ProviderException("Role name cannot be empty or null.")
            If Not RoleExists(rolename) Then _
              Throw New ProviderException("Role does not exist.")

            Dim tmpUserNames As String = ""

            Dim conn As OdbcConnection = New OdbcConnection(connectionString)
            Dim cmd As OdbcCommand = New OdbcCommand("SELECT Username FROM UsersInRoles " & _
                                                     " WHERE Rolename = ? AND ApplicationName = ?", conn)

            cmd.Parameters.Add("@Rolename", OdbcType.VarChar, 255).Value = rolename
            cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName

            Dim reader As OdbcDataReader = Nothing

            Try
                conn.Open()

                reader = cmd.ExecuteReader()

                Do While reader.Read()
                    tmpUserNames &= reader.GetString(0) + ","
                Loop
            Catch e As OdbcException
                ' Handle exception.
            Finally
                If Not reader Is Nothing Then reader.Close()
                conn.Close()
            End Try

            If tmpUserNames.Length > 0 Then
                ' Remove trailing comma.
                tmpUserNames = tmpUserNames.Substring(0, tmpUserNames.Length - 1)
                Return tmpUserNames.Split(CChar(","))
            End If

            Return New String() {}
        End Function
        '</Snippet7>


        '
        ' RoleProvider.IsUserInRole
        '

        '<Snippet8>
        Public Overrides Function IsUserInRole(ByVal username As String, ByVal rolename As String) As Boolean
            If username Is Nothing OrElse username = "" Then _
              Throw New ProviderException("User name cannot be empty or null.")
            If rolename Is Nothing OrElse rolename = "" Then _
              Throw New ProviderException("Role name cannot be empty or null.")

            Dim userIsInRole As Boolean = False

            Dim conn As OdbcConnection = New OdbcConnection(connectionString)
            Dim cmd As OdbcCommand = New OdbcCommand("SELECT COUNT(*) FROM UsersInRoles " & _
                                                     " WHERE Username = ? AND Rolename = ? AND ApplicationName = ?", conn)

            cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username
            cmd.Parameters.Add("@Rolename", OdbcType.VarChar, 255).Value = rolename
            cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName

            Try
                conn.Open()

                Dim numRecs As Integer = CType(cmd.ExecuteScalar(), Integer)

                If numRecs > 0 Then
                    userIsInRole = True
                End If
            Catch e As OdbcException
                ' Handle exception.
            Finally
                conn.Close()
            End Try

            Return userIsInRole
        End Function
        '</Snippet8>


        '
        ' RoleProvider.RemoveUsersFromRoles
        '

        '<Snippet9>
        Public Overrides Sub RemoveUsersFromRoles(ByVal usernames As String(), ByVal rolenames As String())

            For Each rolename As String In rolenames
                If rolename Is Nothing OrElse rolename = "" Then _
                  Throw New ProviderException("Role name cannot be empty or null.")
                If Not RoleExists(rolename) Then _
                  Throw New ProviderException("Role name not found.")
            Next

            For Each username As String In usernames
                If username Is Nothing OrElse username = "" Then _
                  Throw New ProviderException("User name cannot be empty or null.")

                For Each rolename As String In rolenames
                    If Not IsUserInRole(username, rolename) Then
                        Throw New ProviderException("User is not in role.")
                    End If
                Next
            Next

            Dim conn As OdbcConnection = New OdbcConnection(connectionString)
            Dim cmd As OdbcCommand = New OdbcCommand("DELETE FROM UsersInRoles " & _
                                                     " WHERE Username = ? AND Rolename = ? AND ApplicationName = ?", conn)

            Dim userParm As OdbcParameter = cmd.Parameters.Add("@Username", OdbcType.VarChar, 255)
            Dim roleParm As OdbcParameter = cmd.Parameters.Add("@Rolename", OdbcType.VarChar, 255)
            cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName

            Try
                conn.Open()

                For Each username As String In usernames
                    For Each rolename As String In rolenames
                        userParm.Value = username
                        roleParm.Value = rolename
                        cmd.ExecuteNonQuery()
                    Next
                Next
            Catch e As OdbcException
                ' Handle exception.
            Finally
                conn.Close()
            End Try
        End Sub
        '</Snippet9>


        '
        ' RoleProvider.RoleExists
        '

        '<Snippet10>
        Public Overrides Function RoleExists(ByVal rolename As String) As Boolean

            If rolename Is Nothing OrElse rolename = "" Then _
              Throw New ProviderException("Role name cannot be empty or null.")

            Dim exists As Boolean = False

            Dim conn As OdbcConnection = New OdbcConnection(connectionString)
            Dim cmd As OdbcCommand = New OdbcCommand("SELECT COUNT(*) FROM Roles " & _
                                                     " WHERE Rolename = ? AND ApplicationName = ?", conn)

            cmd.Parameters.Add("@Rolename", OdbcType.VarChar, 255).Value = rolename
            cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName

            Try
                conn.Open()

                Dim numRecs As Integer = CType(cmd.ExecuteScalar(), Integer)

                If numRecs > 0 Then
                    exists = True
                End If
            Catch e As OdbcException
                ' Handle exception.
            Finally
                conn.Close()
            End Try

            Return exists
        End Function
        '</Snippet10>


        '
        ' RoleProvider.FindUsersInRole
        '

        '<Snippet11>
        Public Overrides Function FindUsersInRole(ByVal rolename As String, ByVal userNameToMatch As String) As String()
            Dim conn As OdbcConnection = New OdbcConnection(connectionString)
            Dim cmd As OdbcCommand = New OdbcCommand("SELECT Username FROM UsersInRoles  " & _
                                                     " WHERE Username LIKE ? AND RoleName = ? AND ApplicationName = ?", conn)
            cmd.Parameters.Add("@UsernameSearch", OdbcType.VarChar, 255).Value = usernameToMatch
            cmd.Parameters.Add("@RoleName", OdbcType.VarChar, 255).Value = rolename
            cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = pApplicationName

            Dim tmpUserNames As String = ""
            Dim reader As OdbcDataReader = Nothing

            Try
                conn.Open()

                reader = cmd.ExecuteReader()

                Do While reader.Read()
                    tmpUserNames &= reader.GetString(0) & ","
                Loop
            Catch e As OdbcException
                ' Handle exception.
            Finally
                If Not reader Is Nothing Then reader.Close()
                conn.Close()
            End Try

            If tmpUserNames.Length > 0 Then
                ' Remove trailing comma.
                tmpUserNames = tmpUserNames.Substring(0, tmpUserNames.Length - 1)
                Return tmpUserNames.Split(CChar(","))
            End If

            Return Nothing
        End Function
'</Snippet11>

  End Class
End Namespace