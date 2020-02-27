<script language="C#" runat="server">
//<Snippet1>
public void FormsAuthentication_OnAuthenticate(object sender, FormsAuthenticationEventArgs args)
{
  if (FormsAuthentication.CookiesSupported)
  {
    if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
    {
      try
      {
        FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(
          Request.Cookies[FormsAuthentication.FormsCookieName].Value);
        
        args.User = new System.Security.Principal.GenericPrincipal(
          new Samples.AspNet.Security.MyFormsIdentity(ticket),
          new string[0]);
      }
      catch (Exception e)
      {
        // Decrypt method failed.
      }
    }
  }
  else
  {
    throw new HttpException("Cookieless Forms Authentication is not " +
                            "supported for this application.");
  }
}
//</Snippet1>
</script>
