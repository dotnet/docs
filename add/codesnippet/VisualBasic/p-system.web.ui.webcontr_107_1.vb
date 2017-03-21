    Sub Button_Click_Coord(sender As Object, e As EventArgs)
        
        Dim i As Integer
        For i = 0 To Table1.Rows.Count - 1
            Dim j As Integer
            For j = 0 To (Table1.Rows(i).Cells.Count) - 1                
                Table1.Rows(i).Cells(j).Text = "(" & j.ToString() & _
                    ", " & i.ToString() & ")"
            Next j
        Next i 
    End Sub
