<script language="C#" runat="server">
//<Snippet1>
public void WindowsAuthentication_OnAuthenticate(object sender, WindowsAuthenticationEventArgs args)
{
  if (!args.Identity.IsAnonymous)
  {
    args.User = new Samples.AspNet.Security.MyPrincipal(args.Identity);
  }
}
//</Snippet1>
</script>