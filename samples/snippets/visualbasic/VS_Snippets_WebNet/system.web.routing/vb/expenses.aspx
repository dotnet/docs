<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Expenses.aspx.vb" Inherits="Expenses" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%--<Snippet152>--%>
        <h1>
            Expense Report for 
            <asp:Literal ID="Literal1" 
              Text="<%$RouteValue:locale%>" 
              runat="server"></asp:Literal>, 
            <asp:Literal ID="Literal2" 
              Text="<%$RouteValue:year%>" 
              runat="server"></asp:Literal>
        </h1>
        <%--</Snippet152>--%>
    </div>
    </form>
</body>
</html>
