'<Snippet1>
Public Class Form2

    ' Handle the KeyDown event to print the type of character entered into the control.
    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        TextBox2.AppendText($"KeyDown code: {e.KeyCode}, value: {e.KeyValue}, modifiers: {e.Modifiers}" + vbCrLf)
    End Sub

    ' Handle the KeyPress event to print the type of character entered into the control.
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        TextBox2.AppendText($"KeyPress keychar: {e.KeyChar}" + vbCrLf)
    End Sub

    ' Handle the KeyUp event to print the type of character entered into the control.
    Private Sub TextBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyUp
        TextBox2.AppendText($"KeyUp code: {e.KeyCode}, value: {e.KeyValue}, modifiers: {e.Modifiers}" + vbCrLf)
    End Sub

End Class
'</Snippet1>