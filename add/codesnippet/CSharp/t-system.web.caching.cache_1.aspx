<html>
 <Script runat=server language="C#">
    static bool itemRemoved = false;
    static CacheItemRemovedReason reason;
    CacheItemRemovedCallback onRemove = null;

    public void RemovedCallback(String k, Object v, CacheItemRemovedReason r){
      itemRemoved = true;
      reason = r;
    }

    public void AddItemToCache(Object sender, EventArgs e) {
        itemRemoved = false;

        onRemove = new CacheItemRemovedCallback(this.RemovedCallback);

        if (Cache["Key1"] == null)
          Cache.Add("Key1", "Value 1", null, DateTime.Now.AddSeconds(60), Cache.NoSlidingExpiration, CacheItemPriority.High, onRemove);
    }

    public void RemoveItemFromCache(Object sender, EventArgs e) {
        if(Cache["Key1"] != null)
          Cache.Remove("Key1");
    }
 </Script>
 <body>
  <Form runat="server">
   <input type=submit OnServerClick="AddItemToCache" value="Add Item To Cache" runat="server"/>
   <input type=submit OnServerClick="RemoveItemFromCache" value="Remove Item From Cache" runat="server"/>
  </Form>
  <% if (itemRemoved) {
        Response.Write("RemovedCallback event raised.");
        Response.Write("<BR>");
        Response.Write("Reason: <B>" + reason.ToString() + "</B>");
     }
     else {
        Response.Write("Value of cache key: <B>" + Server.HtmlEncode(Cache["Key1"] as string) + "</B>");
     }
  %>
 </body>
</html>