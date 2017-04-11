<!-- <snippet4> -->
<%@ control language="C#" %>

<script runat="server">
  
 // Use a field to reference the current WebPartManager.
  private WebPartManager _manager;

    protected void Page_Load(object src, EventArgs e)
    {
        // Get the current Web Parts manager.
        _manager = WebPartManager.GetCurrentWebPartManager(Page);
        
        // All radio buttons are disabled; the button settings show what the current state is.
        EnterSharedRadioButton.Enabled = false;
        ModifyStateRadioButton.Enabled = false;

        // If Web Parts manager is in User scope, set scope button.
        if (_manager.Personalization.Scope == PersonalizationScope.User)
            UserScopeRadioButton.Checked = true;
        else
            SharedScopeRadioButton.Checked = true;

        // Based on current user rights to enter Shared scope, set buttons.
        if (_manager.Personalization.CanEnterSharedScope)
        {
            EnterSharedRadioButton.Checked = true;
            No_Shared_Scope_Label.Visible = false;
            Toggle_Scope_Button.Enabled = true;
        }
        else
        {
            EnterSharedRadioButton.Checked = false;
            No_Shared_Scope_Label.Visible = true;
            Toggle_Scope_Button.Enabled = false;
        }

        // Based on current user rights to modify personalization state, set buttons.
        if (_manager.Personalization.IsModifiable)
        {
            ModifyStateRadioButton.Checked = true;
            Reset_User_Button.Enabled = true;
        }
        else
        {
            ModifyStateRadioButton.Checked = false;
            Reset_User_Button.Enabled = false;
        }
    }
    // <snippet6>
  // Resets all of a user and shared personalization data for the page.
    protected void Reset_CurrentState_Button_Click(object src, EventArgs e)
    {
        // User must be authorized to modify state before a reset can occur.
        //When in user scope, all users by default can change their own data.
        if (_manager.Personalization.IsModifiable)
        {
            _manager.Personalization.ResetPersonalizationState();
        }
    }
  //  </snippet6>

    // <snippet7>
    // Allows authorized user to change personalization scope.
    protected void Toggle_Scope_Button_Click(object sender, EventArgs e)
    {
        if (_manager.Personalization.CanEnterSharedScope)
        {
            _manager.Personalization.ToggleScope();
        }
        
    }
 // </snippet7>
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