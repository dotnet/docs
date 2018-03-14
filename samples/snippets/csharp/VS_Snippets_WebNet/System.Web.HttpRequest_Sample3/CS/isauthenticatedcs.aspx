<%@ Page Language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
// <snippet1>
    private void Page_Load(object sender, EventArgs e)
    {
        // Check whether the current request has been
        // authenticated. If it has not, redirect the 
        // user to the Login.aspx page.
        if (!Request.IsAuthenticated)
        {
            Response.Redirect("Login.aspx");
        }
    }
// </snippet1>

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
        <!-- Insert content here -->
    </form>
</body>
</html>
