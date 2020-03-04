Public Class ShapeFindForm

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        GetTheForm()
    End Sub
    ' <Snippet1>
    Private Sub GetTheForm()
        Dim myForm As Form = LineShape1.FindForm()
        ' Set the text and color of the form that contains the LineShape.
        myForm.Text = "This form contains a line"
        myForm.BackColor = Color.Red
    End Sub
    ' </Snippet1>
End Class
