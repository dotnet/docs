Imports System.Windows
Imports System.Windows.Interop
Imports System.Windows.Media

Namespace SDKSample
    Friend Class MyWindow
        Public Shared _width As Integer = Form1.ActiveForm.ClientSize.Width
        Public Shared _height As Integer = Form1.ActiveForm.ClientSize.Height
        Public Shared myHwndSource As HwndSource
        Public Shared topmostLayer As Boolean = True
        Public Shared changeColor As Boolean

        Public Shared Sub FillWithCircles(ByVal parentHwnd As IntPtr)
            ' Fill the client area of the form with randomly placed circles.
            For i As Integer = 0 To 199
                CreateShape(parentHwnd)
            Next i
        End Sub

        '<Snippet100>
        Public Shared Sub CreateShape(ByVal parentHwnd As IntPtr)
            ' Create an instance of the shape.
            Dim myShape As New MyShape()

            ' Determine whether the host container window has been created.
            If myHwndSource Is Nothing Then
                ' Create the host container window for the visual objects.
                CreateHostHwnd(parentHwnd)

                ' Associate the shape with the host container window.
                myHwndSource.RootVisual = myShape
            Else
                ' Assign the shape as a child of the root visual.
                CType(myHwndSource.RootVisual, ContainerVisual).Children.Add(myShape)
            End If
        End Sub
        '</Snippet100>

        '<Snippet101>
        ' Constant values from the "winuser.h" header file.
        Friend Const WS_CHILD As Integer = &H40000000, WS_VISIBLE As Integer = &H10000000

        Friend Shared Sub CreateHostHwnd(ByVal parentHwnd As IntPtr)
            ' Set up the parameters for the host hwnd.
            Dim parameters As New HwndSourceParameters("Visual Hit Test", _width, _height)
            parameters.WindowStyle = WS_VISIBLE Or WS_CHILD
            parameters.SetPosition(0, 24)
            parameters.ParentWindow = parentHwnd
            '<Snippet102>
            parameters.HwndSourceHook = New HwndSourceHook(AddressOf ApplicationMessageFilter)
            '</Snippet102>

            ' Create the host hwnd for the visuals.
            myHwndSource = New HwndSource(parameters)

            ' Set the hwnd background color to the form's background color.
            myHwndSource.CompositionTarget.BackgroundColor = System.Windows.Media.Brushes.OldLace.Color
        End Sub
        '</Snippet101>

        '<Snippet103>
        ' Constant values from the "winuser.h" header file.
        Friend Const WM_LBUTTONUP As Integer = &H202, WM_RBUTTONUP As Integer = &H205

        Friend Shared Function ApplicationMessageFilter(ByVal hwnd As IntPtr, ByVal message As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr, ByRef handled As Boolean) As IntPtr
            ' Handle messages passed to the visual.
            Select Case message
                ' Handle the left and right mouse button up messages.
                Case WM_LBUTTONUP, WM_RBUTTONUP
                    Dim pt As New System.Windows.Point()
                    pt.X = CUInt(lParam) And CUInt(&HFFFF) ' LOWORD = x
                    pt.Y = CUInt(lParam) >> 16 ' HIWORD = y
                    MyShape.OnHitTest(pt, message)
            End Select

            Return IntPtr.Zero
        End Function
        '</Snippet103>
    End Class
End Namespace
