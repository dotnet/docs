<!-- <Snippet2> --> 
<%@ Page Language="VB" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Application Services Home Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>Enter Users' Information</h2>

        The following selections enable you to create users, and assign them roles and
        profile information.

        <p>
            <asp:Label ID="LoggedId"  Font-Bold="true" ForeColor="red" runat="server"/>
        </p>

        <table border="1">
            <tr>
                <td align="left">Login to change profile</td>
                <td align="left"><asp:LoginStatus ID="LoginStatus1" runat="server" /></td>
            </tr>
            <tr>
                <td align="left">Define profile information (you must login first)</td>
                <td align="left"><a href="ProfileInfo.aspx" target="_self">Profile Information</a></td>
            </tr>
            <tr>
                <td align="left">Create user and assign role</td>
                <td align="left"><a href="CreateUser.aspx"target="_self">New User</a></td>
            </tr>

         </table>
    </div>

    </form>
</body>
</html>
<!-- </Snippet2> --> 