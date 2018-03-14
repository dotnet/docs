<Script language="C#" runat="server">
    public void Page_Load(Object sender, EventArgs e) {
        if (Cache["key1"] != null)
            text1.InnerHtml = Cache["key1"].ToString();
        else {
            text1.InnerHtml = "No value...";
// <Snippet1>
            // Make key1 dependent on several files.
            String[] files = new String[2];
            files[0] = Server.MapPath("isbn.xml");
            files[1] = Server.MapPath("customer.xml");
            CacheDependency dependency = new CacheDependency(files);

            Cache.Insert("key1", "Value 1", dependency);
        }
// </Snippet1>
    }
</Script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>DependencyMultiFile Example</title>
</head>
<body>
    <form id="Form1" runat="server">
        Cache key dependency example:<br />
        Key 1: <b id="text1" runat="server"/><br />
    </form>
</body>
</html>
