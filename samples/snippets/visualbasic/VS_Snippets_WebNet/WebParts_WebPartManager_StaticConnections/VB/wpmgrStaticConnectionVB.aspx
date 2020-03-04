<!-- <snippet1> -->
<%@ Page Language="vb" %>
<%@ register TagPrefix="uc1" 
  TagName="DisplayModeMenuVB" 
  Src="DisplayModeMenuVB.ascx" %>
<%@ register tagprefix="aspSample" 
  Namespace="Samples.AspNet.VB.Controls" 
  Assembly="ConnectionSampleVB"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Protected Sub Page_Load(ByVal sender As Object, _
    ByVal e As System.EventArgs)
    
    ' Define provider, consumer, and connection points.
    Dim provider As WebPart = mgr.WebParts("zip1")
    Dim provConnPoint As ProviderConnectionPoint = _
      mgr.GetProviderConnectionPoints(provider)("ZipCodeProvider")
    Dim consumer As WebPart = mgr.WebParts("weather1")
    Dim consConnPoint As ConsumerConnectionPoint = _
      mgr.GetConsumerConnectionPoints(consumer)("ZipCodeConsumer")
    
    ' Check whether the connection already exists.
    If mgr.CanConnectWebParts(provider, provConnPoint, _
      consumer, consConnPoint) Then
      ' Create a new static connection.
      Dim conn As New WebPartConnection()
      conn.ID = "staticConn1"
      conn.ConsumerID = "weather1"
      conn.ConsumerConnectionPointID = "ZipCodeConsumer"
      conn.ProviderID = "zip1"
      conn.ProviderConnectionPointID = "ZipCodeProvider"
      mgr.StaticConnections.Add(conn)
    End If
    
  End Sub
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
      <!-- Reference the WebPartManager control. -->
      <asp:WebPartManager ID="mgr" runat="server" />   
    <div>
      <uc1:DisplayModeMenuVB ID="displaymode1" 
        runat="server" />
      <!-- Reference consumer and provider controls 
           in a zone. -->
      <asp:WebPartZone ID="WebPartZone1" runat="server">
        <ZoneTemplate>
          <aspSample:ZipCodeWebPart ID="zip1" 
            runat="server" 
            Title="Zip Code Control"/>
          <aspSample:WeatherWebPart ID="weather1" 
            runat="server" 
            Title="Weather Control" />
        </ZoneTemplate>
      </asp:WebPartZone>
      <hr />
      <!-- Add a ConnectionsZone so users can connect 
           controls. -->
      <asp:ConnectionsZone ID="ConnectionsZone1" 
        runat="server" />
    </div>
    </form>
</body>
</html>
<!-- </snippet1> -->