<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default"  ValidateRequest="false" %>
<%@ OutputCache Location="None" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Federation Relying Party Sample Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <br />
        <h1>Welcome to Relying Party Website.</h1>
        <br />
        <br />
    <div>
        <asp:Label ID="WelcomeMessage" runat="server" Font-Bold="True" 
            Font-Names="Franklin Gothic Book" Font-Size="X-Large"></asp:Label>
    </div>
        <br />
        <br />
    <div>
        <asp:Button ID="SignOutButton" runat="server" onclick="SignOutButton_Click" Text="Sign Out"/>
    </div>
        <br />
        <br />
    </form>
</body>
</html>
