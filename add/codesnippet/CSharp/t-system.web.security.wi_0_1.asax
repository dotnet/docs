public void WindowsAuthentication_OnAuthenticate(object sender, WindowsAuthenticationEventArgs args)
{
  if (!args.Identity.IsAnonymous)
  {
    args.User = new Samples.AspNet.Security.MyPrincipal(args.Identity);
  }
}