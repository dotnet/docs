<!-- <Snippet1> -->
<%@ page language="VB" %>
<%@ Import Namespace="System.Drawing" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    Private Sub Page_Load(ByVal sender As Object, _
        ByVal e As System.EventArgs)

        ' Add rows to the table.
        Dim rowNum As Integer
        For rowNum = 0 To 100
            Dim tempRow As New TableRow
            Dim cellNum As Integer
            For cellNum = 0 To 2
                Dim tempCell As New TableCell
                tempCell.Text = _
                    String.Format("({0},{1})", rowNum, cellNum)
                tempRow.Cells.Add(tempCell)
            Next
            Table1.Rows.Add(tempRow)
        Next
        
        ' Create a TableHeaderRow.
        Dim headerRow As New TableHeaderRow
        headerRow.BackColor = Color.LightBlue

        ' Create TableCell objects to contain 
        ' the text for the header.
        Dim headerTableCell1 As New TableHeaderCell
        Dim headerTableCell2 As New TableHeaderCell
        Dim headerTableCell3 As New TableHeaderCell
        headerTableCell1.Text = "Column 1 Header"
        headerTableCell1.Scope = TableHeaderScope.Column
        headerTableCell1.AbbreviatedText = "Col 1 Head"
        headerTableCell2.Text = "Column 2 Header"
        headerTableCell2.Scope = TableHeaderScope.Column
        headerTableCell2.AbbreviatedText = "Col 2 Head"
        headerTableCell3.Text = "Column 3 Header"
        headerTableCell3.Scope = TableHeaderScope.Column
        headerTableCell3.AbbreviatedText = "Col 3 Head"

        ' Add the TableHeaderCell objects to the Cells
        ' collection of the TableHeaderRow.
        headerRow.Cells.Add(headerTableCell1)
        headerRow.Cells.Add(headerTableCell2)
        headerRow.Cells.Add(headerTableCell3)

        ' Add the TableHeaderRow as the first item 
        ' in the Rows collection of the table.
        Table1.Rows.AddAt(0, headerRow)

        ' Create a TableFooterRow.
        Dim footerRow As New TableFooterRow
        footerRow.BackColor = Color.LightBlue

        ' Create TableCell objects to contain the 
        ' text for the footer.
        Dim footerTableCell1 As New TableCell
        Dim footerTableCell2 As New TableCell
        Dim footerTableCell3 As New TableCell
        footerTableCell1.Text = "Column 1 footer"
        footerTableCell2.Text = "Column 2 footer"
        footerTableCell3.Text = "Column 3 footer"

        ' Add the TableCell objects to the Cells
        ' collection of the TableFooterRow.
        footerRow.Cells.Add(footerTableCell1)
        footerRow.Cells.Add(footerTableCell2)
        footerRow.Cells.Add(footerTableCell3)

        ' Add the TableFooterRow to the Rows
        ' collection of the table.
        Table1.Rows.Add(footerRow)
    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>TableHeaderRow Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

    <h3>TableHeaderRow and TableFooterRow Example</h3>
    <asp:table id="Table1" 
        CellPadding="3" 
        CellSpacing="0" 
        Gridlines="Both" 
        runat="server">
    </asp:table>

    </div>
    </form>
  </body>
</html>
<!-- </Snippet1> -->
