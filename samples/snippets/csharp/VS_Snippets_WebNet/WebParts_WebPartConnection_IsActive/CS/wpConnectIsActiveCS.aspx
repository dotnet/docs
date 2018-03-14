<!-- <snippet1> -->
<%@ Page Language="C#" %>
<%@ register tagprefix="aspSample" 
    namespace="Samples.AspNet.CS.Controls" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
  "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
  
  protected void Button1_Click(object sender, EventArgs e)
  {
    WebPartConnection conn = mgr.StaticConnections[0];
    
    if (conn.IsActive)
      lbl1.Text += "<em>Connection 0 is active.</em>";
    else
      lbl1.Text += "Connection 0 is inactive.";
  }

  protected void mgr_ConnectionsActivated(object sender, EventArgs e)
  {
    if(mgr.Connections[0].IsActive)
      lbl2.Text += "<em>Connection 0 is active.</em>";
    else
      lbl2.Text += "Connection 0 is inactive.";
  }

  protected void mgr_ConnectionsActivating(object sender, EventArgs e)
  {
    if (mgr.Connections[0].IsActive)
      lbl3.Text += "<em>Connection 0 is active.</em>";
    else
      lbl3.Text += "Connection 0 is inactive.";
  }

  protected void Page_PreRender(object sender, EventArgs e)
  {
    if (mgr.Connections[0].IsActive)
      lbl4.Text += "<em>Connection 0 is active.</em>";
    else
      lbl4.Text += "Connection 0 is inactive.";
  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:WebPartManager ID="mgr" runat="server" 
        onconnectionsactivated="mgr_ConnectionsActivated" 
        onconnectionsactivating="mgr_ConnectionsActivating">
        <StaticConnections>
          <asp:WebPartConnection ID="conn1"
            ConsumerConnectionPointID="ZipCodeConsumer"
            ConsumerID="weather1" 
            ProviderConnectionPointID="ZipCodeProvider" 
            ProviderID="zip1" />
        </StaticConnections>      
      </asp:WebPartManager>
      <asp:WebPartZone ID="WebPartZone1" runat="server">
        <ZoneTemplate>
          <aspSample:ZipCodeWebPart ID="zip1" runat="server"
            Title="Zip Code Provider"   />
          <aspSample:WeatherWebPart ID="weather1" runat="server" 
            Title="Zip Code Consumer" />
        </ZoneTemplate>
      </asp:WebPartZone>
      <asp:ConnectionsZone ID="ConnectionsZone1" runat="server">
      </asp:ConnectionsZone>
      <asp:Button ID="Button1" runat="server" 
        Text="Connection Details" 
        OnClick="Button1_Click" />
      <br />
      <asp:Label ID="lbl1" runat="server">
        <h3>Button_Click Status</h3>
      </asp:Label>
      <br />
      <asp:Label ID="lbl2" runat="server">
        <h3>ConnectionActivating Status</h3>
      </asp:Label>
      <br />
      <asp:Label ID="lbl3" runat="server">
        <h3>ConnectionActivated Status</h3>
      </asp:Label>
      <br />
      <asp:Label ID="lbl4" runat="server">
        <h3>ConnectionActivated Status</h3>
      </asp:Label>
    </div>
    </form>
</body>
</html>
<!-- </snippet1> -->