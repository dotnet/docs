<!-- <Snippet1> -->
<%@ Page Language="C#" AutoEventWireup="true" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    void LoginStatus1_LoggedOut(Object sender, System.EventArgs e)
    {
        // Perform any post-logout processing, such as setting the
          // user's last logout time or clearing a per-user cache of 
          // objects here.
    }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
        <form id="form1" runat="server">
            <asp:LoginStatus id="LoginStatus1" 
              runat="server" 
              onloggedout="LoginStatus1_LoggedOut">
            </asp:LoginStatus>
        </form>
    </body>
</html>
<!-- </Snippet1> -->