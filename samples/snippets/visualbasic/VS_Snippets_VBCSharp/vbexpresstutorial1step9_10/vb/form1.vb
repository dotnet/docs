Public Class Form1

    ' <snippet1>
    Private Sub showButton_Click() Handles showButton.Click

        ' Show the Open File dialog. If the user clicks OK, load the
        ' picture that the user chose.
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            PictureBox1.Load(OpenFileDialog1.FileName)
        End If

    End Sub
    ' </snippet1>

    ' <snippet2>
    Private Sub clearButton_Click() Handles clearButton.Click
        ' Clear the picture.
        PictureBox1.Image = Nothing
    End Sub

    Private Sub backgroundButton_Click() Handles backgroundButton.Click
        ' Show the color dialog box. If the user clicks OK, change the
        ' PictureBox control's background to the color the user chose.
        If ColorDialog1.ShowDialog() = DialogResult.OK Then
            PictureBox1.BackColor = ColorDialog1.Color
        End If
    End Sub

    Private Sub closeButton_Click() Handles closeButton.Click
        ' Close the form.
        Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged() Handles CheckBox1.CheckedChanged
        ' If the user selects the Stretch check box, change 
        ' the PictureBox's SizeMode property to "Stretch". If the user 
        ' clears the check box, change it to "Normal".
        If CheckBox1.Checked Then
            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        Else
            PictureBox1.SizeMode = PictureBoxSizeMode.Normal
        End If
    End Sub
    ' </snippet2>

End Class




