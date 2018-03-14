Public Class Form1

    ' <snippet1>
    Private Sub Button1_MouseDown(ByVal sender As System.Object, _
    ByVal e As MouseEventArgs) Handles Button1.MouseDown
        Debug.WriteLine("Button1_MouseDown")
    End Sub

    Private Sub Button1_MouseUp(ByVal sender As System.Object, _
    ByVal e As MouseEventArgs) Handles Button1.MouseUp
        Debug.WriteLine("Button1_MouseUp")
    End Sub

    Private Sub Button1_MouseCaptureChanged(ByVal sender As System.Object, _
    ByVal e As EventArgs) Handles Button1.MouseCaptureChanged
        Debug.WriteLine("Button1_MouseCaptureChanged")
    End Sub
    ' </snippet1>
End Class
