<!-- <snippet1> -->
<%@ Page Language="vb" %>
<%@ register TagPrefix="uc1" 
  TagName="DisplayModeMenuVB" 
  Src="DisplayModeMenuVB.ascx" %>
<%@ register tagprefix="aspSample" 
  Namespace="Samples.AspNet.VB.Controls" 
  Assembly="ConnectionSampleVB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Protected Sub WebPartManager1_WebPartsConnected( _
    ByVal sender As Object, _
    ByVal e As System.Web.UI.WebControls.WebParts.WebPartConnectionsEventArgs)
    
    UpdateLabelData(WebPartManager1.WebParts.Count, _
      WebPartManager1.Connections.Count)
    
  End Sub

  Protected Sub WebPartManager1_WebPartsDisconnected( _
    ByVal sender As Object, _
    ByVal e As System.Web.UI.WebControls.WebParts.WebPartConnectionsEventArgs)
    
    UpdateLabelData(WebPartManager1.WebParts.Count, _
      WebPartManager1.Connections.Count)
    
  End Sub
  
  Private Sub UpdateLabelData(ByVal wpCount As Integer, _
    ByVal connCount As Integer)
    
    Label1.Text = "WebPart Control Count:  " & wpCount.ToString()
    Label2.Text = "Connections Count: " & connCount.ToString()
    
  End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
      <!-- Reference the WebPartManager control. -->
      <asp:WebPartManager ID="WebPartManager1" runat="server" OnWebPartsConnected="WebPartManager1_WebPartsConnected" OnWebPartsDisconnected="WebPartManager1_WebPartsDisconnected" />
    <div>
      <uc1:DisplayModeMenuVB ID="displaymode1" runat="server" />
      <!-- Reference consumer and provider controls in a zone. -->
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
      <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
      <br />
      <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
      <!-- Add a ConnectionsZone so users can connect controls. -->
      <asp:ConnectionsZone ID="ConnectionsZone1" runat="server" />
    </div>
    </form>
</body>
</html>
<!-- </snippet1> -->