    Private Sub AddSizes(ByVal e As PaintEventArgs) 
        Dim size1 As New Size(100, 100)
        Dim size2 As New Size(50, 50)
        e.Graphics.DrawRectangle(Pens.Black, New Rectangle(New Point(10, 10), size1))
        size1 = System.Drawing.Size.Add(size1, size2)
        e.Graphics.DrawRectangle(Pens.Red, New Rectangle(New Point(10, 10), size1))
    
    End Sub