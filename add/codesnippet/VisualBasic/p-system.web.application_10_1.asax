    Sub AuthenticationService_Authenticating _
       (ByVal sender As Object, _
        ByVal e As System.Web.ApplicationServices.AuthenticatingEventArgs)
        Dim studentid As String = String.Empty
        Dim answer As String = String.Empty

        Dim credentials As String() = _
             e.CustomCredential.Split(New Char() {","c})
        If (credentials.Length > 0) Then
            studentid = credentials(0)
            If (credentials.Length > 1) Then
                answer = credentials(1)
            End If
        End If

        Try
            e.Authenticated = _
                StudentAuthentication.ValidateStudentCredentials _
                (e.Username, e.Password, studentid, answer)
        Catch ex As ArgumentNullException
            e.Authenticated = False
        End Try
        

        e.AuthenticationIsComplete = True
    End Sub