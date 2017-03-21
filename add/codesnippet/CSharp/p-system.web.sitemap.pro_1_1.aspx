<%@ Page Language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<SCRIPT runat="server">
private void Page_Load(object sender, System.EventArgs e)
{
    // Navigate the SiteMap built by the default SiteMapProvider.
    Response.Write(SiteMap.RootNode.ToString() + "<BR>");

    Response.Write(SiteMap.RootNode.Url + "<BR>");
    Response.Write(SiteMap.RootNode.Title + "<BR>");

    foreach (SiteMapNode sitemapnode in SiteMap.RootNode.ChildNodes)
    {
        // Iterate through the ChildNodes SiteMapNodesCollection
        // maintained by the RootNode.
        Response.Write(sitemapnode.Url + "<BR>" );
    }

    IEnumerator providers = SiteMap.Providers.GetEnumerator();
    while (providers.MoveNext())
    {
        Response.Write(providers.Current);
        Response.Write("&nbsp;&nbsp;&nbsp;");
        Response.Write("<BR>");
    }
}
</SCRIPT>