<!-- <snippet1> -->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  protected void Button2_Click(object sender, EventArgs e)
  {
    WebPartManager mgr = WebPartManager1;
    Calendar cal = new Calendar();
    cal.ID = "cal1";
    GenericWebPart calWebPart = mgr.CreateWebPart(cal);
    mgr.AddWebPart(calWebPart, WebPartZone1, 1);
  }

  protected void Button1_Click(object sender, EventArgs e)
  {
    if (WebPartZone1.WebParts.Count > 1)
    {
      WebPart cal = WebPartZone1.WebParts[1];
      if (cal.Controls[0].GetType().Name == "Calendar" 
        && cal != null)
        WebPartManager1.DeleteWebPart(cal);
    }

  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Adding a Server Control</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:WebPartManager ID="WebPartManager1" 
        runat="server" />
      <asp:WebPartZone ID="WebPartZone1" runat="server">
        <ZoneTemplate>
          <asp:BulletedList  
            DisplayMode="HyperLink" 
            ID="BulletedList1" 
            runat="server"
            Title="My Links">
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
        </ZoneTemplate>
      </asp:WebPartZone>
      <asp:Button ID="Button1" runat="server" 
        Text="Delete Calendar" 
        OnClick="Button1_Click" />
      <asp:Button ID="Button2" runat="server" 
        Text="Add Calendar" 
        OnClick="Button2_Click" />
    </div>
    </form>
</body>
</html>
<!-- </snippet1> -->