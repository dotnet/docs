<!-- <Snippet3> -->
<%@ Page Language="C#" %>
<%@ Import Namespace="System.Web.Security" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

public void ChangePassword_OnClick(object sender, EventArgs args)
{
  try
  {
    // Update the password.

    if (Membership.Provider.ChangePassword(User.Identity.Name, OldPasswordTextbox.Text, PasswordTextbox.Text))
    {
      Msg.Text = "Password changed.";
      return;
    }
  }
  catch
  {
  }

  Msg.Text = "Password change failed. Please re-enter your values and try again.";
}


</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>Change Password</title>
</head>
<body>

<form id="form1" runat="server">
  <h3>Change Password for <%=User.Identity.Name%></h3>

  <asp:Label id="Msg" ForeColor="maroon" runat="server" />

  <table cellpadding="3" border="0">
    <tr>
      <td>Old Password:</td>
      <td><asp:Textbox id="OldPasswordTextbox" runat="server" TextMode="Password" /></td>
      <td><asp:RequiredFieldValidator id="OldPasswordRequiredValidator" runat="server"
                                      ControlToValidate="OldPasswordTextbox" ForeColor="red"
                                      Display="Static" ErrorMessage="Required" /></td>
    </tr>
    <tr>
      <td>Password:</td>
      <td><asp:Textbox id="PasswordTextbox" runat="server" TextMode="Password" /></td>
      <td><asp:RequiredFieldValidator id="PasswordRequiredValidator" runat="server"
                                      ControlToValidate="PasswordTextbox" ForeColor="red"
                                      Display="Static" ErrorMessage="Required" /></td>
    </tr>
    <tr>
      <td>Confirm Password:</td>
      <td><asp:Textbox id="PasswordConfirmTextbox" runat="server" TextMode="Password" /></td>
      <td><asp:RequiredFieldValidator id="PasswordConfirmRequiredValidator" runat="server"
                                      ControlToValidate="PasswordConfirmTextbox" ForeColor="red"
                                      Display="Static" 
                                      ErrorMessage="Required" />
          <asp:CompareValidator id="PasswordConfirmCompareValidator" runat="server"
                                      ControlToValidate="PasswordConfirmTextbox" ForeColor="red"
                                      Display="Static" ControlToCompare="PasswordTextBox"
                                      ErrorMessage="Confirm password must match password." />
      </td>
    </tr>
    <tr>
      <td></td>
      <td><asp:Button id="ChangePasswordButton" Text="Change Password" 
                      OnClick="ChangePassword_OnClick" runat="server" /></td>
    </tr>
  </table>
</form>

</body>
</html>
<!-- </Snippet3> -->