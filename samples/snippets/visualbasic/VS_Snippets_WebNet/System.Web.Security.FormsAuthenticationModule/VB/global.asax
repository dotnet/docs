<script language="VB" runat="server">
'<Snippet1>
Public Sub FormsAuthentication_OnAuthenticate(sender As Object, _
                                              args As FormsAuthenticationEventArgs)
  If FormsAuthentication.CookiesSupported Then
    If Not Request.Cookies(FormsAuthentication.FormsCookieName) Is Nothing Then
      Try
        Dim ticket As FormsAuthenticationTicket = FormsAuthentication.Decrypt( _
          Request.Cookies(FormsAuthentication.FormsCookieName).Value)
        
        args.User = New System.Security.Principal.GenericPrincipal( _
          New Samples.AspNet.Security.MyFormsIdentity(ticket), _
          New String(0) {})
      Catch e As HttpException
        ' Decrypt method failed.
      End Try
    End If
  Else
      Throw New Exception("Cookieless Forms Authentication is not " & _
                            "supported for this application.")
  End If
End Sub
'</Snippet1>
</script>
