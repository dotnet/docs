<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script language="c#" runat="server">
    public void Page_Load(Object sender, EventArgs e) {
        if (Cache["key1"] != null)
            text1.InnerHtml = Cache["key1"].ToString();
        else {
            text1.InnerHtml = "No value...";
// <Snippet1>
        // Create a DateTime object that determines
        // when dependency monitoring begins.
        DateTime dt = DateTime.Now;
            // Make key1 dependent on several files.
            String[] files = new String[2];
            files[0] = Server.MapPath("isbn.xml");
            files[1] = Server.MapPath("customer.xml");
            CacheDependency dep = new CacheDependency(files, dt);

            Cache.Insert("key1", "Value 1", dep);
        }
// </Snippet1>
    }
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="head1" runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Cache key dependency example:<br />
        Key 1: <b id="text1" runat="server"/><br />    
    </div>
    </form>
</body>
</html>

