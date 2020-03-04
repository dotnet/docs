<!-- <Snippet1> -->
<%@ Page Language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
void Page_Load(object sender, EventArgs e) 
{
    Login1.UserNameLabelText = "User ID:";
    Login1.PasswordLabelText = "User Password:";
}
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
        <form id="form1" runat="server">
            <asp:Login id="Login1" runat="server" 
                UserNameLabelText="User ID:" 
                PasswordLabelText="User Password:">
            </asp:Login>

        </form>
    </body>
</html>
<!-- </Snippet1> -->
