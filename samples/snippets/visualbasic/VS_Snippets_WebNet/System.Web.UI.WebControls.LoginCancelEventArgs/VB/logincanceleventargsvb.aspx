<!-- <snippet1> -->
<%@ Page Language="VB" AutoEventWireup="false" CodeFile="LoginCancelEventArgs.vb" Inherits="LoginCancelEventArgsvb_aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
        <form id="Form1" runat="server">
            <asp:Login id="Login1" 
              runat="server" 
              onloggingin="OnLoggingIn">
            </asp:Login>
        </form>
    </body>
</html>
<!-- </snippet1> -->