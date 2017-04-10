<!-- <snippet1> -->
<%@ page language="C#" %>
<%@ Import Namespace="System.Drawing" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    private void Page_Load(object sender, System.EventArgs e)
    {
//<Snippet4>
        // Create a TableItemStyle object that can be
        // set as the default style for all cells
        // in the table.
        TableItemStyle tableStyle = new TableItemStyle();
        tableStyle.HorizontalAlign = HorizontalAlign.Center;
        tableStyle.VerticalAlign = VerticalAlign.Middle;
        tableStyle.Width = Unit.Pixel(100);
//</Snippet4>

//<Snippet5>
        // Create more rows for the table.
        for (int rowNum = 2; rowNum < 10; rowNum++)
        {
            TableRow tempRow = new TableRow();
            for (int cellNum = 0; cellNum < 3; cellNum++)
            {
                TableCell tempCell = new TableCell();
                tempCell.Text = 
                    String.Format("({0},{1})", rowNum, cellNum);
                tempRow.Cells.Add(tempCell);
            }
            Table1.Rows.Add(tempRow);
        }
//</Snippet5>

//<Snippet6>
        // Apply the TableItemStyle to all rows in the table.
        foreach (TableRow rw in Table1.Rows)
            foreach (TableCell cel in rw.Cells)
                cel.ApplyStyle(tableStyle);
//</Snippet6>

//<Snippet7>
        // Create a header for the table.
        TableHeaderCell header = new TableHeaderCell();
        header.RowSpan = 1;
        header.ColumnSpan = 3;
        header.Text = "Table of (x,y) Values";
        header.Font.Bold = true;
        header.BackColor = Color.Gray;
        header.HorizontalAlign = HorizontalAlign.Center;
        header.VerticalAlign = VerticalAlign.Middle;

        // Add the header to a new row.
        TableRow headerRow = new TableRow();
        headerRow.Cells.Add(header);

        // Add the header row to the table.
        Table1.Rows.AddAt(0, headerRow);  
//</Snippet7>
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>TableCell Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

    <h1>TableCell Example</h1>
    <asp:table id="Table1" runat="server" 
        CellPadding="3" CellSpacing="3"
        Gridlines="both">
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
    </asp:table>

    </div>
    </form>
  </body>
</html>
<!-- </snippet1> -->
