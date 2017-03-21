    <System.Runtime.InteropServices.DllImportAttribute("GDI32.DLL")> _
    Private Shared Function GetStockObject(ByVal fnObject As Integer) As IntPtr
    End Function
    Public Sub FromHfont_Example(ByVal e As PaintEventArgs)

        ' Get a handle for a GDI font.
        Dim hFont As IntPtr = GetStockObject(17)

        ' Create a Font object from hFont.
        Dim hfontFont As Font = Font.FromHfont(hFont)

        ' Use hfontFont to draw text to the screen.
        e.Graphics.DrawString("This font is from a GDI HFONT", hfontFont, _
        Brushes.Black, 0, 0)
    End Sub