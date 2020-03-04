<!-- <Snippet1> -->
<%@ page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>TableRow, TableFooter Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

    <h1>TableRow, TableFooter Example</h1>
    <asp:table id="Table1" runat="server" CellPadding="3" CellSpacing="0">
        <asp:TableRow TableSection="TableHeader" BackColor="Pink">
            <asp:TableCell Text="Header" ColumnSpan="3" />
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Text="(0,0)"></asp:TableCell>
            <asp:TableCell Text="(0,1)"></asp:TableCell>
            <asp:TableCell Text="(0,2)"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Text="(1,0)"></asp:TableCell>
            <asp:TableCell Text="(1,1)"></asp:TableCell>
            <asp:TableCell Text="(1,2)"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow TableSection="TableFooter" BackColor="Pink">
            <asp:TableCell Text="Footer" ColumnSpan="3" />
        </asp:TableRow>
    </asp:table>

    </div>
    </form>
  </body>
</html>
<!-- </Snippet1> -->
