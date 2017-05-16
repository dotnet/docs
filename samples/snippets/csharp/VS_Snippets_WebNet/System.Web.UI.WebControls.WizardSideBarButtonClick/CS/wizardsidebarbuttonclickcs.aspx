<!-- <snippet1> -->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  void OnSideBarButtonClick(object sender, WizardNavigationEventArgs e)
  {
    // When a button in the sidebar area is clicked, put a message
    // in Label1 to be displayed in the header area.
    Label tempLabel = (Label)Wizard1.FindControl("Label1");
    if (tempLabel != null)
    {
      tempLabel.Text = "You clicked the button for Step " + 
        (e.NextStepIndex + 1) + ".";
    }
  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
      <asp:Wizard id="Wizard1" 
        runat="server" 
        onsidebarbuttonclick="OnSideBarButtonClick">
        <WizardSteps>
          <asp:WizardStep id="WizardStep1" 
            runat="server" 
            title="Step 1">
          </asp:WizardStep>
          <asp:WizardStep id="WizardStep2" 
            runat="server" 
            title="Step 2">
          </asp:WizardStep>
          <asp:WizardStep id="WizardStep3" 
            runat="server" 
            title="Step 3">
          </asp:WizardStep>
        </WizardSteps>
        <HeaderTemplate>
          <b>SideBarButtonClick Example</b>
          &nbsp;<br />
          <asp:Label id="Label1" 
            runat="server" 
            width="208px" 
            height="19px">
          </asp:Label>
        </HeaderTemplate>
      </asp:Wizard>
    </form>
  </body>
</html>
<!-- </snippet1> -->

