<%@ Page Language="C#" %>
<%@ Import Namespace="System.Web.Security" %>

<script runat="server">

public void Page_Load()
{

  Snippet2();
  Snippet6();

}

public void Snippet2()
{
  //<Snippet2>
  RolePrincipal r;

  if (Roles.CacheRolesInCookie)
  {
    string roleCookie = "";

    HttpCookie cookie = HttpContext.Current.Request.Cookies[Roles.CookieName];
    if (cookie != null) { roleCookie = cookie.Value; }

    r = new RolePrincipal(User.Identity, roleCookie);
  }
  else
  {
    r = new RolePrincipal(User.Identity);
  }
  //</Snippet2>

  Response.Write(r.IsRoleListCached.ToString() + "<BR>");
}


public void Snippet6()
{
  //<Snippet6>
  try
  {
    RolePrincipal r = (RolePrincipal)User;
    string eTicket = r.ToEncryptedTicket();
    HttpCookie cookie = new HttpCookie(Roles.CookieName, eTicket);
    cookie.Path = Roles.CookiePath;
    cookie.Expires = r.ExpireDate;
    Response.Cookies.Add(cookie);
  }
  catch (InvalidCastException)
  {
    Response.Write("User is not of type RolePrincipal. Are roles enabled?");
  }
  //</Snippet6>
}

</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
</body>
</html>
