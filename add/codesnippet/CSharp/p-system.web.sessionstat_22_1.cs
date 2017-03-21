    //
    // Session.CodePage exists only to support legacy ASP compatibility. ASP.NET developers should use
    // Response.ContentEncoding instead.
    //
    public int CodePage
    {
      get
      { 
        if (HttpContext.Current != null)
          return HttpContext.Current.Response.ContentEncoding.CodePage;
        else
          return Encoding.Default.CodePage;
      }
      set
      { 
        if (HttpContext.Current != null)
          HttpContext.Current.Response.ContentEncoding = Encoding.GetEncoding(value);
      }
    }