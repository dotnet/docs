<!-- <snippet1> -->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  void Page_Load(Object sender, EventArgs e)
  {

    // Declare an array of WizardStepBase objects.
    WizardStepBase[] stepArray = new WizardStepBase[Wizard1.WizardSteps.Count];

    // Use the CopyTo method to copy the WizardStep items 
    // of the Wizard control into the array.
    Wizard1.WizardSteps.CopyTo(stepArray, 0);
    
    // Display the WizardStep items.
    Message.Text = "The WizardStepBase items of the Wizard1 control are: <br/><br/>";
    
    for (int i = 0; i < stepArray.Length; i++)
    {
      Message.Text += stepArray[i].ID + "<br />";
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
        runat="server" >
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
          <b>WizardStepCollection CopyTo Example</b>
        </HeaderTemplate>
      </asp:Wizard>
      <asp:label id="Message" 
        runat="server"/>
    </form>
  </body>
</html>
<!-- </snippet1> -->

