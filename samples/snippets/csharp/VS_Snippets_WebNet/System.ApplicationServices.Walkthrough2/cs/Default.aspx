<!-- <Snippet2> --> 
<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Application Services Home Page</title>
<style type="text/css">
td{padding:6px; vertical-align:top;border:solid 1px #eeeeee;}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Application Services Home Page</h1>

        The following selections let you create users, assign them to roles, and
        set their profile information.

        <p>
            <asp:Label ID="LoggedId"  Font-Bold="true" ForeColor="red" runat="server"/>
        </p>

        <table>
            <tr>
                <td align="right" >Log in:</td>
                <td align="left"><asp:LoginStatus ID="LoginStatus1" runat="server" /></td>
            </tr>
            <tr>
                <td align="right" >Set profile information:<br/>(You must be logged in.)</td>
                <td align="left"><a href="ProfileInfo.aspx" target="_self">Profile Information</a></td>
            </tr>
            <tr>
                <td align="right" >Create user and assign role:</td>
                <td align="left"><a href="CreateUser.aspx"target="_self">New User</a></td>
            </tr>

         </table>
    </div>

    </form>
</body>
</html>
<!-- </Snippet2> --> 

