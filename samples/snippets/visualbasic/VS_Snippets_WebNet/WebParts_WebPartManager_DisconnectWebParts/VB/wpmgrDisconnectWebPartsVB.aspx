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
    
    Dim mgr As WebPartManager = _
      WebPartManager.GetCurrentWebPartManager(Page)
    Dim provPoint As ProviderConnectionPoint = _
      mgr.GetProviderConnectionPoints(zip1)("ZipCodeProvider")
    Dim connPoint As ConsumerConnectionPoint = _
      mgr.GetConsumerConnectionPoints(weather1)("ZipCodeConsumer")
    mgr.ConnectWebParts(zip1, provPoint, weather1, connPoint)

  End Sub
  
  Protected Sub Button2_Click(ByVal sender as Object, _
    ByVal e as System.EventArgs)
    
    If mgr.Connections.Count >= 1 AndAlso _
      mgr.Connections(0) IsNot Nothing Then
      mgr.DisconnectWebParts(mgr.Connections(0))
    End If
    
  End Sub

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
        OnClick="Button1_Click" />
      <asp:Button ID="Button2" runat="server" 
        Text="Disconnect WebPart Controls" 
        OnClick="Button2_Click" />
    </div>
    </form>
</body>
</html>
<!-- </snippet1> -->