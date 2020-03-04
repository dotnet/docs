<!-- <Snippet4> -->

<%@ Page AutoEventWireup="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>User Login Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <h1>
        Log In</h1>
    <div>
        <%--    The Login control does all the work.  --%>
        <asp:Login ID="Login1" runat="server">
        </asp:Login>
    </div>
    </form>
</body>
</html>
<!-- </Snippet4> -->
