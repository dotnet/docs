    public void RemoveSessionID(HttpContext context)
    {
      context.Response.Cookies.Remove(pConfig.CookieName);
    }