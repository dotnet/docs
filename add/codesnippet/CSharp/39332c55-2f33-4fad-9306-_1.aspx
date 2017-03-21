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