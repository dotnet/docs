    Public Sub RemoveMyButton()
        Dim btns As Integer
        btns = toolBar1.Buttons.Count
        
        ' Remove the last toolbar button.
        toolBar1.Buttons.RemoveAt(btns - 1)
    End Sub
