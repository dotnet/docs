Public Class Form1

    ' <snippet1>
    Private Sub showButton_Click() Handles showButton.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            PictureBox1.Load(OpenFileDialog1.FileName)
        End If

    End Sub
    ' </snippet1>

End Class




