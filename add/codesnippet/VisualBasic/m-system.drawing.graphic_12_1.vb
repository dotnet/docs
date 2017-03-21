    Public Class GDI
        <System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")> _
        Friend Shared Function Rectangle(ByVal hdc As IntPtr, _
        ByVal ulCornerX As Integer, ByVal ulCornerY As Integer, ByVal lrCornerX As Integer, _
        ByVal lrCornerY As Integer) As Boolean
        End Function
    End Class

    <System.Security.Permissions.SecurityPermission( _
    System.Security.Permissions.SecurityAction.LinkDemand, Flags:= _
    System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)> _
    Private Sub GetHdcForGDI1(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim redPen As New Pen(Color.Red, 1)

        ' Draw rectangle with GDI+.
        e.Graphics.DrawRectangle(redPen, 10, 10, 100, 50)

        ' Get handle to device context.
        Dim hdc As IntPtr = e.Graphics.GetHdc()

        ' Draw rectangle with GDI using default pen.
        GDI.Rectangle(hdc, 10, 70, 110, 120)

        ' Release handle to device context.
        e.Graphics.ReleaseHdc(hdc)
    End Sub