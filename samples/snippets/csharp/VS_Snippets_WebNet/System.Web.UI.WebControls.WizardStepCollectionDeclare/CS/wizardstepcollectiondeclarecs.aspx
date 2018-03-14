<!-- <snippet3> -->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
      <asp:Wizard id="Wizard1" 
        runat="server" >
        <WizardSteps>
          <asp:WizardStep id="Step1" 
            runat="server" 
            title="Step 1">
          </asp:WizardStep>
          <asp:WizardStep id="Step2" 
            runat="server" 
            title="Step 2">
          </asp:WizardStep>
          <asp:WizardStep id="Step3" 
            runat="server" 
            title="Step 3">
          </asp:WizardStep>
          <asp:WizardStep id="Step4" 
            runat="server" 
            title="Step 4">
          </asp:WizardStep>
          <asp:WizardStep id="Step5" 
            runat="server" 
            title="Step 5">
          </asp:WizardStep>
          <asp:WizardStep id="Step6" 
            runat="server" 
            title="Step 6">
          </asp:WizardStep>
        </WizardSteps>
        <HeaderTemplate>
          <b>WizardStepCollection Example</b>
        </HeaderTemplate>
      </asp:Wizard>
    </form>
  </body>
</html>
<!-- </snippet3> -->
