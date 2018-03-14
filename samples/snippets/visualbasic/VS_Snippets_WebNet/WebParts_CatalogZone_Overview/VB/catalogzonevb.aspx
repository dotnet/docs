<!-- <snippet2> -->
<%@ Page Language="vb" %>
<%@ register TagPrefix="uc1" 
  TagName="DisplayModeMenuVB" 
  Src="DisplayModeMenuVB.ascx" %>
<%@ Register TagPrefix="aspSample"
  Namespace="Samples.AspNet.VB.Controls"  %> 

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
  
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
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
        <aspsample:textdisplaywebpart id="wp1" runat="server" 
           Title="My Text Display WebPart" />
      </ZoneTemplate>
    </asp:WebPartZone>
    <aspSample:MyCatalogZone ID="CatalogZone1" runat="server">
      <ZoneTemplate>
        <asp:ImportCatalogPart id="ImportCatalogPart1" 
          runat="server" />
      </ZoneTemplate>
    </aspSample:MyCatalogZone>
  </form>
</body>
</html>
<!-- </snippet2> -->