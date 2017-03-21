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