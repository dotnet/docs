<!-- <snippet1> -->
<%@ Page Language="C#" %>
<%@ Register TagPrefix="aspSample" 
    Namespace="Samples.AspNet.CS.Controls" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
  "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
  
  protected void Button1_Click(object sender, EventArgs e)
  {
    WebPartConnection conn = mgr.StaticConnections[0];
    
    if (conn.IsStatic)
      lbl2.Text = "The connection is static.";
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
        Text="Connection Details" 
        OnClick="Button1_Click" />
      <br />
      <asp:Label ID="lbl2" runat="server" />
    </div>
    </form>
</body>
</html>
<!-- </snippet1> -->