<!-- <snippet1> -->
<%@ page language="VB" %>
<%@ Import Namespace="System.Drawing" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        '<Snippet4>
        ' Create a TableItemStyle object that can be
        ' set as the default style for all cells
        ' in the table.
        Dim tableStyle As New TableItemStyle()
        tableStyle.HorizontalAlign = HorizontalAlign.Center
        tableStyle.VerticalAlign = VerticalAlign.Middle
        tableStyle.Width = Unit.Pixel(100)
        '</Snippet4>
        '<Snippet5>
        ' Create more rows for the table.
        Dim rowNum As Integer
        For rowNum = 2 To 9
            Dim tempRow As New TableRow()
            Dim cellNum As Integer
            For cellNum = 0 To 2
                Dim tempCell As New TableCell()
                tempCell.Text = _
                    String.Format("({0},{1})", rowNum, cellNum)
                tempRow.Cells.Add(tempCell)
            Next
            Table1.Rows.Add(tempRow)
        Next
        '</Snippet5>

        '<Snippet6>
        ' Apply the TableItemStyle to all rows in the table.
        Dim rw As TableRow
        For Each rw In Table1.Rows
            Dim cel As TableCell
            For Each cel In rw.Cells
                cel.ApplyStyle(tableStyle)
            Next
        Next
        '</Snippet6>

        '<Snippet7>
        ' Create a header for the table.
        Dim header As New TableHeaderCell()
        header.RowSpan = 1
        header.ColumnSpan = 3
        header.Text = "Table of (x,y) Values"
        header.Font.Bold = True
        header.BackColor = Color.Gray
        header.HorizontalAlign = HorizontalAlign.Center
        header.VerticalAlign = VerticalAlign.Middle

        ' Add the header to a new row.
        Dim headerRow As New TableRow()
        headerRow.Cells.Add(header)

        ' Add the header row to the table.
        Table1.Rows.AddAt(0, headerRow)
        '</Snippet7>
    End Sub
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
