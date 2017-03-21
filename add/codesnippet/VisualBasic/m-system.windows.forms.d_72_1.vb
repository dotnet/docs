    Private Sub Button_Click(ByVal sender As Object, ByVal e As EventArgs) Handles myButton.Click
        ' Change the 'GridLineColor'.
        myDataTableStyle.GridLineColor = Color.Blue
    End Sub 'Button_Click
   
    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles myButton1.Click
        ' Reset the 'GridLineColor' to its orginal color.
        myDataTableStyle.ResetGridLineColor()
    End Sub 'Button1_Click