<!-- <Snippet3> -->
<%@ Control Language="VB" AutoEventWireup="true" CodeFile="SimpleControl.ascx.vb" Inherits="SimpleControl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
<form id="Form1" runat="server">
<table cellspacing="15">
<tr>
<td><b>Available items: </b></td>
<td>
    <asp:Label ID="ItemsRemaining" runat="server" Text="Label"></asp:Label>
</td>
</tr>
<tr>
<td><b>As of: </b></td>
<td>
    <asp:Label ID="CacheTime" runat="server" Text="Label"></asp:Label>
</td>
</tr>
</table>
</form>
</body>
</html>
<!-- </Snippet3> -->
