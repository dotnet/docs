<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="false" CodeFile="param1avb.aspx.vb" Inherits="param1avb_aspx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList
          runat="server"
          AutoPostBack="True"
          id="DropDownList1">
            <asp:ListItem Value="USA">USA</asp:ListItem>
            <asp:ListItem Value="UK">UK</asp:ListItem>
         </asp:DropDownList>

        <asp:DataGrid
          runat="server"
          id="DataGrid1" />    
    </div>
    </form>
</body>
</html>
<!--</Snippet1>-->