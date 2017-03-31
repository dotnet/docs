<!-- <snippet1> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Protected Sub Page_Init(ByVal sender As Object, _
    ByVal e As EventArgs)
    Dim mode As WebPartDisplayMode
    For Each mode In mgr.SupportedDisplayModes
      Dim modeName As String = mode.Name
      If mode.IsEnabled(mgr) Then
        Dim item As ListItem = New ListItem(modeName, modeName)
        DisplayModeDropdown.Items.Add(item)
      End If
    Next
    
  End Sub

  Protected Sub DisplayModeDropdown_SelectedIndexChanged(ByVal _
    sender As Object, ByVal e As EventArgs)
    Dim selectedMode As String = _
      DisplayModeDropdown.SelectedValue
    Dim mode As WebPartDisplayMode = _
      mgr.SupportedDisplayModes(selectedMode)
    If mode IsNot Nothing Then
      mgr.DisplayMode = mode
    End If
  End Sub
  
  Protected Sub Page_PreRender(ByVal sender As Object, _
    ByVal e As System.EventArgs)
    If mgr.DisplayMode.Equals(WebPartManager.EditDisplayMode) Then
      Label1.Visible = True
    Else
      Label1.Visible = False
    End If
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
            <asp:ListItem Value="http://www.microsoft.com">
            Microsoft
            </asp:ListItem>
            <asp:ListItem Value="http://www.msn.com">
            MSN
            </asp:ListItem>
            <asp:ListItem Value="http://www.contoso.com">
            Contoso Corp.
            </asp:ListItem>
          </asp:BulletedList>
        </ZoneTemplate>
      </asp:WebPartZone>
      <asp:EditorZone ID="EditorZone1" runat="server">
        <ZoneTemplate>
          <asp:AppearanceEditorPart runat="server" 
            ID="Appearance1">
          </asp:AppearanceEditorPart>
          <asp:LayoutEditorPart runat="server" ID="Layout1">
          </asp:LayoutEditorPart>
        </ZoneTemplate>
      </asp:EditorZone>
      <hr />
      <asp:Label ID="Label1" runat="server" 
        Text="Currently in Edit Mode" 
        Font-Bold="true"
        Font-Size="125%" />
      <br />
      <asp:DropDownList ID="DisplayModeDropdown" runat="server" 
        AutoPostBack="true"
        Width="120"
        OnSelectedIndexChanged=
        "DisplayModeDropdown_SelectedIndexChanged">
      </asp:DropDownList>
    </div>
    </form>
</body>
</html>
<!-- </snippet1> -->