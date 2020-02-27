<!-- <snippet1> -->
<%@ page language="c#" %>
<%@ register TagPrefix="uc1" 
  TagName="DisplayModeMenuCS" 
  Src="DisplayModeMenuCS.ascx" %>
<%@ register tagprefix="aspSample" 
  Namespace="Samples.AspNet.CS.Controls" %>
  
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  // <snippet3>
  protected void Button1_Click(object sender, EventArgs e)
  {
    WebPartDescriptionCollection descriptions =
      ImportCatalogPart1.GetAvailableWebPartDescriptions();
    StringBuilder descriptionContent = new StringBuilder();
    foreach (WebPartDescription description in descriptions)
    {
      descriptionContent.AppendLine("<div><br /><strong>" + description.Title +
        "</strong><br />");
      descriptionContent.AppendLine("&nbsp;ID: " + description.ID + "<br />");
      descriptionContent.AppendLine("&nbsp;Description: " +
        description.Description + "<br /></div><hr />");
    }

    Label1.Text = "<h3>Catalog Contents</h3>" + descriptionContent.ToString();     

  }
  // </snippet3>

  // <snippet4>
  protected void Button2_Click(object sender, EventArgs e)
  {
    WebPartDescriptionCollection descriptions =
      ImportCatalogPart1.GetAvailableWebPartDescriptions();

    if (descriptions.Count > 0)
    {
      WebPart partToAdd =
        ImportCatalogPart1.GetWebPart(descriptions[0]);
      WebPartManager1.AddWebPart(partToAdd, zone1, 0);
    }
  }
  // </snippet4>
  
  protected void Page_Load(object sender, EventArgs e)
  {
    Button1.Visible = false;
    Button2.Visible = false;
    Label1.Visible = false;
  }

  protected void ImportCatalogPart1_PreRender(object sender, 
    EventArgs e)
  {
    Button1.Visible = true;
    Button2.Visible = true;
    Label1.Visible = true;
  }


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
      <uc1:DisplayModeMenuCS ID="DisplayModeMenu1" runat="server" />
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