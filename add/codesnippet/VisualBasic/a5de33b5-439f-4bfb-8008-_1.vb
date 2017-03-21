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