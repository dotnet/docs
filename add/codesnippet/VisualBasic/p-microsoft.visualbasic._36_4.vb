  Private Sub PrintWindowCoordinates(ByVal hwnd As Integer)
  ' Prints left, right, top, and bottom positions
  ' of a window in pixels.

    Dim rectWindow As RECT

    ' Pass in window handle and empty the data structure.
    ' If function returns 0, an error occurred.
    If GetWindowRect(hwnd, rectWindow) = 0 Then
        ' Check LastDllError and display a dialog box if the error
        ' occurred because an invalid handle was passed.
        If Err.LastDllError = ERROR_INVALID_WINDOW_HANDLE Then
            MsgBox(ERROR_INVALID_WINDOW_HANDLE_DESCR, Title:="Error!")
        End If
    Else
        Debug.Print(rectWindow.Bottom)
        Debug.Print(rectWindow.Left)
        Debug.Print(rectWindow.Right)
        Debug.Print(rectWindow.Top)
    End If
  End Sub