<!-- <snippet1> -->
<%@ Page Language="VB" %>
<%@ register tagprefix="uc1" 
    tagname="DisplayModeMenuVB"
    src="~/displaymodemenuvb.ascx" %>
<%@ Register TagPrefix="aspSample" 
    Namespace="Samples.AspNet.VB.Controls" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
  "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  Protected Sub Button1_Click(ByVal sender As Object, _
    ByVal e As System.EventArgs)

    Dim provPoint As ProviderConnectionPoint = _
      mgr.GetProviderConnectionPoints(zip1)("ZipCodeProvider")
    Dim connPoint As ConsumerConnectionPoint = _
      mgr.GetConsumerConnectionPoints(weather1)("ZipCodeConsumer")

    If mgr.CanConnectWebParts(zip1, provPoint, weather1, connPoint) Then
      mgr.ConnectWebParts(zip1, provPoint, weather1, connPoint)
    End If
    
  End Sub
  
  Protected Sub Button2_Click(ByVal sender As Object, _
    ByVal e As System.EventArgs)
    
    Dim conn As WebPartConnection = mgr.Connections(0)

    lblConn.Text = "<h2>Connection Point Details</h2>" & _
      "<h3>Provider Connection Point</h3>" & _
      "  Display name: " & conn.ProviderConnectionPoint.DisplayName & _
      "<br />" & _
      "  ID: " & conn.ProviderConnectionPoint.ID & _
      "<br />" & _
      "  Interface type: " & conn.ProviderConnectionPoint.InterfaceType.ToString() & _
      "<br />" & _
      "  Control type: " & conn.ProviderConnectionPoint.ControlType.ToString() & _
      "<br />" & _
      "  Allows multiple connections: " & _
        conn.ProviderConnectionPoint.AllowsMultipleConnections.ToString() & _
      "<br />" & _
      "  Enabled: " & conn.ProviderConnectionPoint.GetEnabled(zip1).ToString() & _
      "<hr />" & _
      "<h3>Consumer Connection Point</h3>" & _
      "  Display name: " & conn.ConsumerConnectionPoint.DisplayName & _
      "<br />" & _
      "  ID: " & conn.ConsumerConnectionPoint.ID & _
      "<br />" & _
      "  Interface type: " & conn.ConsumerConnectionPoint.InterfaceType.ToString() & _
      "<br />" & _
      "  Control type: " & conn.ConsumerConnectionPoint.ControlType.ToString() & _
      "<br />" & _
      "  Allows multiple connections: " & _
        conn.ConsumerConnectionPoint.AllowsMultipleConnections.ToString() & _
      "<br />" & _
      "  Enabled: " & conn.ConsumerConnectionPoint.GetEnabled(zip1).ToString()
          
  End Sub

  Protected Sub Page_Load(ByVal sender As Object, _
    ByVal e As System.EventArgs)
    lblConn.Text = String.Empty
  End Sub
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
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
      <uc1:displaymodemenuvb id="menu1" runat="server" />
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