Public Class Form1

' <snippet1>
Private Sub TextBox1_KeyDown(ByVal sender As System.Object, _
    ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
    
    If e.KeyCode >= Keys.D0 And e.KeyCode <= Keys.D9 And _
    e.Modifiers <> Keys.Shift Then
        e.SuppressKeyPress = True
    End If
End Sub
' </snippet1>
End Class
