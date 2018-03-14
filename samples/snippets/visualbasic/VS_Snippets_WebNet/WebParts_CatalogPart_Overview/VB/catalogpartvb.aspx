<!-- <snippet1> -->
<%@ Page Language="vb" %>
<%@ register TagPrefix="uc1" 
  TagName="DisplayModeMenuVB" 
  Src="DisplayModeMenuVB.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
  ' <snippet3>
  Protected Sub Button1_Click(ByVal sender As Object, _
    ByVal e As EventArgs)
    
    Label1.Text = "<h3>DeclarativeCatalogPart Property Values</h3>" & _
      "Display Title: " & DeclarativeCatalogPart1.DisplayTitle & _
      "<br />" & _
      "Description: " & DeclarativeCatalogPart1.Description & _
      "<br />" & _
      "Chrome type: " & DeclarativeCatalogPart1.ChromeType.ToString()
    
  End Sub

  Protected Sub WebPartManager1_DisplayModeChanged(ByVal sender _
    As Object, ByVal e As WebPartDisplayModeEventArgs)
    Label1.Text = String.Empty
    If WebPartManager1.DisplayMode _
      Is WebPartManager.CatalogDisplayMode Then
      Button1.Visible = True
    Else
      Button1.Visible = False
    End If
  End Sub
  ' </snippet3>
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CatalogPart Samples</title>
</head>
<body>
  <form id="form1" runat="server">
    <asp:WebPartManager ID="WebPartManager1" runat="server" 
      OnDisplayModeChanged="WebPartManager1_DisplayModeChanged" />
    <uc1:DisplayModeMenuVB ID="DisplayModeMenu1" runat="server" />
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