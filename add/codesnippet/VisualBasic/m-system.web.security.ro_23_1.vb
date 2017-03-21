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