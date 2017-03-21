    <System.Security.Permissions.SecurityPermission( _
    System.Security.Permissions.SecurityAction.LinkDemand, Flags := _
    System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)> _
    Private Sub FromHdcHdc(ByVal e As PaintEventArgs)

        ' Get handle to device context.
        Dim hdc As IntPtr = e.Graphics.GetHdc()

        ' Create new graphics object using handle to device context.
        Dim newGraphics As Graphics = Graphics.FromHdc(hdc)

        ' Draw rectangle to screen.
        newGraphics.DrawRectangle(New Pen(Color.Red, 3), 0, 0, 200, 100)

        ' Release handle to device context and dispose of the Graphics 	' object
        e.Graphics.ReleaseHdc(hdc)
        newGraphics.Dispose()
    End Sub