<script language="VB" runat="server">
'<Snippet1>
Public Sub DefaultAuthentication_OnAuthenticate(sender As Object, _
                                                args As DefaultAuthenticationEventArgs)
  If args.Context.User Is Nothing Then
    args.Context.User = _
      new System.Security.Principal.GenericPrincipal( _
        new System.Security.Principal.GenericIdentity("default"), _
        new String(0) {})
  End If
End Sub
'</Snippet1>
</script>