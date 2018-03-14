<!-- <snippet2> -->
<%@ Page Language="vb"
  Codefile="webpartcollection.vb" 
  Inherits="webpartcollectionvb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:WebPartManager ID="mgr1" runat="server" />
      <asp:WebPartZone ID="WebPartZone1" runat="server">
        <ZoneTemplate>
          <asp:BulletedList 
            ID="BulletedList1" 
            Runat="server"
            DisplayMode="HyperLink" 
            Title="Favorite Links" >
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
          <br />
          <asp:Calendar ID="Calendar1" runat="server" 
            Title="My Calendar" />
        </ZoneTemplate>
      </asp:WebPartZone>
    </div>
    <hr />
    <asp:Button ID="Button1" runat="server" Width="200"
      Text="Toggle ChromeState" OnClick="Button1_Click" />
    <br />
    <asp:Button ID="Button2" runat="server" Width="200"
        Text="Toggle BulletedList1 Title" 
        OnClick="Button2_Click"/>
    </form>
</body>
</html>
<!-- </snippet2> -->