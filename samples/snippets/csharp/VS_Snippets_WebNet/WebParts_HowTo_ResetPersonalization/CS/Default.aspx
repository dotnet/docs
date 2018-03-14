<!--<snippet4>-->
<%@ Page Language="C#"  %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    //<snippet1>
    protected void btnClear_Click(object sender, EventArgs e)
    {
        // Verify that the text box is not empty.
        if (txtUser.Text.Length < 1)
        {
            Response.Write("You must enter a user name.");
            return;
        }
        
        // Reset the user.
        if (! PersonalizationAdministration.ResetUserState("~/Default.aspx", txtUser.Text))
        {
            Response.Write("The user could not be found or the user has not personalized this page");
        }
    }
    //</snippet1>
    
    //<snippet2>
    protected void btnClearList_Click(object sender, EventArgs e)
    {
        // Verify that the text box is not empty.
        if (txtUser.Text.Length < 1)
        {
            Response.Write("You must enter at least one user name.");
            return;
        }

        // Reset the users.
        string[] users = txtUserList.Text.Split(" ,;".ToCharArray());
        int RowsReset = PersonalizationAdministration.ResetUserState("~/Default.aspx", users);
        Response.Write(RowsReset + "of " + users.Length + " users found and removed.");
    }
    //</snippet2>

    //<snippet3>
    protected void btnClearInactive_Click(object sender, EventArgs e)
    {
        // Verify that a date is selected.
        if (calInactive.SelectedDate == DateTime.MinValue)
        {
            Response.Write("You must select a date.");
            return;
        }

        // Reset all users inactive since the selected date.
        int RowsReset = PersonalizationAdministration.ResetInactiveUserState("~/Default.aspx", calInactive.SelectedDate);
        Response.Write(RowsReset + " inactive users removed.");
    }
    //</snippet3>
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>PersonalizationAdministration Sample Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
        <asp:Button ID="btnClear" runat="server" Text="Clear User" OnClick="btnClear_Click" />
        <br />
        <asp:TextBox ID="txtUserList" runat="server" Height="160px"></asp:TextBox>
        <asp:Button ID="btnClearList" runat="server" OnClick="btnClearList_Click" Text="Clear Group" />
        <br />
        <asp:Calendar ID="calInactive" runat="server"></asp:Calendar>
        <asp:Button ID="btnClearInactive" runat="server" Text="Clear Inactive Users" OnClick="btnClearInactive_Click" />
    </form>
</body>
</html>
<!--</snippet4>-->