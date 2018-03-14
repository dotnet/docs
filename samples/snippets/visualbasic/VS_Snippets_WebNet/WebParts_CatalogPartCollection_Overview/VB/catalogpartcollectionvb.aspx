<!-- <snippet1> -->
<%@ Page Language="vb" %>
<%@ register TagPrefix="uc1" 
  TagName="DisplayModeMenuVB" 
  Src="DisplayModeMenuVB.ascx" %>
<%@ Register TagPrefix="aspSample"
  Namespace="Samples.AspNet.VB.Controls" 
  Assembly="TextDisplayWebPartVB" %> 

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
' <snippet2>
Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) 
    Dim list As New ArrayList(2)
    list.Add(PageCatalogPart1)
    list.Add(DeclarativeCatalogPart1)
    ' Pass an ICollection object to the constructor.
    Dim myParts As New CatalogPartCollection(list)
    Dim catalog As CatalogPart
    For Each catalog In  myParts
        catalog.Description = "My " + catalog.DisplayTitle
    Next catalog
    
    ' Use the IndexOf property to locate a CatalogPart control.
    Dim PageCatalogPartIndex As Integer = _
      myParts.IndexOf(PageCatalogPart1)
    myParts(PageCatalogPartIndex).ChromeType = PartChromeType.TitleOnly
    
    ' Use the Contains method to see if a CatalogPart control exists.
    If myParts.Contains(PageCatalogPart1) Then
        Dim closedWebPart As WebPart = Nothing
        Dim descriptions As WebPartDescriptionCollection = _
          PageCatalogPart1.GetAvailableWebPartDescriptions()
        If descriptions.Count > 0 Then
            closedWebPart = PageCatalogPart1.GetWebPart(descriptions(0))
            closedWebPart.AllowClose = False
        End If
    End If
    
    ' Use indexers to display the details of the CatalogPart controls.
    Label1.Text = String.Empty
    Label1.Text = _
      "<h3>PageCatalogPart Details</h3>" & _
      "ID: " & myParts(0).ID + "<br />" & _
      "Count: " & myParts(0).GetAvailableWebPartDescriptions().Count
    Label1.Text += _
      "<h3>DeclarativeCatalogPart Details</h3>" & _
      "ID: " & myParts("DeclarativeCatalogPart1").ID & "<br />" & _
      "Count: " & myParts("DeclarativeCatalogPart1") _
        .GetAvailableWebPartDescriptions().Count

End Sub 
' </snippet2>
</script>  
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>PageCatalogPart Details</title>
</head>
<body>
  <form id="form1" runat="server">
    <asp:WebPartManager ID="WebPartManager1" runat="server" />
    <uc1:DisplayModeMenuVB ID="DisplayModeMenu1" runat="server" />
    <asp:WebPartZone ID="WebPartZone1" runat="server">
      <ZoneTemplate>
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
    </asp:WebPartZone>
    <asp:CatalogZone ID="CatalogZone1" runat="server">
      <ZoneTemplate>
        <asp:DeclarativeCatalogPart ID="DeclarativeCatalogPart1" runat="server">
          <WebPartsTemplate>
            <aspSample:TextDisplayWebPart runat="server" 
              id="TextDisplayWebPart1"
              Title="Text Display WebPart" />
          </WebPartsTemplate>
        </asp:DeclarativeCatalogPart>
        <asp:PageCatalogPart ID="PageCatalogPart1" runat="server" />  
      </ZoneTemplate>
    </asp:CatalogZone>
    <hr />
    <asp:Button ID="Button1" 
      runat="server" 
      Text="Display CatalogPart Properties" 
      OnClick="Button1_Click"/>
    <br />
    <asp:Label ID="Label1" runat="server" Text="" /> 
  </form>
</body>
</html>
<!-- </snippet1> -->