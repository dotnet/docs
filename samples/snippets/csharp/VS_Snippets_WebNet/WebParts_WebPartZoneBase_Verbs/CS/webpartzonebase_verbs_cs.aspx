<!-- <snippet1> -->
<%@ Page Language="C#" 
  Codefile="webpartzonebase_verbs.cs"
  Inherits="WebPartZoneBase_verbs"  %>
<%@ register TagPrefix="uc1" 
  TagName="DisplayModeMenuCS" 
  Src="DisplayModeMenuCS.ascx" %>
<%@ register tagprefix="aspSample" 
  Namespace="Samples.AspNet.CS.Controls" 
  Assembly="TextDisplayWebPartCS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>WebPartZoneBase Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:WebPartManager ID="WebPartManager1" Runat="server" />
      <uc1:DisplayModeMenuCS ID="DisplayModeMenu1" runat="server" />
      <!-- <snippet2> -->
      <asp:WebPartZone ID="WebPartZone1" Runat="server">
        <CloseVerb Text="Close WebPart" />
        <HelpVerb Text="View Help" />
        <ExportVerb Text="Export WebPart Definition" />
        <DeleteVerb Text ="Delete WebPart" />
        <MinimizeVerb Description="Minimize the control" />
        <RestoreVerb Description="Restore the control" />
        <ZoneTemplate>
        </ZoneTemplate>  
      </asp:WebPartZone>
      <!-- </snippet2> -->
      <!-- <snippet3> -->
      <asp:CatalogZone ID="CatalogZone1" Runat="server">
        <ZoneTemplate>
          <asp:DeclarativeCatalogPart ID="DeclarativeCatalogPart1" 
            Runat="server">
            <WebPartsTemplate>
              <aspSample:TextDisplayWebPart 
                runat="server"   
                id="textwebpart" 
                title = "Text Content WebPart" 
                width="350px" 
                AllowClose="true"
                ExportMode="All"
                HelpMode="Modal"
                HelpUrl="TextWebPartHelp.htm" />            
            </WebPartsTemplate>
          </asp:DeclarativeCatalogPart> 
          <asp:PageCatalogPart ID="PageCatalogPart1" Runat="server" />
        </ZoneTemplate>
      </asp:CatalogZone>
      <!-- </snippet3> -->
      <asp:Table ID="Table1" Runat="server">
        <asp:TableRow>
          <asp:TableCell>
            <asp:CheckBoxList ID="CheckBoxList1" Runat="server" 
              AutoPostBack="true" 
              OnSelectedIndexChanged="CheckBoxList1_SelectedItemIndexChanged">
              <asp:ListItem Value="close">Close Verb Enabled</asp:ListItem>
              <asp:ListItem Value="delete">Delete Verb Enabled</asp:ListItem>
              <asp:ListItem Value="export">Export Verb Enabled</asp:ListItem>
              <asp:ListItem Value="minimize">Minimize Verb Enabled</asp:ListItem>
              <asp:ListItem Value="restore">Restore Verb Enabled</asp:ListItem>
            </asp:CheckBoxList>
          </asp:TableCell>
        </asp:TableRow>
      </asp:Table>
    </div>
    </form>
</body>
</html>
<!-- </snippet1> -->