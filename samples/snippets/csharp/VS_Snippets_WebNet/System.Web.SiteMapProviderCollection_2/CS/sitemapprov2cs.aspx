<%@ Page Language="c#" %>
 <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
 <SCRIPT runat="server">
 private void Page_Load(object sender, System.EventArgs e)
 {
// <snippet1>
     // Retrive the SiteMapProviderCollection that contains 
     // the providers currently in use.
     SiteMapProviderCollection providers = SiteMap.Providers;

     // Use the Indexer to retrieve the default provider for ASP.NET.
     SiteMapProvider defaultProvider = providers["AspNetXmlSiteMapProvider"];

// </snippet1>     
 }
 </SCRIPT>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
</body>
</html>
