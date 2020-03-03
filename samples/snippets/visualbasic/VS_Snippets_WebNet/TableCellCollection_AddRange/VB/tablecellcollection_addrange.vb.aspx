<%--
   System.Web.UI.WebControls.TableCellCollection.AddRange
   
   The following program generates an array of 'TableCell' and then
   adds the array to each row using 'AddRange' method of 
   'TableCellCollection' class.
   The row 'myTableRow' is then added to the Table.    
--%>
<%@ page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    ' <Snippet1>      
    Sub Page_Load(ByVal sender As Object, _
        ByVal e As EventArgs)

        Dim numRows As Integer = 3
        Dim numCells As Integer = 2
        ' Create 3 rows, each containing 2 cells.
        Dim rowNum As Integer
        For rowNum = 0 To numRows - 1
            Dim arrayOfTableRowCells(numCells - 1) As TableCell
            Dim rw As New TableRow()
            Dim cellNum As Integer
            For cellNum = 0 To numCells - 1
                Dim cel As New TableCell()
                cel.Text = _
                    String.Format("[Row {0}, Cell {1}]", rowNum, cellNum)
                arrayOfTableRowCells(cellNum) = cel
            Next

            ' Get 'TableCellCollection' associated with the 'TableRow'.
            Dim myTableCellCol As TableCellCollection = rw.Cells
            ' Add a row of cells. 
            myTableCellCol.AddRange(arrayOfTableRowCells)
            Table1.Rows.Add(rw)
        Next
    End Sub
    ' </Snippet1>      
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>TableCaptionAlign Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

    <h3>TableCellCollection Example</h3>
    <asp:Table id="Table1" GridLines="Both" 
        CellPadding="8" Runat="server" />

    </div>
    </form>
  </body>
</html>
