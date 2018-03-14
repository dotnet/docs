<!-- <snippet1> -->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  protected void Button1_Click(object sender, EventArgs e)
  {
    Label1.Text = "WebPart count:  " +
      WebPartManager1.WebParts.Count.ToString();
  }

  protected void Button2_Click(object sender, EventArgs e)
  {
    WebPartManager1.WebParts["Calendar1"].ChromeType = 
      PartChromeType.BorderOnly;
  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
      <!-- Reference the WebPartManager control. -->
    <asp:WebPartManager ID="WebPartManager1" runat="server" />    
    <div>
      <asp:WebPartZone ID="WebPartZone1" runat="server">
        <ZoneTemplate>
          <asp:BulletedList 
            DisplayMode="HyperLink" 
            ID="BulletedList1" 
            runat="server"
            Title="My Links"
            ExportMode="All">
            <asp:ListItem Value="http://www.microsoft.com">
            Microsoft
            </asp:ListItem>
            <asp:ListItem Value="http://www.msn.com">
            MSN
            </asp:ListItem>
            <asp:ListItem Value="http://www.contoso.com">
            Contoso Corp.
            </asp:ListItem>
          </asp:BulletedList>
          <asp:Calendar ID="Calendar1" runat="server" 
            Title="My Calendar" />
        </ZoneTemplate>
      </asp:WebPartZone>
      <hr />
      <asp:Button ID="Button1" runat="server" 
        Text="WebPart Count" 
        OnClick="Button1_Click" />
      <asp:Button ID="Button2" runat="server" 
        Text="Hide Calendar Title" 
        OnClick="Button2_Click" />  
      <br />
      <asp:Label ID="Label1" runat="server" text="" />
    </div>
    </form>
</body>
</html>
<!-- </snippet1> -->