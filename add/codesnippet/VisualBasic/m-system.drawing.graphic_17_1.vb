    Private Sub FromHwndHwnd(ByVal e As PaintEventArgs)

        ' Get handle to form.
        Dim hwnd As IntPtr = Me.Handle


        ' Create new graphics object using handle to window.
        Dim newGraphics As Graphics = Graphics.FromHwnd(hwnd)

        ' Draw rectangle to screen.
        newGraphics.DrawRectangle(New Pen(Color.Red, 3), 0, 0, 200, 100)

        ' Dispose of new graphics.
        newGraphics.Dispose()
    End Sub