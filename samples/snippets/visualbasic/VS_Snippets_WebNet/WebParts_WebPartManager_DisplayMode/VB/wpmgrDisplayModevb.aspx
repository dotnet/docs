<!-- <snippet1> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  
  Protected Sub Button1_Click(ByVal sender As Object, _
    ByVal e As EventArgs)
    mgr.DisplayMode = WebPartManager.BrowseDisplayMode
  End Sub
  
  Protected Sub Button2_Click(ByVal sender As Object, _
    ByVal e As EventArgs)
    mgr.DisplayMode = WebPartManager.DesignDisplayMode
  End Sub
  
  Protected Sub Button3_Click(ByVal sender As Object, _
  ByVal e As EventArgs)
    mgr.DisplayMode = WebPartManager.EditDisplayMode
  End Sub
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:WebPartManager ID="mgr" runat="server">
      </asp:WebPartManager>
      <asp:WebPartZone ID="WebPartZone1" runat="server">
        <ZoneTemplate>
          <asp:Calendar ID="Calendar1" runat="server" 
            Title="My Calendar" />
        </ZoneTemplate>
      </asp:WebPartZone>
      <asp:WebPartZone ID="WebPartZone2" runat="server">
        <ZoneTemplate>
          <asp:BulletedList 
            DisplayMode="HyperLink" 
            ID="BulletedList1" 
            runat="server"
            Title="My Links">
            <asp:ListItem Value="http://www.microsoft.com">Microsoft</asp:ListItem>
            <asp:ListItem Value="http://www.msn.com">MSN</asp:ListItem>
            <asp:ListItem Value="http://www.contoso.com">Contoso Corp.</asp:ListItem>
          </asp:BulletedList>
        </ZoneTemplate>
      </asp:WebPartZone>
      <asp:EditorZone ID="EditorZone1" runat="server">
        <ZoneTemplate>
          <asp:AppearanceEditorPart runat="server" ID="Appearance1">
          </asp:AppearanceEditorPart>
          <asp:LayoutEditorPart runat="server" ID="Layout1">
          </asp:LayoutEditorPart>
        </ZoneTemplate>
      </asp:EditorZone>
      <hr />
      <asp:Button ID="Button1" runat="server" Text="Browse Mode" OnClick="Button1_Click" />
      <br />
      <asp:Button ID="Button2" runat="server" Text="Design Mode" OnClick="Button2_Click"/>
      <br />
      <asp:Button ID="Button3" runat="server" Text="Edit Mode" OnClick="Button3_Click"/>
    </div>
    </form>
</body>
</html>
<!-- </snippet1> -->