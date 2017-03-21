Public Overrides Function ChangePassword(username As String, _
                                         oldPwd As String, _
                                         newPwd As String) As Boolean
  
  If Not ValidateUser(username, oldPwd) Then
    Return False
  End If

  Dim args As ValidatePasswordEventArgs = _
    New ValidatePasswordEventArgs(username, newPwd, True)

  OnValidatingPassword(args)
  
  If args.Cancel Then
    If Not args.FailureInformation Is Nothing Then
      Throw args.FailureInformation
    Else
      Throw New MembershipPasswordException("Change password canceled due to New password validation failure.")
    End If
  End If


  Dim conn As OdbcConnection = New OdbcConnection(ConnectionString)
            Dim cmd As OdbcCommand = New OdbcCommand("UPDATE Users " & _
                       " SET Password = ?, LastPasswordChangedDate = ? " & _
                       " WHERE Username = ? AND Password = ? AND ApplicationName = ?", conn)

  cmd.Parameters.Add("@Password", OdbcType.VarChar, 128).Value = EncodePassword(newPwd)
  cmd.Parameters.Add("@LastPasswordChangedDate", OdbcType.DateTime).Value = DateTime.Now
  cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username
  cmd.Parameters.Add("@OldPassword", OdbcType.VarChar, 128).Value = oldPwd
  cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName


  Dim rowsAffected As Integer = 0

  Try
    conn.Open()

    rowsAffected = cmd.ExecuteNonQuery()
  Catch e As OdbcException
    ' Handle exception.
  Finally
    conn.Close()
  End Try

  If rowsAffected > 0 Then Return True

  Return False
End Function