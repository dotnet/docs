<!-- <snippet1> -->
<%@ Page Language="VB" %>
<%@ Register TagPrefix="aspSample" 
    Namespace="Samples.AspNet.VB.Controls" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
  "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  Protected Sub Button1_Click(ByVal sender As Object, _
    ByVal e As System.EventArgs)
    
    Dim conn As WebPartConnection = mgr.StaticConnections(0)
    
    If conn.IsActive Then
      lbl1.Text += "<em>Connection 0 is active.</em>"
    Else
      lbl1.Text += "Connection 0 is inactive."
    End If
    
  End Sub
    
  Protected Sub mgr_ConnectionsActivated(ByVal sender As Object, _
    ByVal e As System.EventArgs)
    
    If mgr.Connections(0).IsActive Then
      lbl2.Text += "<em>Connection 0 is active.</em>"
    Else
      lbl2.Text += "Connection 0 is inactive."
    End If
    
  End Sub

  Protected Sub mgr_ConnectionsActivating(ByVal sender As Object, _
    ByVal e As System.EventArgs)

    If mgr.Connections(0).IsActive Then
      lbl3.Text += "<em>Connection 0 is active.</em>"
    Else
      lbl3.Text += "Connection 0 is inactive."
    End If
    
  End Sub

  Protected Sub Page_PreRender(ByVal sender As Object, _
    ByVal e As System.EventArgs)

    If mgr.Connections(0).IsActive Then
      lbl4.Text += "<em>Connection 0 is active.</em>"
    Else
      lbl4.Text += "Connection 0 is inactive."
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
      <asp:WebPartManager ID="mgr" runat="server" 
        OnConnectionsActivated="mgr_ConnectionsActivated" 
        OnConnectionsActivating="mgr_ConnectionsActivating">
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