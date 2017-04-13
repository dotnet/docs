<!-- <Snippet11> -->
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReadWriteCache.aspx.cs" Inherits="ReadWriteCache" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Read Write Application Cache</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Read Write Application Cache</h2>

        <asp:Label ID="Label1" Text="[Application Cache goes here.]" runat="server"></asp:Label>
        
        <hr />

        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Write Cache" /> &nbsp; &nbsp;
        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Read Cache" />
    </form>
</body>
</html>
<!-- <Snippet11> -->