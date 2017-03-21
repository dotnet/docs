Public Class Form1


'<Snippet1>
Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

    Me.TextBox1.AutoSize = True
    Me.TextBox1.Text = "Hello world!"
    Me.TextBox1.Font = New System.Drawing.Font("Arial", 10, FontStyle.Regular)

    Me.TextBox2.AutoSize = False
    Me.TextBox2.Text = "Hello world!"
    Me.TextBox2.Font = New System.Drawing.Font("Arial", 10, FontStyle.Regular)
End Sub


Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

    Me.TextBox1.AutoSize = True
        Me.TextBox1.Text = "Goodbye world!"
    Me.TextBox1.Font = New System.Drawing.Font("ArialBlack", 14, FontStyle.Regular)

    Me.TextBox2.AutoSize = False
        Me.TextBox2.Text = "Goodbye world!"
    Me.TextBox2.Font = New System.Drawing.Font("ArialBlack", 14, FontStyle.Regular)
End Sub
'</Snippet1>


End Class
