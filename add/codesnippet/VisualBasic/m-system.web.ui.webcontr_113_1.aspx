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