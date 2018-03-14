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

  Protected Sub Page_PreRender(ByVal sender As Object, _
    ByVal e As System.EventArgs)
    
    ' Clear the label if it has a previously set value.
    Label1.Text = String.Empty
    
    ' Cast the WebPartManager to the IPersonalizable interface 
    ' so that you can access the property.
    Dim stateData As IPersonalizable = CType(mgr1, IPersonalizable)
    If stateData.IsDirty Then
      Label1.Text = "WebPartManager personalization data is dirty."
    End If
    
  End Sub
    
  Protected Sub Button1_Click(ByVal sender As Object, _
    ByVal e As System.EventArgs)

    Dim provPoint As ProviderConnectionPoint = _
      mgr1.GetProviderConnectionPoints(zip1)("ZipCodeProvider")
    Dim connPoint As ConsumerConnectionPoint = _
      mgr1.GetConsumerConnectionPoints(weather1)("ZipCodeConsumer")
    Dim conn1 As WebPartConnection = _
      mgr1.ConnectWebParts(zip1, provPoint, weather1, connPoint)
      
  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:WebPartManager ID="mgr1" runat="server" />
      <uc1:DisplayModeMenuVB ID="menu1" runat="server" />
      <asp:WebPartZone ID="WebPartZone1" runat="server">
        <ZoneTemplate>
          <aspSample:ZipCodeWebPart ID="zip1" runat="server"
            Title="Zip Code Provider" />
          <aspSample:WeatherWebPart ID="weather1" runat="server" 
            Title="Zip Code Consumer" />
        </ZoneTemplate>
      </asp:WebPartZone>
      <asp:WebPartZone ID="WebPartZone2" runat="server">
        <ZoneTemplate>
        </ZoneTemplate>
      </asp:WebPartZone>
      <asp:CatalogZone ID="CatalogZone1" runat="server">
        <ZoneTemplate>
          <asp:DeclarativeCatalogPart ID="DeclarativeCatalogPart1" 
            runat="server">
            <WebPartsTemplate>
              <asp:Calendar ID="Calendar1" runat="server" 
                Title="My Calendar" />
            </WebPartsTemplate>
          </asp:DeclarativeCatalogPart>
          <asp:PageCatalogPart ID="PageCatalogPart1" runat="server" />
        </ZoneTemplate>
      </asp:CatalogZone>
      <asp:ConnectionsZone ID="ConnectionsZone1" runat="server" />
      <asp:Button ID="Button1" runat="server" 
        Text="Connect WebPart Controls" 
        OnClick="Button1_Click" />
      <hr />
      <asp:Label ID="Label1" runat="server" 
        Text="" 
        Font-Bold="true" />
    </div>
    </form>
</body>
</html>
<!-- </snippet1> -->