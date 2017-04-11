<!-- <snippet1> -->
<%@ Page Language="vb" %>
<%@ Register TagPrefix="uc1" 
    TagName="DisplayModeMenuVB"
    Src="~/displaymodemenuvb.ascx" %>
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
    mgr.ConnectWebParts(zip1, provPoint, weather1, connPoint)

  End Sub

  Protected Sub Button2_Click(ByVal sender As Object, _
    ByVal e As System.EventArgs)
    
    Dim conn as WebPartConnection = mgr.Connections(0)

    lbl2.Text = "<h3>Connection Details</h3>" & _
      "Connection ID: " & conn.ID & _
      "<br />" & _
      "Consumer ID: " & conn.ConsumerID & _ 
      "<br />" & _
      "Provider ID: " & conn.ProviderID
  End Sub

  Protected Sub mgr_DisplayModeChanged (ByVal sender as Object, _
    ByVal e as WebPartDisplayModeEventArgs)

    If mgr.DisplayMode Is WebPartManager.ConnectDisplayMode Then
      Button1.Visible = True
      Button2.Visible = True
    Else
      Button1.Visible = False
      Button2.Visible = False
    End If

  End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:WebPartManager ID="mgr" runat="server" OnDisplayModeChanged="mgr_DisplayModeChanged">
        <StaticConnections>
          <asp:WebPartConnection ID="conn1"
            ConsumerConnectionPointID="ZipCodeConsumer"
            ConsumerID="weather1" 
            ProviderConnectionPointID="ZipCodeProvider" 
            ProviderID="zip1" />
        </StaticConnections>
      </asp:WebPartManager>
      <uc1:DisplayModeMenuVB ID="menu1" runat="server" />
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
        OnClick="Button1_Click" 
    Visible="false" />
      <br />
      <asp:Button ID="Button2" runat="server" 
        Text="Connection Details" 
        OnClick="Button2_Click" 
        Visible="false" /> 
      <br />   
      <asp:Label ID="lbl2" runat="server" />
    </div>
    </form>
</body>
</html>
<!-- </snippet1> -->