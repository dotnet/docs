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