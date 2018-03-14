<!-- <snippet4> -->
<%@ control language="VB" %>

<script runat="server">
  
  ' Use a field to reference the current WebPartManager.
Private _manager As WebPartManager


Protected Sub Page_Load(ByVal src As Object, ByVal e As EventArgs) 
    ' Get the current Web Parts manager.
    _manager = WebPartManager.GetCurrentWebPartManager(Page)
    
    ' All radio buttons are disabled; the button settings show what the current state is.
    EnterSharedRadioButton.Enabled = False
    ModifyStateRadioButton.Enabled = False
    
    ' If Web Parts manager is in User scope, set scope button.
    If _manager.Personalization.Scope = PersonalizationScope.User Then
        UserScopeRadioButton.Checked = True
    Else
        SharedScopeRadioButton.Checked = True
    End If 
    ' Based on current user rights to enter Shared scope, set buttons.
    If _manager.Personalization.CanEnterSharedScope Then
        EnterSharedRadioButton.Checked = True
        No_Shared_Scope_Label.Visible = False
        Toggle_Scope_Button.Enabled = True
    Else
        EnterSharedRadioButton.Checked = False
        No_Shared_Scope_Label.Visible = True
        Toggle_Scope_Button.Enabled = False
    End If
    
    ' Based on current user rights to modify personalization state, set buttons.
    If _manager.Personalization.IsModifiable Then
        ModifyStateRadioButton.Checked = True
        Reset_User_Button.Enabled = True
    Else
        ModifyStateRadioButton.Checked = False
        Reset_User_Button.Enabled = False
    End If

End Sub 'Page_Load

' <snippet6>
' Resets all of a user and shared personalization data for the page.
Protected Sub Reset_CurrentState_Button_Click(ByVal src As Object, ByVal e As EventArgs) 
    ' User must be authorized to modify state before a reset can occur.
    'When in user scope, all users by default can change their own data.
    If _manager.Personalization.IsModifiable Then
        _manager.Personalization.ResetPersonalizationState()
    End If

End Sub 'Reset_CurrentState_Button_Click

'  </snippet6>
' <snippet7>
' Allows authorized user to change personalization scope.
Protected Sub Toggle_Scope_Button_Click(ByVal sender As Object, ByVal e As EventArgs) 
    If _manager.Personalization.CanEnterSharedScope Then
        _manager.Personalization.ToggleScope()
    End If

End Sub 'Toggle_Scope_Button_Click 
' </snippet7>
</script>
<div>
    &nbsp;<asp:Panel ID="Panel1" runat="server" 
    Borderwidth="1" 
    Width="208px" 
    BackColor="lightgray"
    Font-Names="Verdana, Arial, Sans Serif" Height="214px" >
    <asp:Label ID="Label1" runat="server" 
      Text="Page Scope" 
      Font-Bold="True"
      Font-Size="8pt"
      Width="120px" />&nbsp;<br />
    
    
      <asp:RadioButton ID="UserScopeRadioButton" runat="server" 
        Text="User" 
        AutoPostBack="true"
        GroupName="Scope"  
         Enabled="false" />
      <asp:RadioButton ID="SharedScopeRadioButton" runat="server" 
        Text="Shared" 
        AutoPostBack="true"
        GroupName="Scope" 
        Enabled="false" />
        <br />
        <asp:Label BorderStyle="None" Font-Bold="True" Font-Names="Courier New" ID="No_Shared_Scope_Label" Font-Size="Smaller" ForeColor="red"
           runat="server" Visible="false" Width="179px">User cannot enter Shared scope</asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" 
      Text="Current User Can:" 
      Font-Bold="True"
      Font-Size="8pt"
      Width="165px" />
      <br />
        <asp:RadioButton ID="ModifyStateRadioButton" runat="server" 
        Text="Modify State" Width="138px" />
        <br />
        <asp:RadioButton ID="EnterSharedRadioButton" runat="server" 
        Text="Enter Shared Scope" 
        AutoPostBack="true"  />&nbsp;<br />
        <br />
        <asp:Button ID="Toggle_Scope_Button" OnClick="Toggle_Scope_Button_Click" runat="server"
            Text="Change Scope" Width="186px" /><br />
        <br />
        <asp:Button ID="Reset_User_Button" OnClick="Reset_CurrentState_Button_Click" runat="server"
            Text="Reset Current Personalization" Width="185px" /></asp:Panel>
    &nbsp; &nbsp;
</div>
<!-- </snippet4> -->