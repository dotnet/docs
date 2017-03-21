        Public Overrides Function CreateUser(ByVal username As String, _
        ByVal password As String, _
        ByVal email As String, _
        ByVal passwordQuestion As String, _
        ByVal passwordAnswer As String, _
        ByVal isApproved As Boolean, _
        ByVal providerUserKey As Object, _
                 ByRef status As MembershipCreateStatus) As MembershipUser

            Dim Args As ValidatePasswordEventArgs = _
              New ValidatePasswordEventArgs(username, password, True)

            OnValidatingPassword(args)

            If args.Cancel Then
                status = MembershipCreateStatus.InvalidPassword
                Return Nothing
            End If


            If RequiresUniqueEmail AndAlso GetUserNameByEmail(email) <> "" Then
                status = MembershipCreateStatus.DuplicateEmail
                Return Nothing
            End If

            Dim u As MembershipUser = GetUser(username, False)

            If u Is Nothing Then
                Dim createDate As DateTime = DateTime.Now

                If providerUserKey Is Nothing Then
                    providerUserKey = Guid.NewGuid()
                Else
                    If Not TypeOf providerUserKey Is Guid Then
                        status = MembershipCreateStatus.InvalidProviderUserKey
                        Return Nothing
                    End If
                End If

                Dim conn As OdbcConnection = New OdbcConnection(ConnectionString)
                Dim cmd As OdbcCommand = New OdbcCommand("INSERT INTO Users " & _
                      " (PKID, Username, Password, Email, PasswordQuestion, " & _
                      " PasswordAnswer, IsApproved," & _
                      " Comment, CreationDate, LastPasswordChangedDate, LastActivityDate," & _
                      " ApplicationName, IsLockedOut, LastLockedOutDate," & _
                      " FailedPasswordAttemptCount, FailedPasswordAttemptWindowStart, " & _
                      " FailedPasswordAnswerAttemptCount, FailedPasswordAnswerAttemptWindowStart)" & _
                      " Values(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)", conn)

                cmd.Parameters.Add("@PKID", OdbcType.UniqueIdentifier).Value = providerUserKey
                cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username
                cmd.Parameters.Add("@Password", OdbcType.VarChar, 255).Value = EncodePassword(password)
                cmd.Parameters.Add("@Email", OdbcType.VarChar, 128).Value = email
                cmd.Parameters.Add("@PasswordQuestion", OdbcType.VarChar, 255).Value = passwordQuestion
                cmd.Parameters.Add("@PasswordAnswer", OdbcType.VarChar, 255).Value = EncodePassword(passwordAnswer)
                cmd.Parameters.Add("@IsApproved", OdbcType.Bit).Value = isApproved
                cmd.Parameters.Add("@Comment", OdbcType.VarChar, 255).Value = ""
                cmd.Parameters.Add("@CreationDate", OdbcType.DateTime).Value = createDate
                cmd.Parameters.Add("@LastPasswordChangedDate", OdbcType.DateTime).Value = createDate
                cmd.Parameters.Add("@LastActivityDate", OdbcType.DateTime).Value = createDate
                cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = pApplicationName
                cmd.Parameters.Add("@IsLockedOut", OdbcType.Bit).Value = False
                cmd.Parameters.Add("@LastLockedOutDate", OdbcType.DateTime).Value = createDate
                cmd.Parameters.Add("@FailedPasswordAttemptCount", OdbcType.Int).Value = 0
                cmd.Parameters.Add("@FailedPasswordAttemptWindowStart", OdbcType.DateTime).Value = createDate
                cmd.Parameters.Add("@FailedPasswordAnswerAttemptCount", OdbcType.Int).Value = 0
                cmd.Parameters.Add("@FailedPasswordAnswerAttemptWindowStart", OdbcType.DateTime).Value = createDate

                Try
                    conn.Open()

                    Dim recAdded As Integer = cmd.ExecuteNonQuery()

                    If recAdded > 0 Then
                        status = MembershipCreateStatus.Success
                    Else
                        status = MembershipCreateStatus.UserRejected
                    End If
                Catch e As OdbcException
                    ' Handle exception.

                    status = MembershipCreateStatus.ProviderError
                Finally
                    conn.Close()
                End Try


                Return GetUser(username, False)
            Else
                status = MembershipCreateStatus.DuplicateUserName
            End If

            Return Nothing
        End Function