<!-- <snippet1> -->
<%@ Page Language="C#" %>
<%@ Register TagPrefix="uc1" 
    TagName="DisplayModeMenuCS"
    Src="~/displaymodemenucs.ascx" %>
<%@ Register TagPrefix="aspSample" 
    Namespace="Samples.AspNet.CS.Controls" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    
  protected void Button1_Click(object sender, EventArgs e)
  {
    ProviderConnectionPoint provPoint =
      mgr.GetProviderConnectionPoints(zip1)["ZipCodeProvider"];
    ConsumerConnectionPoint connPoint =
      mgr.GetConsumerConnectionPoints(weather1)["ZipCodeConsumer"];
    WebPartConnection conn1 = mgr.ConnectWebParts(zip1, provPoint,
      weather1, connPoint);
  }

  protected void Button2_Click(object sender, EventArgs e)
  {
    if (mgr.Connections.Count >= 1 && mgr.Connections[0] != null)
      mgr.DisconnectWebParts(mgr.Connections[0]);
  }
  

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:WebPartManager ID="mgr" runat="server">
      </asp:WebPartManager>
      <uc1:DisplayModeMenuCS ID="menu1" runat="server" />
      <asp:WebPartZone ID="WebPartZone1" runat="server">
        <ZoneTemplate>
          <aspSample:ZipCodeWebPart ID="zip1" runat="server"
            Title="Zip Code Provider" />
          <aspSample:WeatherWebPart ID="weather1" runat="server" 
            Title="Zip Code Consumer" />
        </ZoneTemplate>
      </asp:WebPartZone>
      <asp:ConnectionsZone ID="ConnectionsZone1" runat="server">
      </asp:ConnectionsZone>
      <asp:Button ID="Button1" runat="server" 
        Text="Connect WebPart Controls" 
        OnClick="Button1_Click" />
      <asp:Button ID="Button2" runat="server" 
        Text="Disconnect WebPart Controls" 
        OnClick="Button2_Click" />
    </div>
    </form>
</body>
</html>
<!-- </snippet1> -->