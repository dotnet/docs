<!-- <Snippet1> -->
<%@ page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>TableHeaderRow-TableFooterRow Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

    <h3>TableHeaderRow and TableFooterRow Example</h3>

    <asp:Table id="Table1" runat="server" 
        CellPadding="3" 
        CellSpacing="0"
        GridLines="both"
        Caption="Sample Table">

        <asp:TableHeaderRow id="Table1HeaderRow" 
            BackColor="LightBlue"
            runat="server">
            <asp:TableHeaderCell 
                Scope="Column" 
                Text="Col1" />
            <asp:TableHeaderCell  
                Scope="Column" 
                Text="Col2" />
            <asp:TableHeaderCell 
                Scope="Column" 
                Text="Col3" />
        </asp:TableHeaderRow>              

        <asp:TableRow>
            <asp:TableCell Text="(0,0)" />
            <asp:TableCell Text="(0,1)" />
            <asp:TableCell Text="(0,2)" />
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell Text="(1,0)" />
            <asp:TableCell Text="(1,1)" />
            <asp:TableCell Text="(1,2)" />
        </asp:TableRow> 

        <asp:TableFooterRow runat="server"
            BackColor="LightBlue">
            <asp:TableCell 
                ColumnSpan="3" 
                Text="The footer row." />
        </asp:TableFooterRow>                               
    </asp:Table>

    </div>
    </form>
  </body>
</html>
<!-- </Snippet1> -->
