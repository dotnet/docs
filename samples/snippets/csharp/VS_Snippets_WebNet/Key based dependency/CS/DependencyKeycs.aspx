<Script language="c#" runat="server">
    public void DisplayValues() {
        if (Cache["key1"] != null)
            text1.InnerHtml = Cache["key1"].ToString();
        else
            text1.InnerHtml = "No value...";
        
 
        if (Cache["key2"] != null)
            text2.InnerHtml = Cache["key2"].ToString();
        else
            text2.InnerHtml = "No value...";
    }

// <Snippet1>
    public void CreateDependency(Object sender, EventArgs e) {
        // Create a cache entry.
        Cache["key1"] = "Value 1";

        // Make key2 dependent on key1.
        String[] dependencyKey = new String[1];
        dependencyKey[0] = "key1";
        CacheDependency dependency = new CacheDependency(null, dependencyKey);

        Cache.Insert("key2", "Value 2", dependency);

        DisplayValues();
    }
// </Snippet1>

    public void Invalidate(Object sender, EventArgs e) {
        Cache.Remove("key1");
        DisplayValues();
    }
</Script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Cache Key Dependency Example</title>
</head>
<body>
    <form id="Form1" runat="server">
        <h3>Cache Key Dependency example:</h3>
        Key 1: <b id="text1" runat="server"/><br />
        Key 2: <b id="text2" runat="server"/><br />  
        <input type="submit" id="submit1" value="Create Dependency" onserverclick="CreateDependency" runat="server" />
        <input type="submit" id="submit2" value="Invalidate Key 1" onserverclick="Invalidate" runat="server" />
    </form>
</body>
</html>
