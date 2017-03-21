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