<!-- <snippet1> -->
<%@ Page Language="C#" 
  Codefile="Toolzone_overview.cs"
  Inherits="Toolzone_overview_cs"  %>
<%@ register TagPrefix="uc1" 
  TagName="DisplayModeMenuCS" 
  Src="DisplayModeMenuCS.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Tool Zone Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:WebPartManager ID="WebPartManager1" Runat="server" />
      <uc1:DisplayModeMenuCS ID="DisplayModeMenu1" runat="server" />
      <asp:WebPartZone ID="WebPartZone1" Runat="server" >
        <ZoneTemplate>
          <asp:BulletedList 
            ID="BulletedList1" 
            Runat="server"
            DisplayMode="HyperLink" 
            Title="Favorite Links" >
            <asp:ListItem Value="http://msdn.microsoft.com">MSDN</asp:ListItem>
            <asp:ListItem Value="http://www.asp.net">ASP.NET</asp:ListItem>
            <asp:ListItem Value="http://www.msn.com">MSN</asp:ListItem>
          </asp:BulletedList>
        </ZoneTemplate>
      </asp:WebPartZone>
      <asp:EditorZone 
        ID="EditorZone1" 
        Runat="server">
        <HeaderVerbStyle Font-Underline="true" />
        <ZoneTemplate>
          <asp:AppearanceEditorPart ID="AppearanceEditorPart1" Runat="server" />
          <asp:LayoutEditorPart ID="LayoutEditorPart1" Runat="server" /> 
        </ZoneTemplate>
      </asp:EditorZone>
      <asp:CatalogZone ID="CatalogZone1" Runat="server">
        <LabelStyle Font-Italic="true" />
        <ZoneTemplate>
          <asp:DeclarativeCatalogPart ID="DeclarativeCatalogPart1" Runat="server">
            <WebPartsTemplate>
              <asp:Calendar ID="Calendar1" Runat="server" Title="My Calendar" />
            </WebPartsTemplate>
          </asp:DeclarativeCatalogPart>
        </ZoneTemplate>
      </asp:CatalogZone>
      <asp:Button ID="Button1" Runat="server" Text="Update Edit Zone Text" OnClick="Button1_Click" />
      <asp:TextBox ID="TextBox1" Runat="server"></asp:TextBox>
    </div>
    </form>
</body>
</html>
<!-- </snippet1> -->