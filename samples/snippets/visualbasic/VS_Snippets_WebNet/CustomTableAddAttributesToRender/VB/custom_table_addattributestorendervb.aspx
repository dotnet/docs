<!-- <Snippet1> -->
<%@ Page Language="VB" %>
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.VB.Controls" Assembly="Samples.AspNet.VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head2" runat="server">
    <title>Custom Table - AddAttributesToRender - VB Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

    <h3>Custom Table - AddAttributesToRender - VB Example</h3>

    <aspSample:CustomTableAddAttributesToRender 
        id="Table1" runat="server"
        GridLines="Both" CellPadding="4">
        <asp:TableRow>
            <asp:TableCell>Row 0, Col 0</asp:TableCell>
            <asp:TableCell>Row 0, Col 1</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Row 1, Col 0</asp:TableCell>
            <asp:TableCell>Row 1, Col 1</asp:TableCell>
        </asp:TableRow>
    </aspSample:CustomTableAddAttributesToRender>
      
    </div>
    </form>
</body>
</html>
<!--</Snippet1>-->
