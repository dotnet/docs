<!-- <Snippet1> -->
<%@ Page Language="VB" %>
<%@ register tagprefix="aspSample" 
  Namespace="Samples.AspNet.VB.Controls" %>
<%@ Register TagPrefix="uc1" TagName="DisplayModeMenuVB" Src="~/DisplayModeMenuVB.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
  <title>Web Parts Page</title>
</head>
<body>
  <h1>Web Parts Demonstration Page</h1>
  <form runat="server" id="form1">
<asp:webpartmanager id="WebPartManager1" runat="server" />
<uc1:DisplayModeMenuVB runat="server" ID="DisplayModeMenu" />
  <br />
  <table cellspacing="0" cellpadding="0" border="0">
    <tr>
      <td valign="top">
    <asp:webpartzone id="SideBarZone" runat="server" 
        headertext="Sidebar">
        <zonetemplate>
        </zonetemplate>
      </asp:webpartzone>
      <aspSample:MyCatalogZone ID="CatalogZone1" runat="server">
      <ZoneTemplate>
          <asp:ImportCatalogPart ID="ImportCatalog" runat="server" />
      </ZoneTemplate>
    </aspSample:MyCatalogZone>
      </td>
      <td valign="top">
    <asp:webpartzone id="MainZone" runat="server" headertext="Main">
         <zonetemplate>
        <asp:label id="contentPart" runat="server" Title="Content">
              <h2>Welcome to My Home Page</h2>
              <p>Use links to visit my favorite sites!</p>
            </asp:label>
         </zonetemplate>
       </asp:webpartzone>
      </td>
      <td valign="top">
      </td>
    </tr>
  </table>
  </form>
</body>
</html>
<!-- </Snippet1> -->
