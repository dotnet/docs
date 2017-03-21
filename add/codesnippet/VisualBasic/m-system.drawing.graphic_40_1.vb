    <System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")> _
    Private Shared Function SelectPalette(ByVal hdc As IntPtr, _
    ByVal htPalette As IntPtr, ByVal bForceBackground As Boolean) As IntPtr
    End Function

    <System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")> _
    Private Shared Function RealizePalette(ByVal hdc As IntPtr) As Integer
    End Function

    <System.Security.Permissions.SecurityPermission( _
    System.Security.Permissions.SecurityAction.LinkDemand, Flags:= _
    System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)> _
    Private Sub GetHalftonePaletteVoid(ByVal e As PaintEventArgs)

        ' Create and draw image.
        Dim imageFile As Image = Image.FromFile("SampImag.jpg")
        e.Graphics.DrawImage(imageFile, New Point(0, 0))

        ' Get handle to device context.
        Dim hdc As IntPtr = e.Graphics.GetHdc()

        ' Get handle to halftone palette.
        Dim htPalette As IntPtr = Graphics.GetHalftonePalette()

        ' Select and realize new palette.
        SelectPalette(hdc, htPalette, True)
        RealizePalette(hdc)

        ' Create new graphics object.
        Dim newGraphics As Graphics = Graphics.FromHdc(hdc)

        ' Draw image with new palette.
        newGraphics.DrawImage(imageFile, 300, 0)

        ' Release handle to device context.
        e.Graphics.ReleaseHdc(hdc)
    End Sub