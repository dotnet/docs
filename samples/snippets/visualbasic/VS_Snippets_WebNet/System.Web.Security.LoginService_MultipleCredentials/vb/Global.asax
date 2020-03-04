<%@ Application Language="VB" %>

<script runat="server">

    ' <Snippet1>
    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        AddHandler System.Web.ApplicationServices.AuthenticationService.Authenticating, _
          AddressOf Me.AuthenticationService_Authenticating
    End Sub
    ' </Snippet1>
    
    ' <Snippet2>
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
    ' </Snippet2>
    
    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application shutdown
    End Sub
        
    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when an unhandled error occurs
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a new session is started
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a session ends. 
        ' Note: The Session_End event is raised only when the sessionstate mode
        ' is set to InProc in the Web.config file. If session mode is set to StateServer 
        ' or SQLServer, the event is not raised.
    End Sub
    
    Class StudentAuthentication
        Shared Function ValidateStudentCredentials(ByVal username As String, ByVal password As String, ByVal studentid As String, ByVal birthdate As String) As Boolean
            Return True
        End Function
    End Class
       
</script>