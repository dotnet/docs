    Public Sub CreateMyBorderlesWindow()
        FormBorderStyle = FormBorderStyle.None
        MaximizeBox = False
        MinimizeBox = False
        StartPosition = FormStartPosition.CenterScreen
        ' Remove the control box so the form will only display client area.
        ControlBox = False
    End Sub 'CreateMyBorderlesWindow