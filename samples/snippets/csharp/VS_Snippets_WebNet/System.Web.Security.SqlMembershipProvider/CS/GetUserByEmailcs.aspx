<!-- <Snippet7> -->
<%@ Page Language="C#" %>
<%@ Import Namespace="System.Web.Security" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

public void Search_OnClick(object sender, EventArgs args)
{
  string username = Membership.GetUserNameByEmail(EmailTextBox.Text);

  if (username == null)
  {
    Msg.Text = "E-mail address " + Server.HtmlEncode(EmailTextBox.Text) + " is not found. Please reenter.";
  }
  else
  {
    Msg.Text = "The user name for " + Server.HtmlEncode(EmailTextBox.Text) + 
               " is " + Server.HtmlEncode(username) + ".";
  }

}

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>Sample: Retrieve Username By E-mail</title>
</head>
<body>

<form id="form1" runat="server">
  <h3>Forgot your Username? Search for it by e-mail address.</h3>

  <asp:Label id="Msg" runat="server" ForeColor="maroon" /><br />

  E-mail address: <asp:Textbox id="EmailTextBox" Columns="30" runat="server" />
                  <asp:RequiredFieldValidator id="EmailRequiredValidator" runat="server"
                                        ControlToValidate="EmailTextBox" ForeColor="red"
                                        Display="Static" ErrorMessage="Required" /><br />

  <asp:Button id="SearchButton" Text="Search" 
              OnClick="Search_OnClick" runat="server" />

</form>

</body>
</html>
<!-- </Snippet7> -->