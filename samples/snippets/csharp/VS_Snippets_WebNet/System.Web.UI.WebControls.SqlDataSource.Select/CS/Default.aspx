<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <!-- <Snippet1> -->
        <asp:SqlDataSource 
            ID="SqlDataSource1" 
            runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            SelectCommand="SELECT Count(*) FROM [Products] WHERE ([ReorderLevel] &gt; 0)">
        </asp:SqlDataSource>
        <asp:Label 
            ID="Label1" 
            runat="server" 
            Text="">
        </asp:Label>
        <br />
        <asp:Button 
            ID="Button1" 
            Text="Check Reorder Status" 
            runat="server" 
            onclick="Button1_Click" />
        <!-- </Snippet1> -->
    </div>
    </form>
</body>
</html>
