    public bool IsCookieless
    {
      get { return CookieMode == HttpCookieMode.UseUri; }
    }