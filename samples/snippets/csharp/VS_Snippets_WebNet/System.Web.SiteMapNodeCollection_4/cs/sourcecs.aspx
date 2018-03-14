<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  protected void Page_Load(object sender, EventArgs e)
  {
    // <Snippet1>
    String providername1 = "AspNetXmlSiteMapProvider";
    String providername2 = "MyXmlSiteMapProvider";
    SiteMapProviderCollection providers = SiteMap.Providers;

    if (providers[providername1] != null && providers[providername2] != null)
    {
      SiteMapProvider provider1 = providers[providername1];
      SiteMapProvider provider2 = providers[providername2];
      SiteMapNodeCollection collection1 = provider1.RootNode.ChildNodes;
      SiteMapNodeCollection collection2 = provider2.RootNode.ChildNodes;
      int matches = 0;
      foreach (SiteMapNode node in collection1)
      {
        if (collection2.Contains(node))
        {
          Response.Write("Match found at " +
            providername1 + ", index = " +
            collection1.IndexOf(node) + " with " +
            providername2 + ", index = " +
            collection2.IndexOf(node) + ".<br />");
          matches++;
        }
      }
      Response.Write("Number of matches found = " +
        matches.ToString() + ".");
    }
    else
    {
      Response.Write(providername1 + " or " +
        providername2 + " not found.");
    }
    // </Snippet1>
    
  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SiteMapNodeCollection Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
