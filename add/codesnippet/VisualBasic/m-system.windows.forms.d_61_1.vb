    Private Sub myButton1_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Set the 'HeaderForeColor' property.
        myDataTableStyle.HeaderForeColor = Color.Blue
    End Sub 'myButton1_Click
   
    Private Sub myButton2_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Reset the 'HeaderForeColor' property to its default value.
        myDataTableStyle.ResetHeaderForeColor()
    End Sub 'myButton2_Click
   