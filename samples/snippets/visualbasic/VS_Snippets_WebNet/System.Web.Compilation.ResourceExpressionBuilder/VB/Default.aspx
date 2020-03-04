<!--<Snippet1>-->
<%@ Page Language="VB" UICulture="auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Sales Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        All prices listed in 
        <asp:Literal ID="Literal1" runat="server" 
        Text="<%$ Resources: Financial, Currency %>" />.
    </div>
    </form>
</body>
</html>
<!--</Snippet1>-->
