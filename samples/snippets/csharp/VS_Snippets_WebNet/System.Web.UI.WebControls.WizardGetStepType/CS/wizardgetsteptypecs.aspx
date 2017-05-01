<!-- <snippet1> -->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  void OnActiveStepChanged(object sender, EventArgs e)
  { 
    Label tempLabel = (Label)Wizard1.FindControl("Label1");
    if (tempLabel != null)
    {
      // Get the step type of the ActiveStep and write it to Label1.
      WizardStepType tempStepType = Wizard1.GetStepType(Wizard1.ActiveStep, Wizard1.ActiveStepIndex);
      tempLabel.Text = "The current step type is " + tempStepType.ToString() + ".";
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
          onactivestepchanged="OnActiveStepChanged">
          <WizardSteps>
            <asp:WizardStep id="WizardStep1" 
              title="Step 1" 
              runat="server">
            </asp:WizardStep>
            <asp:WizardStep id="WizardStep2" 
              title="Step 2" 
              runat="server">
            </asp:WizardStep>
            <asp:WizardStep id="WizardStep3" 
              runat="server" 
              title="Step 3">
            </asp:WizardStep>
          </WizardSteps>
          <HeaderTemplate>
            <b>GetStepType Example</b>
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