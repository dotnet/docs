    private SiteMapNode GetNode(ArrayList list, string url)
    {
      for (int i = 0; i < list.Count; i++)
      {
        DictionaryEntry item = (DictionaryEntry)list[i];
        if ((string)item.Key == url)
          return item.Value as SiteMapNode;
      }
      return null;
    }

    // Get the URL of the currently displayed page.
    private string FindCurrentUrl()
    {
      try
      {
        // The current HttpContext.
        HttpContext currentContext = HttpContext.Current;
        if (currentContext != null)
        {
          return currentContext.Request.RawUrl;
        }
        else
        {
          throw new Exception("HttpContext.Current is Invalid");
        }
      }
      catch (Exception e)
      {
        throw new NotSupportedException("This provider requires a valid context.",e);
      }
    }