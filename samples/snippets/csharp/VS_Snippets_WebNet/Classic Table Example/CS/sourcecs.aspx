<!--<Snippet1>-->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

    <h3>Table example, constructed at design time</h3>
    <asp:Table id="Table1" runat="server"
        CellPadding="10" 
        GridLines="Both"
        HorizontalAlign="Center">
        <asp:TableRow>
            <asp:TableCell>
                Row 0, Col 0
            </asp:TableCell>
            <asp:TableCell>
                Row 0, Col 1
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                Row 1, Col 0
            </asp:TableCell>
            <asp:TableCell>
                Row 1, Col 1
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    
    </div>
    </form>
</body>
</html>
<!--</Snippet1>-->
