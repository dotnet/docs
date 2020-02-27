<!-- <Snippet1> -->
<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    void LoginStatus1_LoggingOut(Object sender, System.Web.UI.WebControls.LoginCancelEventArgs e)
    {
        Message.Text = "LoggingOut event. Don't go away now.";
        e.Cancel = true;
    }
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
        <form id="FORM1" runat="server">
            <asp:LoginStatus id="LoginStatus1" 
              runat="server" 
              onloggingout="LoginStatus1_LoggingOut">
            </asp:LoginStatus>
            <p></p>
            <asp:Literal id="Message" 
              runat="server" />
        </form>
    </body>
</html>
<!-- </Snippet1> -->
