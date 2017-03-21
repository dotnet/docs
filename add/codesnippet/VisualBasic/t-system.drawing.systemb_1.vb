    Private Sub ShowHotKey(ByVal e As PaintEventArgs)

        ' Declare the string with keyboard shortcut.
        Dim text As String = "&Click Here"

        ' Declare a new StringFormat.
        Dim format As New StringFormat

        ' Set the HotkeyPrefix property.
        format.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show

        ' Draw the string.
        Dim theBrush As Brush = _
            SystemBrushes.FromSystemColor(SystemColors.Highlight)
        e.Graphics.DrawString(text, Me.Font, theBrush, 30, 40, format)
    End Sub