    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Add a text string to the TextBox.
        TextBox1.Text = "Hello World!"

        ' Set the size of the TextBox.
        TextBox1.AutoSize = False
        TextBox1.Size = New Size(Width, Height/3)

        ' Align the text in the center of the control element. 
        TextBox1.TextAlign = HorizontalAlignment.Center
    End Sub