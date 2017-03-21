    public string GetSessionID(HttpContext context)
    {
      string id = null;

      if (pConfig.Cookieless == HttpCookieMode.UseUri)
      {
        // Retrieve the SessionID from the URI.
      }
      else
      {
        id = context.Request.Cookies[pConfig.CookieName].Value;
      }      

      // Verify that the retrieved SessionID is valid. If not, return null.

      if (!Validate(id))
        id = null;

      return id;
    }