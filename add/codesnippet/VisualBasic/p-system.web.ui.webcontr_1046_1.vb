    Sub Button_Click_Coord(sender As Object, e As EventArgs)
        
        Dim rowNum As Integer
        For rowNum = 0 To Table1.Rows.Count - 1
            Dim cellNum As Integer
            For cellNum = 0 To (Table1.Rows(rowNum).Cells.Count) - 1                
                Table1.Rows(rowNum).Cells(cellNum).Text = _
                    String.Format("({0}, {1})", rowNum, cellNum)
            Next
        Next
    End Sub
