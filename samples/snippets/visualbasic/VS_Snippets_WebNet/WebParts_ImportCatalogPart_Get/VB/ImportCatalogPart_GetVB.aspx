<!-- <snippet1> -->
<%@ page language="vb" %>
<%@ register TagPrefix="uc1" 
  TagName="DisplayModeMenuVB" 
  Src="DisplayModeMenuVB.ascx" %>
<%@ register tagprefix="aspSample" 
  Namespace="Samples.AspNet.VB.Controls" %>
  
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

' <snippet3>
Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
    Dim descriptions As WebPartDescriptionCollection = _
      ImportCatalogPart1.GetAvailableWebPartDescriptions()
    Dim descriptionContent As StringBuilder = New StringBuilder()
    Dim description As WebPartDescription
    For Each description In descriptions
      descriptionContent.AppendLine("<div><br /><strong>" + _
        description.Title + "</strong><br />")
      descriptionContent.AppendLine("&nbsp;ID: " + _
        description.ID + "<br />")
      descriptionContent.AppendLine("&nbsp;Description: " + _
        description.Description + "<br /></div><hr />")
    Next description

    Label1.Text = "<h3>Catalog Contents</h3>" + descriptionContent.ToString()
End Sub
' </snippet3>

' <snippet4>
Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs)
    Dim descriptions As WebPartDescriptionCollection = _
      ImportCatalogPart1.GetAvailableWebPartDescriptions
    If (descriptions.Count > 0) Then
        Dim partToAdd As WebPart = ImportCatalogPart1.GetWebPart(descriptions(0))
        WebPartManager1.AddWebPart(partToAdd, zone1, 0)
    End If
End Sub
' </snippet4>

Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
    Button1.Visible = false
    Button2.Visible = false
    Label1.Visible = false
End Sub

Protected Sub ImportCatalogPart1_PreRender(ByVal sender As Object, ByVal e As EventArgs)
    Button1.Visible = true
    Button2.Visible = true
    Label1.Visible = true
End Sub

</script>


<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>
      ImportCatalogPart Control
    </title>
  </head>
  <body>
    <form id="form1" runat="server">
      <asp:webpartmanager id="WebPartManager1" runat="server"  />
      <uc1:DisplayModeMenuVB ID="DisplayModeMenu1" runat="server" />
      <asp:webpartzone id="zone1" runat="server" >
        <PartTitleStyle BorderWidth="1"
          Font-Names="Verdana, Arial"
          Font-Size="110%"
          BackColor="LightBlue" />
        <zonetemplate>
          <asp:Calendar ID="Calendar1" runat="server" Title="My Calendar" />
          <aspsample:textdisplaywebpart id="wp1" runat="server" 
            Title="Text Display WebPart" exportmode="all" 
            description="Dynamically displays text in a label"/>
          <aspsample:userinfowebpart id="wp2" runat="server" 
            Title="User Info WebPart" exportmode="all" 
            description="Gathers user information" />
        </zonetemplate>
      </asp:webpartzone> 
      <!-- <snippet2> -->
      <asp:CatalogZone ID="CatalogZone1" runat="server">
        <ZoneTemplate>
          <asp:ImportCatalogPart ID="ImportCatalogPart1" 
            runat="server" 
            OnPreRender="ImportCatalogPart1_PreRender" />
        </ZoneTemplate>
      </asp:CatalogZone>
      <!-- </snippet2> -->
      <hr />
      <asp:Button ID="Button1" runat="server" 
        Text="Get WebPart Description" 
        OnClick="Button1_Click" />
      <br />
      <asp:Button ID="Button2" runat="server" 
        Text="Use GetWebPart" 
        OnClick="Button2_Click" />
      <asp:Label ID="Label1" runat="server" Text=""></asp:Label>  
    </form>
  </body>
</html>
<!-- </snippet1> -->