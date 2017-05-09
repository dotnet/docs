<!-- <snippet1> -->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  void OnActiveStepChanged(object sender, EventArgs e)
  {
    // If the ActiveStep is changing to Step2, check to see whether the 
    // CheckBox1 CheckBox is selected.  If it is, skip to the Step2 step.
    if (Wizard1.ActiveStepIndex == Wizard1.WizardSteps.IndexOf(this.WizardStep2))
    {
      if (this.CheckBox1.Checked)
      {
        Wizard1.ActiveStepIndex = Wizard1.WizardSteps.IndexOf(this.WizardStep3);
      }
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
          OnActiveStepChanged="OnActiveStepChanged">
          <WizardSteps>
            <asp:WizardStep id="WizardStep1" 
              title="Step 1" 
              runat="server">
              <asp:CheckBox id="CheckBox1" 
                runat="Server" 
                text="Select this check box to skip Step 2." />
                You are currently on Step 1.
            </asp:WizardStep>
            <asp:WizardStep id="WizardStep2" 
              title="Step 2" 
              runat="server">
              You are currently on Step 2.
            </asp:WizardStep>
            <asp:WizardStep id="WizardStep3" 
              runat="server" 
              title="Step 3">
              You are currently on Step 3.
            </asp:WizardStep>
          </WizardSteps>
          <HeaderTemplate>
            <b>ActiveStepIndex Example</b>
          </HeaderTemplate>
        </asp:Wizard>
      </form>
  </body>
</html>
<!-- </snippet1> -->