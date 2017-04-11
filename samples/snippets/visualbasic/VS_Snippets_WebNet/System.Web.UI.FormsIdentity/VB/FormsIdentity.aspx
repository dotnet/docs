<%--<snippet1>--%>
<%@ Page Language="vb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<%@ Import Namespace="System.Globalization" %>
<script runat="server">
    Private Sub Login_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Login.Click

        ' For the example, the user name must be "UserName" and the password
        ' must be "Password" for authentication to succeed.
        Dim isAuthenticated As Boolean
        If String.Compare(UserNameTextBox.Text, "UserName", True, _
            CultureInfo.InvariantCulture) = 0 Then
            If String.Compare(PasswordTextBox.Text, "Password", True, _
                CultureInfo.InvariantCulture) = 0 Then
                isAuthenticated = True
            End If
        Else
            isAuthenticated = False
        End If

        ' Create the FormsIdentity for the user.
        CreateFormsIdentity(UserNameTextBox.Text, isAuthenticated)

    End Sub

    Private Sub CreateFormsIdentity(ByVal userName As String, _
        ByVal isAuthenticated As Boolean)

        Dim formsId As System.Web.Security.FormsIdentity
        Dim authenticationTicket As _
            System.Web.Security.FormsAuthenticationTicket

        If isAuthenticated Then
            ' If authentication passed, create a ticket 
            ' as a Manager that expires in 15 minutes.
            authenticationTicket = _
                New FormsAuthenticationTicket(1, userName, DateTime.Now, _
                DateTime.Now.AddMinutes(15), False, "Manager")
        Else
            ' If authentication failed, create a ticket 
            ' as a guest that expired 5 minutes ago.
            authenticationTicket = _
                New FormsAuthenticationTicket(1, userName, DateTime.Now, _
                DateTime.Now.Subtract(New TimeSpan(0, 5, 0)), False, "Guest")
        End If

        ' Create form identity from FormsAuthenticationTicket.
        formsId = New FormsIdentity(authenticationTicket)

        Response.Clear()
        Response.Write("Authenticate Type: " & _
            formsId.AuthenticationType & "<BR>")

        ' Get FormsAuthenticationTicket from the FormIdentity
        Dim ticket As FormsAuthenticationTicket = formsId.Ticket()
        If ticket.Expired Then
            Response.Write("Authentication failed, so the role is set to " & _
                ticket.UserData)
        Else
            Response.Write("Authentication succeeded, so the role is set to " & _
                ticket.UserData)
        End If
    End Sub

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head>
        <title>WebForm1</title>
    </head>
    <body>
        <form id="Form1" method="post" runat="server">
            <asp:Label id="UserIdLabel" runat="server"
                style="left: 144px; position: absolute; top: 160px">
                User-ID:</asp:Label>
            <asp:Label id="PasswordLabel" runat="server"
                style="left: 144px; position: absolute; top: 200px">
                Password:</asp:Label>
            <asp:TextBox id="UserNameTextBox" runat="server"
                style="left: 232px; position: absolute; top: 160px;
                width:182px; height:22px"></asp:TextBox>
            <asp:TextBox id="PasswordTextBox" runat="server"
                style="left: 232px; position: absolute; top: 200px;
                width:181px; height:22px" TextMode="Password">
                </asp:TextBox>
            <asp:Button id="Login" runat="server" Text="Login"
                style="left: 232px; position: absolute; top: 232px; 
                width:100px"></asp:Button>
        </form>
    </body>
</html>
<%--</snippet1>--%>