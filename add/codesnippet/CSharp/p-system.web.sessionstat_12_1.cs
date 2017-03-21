    //
    // Session.LCID exists only to support legacy ASP compatibility. ASP.NET developers should use
    // Page.LCID instead.
    //
    public int LCID
    {
      get { return Thread.CurrentThread.CurrentCulture.LCID; }
      set { Thread.CurrentThread.CurrentCulture = CultureInfo.ReadOnly(new CultureInfo(value)); }
    }