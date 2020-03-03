<!-- <Snippet7> -->
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateUser.aspx.cs" Inherits="CreateUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Add User Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Add User</h1>
        <a href="Default.aspx">Back to default page</a><br />
        &nbsp;<asp:CreateUserWizard ID="CreateUserWizard1" runat="server" OnCreatedUser="On_CreatedUser">
            <WizardSteps>
                <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server" />
                <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server" />
            </WizardSteps>
        </asp:CreateUserWizard>
        <span style="font-weight: bold; color: Red">Security Group</span>
        <br />
        <asp:RadioButton ID="RDO_Friends" Text="Friends" runat="server" Checked="true" GroupName="GP1" />
        &nbsp;
        <asp:RadioButton ID="RDO_Manager" Text="Managers" runat="server" GroupName="GP1" />
    </div>
    </form>
</body>
</html>

<!-- </Snippet7> -->
