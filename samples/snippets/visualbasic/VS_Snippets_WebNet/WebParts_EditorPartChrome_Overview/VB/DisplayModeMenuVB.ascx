<!-- <snippet7> -->
<%@ control language="vb" classname="DisplayModeMenuVB"%>
<script runat="server">
  ' Use a field to reference the current WebPartManager.
  Dim _manager As WebPartManager

  Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
    AddHandler Page.InitComplete, AddressOf InitComplete
  End Sub

  Sub InitComplete(ByVal sender As Object, ByVal e As System.EventArgs)
    _manager = WebPartManager.GetCurrentWebPartManager(Page)
      
    Dim browseModeName As String = WebPartManager.BrowseDisplayMode.Name
      
    ' Fill the dropdown with the names of supported display modes.
    Dim mode As WebPartDisplayMode
    For Each mode In _manager.SupportedDisplayModes
      Dim modeName As String = mode.Name
      ' Make sure a mode is enabled before adding it.
      If mode.IsEnabled(_manager) Then
        Dim item As New ListItem(modeName, modeName)
        DisplayModeDropdown.Items.Add(item)
      End If
    Next mode
      
    ' If shared scope is allowed for this user, display the scope-switching
    ' UI and select the appropriate radio button for the current user scope.
    If _manager.Personalization.CanEnterSharedScope Then
      Panel2.Visible = True
      If _manager.Personalization.Scope = PersonalizationScope.User Then
        RadioButton1.Checked = True
      Else
        RadioButton2.Checked = True
      End If
    End If
   
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
   
  ' Set the selected item equal to the current display mode.
  Sub Page_PreRender(ByVal sender As Object, ByVal e As EventArgs)
    Dim items As ListItemCollection = DisplayModeDropdown.Items
    Dim selectedIndex As Integer = _
      items.IndexOf(items.FindByText(_manager.DisplayMode.Name))
    DisplayModeDropdown.SelectedIndex = selectedIndex

  End Sub

  ' Reset all of a user's personalization data for the page.
  Protected Sub LinkButton1_Click(ByVal sender As Object, _
    ByVal e As EventArgs)
    
    _manager.Personalization.ResetPersonalizationState()
    
  End Sub

  ' If not in User personalization scope, toggle into it.
  Protected Sub RadioButton1_CheckedChanged(ByVal sender As Object, _
    ByVal e As EventArgs)
    
    If _manager.Personalization.Scope = PersonalizationScope.Shared Then
      _manager.Personalization.ToggleScope()
    End If

  End Sub
   
  ' If not in Shared scope, and if user is allowed, toggle the scope.
  Protected Sub RadioButton2_CheckedChanged(ByVal sender As Object, _
    ByVal e As EventArgs)
    
    If _manager.Personalization.CanEnterSharedScope AndAlso _
      _manager.Personalization.Scope = PersonalizationScope.User Then
      _manager.Personalization.ToggleScope()
    End If

  End Sub

</script>
<div>
  <asp:Panel ID="Panel1" runat="server" 
    Borderwidth="1" 
    Width="230" 
    BackColor="lightgray"
    Font-Names="Verdana, Arial, Sans Serif" >
    <asp:Label ID="Label1" runat="server" 
      Text="&nbsp;Display Mode" 
      Font-Bold="true"
      Font-Size="8"
      Width="120" 
      AssociatedControlID="DisplayModeDropdown"/>
    <div>
    <asp:DropDownList ID="DisplayModeDropdown" runat="server"  
      AutoPostBack="true" 
      Width="120"
      OnSelectedIndexChanged="DisplayModeDropdown_SelectedIndexChanged" />
    <asp:LinkButton ID="LinkButton1" runat="server"
      Text="Reset User State" 
      ToolTip="Reset the current user's personalization data for the page."
      Font-Size="8" 
      OnClick="LinkButton1_Click" />
    </div>
    <asp:Panel ID="Panel2" runat="server" 
      GroupingText="Personalization Scope"
      Font-Bold="true"
      Font-Size="8" 
      Visible="false" >
      <asp:RadioButton ID="RadioButton1" runat="server" 
        Text="User" 
        AutoPostBack="true"
        GroupName="Scope" OnCheckedChanged="RadioButton1_CheckedChanged" />
      <asp:RadioButton ID="RadioButton2" runat="server" 
        Text="Shared" 
        AutoPostBack="true"
        GroupName="Scope" 
        OnCheckedChanged="RadioButton2_CheckedChanged" />
    </asp:Panel>
  </asp:Panel>
</div>
<!-- </snippet7> -->