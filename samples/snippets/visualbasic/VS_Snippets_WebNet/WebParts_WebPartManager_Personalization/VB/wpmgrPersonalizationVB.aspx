<!-- <snippet1> -->
<%@ Page Language="vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Protected Sub Button1_Click(ByVal sender As Object, _
    ByVal e As System.EventArgs)
    If mgr1.Personalization.Scope = PersonalizationScope.User _
      AndAlso mgr1.Personalization.CanEnterSharedScope Then
      mgr1.Personalization.ToggleScope()
    ElseIf mgr1.Personalization.Scope = _
      PersonalizationScope.Shared Then
      mgr1.Personalization.ToggleScope()
    Else
      ' If the user cannot enter shared scope you may want
      ' to notify them on the page.
    End If
    
  End Sub
  
  Protected Sub Button2_Click(ByVal sender As Object, _
    ByVal e As System.EventArgs)
    mgr1.DisplayMode = WebPartManager.EditDisplayMode
  End Sub
  
  Protected Sub Button3_Click(ByVal sender As Object, _
    ByVal e As System.EventArgs)
    mgr1.DisplayMode = WebPartManager.BrowseDisplayMode
  End Sub

  Protected Sub Page_Load(ByVal sender As Object, _
    ByVal e As System.EventArgs)
    Label1.Text = "Scope is: " & mgr1.Personalization.Scope.ToString()
  End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:WebPartManager ID="mgr1" runat="server" />
      <asp:WebPartZone ID="WebPartZone1" runat="server">
        <ZoneTemplate>
          <asp:Calendar ID="Calendar1" runat="server" />
        </ZoneTemplate>
      </asp:WebPartZone>
      <asp:EditorZone ID="EditorZone1" runat="server">
        <ZoneTemplate>
          <asp:AppearanceEditorPart ID="AppearanceEditorPart1" 
            runat="server"  />
          <asp:BehaviorEditorPart ID="BehaviorEditorPart1" 
            runat="server" />
        </ZoneTemplate>
      </asp:EditorZone>
      <hr />
      <asp:Button ID="Button1" runat="server" Text="Toggle Scope" OnClick="Button1_Click"  />
      <asp:Button ID="Button2" runat="server" Text="Edit Mode" OnClick="Button2_Click" />
      <asp:Button ID="Button3" runat="server" Text="Browse Mode" OnClick="Button3_Click" />
      <br />
      <asp:Label ID="Label1" runat="server" Text="" />
     </div>
     </form>
</body>
</html>
<!-- </snippet1> -->