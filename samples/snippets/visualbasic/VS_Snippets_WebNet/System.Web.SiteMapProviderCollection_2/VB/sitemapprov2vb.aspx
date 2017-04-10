<%@ Page Language="VB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<SCRIPT runat="server">
Private Sub Page_Load(sender As Object, e As System.EventArgs)
' <snippet1>
     ' Retrive the SiteMapProviderCollection that contains 
     ' the providers currently in use.
     Dim providers As SiteMapProviderCollection 
     providers = SiteMap.Providers

     ' Use the Indexer to retrieve the default provider for ASP.NET.
     Dim defaultProvider As SiteMapProvider 
     defaultProvider = providers("AspNetXmlSiteMapProvider")
' </snippet1>
End Sub ' Page_Load
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
