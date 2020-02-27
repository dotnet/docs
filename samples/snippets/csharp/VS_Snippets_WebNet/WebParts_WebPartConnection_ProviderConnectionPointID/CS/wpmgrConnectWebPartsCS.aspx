<!-- <snippet1> -->
<%@ Page Language="C#" %>
<%@ Register TagPrefix="uc1" 
    TagName="DisplayModeMenuCS"
    Src="~/displaymodemenucs.ascx" %>
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
    WebPartConnection conn1 = mgr.ConnectWebParts(zip1, provPoint,
      weather1, connPoint);
  }

  protected void Button2_Click(object sender, EventArgs e)
  {

    ProviderConnectionPoint connpoint = 
      mgr.Connections[0].ProviderConnectionPoint;
    
    lbl2.Text = "<h3>Provider Connection Points Details</h3>" +
      "Display name: " + connpoint.DisplayName +
      "<br />" +
      "Connection Point ID: " + mgr.Connections[0].ProviderConnectionPointID;

  }


  protected void mgr_DisplayModeChanged(object sender, WebPartDisplayModeEventArgs e)
  {
    if (mgr.DisplayMode == WebPartManager.ConnectDisplayMode)
    {
      Button1.Visible = true;
      Button2.Visible = true;
    }
    else
    {
      Button1.Visible = false;
      Button2.Visible = false;
    }

  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
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
      <uc1:DisplayModeMenuCS ID="menu1" runat="server" />
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
        Text="Connect WebPart Controls" 
        OnClick="Button1_Click" 
        Visible="false" />
      <br />
      <asp:Button ID="Button2" runat="server" 
        Text="ConnectionPoint Details" 
        OnClick="Button2_Click" 
        Visible="false" /> 
      <br />   
      <asp:Label ID="lbl2" runat="server" />
    </div>
    </form>
</body>
</html>
<!-- </snippet1> -->