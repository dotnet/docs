<%@ Page Language="C#" %>

<%@ Import Namespace="System.Web.Security" %>
<%@ Import Namespace="System.Web" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  //<Snippet11>
  public void Page_Load()
  {
    Membership.ValidatingPassword +=
      new MembershipValidatePasswordEventHandler(OnValidatePassword);
  }

  public void OnValidatePassword(object sender,
                                ValidatePasswordEventArgs args)
  {
    System.Text.RegularExpressions.Regex r =
      new System.Text.RegularExpressions.Regex(@"(?=.{6,})(?=(.*\d){1,})(?=(.*\W){1,})");


    if (!r.IsMatch(args.Password))
    {
      args.FailureInformation =
        new HttpException("Password must be at least 6 characters long and " +
                          "contain at least one number and one special character.");
      args.Cancel = true;
    }
  }
  //</Snippet11>


  public void CreateUser_OnClick(object sender, EventArgs args)
  {
    try
    {
      // Create new user.

      MembershipUser newUser = Membership.CreateUser(UsernameTextbox.Text, PasswordTextbox.Text,
                                                     EmailTextbox.Text);


      // If user created successfully, set password question and answer (if applicable) and 
      // redirect to login page. Otherwise return an error message.

      if (Membership.RequiresQuestionAndAnswer)
      {
        newUser.ChangePasswordQuestionAndAnswer(PasswordTextbox.Text,
                                                PasswordQuestionTextbox.Text,
                                                PasswordAnswerTextbox.Text);
      }

      Response.Redirect("login.aspx");
    }
    catch (MembershipCreateUserException e)
    {
      Msg.Text = GetErrorMessage(e.StatusCode);
    }
    catch (HttpException e)
    {
      Msg.Text = e.Message;
    }
  }

  public string GetErrorMessage(MembershipCreateStatus status)
  {
    switch (status)
    {
      case MembershipCreateStatus.DuplicateUserName:
        return "Username already exists. Please enter a different user name.";

      case MembershipCreateStatus.DuplicateEmail:
        return "A username for that e-mail address already exists. Please enter a different e-mail address.";

      case MembershipCreateStatus.InvalidPassword:
        return "The password provided is invalid. Please enter a valid password value.";

      case MembershipCreateStatus.InvalidEmail:
        return "The e-mail address provided is invalid. Please check the value and try again.";

      case MembershipCreateStatus.InvalidAnswer:
        return "The password retrieval answer provided is invalid. Please check the value and try again.";

      case MembershipCreateStatus.InvalidQuestion:
        return "The password retrieval question provided is invalid. Please check the value and try again.";

      case MembershipCreateStatus.InvalidUserName:
        return "The user name provided is invalid. Please check the value and try again.";

      case MembershipCreateStatus.ProviderError:
        return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

      case MembershipCreateStatus.UserRejected:
        return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

      default:
        return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
    }
  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
  <title>Create User</title>
</head>
<body>
  <form id="form1" runat="server">
    <h3>
      Create New User</h3>
    <asp:Label ID="Msg" ForeColor="maroon" runat="server" /><br />
    <table cellpadding="3" border="0">
      <tr>
        <td>
          Username:</td>
        <td>
          <asp:TextBox ID="UsernameTextbox" runat="server" /></td>
        <td>
          <asp:RequiredFieldValidator ID="UsernameRequiredValidator" runat="server" ControlToValidate="UserNameTextbox"
            ForeColor="red" Display="Static" ErrorMessage="Required" /></td>
      </tr>
      <tr>
        <td>
          Password:</td>
        <td>
          <asp:TextBox ID="PasswordTextbox" runat="server" TextMode="Password" /></td>
        <td>
          <asp:RequiredFieldValidator ID="PasswordRequiredValidator" runat="server" ControlToValidate="PasswordTextbox"
            ForeColor="red" Display="Static" ErrorMessage="Required" /></td>
      </tr>
      <tr>
        <td>
          Confirm Password:</td>
        <td>
          <asp:TextBox ID="PasswordConfirmTextbox" runat="server" TextMode="Password" /></td>
        <td>
          <asp:RequiredFieldValidator ID="PasswordConfirmRequiredValidator" runat="server"
            ControlToValidate="PasswordConfirmTextbox" ForeColor="red" Display="Static" ErrorMessage="Required" />
          <asp:CompareValidator ID="PasswordConfirmCompareValidator" runat="server" ControlToValidate="PasswordConfirmTextbox"
            ForeColor="red" Display="Static" ControlToCompare="PasswordTextBox" ErrorMessage="Confirm password must match password." />
        </td>
      </tr>
      <tr>
        <td>
          Email Address:</td>
        <td>
          <asp:TextBox ID="EmailTextbox" runat="server" /></td>
        <td>
          <asp:RequiredFieldValidator ID="EmailRequiredValidator" runat="server" ControlToValidate="EmailTextbox"
            ForeColor="red" Display="Static" ErrorMessage="Required" /></td>
      </tr>
      <% if (Membership.RequiresQuestionAndAnswer)
         { %>
      <tr>
        <td>
          Password Question:</td>
        <td>
          <asp:TextBox ID="PasswordQuestionTextbox" runat="server" /></td>
        <td>
          <asp:RequiredFieldValidator ID="PasswordQuestionRequiredValidator" runat="server"
            ControlToValidate="PasswordQuestionTextbox" ForeColor="red" Display="Static" ErrorMessage="Required" /></td>
      </tr>
      <tr>
        <td>
          Password Answer:</td>
        <td>
          <asp:TextBox ID="PasswordAnswerTextbox" runat="server" /></td>
        <td>
          <asp:RequiredFieldValidator ID="PasswordAnswerRequiredValidator" runat="server" ControlToValidate="PasswordAnswerTextbox"
            ForeColor="red" Display="Static" ErrorMessage="Required" /></td>
      </tr>
      <% } %>
      <tr>
        <td>
        </td>
        <td>
          <asp:Button ID="CreateUserButton" Text="Create User" OnClick="CreateUser_OnClick"
            runat="server" /></td>
      </tr>
    </table>
  </form>
</body>
</html>
