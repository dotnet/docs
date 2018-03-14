<!-- <snippet1> -->
<%@ Page Language="C#" %>
<%@ register TagPrefix="uc1" 
  TagName="DisplayModeMenuCS" 
  Src="DisplayModeMenuCS.ascx" %>
<%@ Register TagPrefix="aspSample"
  Namespace="Samples.AspNet.CS.Controls" 
  Assembly="TextDisplayWebPartCS" %> 

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  // <snippet2>
  protected void Button1_Click(object sender, EventArgs e)
  {
    ArrayList list = new ArrayList(2);
    list.Add(PageCatalogPart1);
    list.Add(DeclarativeCatalogPart1);
    // Pass an ICollection object to the constructor.
    CatalogPartCollection myParts = new CatalogPartCollection(list);
    foreach (CatalogPart catalog in myParts)
    {
      catalog.Description = "My " + catalog.DisplayTitle;
    }

    // Use the IndexOf property to locate a CatalogPart control.
    int PageCatalogPartIndex = myParts.IndexOf(PageCatalogPart1);
    myParts[PageCatalogPartIndex].ChromeType = PartChromeType.TitleOnly;

    // Use the Contains method to see if a CatalogPart control exists.
    if (myParts.Contains(PageCatalogPart1))
    {
      WebPart closedWebPart = null;
      WebPartDescriptionCollection descriptions = PageCatalogPart1.GetAvailableWebPartDescriptions();
      if (descriptions.Count > 0)
      {
        closedWebPart = PageCatalogPart1.GetWebPart(descriptions[0]);
        closedWebPart.AllowClose = false;
      }
    }
    
    // Use indexers to display the details of the CatalogPart controls.
    Label1.Text = String.Empty;
    Label1.Text =
      "<h3>PageCatalogPart Details</h3>" +
      "ID: " + myParts[0].ID + "<br />" +
      "Count: " + myParts[0].GetAvailableWebPartDescriptions().Count;
    Label1.Text += 
      "<h3>DeclarativeCatalogPart Details</h3>" +
      "ID: " + myParts["DeclarativeCatalogPart1"].ID + "<br />" +
      "Count: " + myParts["DeclarativeCatalogPart1"].GetAvailableWebPartDescriptions().Count;
  }
  // </snippet2>
</script> 
 
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>PageCatalogPart Details</title>
</head>
<body>
  <form id="form1" runat="server">
    <asp:WebPartManager ID="WebPartManager1" runat="server" />
    <uc1:DisplayModeMenuCS ID="DisplayModeMenu1" runat="server" />
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