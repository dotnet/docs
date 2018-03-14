<!-- <Snippet1> -->
<%@ page language="VB"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    Sub OnLoggedInHandler(ByVal sender As Object, ByVal e As EventArgs)
        Createuserwizard1.CompleteSuccessText = _
            String.Format("{0}, thanks for signing up for an account.", _
            Context.User.Identity.Name)
    End Sub
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
        <title>
            CreateUserWizard Sample</title>
    </head>
    <body>
        <form id="form1" runat="server">
            <asp:createuserwizard id="Createuserwizard1" runat="server" 
                oncreateduser="OnLoggedInHandler">
            </asp:createuserwizard>
        </form>
    </body>
</html>
<!-- </Snippet1> -->