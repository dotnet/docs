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