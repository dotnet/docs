<!-- <snippet1> -->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  
  protected void mgr1_AuthorizeWebPart(object sender, 
    WebPartAuthorizationEventArgs e)
  {
    if (!String.IsNullOrEmpty(e.AuthorizationFilter))
    {
      if (e.AuthorizationFilter == "user")
        e.IsAuthorized = true;
      else
        e.IsAuthorized = false;
    }
  }
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:WebPartManager ID="mgr1" runat="server"
        OnAuthorizeWebPart="mgr1_AuthorizeWebPart" />
      <asp:WebPartZone ID="WebPartZone1" runat="server">
        <ZoneTemplate>
          <asp:BulletedList 
            ID="BulletedList1" 
            Runat="server"
            DisplayMode="HyperLink" 
            Title="Favorite Links"
            AuthorizationFilter="admin">
            <asp:ListItem Value="http://msdn.microsoft.com">
              MSDN
            </asp:ListItem>
            <asp:ListItem Value="http://www.asp.net">
              ASP.NET
            </asp:ListItem>
            <asp:ListItem Value="http://www.msn.com">
              MSN
            </asp:ListItem>
          </asp:BulletedList>
          <asp:Label ID="Label1" runat="server" 
            Text="Hello World"
            Title="Filter Test"
            AuthorizationFilter="admin" />
          <asp:Calendar ID="Calendar1" runat="server" 
            Title="My Calendar"/>
        </ZoneTemplate>
      </asp:WebPartZone>
    </div>
    </form>
</body>
</html>
<!-- </snippet1> -->