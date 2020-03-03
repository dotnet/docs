<!-- <snippet4> -->
<%@ control language="vb" classname="DisplayModeMenuVB"%>

<script runat="server">
  
' Use a field to reference the current WebPartManager.
Dim _manager As WebPartManager


Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs) 
    AddHandler Page.InitComplete, AddressOf InitComplete

End Sub 


Sub InitComplete(ByVal sender As Object, ByVal e As System.EventArgs) 
    _manager = WebPartManager.GetCurrentWebPartManager(Page)
    
    Dim browseModeName As String = _
      WebPartManager.BrowseDisplayMode.Name
    
    ' Fill the dropdown with the names of supported display modes.
    Dim mode As WebPartDisplayMode
    For Each mode In  _manager.SupportedDisplayModes
        Dim modeName As String = mode.Name
        ' Make sure a mode is enabled before adding it.
        If mode.IsEnabled(_manager) Then
        Dim item As New ListItem(modeName, modeName)
            DisplayModeDropdown.Items.Add(item)
        End If
    Next mode

End Sub 
 

' Change the page to the selected display mode.
  Sub DisplayModeDropdown_SelectedIndexChanged(ByVal sender As Object, _
    ByVal e As EventArgs)
    Dim selectedMode As String = DisplayModeDropdown.SelectedValue
    
    Dim mode As WebPartDisplayMode = _
      _manager.SupportedDisplayModes(selectedMode)
    If Not (mode Is Nothing) Then
      _manager.DisplayMode = mode
    End If
 
  End Sub


Sub Page_PreRender(ByVal sender As Object, ByVal e As EventArgs) 
    DisplayModeDropdown.SelectedValue = _manager.DisplayMode.Name

End Sub 

</script>
<div>
  <asp:Panel ID="Panel1" runat="server" 
    Borderwidth="1" 
    Width="125" 
    BackColor="lightgray"
    Font-Names="Verdana, Arial, Sans Serif" >
  <asp:Label ID="Label1" runat="server" 
    Text="&nbsp;Display Mode" 
    Font-Bold="true"
    Font-Size="8"
    Width="120" 
    AssociatedControlID="DisplayModeDropdown"/>
  <asp:DropDownList ID="DisplayModeDropdown" 
    runat="server"  
    AutoPostBack="true" 
    Width="120"
    OnSelectedIndexChanged="DisplayModeDropdown_SelectedIndexChanged" />
  </asp:Panel>
</div>
<!-- </snippet4> -->