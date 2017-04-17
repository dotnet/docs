<!-- <snippet1> -->
<%@ page language="c#" %>
<%@ register TagPrefix="uc1" 
  TagName="DisplayModeMenuCS" 
  Src="DisplayModeMenuCS.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  
protected void Page_Load(object sender, EventArgs e)
{
  Button1.Visible = false;
  TextBox1.Visible = false;
}

// <snippet3>
protected void Button1_Click(object sender, EventArgs e)
{
  DeclarativeCatalogPart1.WebPartsListUserControlPath =
    Server.HtmlEncode(TextBox1.Text);
}
// </snippet3>

// <snippet4>
protected void DeclarativeCatalogPart1_PreRender(object sender,
  EventArgs e)
{
  Button1.Visible = true;
  TextBox1.Visible = true;
}
// </snippet4> 

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
        Text="Update WebPartsListUserControlPath property" 
        OnClick="Button1_Click" />
      <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
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
            OnPreRender="DeclarativeCatalogPart1_PreRender"
            WebPartsListUserControlPath="webusercontrolcs.ascx">
            <WebPartsTemplate>
              <asp:Calendar ID="Calendar1" runat="server" 
                Title="My Calendar" 
                Description="ASP.NET Calendar control used as a personal calendar." />
            </WebPartsTemplate>              
          </asp:DeclarativeCatalogPart>
        </ZoneTemplate>
      </asp:CatalogZone>
      <!-- </snippet2> --> 
    </form>
  </body>
</html>
<!-- </snippet1> -->