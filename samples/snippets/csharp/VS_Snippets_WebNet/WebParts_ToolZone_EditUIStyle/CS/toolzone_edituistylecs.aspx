<!-- <snippet1> -->
<%@ Page Language="C#" %>
<%@ register TagPrefix="uc1" 
  TagName="DisplayModeMenuCS" 
  Src="DisplayModeMenuCS.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

<script runat="server">

  void Button1_Click(object sender, EventArgs e)
  {
    EditorZone1.EditUIStyle.Font.Bold = true;
  }
</script>
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
        <EditUIStyle BackColor="#6699cc" />
        <ZoneTemplate>
          <asp:AppearanceEditorPart ID="AppearanceEditorPart1" Runat="server" />
          <asp:LayoutEditorPart ID="LayoutEditorPart1" Runat="server" /> 
        </ZoneTemplate>
      </asp:EditorZone>
      <asp:Button ID="Button1" Runat="server" Text="Change Edit UI Font" OnClick="Button1_Click" />
      </div>
    </form>
</body>
</html>
<!-- </snippet1> -->