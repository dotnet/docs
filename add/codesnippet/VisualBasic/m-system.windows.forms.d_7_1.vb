    Private Sub Button_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Change the color of 'HeaderBack'.
        myDataTableStyle.HeaderBackColor = Color.LightPink
    End Sub 'Button_Click
   
    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Reset the 'HeaderBack' to its origanal color.
        myDataTableStyle.ResetHeaderBackColor()
    End Sub 'Button1_Click