<%@ Page Language="VB"  %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    '<snippet1>
Protected Sub Design_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Design.Click
  ' Get the current WebPartManager instance.
  Dim mgr As WebPartManager
  mgr = WebPartManager.GetCurrentWebPartManager(Page)

  ' Set the display mode.
  mgr.DisplayMode = mgr.SupportedDisplayModes.Item("Design")
End Sub

Protected Sub Browse_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Browse.Click
  ' Get the current WebPartManager instance.
  Dim mgr As WebPartManager
  mgr = WebPartManager.GetCurrentWebPartManager(Page)

  ' Set the display mode.
  mgr.DisplayMode = mgr.SupportedDisplayModes.Item("Browse")
End Sub
    '</snippet1>
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Web Part Display Mode Sample Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:WebPartManager ID="WebPartManager1" runat="server">
        </asp:WebPartManager>
        <asp:WebPartZone ID="WebPartZone1" runat="server">
            <ZoneTemplate>
                <asp:Label ID="Label1" runat="server" Text="Label1"></asp:Label>
            </ZoneTemplate>
        </asp:WebPartZone>
        <asp:WebPartZone ID="WebPartZone2" runat="server">
            <ZoneTemplate>
                <asp:Label ID="Label2" runat="server" Text="Label2"></asp:Label>
            </ZoneTemplate>
        </asp:WebPartZone>
        <asp:Button ID="Design" runat="server" Text="Design" />
        <asp:Button ID="Browse" runat="server" Text="Browse" />
    </form>
</body>
</html>
