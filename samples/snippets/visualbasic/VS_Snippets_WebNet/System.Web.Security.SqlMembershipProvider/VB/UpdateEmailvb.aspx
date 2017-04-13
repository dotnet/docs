<!-- <Snippet11> -->
<%@ Page Language="vb" %>
<%@ Import Namespace="System.Web.Security" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

Dim u As MembershipUser

Public Sub Page_Load(sender As Object, args As EventArgs)

  u = Membership.GetUser(User.Identity.Name)

  If Not IsPostBack Then EmailTextBox.Text = u.Email

End Sub

Public Sub UpdateEmailButton_OnClick(sender As Object, args As EventArgs)

  Try
    u.Email = EmailTextBox.Text

    Membership.UpdateUser(u)
  
    Msg.Text = "User e-mail updated."
  Catch e As System.Configuration.Provider.ProviderException
    Msg.Text = e.Message
  End Try

End Sub

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>Sample: Update User E-Mail</title>
</head>
<body>

<form id="form1" runat="server">
  <h3>Update E-Mail Address for <%=User.Identity.Name%></h3>

  <asp:Label id="Msg" ForeColor="maroon" runat="server" /><br />

  <table cellpadding="3" border="0">
    <tr>
      <td>E-mail Address:</td>
      <td><asp:TextBox id="EmailTextBox" MaxLength="128" Columns="30" runat="server" /></td>
      <td><asp:RequiredFieldValidator id="EmailRequiredValidator" runat="server"
                                    ControlToValidate="EmailTextBox" ForeColor="red"
                                    Display="Static" ErrorMessage="Required" /></td>
    </tr>
    <tr>
      <td></td>
      <td><asp:Button id="UpdateEmailButton" 
                      Text="Update E-mail" 
                      OnClick="UpdateEmailButton_OnClick" 
                      runat="server" /></td>
    </tr>
  </table>
</form>

</body>
</html>
<!-- </Snippet11> -->