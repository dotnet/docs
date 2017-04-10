<%@ page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
<form id="form1" runat="server">
<!--<snippet1>-->
<asp:repeater runat="server" id="Specials" skinid = "ProductSpecialsList" />
<asp:repeater runat="server" id="TopItems" skinid = "ProductList" />
<asp:repeater runat="server" id="Items" skinid = "ProductList" />
<!--</snippet1>-->
</form>
</body>
</html>
