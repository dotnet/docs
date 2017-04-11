'<Snippet1>
Imports System.Web.Security
Imports System.Configuration.Provider
Imports System.Collections.Specialized
Imports System
Imports System.Data
Imports System.Data.Odbc
Imports System.Configuration
Imports System.Diagnostics
Imports System.Web
Imports System.Globalization
Imports Microsoft.VisualBasic

'
'
' This provider works with the following schema for the tables of role data.
' 
' CREATE TABLE Roles
' (
'   Rolename Text (255) NOT NULL,
'   ApplicationName Text (255) NOT NULL,
'     CONSTRAINT PKRoles PRIMARY KEY (Rolename, ApplicationName)
' )
'
' CREATE TABLE UsersInRoles
' (
'   Username Text (255) NOT NULL,
'   Rolename Text (255) NOT NULL,
'   ApplicationName Text (255) NOT NULL,
'     CONSTRAINT PKUsersInRoles PRIMARY KEY (Username, Rolename, ApplicationName)
' )
'
'


Namespace Samples.AspNet.Roles

  Public NotInheritable Class OdbcRoleProvider
    Inherits RoleProvider
  

    '
    ' Global OdbcConnection, generated password length, generic exception message, event log info.
    '

    Private conn As OdbcConnection 

    Private eventSource As String = "OdbcRoleProvider"
    Private eventLog As String = "Application"
    Private exceptionMessage As String = "An exception occurred. Please check the Event Log."

    Private pConnectionStringSettings As ConnectionStringSettings
    Private connectionString As String


    '
    ' If false, exceptions are Thrown to the caller. If true,
    ' exceptions are written to the event log.
    '

    Private pWriteExceptionsToEventLog As Boolean = False

    Public Property WriteExceptionsToEventLog As Boolean
      Get
        Return pWriteExceptionsToEventLog
      End Get
      Set
        pWriteExceptionsToEventLog = value
      End Set
    End Property



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


      If Not config("writeExceptionsToEventLog") Is Nothing Then      
        If config("writeExceptionsToEventLog").ToUpper() = "TRUE" Then
          pWriteExceptionsToEventLog = true
        End If
      End If


      '
      ' Initialize OdbcConnection.
      '

      pConnectionStringSettings = _
        ConfigurationManager.ConnectionStrings(config("connectionStringName"))

      If pConnectionStringSettings Is Nothing OrElse pConnectionStringSettings.ConnectionString.Trim() = "" Then
        Throw New ProviderException("Connection string cannot be blank.")
      End If

      connectionString = pConnectionStringSettings.ConnectionString
    End Sub



    '
    ' System.Web.Security.RoleProvider properties.
    '    

    Private pApplicationName As String

    Public Overrides Property ApplicationName As String
      Get
        Return pApplicationName
      End Get
      Set
        pApplicationName = value
      End Set
    End Property


    '
    ' System.Web.Security.RoleProvider methods.
    '

    '
    ' RoleProvider.AddUsersToRoles
    '

    Public Overrides Sub AddUsersToRoles(usernames As String(), rolenames As String())
    
      For Each rolename As String In rolenames
        If Not RoleExists(rolename) Then
          Throw New ProviderException("Role name not found.")
        End If
      Next

      For Each username As String In usernames      
        If username.Contains(",") Then        
          Throw New ArgumentException("User names cannot contain commas.")
        End If

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

      Dim tran As OdbcTransaction = Nothing

      Try      
        conn.Open()
        tran = conn.BeginTransaction()
        cmd.Transaction = tran

        For Each username As String In usernames
          For Each rolename As String In rolenames
            userParm.Value = username
            roleParm.Value = rolename
            cmd.ExecuteNonQuery()
          Next
        Next

        tran.Commit()
      Catch e As OdbcException
        Try
          tran.Rollback()
        Catch
        End Try


        If WriteExceptionsToEventLog Then        
          WriteToEventLog(e, "AddUsersToRoles")
        Else
          Throw e
        End If
      Finally
        conn.Close()      
      End Try
    End Sub


    '
    ' RoleProvider.CreateRole
    '

    Public Overrides Sub CreateRole(rolename As String)
     
      If rolename.Contains(",") Then
        Throw New ArgumentException("Role names cannot contain commas.")
      End If

      If RoleExists(rolename) Then      
        Throw New ProviderException("Role name already exists.")
      End If

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
                If WriteExceptionsToEventLog Then
                    WriteToEventLog(e, "CreateRole")
                Else
                    Throw e
                End If
            Finally
                conn.Close()
            End Try
        End Sub


        '
        ' RoleProvider.DeleteRole
        '

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

            Dim tran As OdbcTransaction = Nothing

            Try
                conn.Open()
                tran = conn.BeginTransaction()
                cmd.Transaction = tran
                cmd2.Transaction = tran

                cmd2.ExecuteNonQuery()
                cmd.ExecuteNonQuery()

                tran.Commit()
            Catch e As OdbcException
                Try
                    tran.Rollback()
                Catch
                End Try


                If WriteExceptionsToEventLog Then
                    WriteToEventLog(e, "DeleteRole")

                    Return False
                Else
                    Throw e
                End If
            Finally
                conn.Close()
            End Try

            Return True
        End Function


        '
        ' RoleProvider.GetAllRoles
        '

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
                If WriteExceptionsToEventLog Then
                    WriteToEventLog(e, "GetAllRoles")
                Else
                    Throw e
                End If
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


        '
        ' RoleProvider.GetRolesForUser
        '

        Public Overrides Function GetRolesForUser(ByVal username As String) As String()
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
                If WriteExceptionsToEventLog Then
                    WriteToEventLog(e, "GetRolesForUser")
                Else
                    Throw e
                End If
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


        '
        ' RoleProvider.GetUsersInRole
        '

        Public Overrides Function GetUsersInRole(ByVal rolename As String) As String()
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
                    tmpUserNames &= reader.GetString(0) & ","
                Loop
            Catch e As OdbcException
                If WriteExceptionsToEventLog Then
                    WriteToEventLog(e, "GetUsersInRole")
                Else
                    Throw e
                End If
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


        '
        ' RoleProvider.IsUserInRole
        '

        Public Overrides Function IsUserInRole(ByVal username As String, ByVal rolename As String) As Boolean

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
                If WriteExceptionsToEventLog Then
                    WriteToEventLog(e, "IsUserInRole")
                Else
                    Throw e
                End If
            Finally
                conn.Close()
            End Try

            Return userIsInRole
        End Function


        '
        ' RoleProvider.RemoveUsersFromRoles
        '

        Public Overrides Sub RemoveUsersFromRoles(ByVal usernames As String(), ByVal rolenames As String())

            For Each rolename As String In rolenames
                If Not RoleExists(rolename) Then
                    Throw New ProviderException("Role name not found.")
                End If
            Next

            For Each username As String In usernames
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

            Dim tran As OdbcTransaction = Nothing

            Try
                conn.Open()
                tran = conn.BeginTransaction
                cmd.Transaction = tran

                For Each username As String In usernames
                    For Each rolename As String In rolenames
                        userParm.Value = username
                        roleParm.Value = rolename
                        cmd.ExecuteNonQuery()
                    Next
                Next

                tran.Commit()
            Catch e As OdbcException
                Try
                    tran.Rollback()
                Catch
                End Try


                If WriteExceptionsToEventLog Then
                    WriteToEventLog(e, "RemoveUsersFromRoles")
                Else
                    Throw e
                End If
            Finally
                conn.Close()
            End Try
        End Sub


        '
        ' RoleProvider.RoleExists
        '

        Public Overrides Function RoleExists(ByVal rolename As String) As Boolean
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
                If WriteExceptionsToEventLog Then
                    WriteToEventLog(e, "RoleExists")
                Else
                    Throw e
                End If
            Finally
                conn.Close()
            End Try

            Return exists
        End Function

        '
        ' RoleProvider.FindUsersInRole
        '

        Public Overrides Function FindUsersInRole(ByVal rolename As String, ByVal usernameToMatch As String) As String()

            Dim conn As OdbcConnection = New OdbcConnection(connectionString)
            Dim cmd As OdbcCommand = New OdbcCommand("SELECT Username FROM UsersInRoles  " & _
                      "WHERE Username LIKE ? AND RoleName = ? AND ApplicationName = ?", conn)
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
                If WriteExceptionsToEventLog Then
                    WriteToEventLog(e, "FindUsersInRole")
                Else
                    Throw e
                End If
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

    '
    ' WriteToEventLog
    '   A helper function that writes exception detail to the event log. Exceptions
    ' are written to the event log as a security measure to aSub Private database
    ' details from being returned to the browser. If a method does not Return a status
    ' or boolean indicating the action succeeded or failed, a generic exception is also 
    ' Thrown by the caller.
    '

    Private Sub WriteToEventLog(e As OdbcException, action As String)
      Dim log As EventLog = New EventLog()
      log.Source = eventSource
      log.Log = eventLog

      Dim message As String = exceptionMessage & vbCrLf & vbCrLf
      message &= "Action: " & action & vbCrLf & vbCrLf
      message &= "Exception: " & e.ToString()

      log.WriteEnTry(message)
    End Sub

  End Class
End Namespace
'</Snippet1>