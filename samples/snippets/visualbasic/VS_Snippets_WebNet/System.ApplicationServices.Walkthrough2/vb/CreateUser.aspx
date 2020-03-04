<!-- <Snippet7> -->
<%@ Page Language="VB" AutoEventWireup="true" CodeFile="CreateUser.aspx.vb" Inherits="CreateUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Add New User</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <h2>Add New User</h2>

        <a href="Default.aspx">back to default page</a>

		<asp:CreateUserWizard ID="CreateUserWizard1" runat="server"
		  OnCreatedUser="On_CreatedUser">
			<wizardsteps>
				<asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server"  />
				<asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server"  />
			</wizardsteps>
		</asp:CreateUserWizard>

		<span style="font-weight:bold; color:Red">Security Group</span> <br />
		<asp:RadioButton ID="RDO_Friends"  Text="Friends" runat="server" Checked="true"  GroupName="GP1"/>
		<asp:RadioButton ID="RDO_Manager" Text="Managers" runat="server" GroupName="GP1" />
    </div>
    </form>
</body>
</html>
<!-- </Snippet7> -->
