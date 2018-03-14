<!-- <snippet1> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
      <asp:Wizard id="Wizard1" 
        runat="server"
    displaysidebar="false" >
        <WizardSteps>
          <asp:WizardStep id="WizardStep1" 
            title="Step 1" 
            allowreturn="false"
            runat="server">
            You are currently on Step 1.
          </asp:WizardStep>
          <asp:WizardStep id="WizardStep2" 
            title="Step 2" 
            runat="server">
            You are currently on Step 2.
          </asp:WizardStep>
          <asp:WizardStep id="WizardStep3" 
            title="Step 3" 
            runat="server">
            You are currently on Step 3.
          </asp:WizardStep>
        </WizardSteps>
        <HeaderTemplate>
          <b>WizardStepBase AllowReturn Example</b>
        </HeaderTemplate>
      </asp:Wizard>
    </form>
  </body>
</html>
<!-- </snippet1> -->

