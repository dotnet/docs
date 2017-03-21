    Public Sub CreateMyMultilineTextBox()
        ' Create an instance of a TextBox control.
        Dim textBox1 As New TextBox()
        
        ' Set the Multiline property to true.
        textBox1.Multiline = True
        ' Add vertical scroll bars to the TextBox control.
        textBox1.ScrollBars = ScrollBars.Vertical
        ' Allow the TAB key to be entered in the TextBox control.
        textBox1.AcceptsReturn = True
        ' Allow the TAB key to be entered in the TextBox control.
        textBox1.AcceptsTab = True
        ' Set WordWrap to true to allow text to wrap to the next line.
        textBox1.WordWrap = True
        ' Set the default text of the control.
        textBox1.Text = "Welcome!"
    End Sub
