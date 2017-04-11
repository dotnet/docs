<!-- <snippet1> -->
<%@ Page Language="C#" %>
<%@ register TagPrefix="uc1" 
  TagName="DisplayModeMenuCS" 
  Src="DisplayModeMenuCS.ascx" %>
  
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
  
  // <snippet3>
  protected void Button1_Click(object sender, EventArgs e)
  {
    
    Label1.Text = "<h3>DeclarativeCatalogPart Property Values</h3>" +
      "Display Title: " + DeclarativeCatalogPart1.DisplayTitle + 
      "<br />" + 
      "Description: " + DeclarativeCatalogPart1.Description + 
      "<br />" + 
      "Chrome type: " + DeclarativeCatalogPart1.ChromeType.ToString();
  }

  protected void WebPartManager1_DisplayModeChanged(object sender, 
    WebPartDisplayModeEventArgs e)
  {
    Label1.Text = String.Empty;
    if (WebPartManager1.DisplayMode == WebPartManager.CatalogDisplayMode)
      Button1.Visible = true;
    else
      Button1.Visible = false;
  }
  // </snippet3>
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CatalogPart Samples</title>
</head>
<body>
  <form id="form1" runat="server">
    <asp:WebPartManager ID="WebPartManager1" runat="server" 
      OnDisplayModeChanged="WebPartManager1_DisplayModeChanged" />
    <uc1:DisplayModeMenuCS ID="DisplayModeMenu1" runat="server" />
    <asp:WebPartZone ID="WebPartZone1" runat="server">
      <ZoneTemplate>
        <asp:AdRotator ID="AdRotator1" runat="server" 
          AdvertisementFile="~/quotes.xml" 
          Title="Favorite Quotes"  />         
      </ZoneTemplate>
    </asp:WebPartZone>
    <!-- <snippet2> -->
    <asp:CatalogZone ID="CatalogZone1" runat="server">
      <ZoneTemplate>
        <asp:DeclarativeCatalogPart 
          ID="DeclarativeCatalogPart1" 
          runat="server"
          Title="Controls to Add"
          ChromeType="TitleOnly"
          Description="Provides a list of controls that users can
            add to the page.">
          <WebPartsTemplate>
            <asp:Calendar ID="Calendar1" runat="server" 
              Title="My Calendar" />         
          </WebPartsTemplate>
        </asp:DeclarativeCatalogPart>
        <asp:PageCatalogPart ID="PageCatalogPart1" runat="server" />
        <asp:importcatalogpart id="ImportCatalogPart1" runat="server" />
      </ZoneTemplate>
    </asp:CatalogZone>
    <!-- </snippet2> -->
    <hr />
    <asp:Button ID="Button1" runat="server" 
      Text="Display DeclarativeCatalogPart Properties" 
      OnClick="Button1_Click" 
      Visible="false"/>
    <br />
    <asp:Label ID="Label1" runat="server" Text="" />
  </form>
</body>
</html>
<!-- </snippet1> -->