<!-- <snippet1> -->
<%@ page language="c#" %>
<%@ register TagPrefix="uc1" 
  TagName="DisplayModeMenuCS" 
  Src="DisplayModeMenuCS.ascx" %>
<%@ register tagprefix="aspSample" 
  Namespace="Samples.AspNet.CS.Controls" 
  Assembly="UserInfoWebPartCS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  
  protected void Page_Load(object sender, EventArgs e)
  {
    Button1.Visible = false;
    Button2.Visible = false;
    Label1.Visible = false;
  }

  // <snippet3>
  protected void Button1_Click(object sender, EventArgs e)
  {
    WebPartDescriptionCollection descriptions =
      DeclarativeCatalogPart1.GetAvailableWebPartDescriptions();
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
      DeclarativeCatalogPart1.GetAvailableWebPartDescriptions();

    WebPart partToAdd = DeclarativeCatalogPart1.GetWebPart(descriptions[2]);
    WebPartManager1.AddWebPart(partToAdd, zone1, 0);   
  }
  // </snippet4>

  // <snippet5>
  protected void DeclarativeCatalogPart1_PreRender(object sender,
    EventArgs e)
  {
    Button1.Visible = true;
    Button2.Visible = true;
    Label1.Visible = true;
  }
  // </snippet5> 

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>
      DeclarativeCatalogPart Control
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
          <asp:BulletedList ID="BulletedList1" 
            Runat="server"
            DisplayMode="HyperLink"
            Title="Favorites">
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
        </zonetemplate>
      </asp:webpartzone> 
      <div>
      <hr />
      <asp:Button ID="Button1" runat="server" 
        Text="Display WebPart descriptions" 
        OnClick="Button1_Click" />
      <br />
      <asp:Button ID="Button2" runat="server" 
        Text="Add TextDisplayWebPart" OnClick="Button2_Click" />
      <asp:Label ID="Label1" runat="server" Text="" />
      </div>
      <!-- <snippet2> -->
      <asp:CatalogZone ID="CatalogZone1" runat="server">
        <ZoneTemplate>
          <asp:DeclarativeCatalogPart ID="DeclarativeCatalogPart1"  
            runat="server" 
            Title="Web Parts Catalog"
            ChromeType="TitleOnly" 
            Description="Contains a user control with Web Parts and 
              an ASP.NET Calendar control." 
            OnPreRender="DeclarativeCatalogPart1_PreRender">
            <WebPartsTemplate>
              <asp:Calendar ID="Calendar1" runat="server" 
                Title="My Calendar" 
                Description="ASP.NET Calendar control used as a personal 
                  calendar." />
              <aspSample:UserInfoWebPart 
                runat="server"   
                id="userinfo1" 
                title = "User Information WebPart"
                Description ="Contains custom, editable user information 
                  for display on a page." />
              <aspSample:TextDisplayWebPart 
                runat="server"   
                id="TextDisplayWebPart1" 
                title = "Text Display WebPart" 
                Description="Contains a label where users can dynamically 
                  update the text." />
            </WebPartsTemplate>              
          </asp:DeclarativeCatalogPart>
        </ZoneTemplate>
      </asp:CatalogZone>
      <!-- </snippet2> -->
    </form>
  </body>
</html>
<!-- </snippet1> -->