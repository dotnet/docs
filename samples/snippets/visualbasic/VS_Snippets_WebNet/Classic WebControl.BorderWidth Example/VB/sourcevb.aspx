<!--<Snippet1>-->
<%@ Page Language="VB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Table Property</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3>Property of a Table Web Control</h3>
 
        <asp:Table id="Table1" runat="server"
            CellPadding = "10" 
            CellSpacing="0"
            GridLines="Both"
            BorderColor="Red"
            BorderWidth="3">

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
