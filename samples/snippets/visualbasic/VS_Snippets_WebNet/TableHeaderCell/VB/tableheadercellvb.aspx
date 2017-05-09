<!-- <Snippet1> -->
<%@ page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>TableHeaderCell Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

    <h1>TableHeaderCell Example</h1>
    <asp:table id="Table1" runat="server" 
        CellPadding="3" 
        CellSpacing="3" 
        BorderWidth="1" 
        GridLines="Both"> 
        <asp:TableHeaderRow ID="TableHeaderRow1" runat="server">
            <asp:TableHeaderCell runat="server" 
                ID="Column1Header"
                CategoryText="Column1"
                AbbreviatedText="Header 1"
                Scope="Column" 
                HorizontalAlign="Center" 
                VerticalAlign="Middle" 
                BackColor="LightGray">
                Column 1 Header
            </asp:TableHeaderCell>
            <asp:TableHeaderCell runat="server"
                ID="Column2Header"
                CategoryText="Column2,Column2Alternative"
                AbbreviatedText="Header 2"
                Scope="Column"
                HorizontalAlign="Center" 
                VerticalAlign="Middle"
                BackColor="LightGray">
                Column 2 Header
            </asp:TableHeaderCell>                                        
            <asp:TableHeaderCell runat="server" 
                ID="Column3Header"
                CategoryText="Column3"
                AbbreviatedText="Header 3"
                Scope="Column"
                HorizontalAlign="Center" 
                VerticalAlign="Middle"
                BackColor="LightGray">
                Column 3 Header
            </asp:TableHeaderCell>                                        
        </asp:TableHeaderRow>
        <asp:TableRow HorizontalAlign="Center">
            <asp:TableCell AssociatedHeaderCellID="Column1Header"
                HorizontalAlign="Left">
                (0,0)
            </asp:TableCell>
            <asp:TableCell 
                AssociatedHeaderCellID="Column2Header">
                (0,1)
            </asp:TableCell>
            <asp:TableCell 
                AssociatedHeaderCellID="Column3Header">
                (0,2)
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow 
            HorizontalAlign="Center">
            <asp:TableCell 
                AssociatedHeaderCellID="Column1Header"
                HorizontalAlign="Left">
                (1,0)
            </asp:TableCell>
            <asp:TableCell 
                AssociatedHeaderCellID="Column2Header">
                (1,1)
            </asp:TableCell>
            <asp:TableCell 
                AssociatedHeaderCellID="Column3Header">
                (1,2)
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow 
            HorizontalAlign="Center">
            <asp:TableCell 
                AssociatedHeaderCellID=
                    "Column1Header,Column2Header,Column3Header"
                ColumnSpan="3"
                HorizontalAlign="Left">
                (2,0)
            </asp:TableCell>
        </asp:TableRow>
    </asp:table>

    </div>
    </form>
  </body>
</html>
<!-- </Snippet1> -->
