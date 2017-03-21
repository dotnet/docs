    Private Sub ZoomMyRichTextBox()
        ' Enable users to select entire word when double clicked.
        richTextBox1.AutoWordSelection = True
        ' Clear contents of control.
        richTextBox1.Clear()
        ' Set the right margin to restrict horizontal text.
        richTextBox1.RightMargin = 2
        ' Set the text for the control.
        richTextBox1.SelectedText = "Alpha Bravo Charlie Delta Echo Foxtrot"
        ' Zoom by 2 points.
        richTextBox1.ZoomFactor = 2.0F
    End Sub