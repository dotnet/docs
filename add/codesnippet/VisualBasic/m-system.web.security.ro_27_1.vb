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