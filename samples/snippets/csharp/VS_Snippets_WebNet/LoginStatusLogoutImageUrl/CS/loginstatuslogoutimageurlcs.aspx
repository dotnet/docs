<!-- <Snippet1> -->
<%@ Page Language="C#" autoeventwireup="False" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    void Button1_Click(Object sender, EventArgs e) {
        LoginStatus1.LogoutImageUrl = String.Empty;
        Button1.Visible = false;
    }

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            <asp:LoginStatus id="LoginStatus1" runat="server" 
               LogoutImageUrl="images\logoff.png" />
        </p>
        <p>
            <asp:Button id="Button1" onclick="Button1_Click" runat="server" 
               Text="Use Text" />
        </p>
    </form>
</body>
</html>
<!-- </Snippet1> -->