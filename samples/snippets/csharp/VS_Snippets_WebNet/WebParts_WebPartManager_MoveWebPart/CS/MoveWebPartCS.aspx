<!-- <snippet1> -->
<%@ Page Language="C#" %>
<%@ Register TagPrefix="uc1" 
    TagName="DisplayModeMenuCS"
    Src="~/displaymodemenucs.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  protected void Button1_Click(object sender, EventArgs e)
  {
    GenericWebPart part = mgr1.GetGenericWebPart(list1);
    mgr1.MoveWebPart(part, zone2, zone2.WebParts.Count - 1);
  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:WebPartManager ID="mgr1" runat="server" />
      <uc1:DisplayModeMenuCS ID="menu1" runat="server" />
      <asp:WebPartZone ID="zone1" runat="server">
        <ZoneTemplate>
          <asp:Label ID="Label1" runat="server" 
            Text="My Navigation" 
            Title="Zone 1 Label"/>
          <asp:BulletedList 
            ID="list1" 
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
        </ZoneTemplate>
      </asp:WebPartZone>
      <asp:WebPartZone ID="zone2" runat="server">
        <ZoneTemplate>
          <asp:Label ID="Label2" runat="server" 
            Text="My Data" 
            Title="Zone 2 Label"/>
          <asp:Calendar ID="Calendar1" runat="server" 
            Title="My Calendar"/>
        </ZoneTemplate>
      </asp:WebPartZone>
      <hr />
      <asp:Button ID="Button1" runat="server" 
        Text="Move WebPart" 
        OnClick="Button1_Click" />
    </div>
    </form>
</body>
</html>
<!-- </snippet1> -->