    Public Sub Clone_Example(ByVal e As PaintEventArgs)

        ' Create a Font object.
        Dim myFont As New Font("Arial", 16)

        ' Create a copy of myFont.
        Dim cloneFont As Font = CType(myFont.Clone(), Font)

        ' Use cloneFont to draw text to the screen.
        e.Graphics.DrawString("This is a cloned font", cloneFont, _
        Brushes.Black, 0, 0)
    End Sub