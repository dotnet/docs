<script language="C#" runat="server">
//<Snippet1>
public void DefaultAuthentication_OnAuthenticate(object sender,
                                                 DefaultAuthenticationEventArgs args)
{
  if (args.Context.User == null)
    args.Context.User = 
      new System.Security.Principal.GenericPrincipal(
        new System.Security.Principal.GenericIdentity("default"),
        new String[0]);
}
//</Snippet1>
</script>