<!-- <snippet1> -->
<%@ Page Language="C#" %>
<%@ Register TagPrefix="uc1"
    TagName="DisplayModeMenuCS"
    Src="~/DisplayModeMenuCS.ascx" %>
<%@ Register TagPrefix="aspSample" 
    Namespace="Samples.AspNet.CS.Controls"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  // <snippet2>
  protected void Button1_Click(object sender, EventArgs e)
  {
    Label1.Text = String.Empty;
    
    WebPartDescriptionCollection descriptions = 
      DeclarativeCatalogPart1.GetAvailableWebPartDescriptions();

    foreach (WebPartDescription desc in descriptions)
    {
      Label1.Text += "ID: " + desc.ID + "<br />" +
        "Title: " + desc.Title + "<br />" +
        "Description: " + desc.Description + "<br />" +
        "ImageUrl: " + desc.CatalogIconImageUrl + "<br />" +
        "<hr />";
    }
  }
  // </snippet2>

  protected void Page_PreRender(object sender, EventArgs e)
  {
    if (mgr1.DisplayMode == WebPartManager.CatalogDisplayMode)
    {
      Button1.Visible = true;
      Label1.Visible = true;
    }
    else
    {
      Button1.Visible = false;
      Label1.Visible = false;
    }
  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  <title>Untitled Page</title>
</head>
<body>
  <form id="form1" runat="server">
    <asp:WebPartManager ID="mgr1" runat="server">
    </asp:WebPartManager>
    <uc1:DisplayModeMenuCS ID="menu1" runat="server" />
    <asp:WebPartZone ID="WebPartZone1" runat="server">
      <ZoneTemplate>
        <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
      </ZoneTemplate>
    </asp:WebPartZone>
    <asp:CatalogZone ID="CatalogZone1" runat="server">
      <ZoneTemplate>
        <asp:DeclarativeCatalogPart ID="DeclarativeCatalogPart1" runat="server">
          <WebPartsTemplate>
            <aspSample:TextDisplayWebPart ID="txtDisplayWebPart1" runat="server"
              Title="Text Display"
              Description="Displays entered text in a label control."
              CatalogIconImageUrl="MyWebPartIcon.gif" 
              />
            <asp:BulletedList 
              ID="BulletedList1"
              Runat="server"
              DisplayMode="HyperLink" 
              Title="Favorite Links"
              CatalogIconImageUrl="MyLinksIcon.gif"
              Description="My Favorite Links">
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
          </WebPartsTemplate>
        </asp:DeclarativeCatalogPart>
      </ZoneTemplate>
    </asp:CatalogZone> 
    <hr />
    <asp:Button ID="Button1" runat="server" 
      Text="List WebPartDescription Info" OnClick="Button1_Click" /> 
    <br />
    <asp:Label ID="Label1" runat="server" Text="" />
    <div>
    </div>
  </form>
</body>
</html>
<!-- </snippet1> -->