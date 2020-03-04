<!-- <snippet1> -->
<%@ Page Language="C#" %>
<%@ register tagprefix="uc1" 
    tagname="DisplayModeMenuCS"
    src="~/displaymodemenucs.ascx" %>
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
      
    if(mgr.CanConnectWebParts(zip1, provPoint, weather1, connPoint))
      mgr.ConnectWebParts(zip1, provPoint, weather1, connPoint);
  
  }  
  protected void Button2_Click(object sender, EventArgs e)
  {
    WebPartConnection conn = mgr.Connections[0];
    
    lblConn.Text = "<h2>Connection Point Details</h2>" + 
       "<h3>Provider Connection Point</h3>" + 
       "  Display name: " + conn.ProviderConnectionPoint.DisplayName + 
       "<br />" + 
       "  ID: " + conn.ProviderConnectionPoint.ID + 
       "<br />" + 
       "  Interface type: " + 
        conn.ProviderConnectionPoint.InterfaceType.ToString() + 
       "<br />" + 
       "  Control type: " + conn.ProviderConnectionPoint.ControlType.ToString() + 
       "<br />" + 
       "  Allows multiple connections: " + 
          conn.ProviderConnectionPoint.AllowsMultipleConnections.ToString() + 
       "<br />" + 
       "  Enabled: " + conn.ProviderConnectionPoint.GetEnabled(zip1).ToString() + 
       "<hr />" + 
       "<h3>Consumer Connection Point</h3>" + 
       "  Display name: " + conn.ConsumerConnectionPoint.DisplayName + 
       "<br />" + 
       "  ID: " + conn.ConsumerConnectionPoint.ID + 
       "<br />" + 
       "  Interface type: " + conn.ConsumerConnectionPoint.InterfaceType.ToString() + 
       "<br />" + 
       "  Control type: " + conn.ConsumerConnectionPoint.ControlType.ToString() + 
       "<br />" + 
       "  Allows multiple connections: " + 
          conn.ConsumerConnectionPoint.AllowsMultipleConnections.ToString() + 
       "<br />" + 
       "  Enabled: " + conn.ConsumerConnectionPoint.GetEnabled(zip1).ToString();
  }

  protected void Page_Load(object sender, EventArgs e)
  {
    lblConn.Text = String.Empty;
  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:WebPartManager ID="mgr" runat="server" >
        <StaticConnections>
          <asp:WebPartConnection ID="conn1"
            ConsumerConnectionPointID="ZipCodeConsumer"
            ConsumerID="weather1" 
            ProviderConnectionPointID="ZipCodeProvider" 
            ProviderID="zip1" />
        </StaticConnections>      
      </asp:WebPartManager>
      <uc1:displaymodemenucs id="menu1" runat="server" />
      <asp:WebPartZone ID="WebPartZone1" runat="server">
        <ZoneTemplate>
          <aspSample:ZipCodeWebPart ID="zip1" runat="server"
            Title="Zip Code Provider"  />
          <aspSample:WeatherWebPart ID="weather1" runat="server" 
            Title="Zip Code Consumer" />
        </ZoneTemplate>
      </asp:WebPartZone>
      <asp:ConnectionsZone ID="ConnectionsZone1" runat="server">
      </asp:ConnectionsZone>
      <asp:Button ID="Button1" runat="server" 
        Text="Dynamic Connection" 
        OnClick="Button1_Click" />      
      <br />
      <asp:Button ID="Button2" runat="server" 
        Text="Connection Point Details" 
        OnClick="Button2_Click" />
      <br />
      <asp:Label ID="lblConn" runat="server" />
    </div>
    </form>
</body>
</html>
<!-- </snippet1> -->