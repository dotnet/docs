<Script language="c#" runat="server">
    public void Page_Load(Object sender, EventArgs e) {
        if (Cache["key1"] != null)
            text1.InnerHtml = Cache["key1"].ToString();
        else {
            text1.InnerHtml = "No value...";
// <Snippet1>
            // Make key1 dependent on a file.
            CacheDependency dependency = new CacheDependency(Server.MapPath("isbn.xml"));

            Cache.Insert("key1", "Value 1", dependency);
// </Snippet1>
        }

    }
</Script>
Cache key dependency example:<BR>
Key 1: <B id="text1" runat="server"/><BR>