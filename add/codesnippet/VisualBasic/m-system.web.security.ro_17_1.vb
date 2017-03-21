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