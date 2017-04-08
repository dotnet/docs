<%@ Page debug="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <script runat="server">

Public cacheItem As [String]


Public Sub Page_Load(sender As [Object], e As EventArgs)
   If Cache("key1") Is Nothing Then
      Cache("key1") = "myValue1"
   End If
   
   If Cache("key2") Is Nothing Then
      Cache("key2") = "myvalue2"
   End If
   
   If Cache("key3") Is Nothing Then
      Cache("key3") = "myvalue3"
   End If
   
   If Not IsPostBack Then
      Label1.Text = "Click the button to see the values of items in the cache."
      End If '
End Sub 'Page_Load


Public Sub myBtn_Click(sender As [Object], e As EventArgs)
   Label1.Text = "Here you go!"
' <snippet1>   
   Dim CacheEnum As IDictionaryEnumerator = Cache.GetEnumerator()
   While CacheEnum.MoveNext()
      cacheItem = Server.HtmlEncode(CacheEnum.Current.Value.ToString())
      Response.Write(cacheItem)
   End While
' </snippet1>
End Sub 'myBtn_Click 
 </script>
 
 <head runat="server">
    <title>A Cache.GetEnumerator Example</title>
</head>
<body>
   <h3>A Cache.GetEnumerator Example</h3>
   <form id="form1" runat="server">
     <asp:label id="Label1" runat="server" AssociatedControlID="myBtn" /><br />
     <asp:button id="myBtn" Text="Click Here!" OnClick="myBtn_Click" runat="server" />
   </form>
 </body>
</html>
