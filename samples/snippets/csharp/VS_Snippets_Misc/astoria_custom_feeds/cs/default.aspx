<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NorthwindService._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <ol>
    <li><a href="Northwind.svc">Run Northwind Service (Entity Framework Provider)</a></li>
    <li><a href="OrderItems.svc">Run Order Items Service (Reflection Provider)</a></li>
    </ol>
    </div>
    </form>
</body>
</html>
