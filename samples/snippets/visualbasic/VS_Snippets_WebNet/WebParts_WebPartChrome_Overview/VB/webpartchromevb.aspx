<!-- <snippet1> -->
<%@ Page Language="vb" %>
<%@ Register TagPrefix="uc1" 
  TagName="DisplayModeMenuVB"
  Src="~/DisplayModeMenuVB.ascx" %>
<%@ Register TagPrefix="aspSample" 
  Namespace="Samples.AspNet.VB.Controls" 
  Assembly="MyChromeVB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
  <form id="form1" runat="server">
    <asp:WebPartManager ID="WebPartManager1" runat="server" />
    <uc1:DisplayModeMenuVB id="menu1" runat="server" />
    <aspSample:MyZone ID="WebPartZone1" runat="server"
      RenderVerbsInMenu="true">
      <PartTitleStyle Font-Bold="true"
        BorderWidth="1" 
        BackColor="lightblue"/>
      <ZoneTemplate>
        <asp:Panel runat="server" id="panel1" 
          title="Vote on Issues" >
          <asp:RadioButtonList ID="RadioButtonList1" runat="server" >
            <asp:ListItem Value="1">Issue 1</asp:ListItem>
            <asp:ListItem Value="2">Issue 2</asp:ListItem>
            <asp:ListItem Value="3">Issue 3</asp:ListItem>
          </asp:RadioButtonList>
          <asp:Button ID="Button1" runat="server" Text="Cast Vote" />
        </asp:Panel>
        <asp:FileUpload ID="FileUpload1" runat="server" 
          title="Upload Files" />
      </ZoneTemplate>
    </aspSample:MyZone>
    <asp:WebPartZone ID="WebPartZone2" runat="server" />
    <asp:EditorZone ID="EditorZone1" runat="server">
      <ZoneTemplate>
        <asp:AppearanceEditorPart ID="AppearanceEditorPart1" runat="server" />
      </ZoneTemplate>
    </asp:EditorZone>
  </form>
</body>
</html>
<!-- </snippet1> -->