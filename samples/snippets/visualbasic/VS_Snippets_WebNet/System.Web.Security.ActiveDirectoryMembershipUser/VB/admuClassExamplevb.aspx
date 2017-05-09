<!-- <Snippet1> -->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
    Dim user As MembershipUser = Membership.GetUser()
        
    userName.Text = user.UserName
    emailAddress.Text = user.Email
        
    ' <Snippet2>
    If TypeOf (user) Is ActiveDirectoryMembershipUser Then
      lastLoginDate.Text = "Not available"
      lastActivityDate.Text = "Not available"
    Else
      lastLoginDate.Text = user.LastLoginDate.ToString()
      lastActivityDate.Text = user.LastActivityDate.ToString()
    End If
    ' </Snippet2>
    
    ' <Snippet3>
    Dim sidValue As System.Security.Principal.SecurityIdentifier
    sidValue = CType(user.ProviderUserKey, System.Security.Principal.SecurityIdentifier)
    
    sid.Text = sidValue.ToString()
    ' </Snippet3>
  End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>User information page</title>
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
