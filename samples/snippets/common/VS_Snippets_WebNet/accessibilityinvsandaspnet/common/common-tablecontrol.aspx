<%@ Page %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
<%--<Snippet21>--%>
<asp:Table ID="Table1" runat="server">
    <asp:TableHeaderRow TableSection="TableHeader">
        <asp:TableHeaderCell ID="productheader">Product</asp:TableHeaderCell>
        <asp:TableHeaderCell ID="priceheader">Price</asp:TableHeaderCell>
    </asp:TableHeaderRow>
    <asp:TableRow>
        <asp:TableCell AssociatedHeaderCellID="productheader">Milk</asp:TableCell>
        <asp:TableCell AssociatedHeaderCellID="priceheader">$2.33</asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell AssociatedHeaderCellID="productheader">Cereal</asp:TableCell>
        <asp:TableCell AssociatedHeaderCellID="priceheader">$5.61</asp:TableCell>
    </asp:TableRow>
</asp:Table>
<%--</Snippet21>--%>
    </div>
    </form>
</body>
</html>
