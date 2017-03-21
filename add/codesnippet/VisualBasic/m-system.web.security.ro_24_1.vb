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