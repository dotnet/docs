
    ' Reference the DeleteObject method in the GDI library.
    <System.Runtime.InteropServices.DllImportAttribute("GDI32.DLL")> _
    Private Shared Function DeleteObject(ByVal objectHandle As IntPtr) As Boolean
    End Function

    Public Sub ToHfont_Example(ByVal e As PaintEventArgs)

        ' Create a Font object.
        Dim myFont As New Font("Arial", 16)

        ' Get a handle to the Font object.
        Dim hFont As IntPtr = myFont.ToHfont()

        ' Display a message box with the value of hFont.
        MessageBox.Show(hFont.ToString())

        ' Dispose of the hFont.
        DeleteObject(hFont)
    End Sub