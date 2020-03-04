<%@ Page language="C#" debug="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <script runat="server">

   public Object cacheItem;

   public void Page_Load(Object sender, EventArgs e)
   {
     if (Cache["key1"] == null) {
       Cache["key1"]= "myValue1";
     }
     
     if (Cache["key2"] == null) {
       Cache["key2"]= "myvalue2";
     }

     if (Cache["key3"] == null) {
       Cache["key3"]= "myvalue3";
     }

     if (!IsPostBack) {
       Label1.Text = "Click the button to see the values of items in the Cache.";
     }
   }

   public void myBtn_Click(Object sender, EventArgs e)
   {
     Label1.Text = "Here you go!";
// <snippet1>
     IDictionaryEnumerator CacheEnum = Cache.GetEnumerator();
     while (CacheEnum.MoveNext())
     {
       cacheItem = Server.HtmlEncode(CacheEnum.Current.ToString()); 
       Response.Write(cacheItem);
     }
// </snippet1>
   }              
 </script>
 
 <head runat="server">
    <title>A Cache.GetEnumerator Example</title>
</head>
<body>
   <h3>A Cache.GetEnumerator Example</h3>
   <form id="form1" runat="server">
     <asp:label id="Label1" runat="server" AssociatedControlID="myBtn"/><br />
     <asp:button id="myBtn" Text="Click Here!" OnClick="myBtn_Click" runat="server" />
   </form>
 </body>
</html>
