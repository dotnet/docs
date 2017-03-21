<System.Runtime.InteropServices.DllImportAttribute("user32.dll")> _
    Private Shared Function DestroyIcon(ByVal handle _ 
	As IntPtr) As Boolean 
    End Function

   Private Sub GetHicon_Example(ByVal e As PaintEventArgs)

        ' Create a Bitmap object from an image file.
        Dim myBitmap As New Bitmap("c:\FakePhoto.jpg")

        ' Draw myBitmap to the screen.
        e.Graphics.DrawImage(myBitmap, 0, 0)

        ' Get an Hicon for myBitmap.
        Dim HIcon As IntPtr = myBitmap.GetHicon()
	
        ' Create a new icon from the handle.
        Dim newIcon As Icon = System.Drawing.Icon.FromHandle(HIcon)

        ' Set the form Icon attribute to the new icon.
        Me.Icon = newIcon

        ' You can now destroy the icon, since the form creates its 
        ' own copy of the icon accessible through the Form.Icon property.
	DestroyIcon(newIcon.Handle)
    End Sub
