Public Overrides Function GetAllUsers(pageIndex As Integer, _
                                      pageSize As Integer, _
                                      ByRef totalRecords As Integer) _
                                      As MembershipUserCollection 
  
  Dim conn As OdbcConnection = New OdbcConnection(ConnectionString)
            Dim cmd As OdbcCommand = New OdbcCommand("SELECT Count(*) FROM Users  " & _
                                                     "WHERE ApplicationName = ?", conn)
            cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName

            Dim users As MembershipUserCollection = New MembershipUserCollection()

            Dim reader As OdbcDataReader = Nothing
            totalRecords = 0

            Try
                conn.Open()
                totalRecords = CType(cmd.ExecuteScalar(), Integer)

                If totalRecords <= 0 Then Return users

                cmd.CommandText = "SELECT Username, Email, PasswordQuestion," & _
                                  " Comment, IsApproved, CreationDate, LastLoginDate," & _
                                  " LastActivityDate, LastPasswordChangedDate " & _
                                  " FROM Users  " & _
                                  " WHERE ApplicationName = ? " & _
                                  " ORDER BY Username Asc"

                reader = cmd.ExecuteReader()

                Dim counter As Integer = 0
                Dim startIndex As Integer = pageSize * pageIndex
                Dim endIndex As Integer = startIndex + pageSize - 1

                Do While reader.Read()
                    If counter >= startIndex Then
                        Dim u As MembershipUser = GetUserFromReader(reader)
                        users.Add(u)
                    End If

                    If counter >= endIndex Then cmd.Cancel()

                    counter += 1
                Loop
            Catch e As OdbcException
                ' Handle exception.
            Finally
                If Not reader Is Nothing Then reader.Close()
                conn.Close()
            End Try

  Return users
End Function


'
' GetUserFromReader
' A helper function that takes the current row from the OdbcDataReader
' and populates a MembershipUser object with the values. Called by the 
' MembershipUser.GetUser implementation.
'

Public Function GetUserFromReader(reader As OdbcDataReader) As MembershipUser
  
  Dim providerUserKey As Object = reader.GetValue(0)
  Dim username As String = reader.GetString(1)
  Dim email As String = reader.GetString(2)

  Dim passwordQuestion As String = ""
  If Not reader.GetValue(3) Is DBNull.Value Then _
    passwordQuestion = reader.GetString(3)

  Dim comment As String = ""
  If Not reader.GetValue(4) Is DBNull.Value Then _
    comment = reader.GetString(4)

  Dim isApproved As Boolean = reader.GetBoolean(5)
  Dim isLockedOut As Boolean = reader.GetBoolean(6)
  Dim creationDate As DateTime = reader.GetDateTime(7)

  Dim lastLoginDate As DateTime = New DateTime()
  If Not reader.GetValue(8) Is DBNull.Value Then _
    lastLoginDate = reader.GetDateTime(8)

  Dim lastActivityDate As DateTime = reader.GetDateTime(9)
  Dim lastPasswordChangedDate As DateTime = reader.GetDateTime(10)

  Dim lastLockedOutDate As DateTime = New DateTime()
  If Not reader.GetValue(11) Is DBNull.Value Then _
    lastLockedOutDate = reader.GetDateTime(11)
      
  Dim u As MembershipUser = New MembershipUser(Me.Name, _
                                        username, _
                                        providerUserKey, _
                                        email, _
                                        passwordQuestion, _
                                        comment, _
                                        isApproved, _
                                        isLockedOut, _
                                        creationDate, _
                                        lastLoginDate, _
                                        lastActivityDate, _
                                        lastPasswordChangedDate, _
                                        lastLockedOutDate)

  Return u
End Function