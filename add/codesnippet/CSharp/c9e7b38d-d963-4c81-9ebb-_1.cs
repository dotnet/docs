    public void SaveSessionID(HttpContext context, string id, out bool redirected, out bool cookieAdded)
    {
      redirected = false;
      cookieAdded = false;

      if (pConfig.Cookieless == HttpCookieMode.UseUri)
      {
        // Add the SessionID to the URI. Set the redirected variable as appropriate.

        redirected = true;
        return;
      }
      else
      {
        context.Response.Cookies.Add(new HttpCookie(pConfig.CookieName, id));
        cookieAdded = true;
      }
    }