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