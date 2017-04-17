<!-- <Snippet1> -->

<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  protected void Page_Load(object sender, EventArgs e)
  {
    MembershipUser user =
        Membership.GetUser();

    userName.Text = user.UserName;
    emailAddress.Text = user.Email;

    // <Snippet2>
    if (user is ActiveDirectoryMembershipUser)
    {
      lastLoginDate.Text = "Not available";
      lastActivityDate.Text = "Not available";
    }
    else
    {
      lastLoginDate.Text = user.LastLoginDate.ToShortDateString();
      lastActivityDate.Text = user.LastActivityDate.ToShortDateString();
    }
    // </Snippet2>   
    
    // <Snippet3>
    System.Security.Principal.SecurityIdentifier sidValue =
      (System.Security.Principal.SecurityIdentifier)user.ProviderUserKey;

    sid.Text = sidValue.ToString();
    // </Snippet3>
  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>User information</title>
</head>
<body>
  <form id="form1" runat="server">
    <div>
      <table>
        <tr>
          <td>
            User name:</td>
          <td>
            <asp:Literal ID="userName" runat="server" /></td>
        </tr>
        <tr>
          <td>
            E-mail Address:</td>
          <td>
            <asp:Literal ID="emailAddress" runat="server" /></td>
        </tr>
        <tr>
          <td>
            Last Login Date:</td>
          <td>
            <asp:Literal ID="lastLoginDate" runat="server" /></td>
        </tr>
        <tr>
          <td>
            Last Activity Date:</td>
          <td>
            <asp:Literal ID="lastActivityDate" runat="server" /></td>
        </tr>
        <tr>
          <td>
            Security Identifier SID:</td>
          <td>
            <asp:Literal ID="sid" runat="server" /></td>
        </tr>
      </table>
    </div>
  </form>
</body>
</html>
<!-- </Snippet1> -->
