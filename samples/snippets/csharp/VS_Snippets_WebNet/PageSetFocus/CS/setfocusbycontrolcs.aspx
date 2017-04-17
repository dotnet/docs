<!-- <Snippet2> -->
<%@ page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    void Page_Init(object sender, EventArgs e)
    {
        SetFocus(focusHere);
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:textbox id="default" runat="server" /><br />
        <asp:textbox id="focusHere" runat="server" />
    </form>
</body>
</html>
<!-- </Snippet2> -->
