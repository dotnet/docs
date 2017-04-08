<!-- <snippet1> -->
<%@ page language="vb" %>
<%@ register TagPrefix="uc1" 
  TagName="DisplayModeMenuVB" 
  Src="DisplayModeMenuvb.ascx" %>
<%@ register tagprefix="aspSample" 
  Namespace="Samples.AspNet.VB.Controls" 
  Assembly="TextDisplayWebPartVB" %>
  
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">


  Dim manager As WebPartManager


  Protected Sub WebPartManager1_DisplayModeChanged(ByVal sender _
    As Object, ByVal e As WebPartDisplayModeEventArgs)
    If e.OldDisplayMode.Name <> "Catalog" Then
      Panel1.Visible = True
    Else
      Panel1.Visible = False
    End If

  End Sub
   
  ' <snippet3>
  Protected Sub Button1_Click(ByVal sender As Object, _
    ByVal e As EventArgs)
    If CatalogZone1.AddVerb.Enabled Then
      CatalogZone1.AddVerb.Enabled = False
      CatalogZone1.CloseVerb.Enabled = False
    Else
      CatalogZone1.AddVerb.Enabled = True
      CatalogZone1.CloseVerb.Enabled = True
    End If

  End Sub
  ' </snippet3>
  
  ' <snippet4>
  Protected Sub Button2_Click(ByVal sender As Object, _
    ByVal e As EventArgs)
    Label1.Text = "<h3>CatalogPart List</h3>"
    Dim part As CatalogPart
    For Each part In CatalogZone1.CatalogParts
      Label1.Text += part.ID + "<br />"
    Next part

  End Sub
  ' </snippet4>
  
  ' <snippet5>
  Protected Sub Button3_Click(ByVal sender As Object, _
    ByVal e As EventArgs)
    CatalogZone1.SelectTargetZoneText = "Add to zone"
    CatalogZone1.EmptyZoneText = "Zone is empty"
    CatalogZone1.HeaderText = "My Updated Header"
    CatalogZone1.InstructionText = "My Updated Instructions"
  End Sub
  ' </snippet5>
  
  ' <snippet6>
  Protected Sub Button4_Click(ByVal sender As Object, _
    ByVal e As EventArgs)
    Label1.Text = CatalogZone1.SelectedCatalogPartID
  End Sub
  ' </snippet6>
  
  ' <snippet7>
  Protected Sub Button5_Click(ByVal sender As Object, _
    ByVal e As EventArgs)
    CatalogZone1.PartLinkStyle.ForeColor = _
      System.Drawing.Color.Red
    CatalogZone1.SelectedPartLinkStyle.ForeColor = _
      System.Drawing.Color.Blue
  End Sub
  ' </snippet7>
  
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
      <uc1:DisplayModeMenuVB ID="DisplayModeMenu1" runat="server" />
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