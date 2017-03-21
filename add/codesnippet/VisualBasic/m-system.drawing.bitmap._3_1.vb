    <System.Runtime.InteropServices.DllImportAttribute("user32.dll", CharSet:=CharSet.Unicode)> _
    Private Shared Function LoadImage(ByVal Hinstance As Integer, ByVal name As String, ByVal type As Integer, ByVal width As Integer, ByVal height As Integer, ByVal load As Integer) As IntPtr
    End Function

    Private Sub HICON_Example(ByVal e As PaintEventArgs)

        ' Get a handle to an icon.
        Dim Hicon As IntPtr = LoadImage(0, "smile.ico", 1, 0, 0, 16)

        ' Create a Bitmap object from the icon handle.
        Dim iconBitmap As Bitmap = Bitmap.FromHicon(Hicon)

        ' Draw the Bitmap object to the screen.
        e.Graphics.DrawImage(iconBitmap, 0, 0)
    End Sub