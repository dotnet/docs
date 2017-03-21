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