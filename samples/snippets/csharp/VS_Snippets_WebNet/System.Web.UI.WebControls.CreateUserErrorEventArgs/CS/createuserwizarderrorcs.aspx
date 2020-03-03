<!-- <snippet1> -->
<%@ Page Language="C#" CodeFile="CreateUserWizardError.cs" Inherits="CreateUserWizardErrorcs_aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>CreateUserWizardError Example</title>
</head>
<body>
    <form id="form1" runat="server">
      <h3>CreateUserWizardError Example</h3>
      <asp:CreateUserWizard id="CreateUserWizard1" 
        runat="server" 
        oncreateusererror="OnCreateUserError">
        <WizardSteps>
                <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                </asp:CreateUserWizardStep>
                <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                </asp:CompleteWizardStep>
            </WizardSteps>
      </asp:CreateUserWizard>
      <asp:Label id="Label1" 
        runat="server">
      </asp:Label>
    </form>
  </body>
</html>
<!-- </snippet1> -->
