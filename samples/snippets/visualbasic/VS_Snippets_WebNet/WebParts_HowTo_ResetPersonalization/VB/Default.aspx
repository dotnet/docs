<!--<snippet4>-->
<%@ Page Language="VB"  %>
<!DOCTYPE html PUBLIC "-'W3C'DTD XHTML 1.0 Transitional'EN" "http:'www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    '<snippet1>
    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ' Verify that the text box txtUser is not empty.
        If (txtUser.Text.Length < 1) Then
            Response.Write("You must enter a user name.")
        End If
        Return
        
        ' Reset the user.
        If (Not PersonalizationAdministration.ResetUserState("~/Default.aspx", txtUser.Text)) Then
            Response.Write("The user could not be found or the user has not personalized this page.")
        End If
    End Sub
    '</snippet1>
    
    '<snippet2>
    Protected Sub btnClearList_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ' Verify that the text box is not empty.
        If (txtUser.Text.Length < 1) Then
            Response.Write("You must enter at least one user name.")
            Return
        End If
    
        ' Extract the list of users.
        Dim users As Array
        users = txtUserList.Text.Split(" ,;".ToCharArray())
        
        ' Reset the users.
        Dim RowsReset As Integer
        RowsReset = PersonalizationAdministration.ResetUserState("~/Default.aspx", users)
        Response.Write(RowsReset + "of " + users.Length + " users found and removed.")
    End Sub
    '</snippet2>

    '<snippet3>
    Protected Sub btnClearInactive_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ' Verify that a date is selected.
        If (calInactive.SelectedDate = DateTime.MinValue) Then
            Response.Write("You must select a date.")
            Return
        End If

        ' Reset all users inactive since the selected date.
        Dim RowsReset As Integer
        RowsReset = PersonalizationAdministration.ResetInactiveUserState("~/Default.aspx", calInactive.SelectedDate)
        Response.Write(RowsReset + " inactive users removed.")
    End Sub
    '</snippet3>

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