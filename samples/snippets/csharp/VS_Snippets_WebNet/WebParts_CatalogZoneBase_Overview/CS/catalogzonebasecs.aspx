<!-- <snippet1> -->
<%@ page language="c#" %>
<%@ register TagPrefix="uc1" 
  TagName="DisplayModeMenuCS" 
  Src="DisplayModeMenucs.ascx" %>
<%@ register tagprefix="aspSample" 
  Namespace="Samples.AspNet.CS.Controls" 
  Assembly="TextDisplayWebPartCS" %>
  
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  WebPartManager manager;

  protected void WebPartManager1_DisplayModeChanged(object sender,
    WebPartDisplayModeEventArgs e)
  {
    if (e.OldDisplayMode.Name != "Catalog")
      Panel1.Visible = true;
    else
      Panel1.Visible = false;
  }
  
  // <snippet3>
  protected void Button1_Click(object sender, EventArgs e)
  {
    if (CatalogZone1.AddVerb.Enabled)
    {
      CatalogZone1.AddVerb.Enabled = false;
      CatalogZone1.CloseVerb.Enabled = false;
    }
    else
    {
      CatalogZone1.AddVerb.Enabled = true;
      CatalogZone1.CloseVerb.Enabled = true;
    }
  }
  // </snippet3>

  // <snippet4>
  protected void Button2_Click(object sender, EventArgs e)
  {
    Label1.Text = "<h3>CatalogPart List</h3>";
    foreach(CatalogPart part in CatalogZone1.CatalogParts)
    {
      Label1.Text += part.ID + "<br />";
    }
  }
  // </snippet4>

  // <snippet5>
  protected void Button3_Click(object sender, EventArgs e)
  {
    CatalogZone1.SelectTargetZoneText = "Add to zone";
    CatalogZone1.EmptyZoneText = "Zone is empty";
    CatalogZone1.HeaderText = "My Updated Header";
    CatalogZone1.InstructionText = "My Updated Instructions";
  }
  // </snippet5>

  // <snippet6>
  protected void Button4_Click(object sender, EventArgs e)
  {
    Label1.Text = CatalogZone1.SelectedCatalogPartID;
  }
  // </snippet6>

  // <snippet7>
  protected void Button5_Click(object sender, EventArgs e)
  {
    CatalogZone1.PartLinkStyle.ForeColor = System.Drawing.Color.Red;
    CatalogZone1.SelectedPartLinkStyle.ForeColor = 
      System.Drawing.Color.Blue;
  }
  // </snippet7>

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>
      CatalogZoneBase Example
    </title>
  </head>
  <body>
    <form id="form1" runat="server">
      <asp:webpartmanager id="WebPartManager1" runat="server" 
        OnDisplayModeChanged="WebPartManager1_DisplayModeChanged" />
      <uc1:DisplayModeMenuCS ID="DisplayModeMenu1" runat="server" />
      <asp:webpartzone id="zone1" runat="server">
        <zonetemplate>
          <asp:BulletedList 
            ID="BulletedList1" 
            Runat="server"
            DisplayMode="HyperLink" 
            Title="Favorite Links" >
            <asp:ListItem Value="http://msdn.microsoft.com">
              MSDN
            </asp:ListItem>
            <asp:ListItem Value="http://www.asp.net">
              ASP.NET
            </asp:ListItem>
            <asp:ListItem Value="http://www.msn.com">
              MSN
            </asp:ListItem>
          </asp:BulletedList>
        </ZoneTemplate>        
      </asp:webpartzone>
      <!-- <snippet2> -->
      <asp:CatalogZone ID="CatalogZone1" runat="server"
        EmptyZoneText="No controls are in the zone."
        HeaderText="My Web Parts Catalog"
        InstructionText="Add Web Parts controls to the zone."
        PartLinkStyle-Font-Italic="true"
        SelectedPartLinkStyle-Font-Bold="true"
        SelectTargetZoneText="Select zone"
        AddVerb-Text="Add Control"
        CloseVerb-Description="Close and return to browse mode." 
        SelectedCatalogPartID="Currently Selected CatalogPart ID.">
        <ZoneTemplate>
          <asp:DeclarativeCatalogPart ID="DeclarativeCatalogPart1" 
            runat="server">
            <WebPartsTemplate>
              <aspSample:TextDisplayWebPart 
                runat="server"   
                id="textwebpart" 
                title = "Text Content WebPart" 
                ExportMode="All"/>  
              <asp:Calendar id="calendar1" runat="server" 
                Title="My Calendar" />               
            </WebPartsTemplate>
          </asp:DeclarativeCatalogPart> 
          <asp:PageCatalogPart ID="PageCatalogPart1" runat="server" />
          <asp:ImportCatalogPart ID="ImportCatalogPart1" runat="server" /> 
        </ZoneTemplate>
      </asp:CatalogZone>
      <hr />
      <asp:CatalogZone ID="CatalogZone2" runat="server"
        BorderWidth="2"
        HeaderText="My Empty CatalogZone"
        EmptyZoneText="No controls are in the zone." />
      <!-- </snippet2> -->
      <hr />
      <asp:Panel ID="Panel1" runat="server" Visible="false">
        <asp:Button ID="Button1" runat="server" Width="200" 
          Text="Enable or Disable Verbs" 
          OnClick="Button1_Click" />
        <br />
        <asp:Button ID="Button2" runat="server" Width="200" 
          Text="List CatalogParts" OnClick="Button2_Click" />  
        <br />
        <asp:Button ID="Button3" runat="server" Width="200" 
          Text="Set Zone Text Properties" OnClick="Button3_Click" />  
        <br />   
        <asp:Button ID="Button4" runat="server" Width="200" 
          Text="Show Selected CatalogPart ID" OnClick="Button4_Click"  />  
        <br /> 
        <asp:Button ID="Button5" runat="server" Width="200" 
          Text="Change Part Link Styles" OnClick="Button5_Click"  />  
        <br />     
        <asp:Label ID="Label1" runat="server" Text="" /></asp:Panel>
    </form>
  </body>
</html>
<!-- </snippet1> -->