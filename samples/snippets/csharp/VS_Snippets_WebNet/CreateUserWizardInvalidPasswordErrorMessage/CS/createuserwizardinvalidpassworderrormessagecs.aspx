<!-- <Snippet1> -->
<%@ page language="C#"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CreateUserWizard InvalidPasswordErrorMessage sample</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:createuserwizard id="Createuserwizard1" runat="server"
        InvalidEmailErrorMessage="Your password must contain a mixture of upper and lower case characters.">
        <WizardSteps>
                <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                </asp:CreateUserWizardStep>
                <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                </asp:CompleteWizardStep>
            </WizardSteps>      
      </asp:createuserwizard>
    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->
