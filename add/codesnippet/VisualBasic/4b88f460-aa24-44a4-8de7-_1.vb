    Private Sub MeasureText1(ByVal e As PaintEventArgs)
        Dim text1 As String = "Measure this text"
        Dim arialBold As New Font("Arial", 12.0F)
        Dim textSize As Size = TextRenderer.MeasureText(text1, arialBold)
        TextRenderer.DrawText(e.Graphics, text1, arialBold, _
            New Rectangle(New Point(10, 10), textSize), Color.Red)

    End Sub
