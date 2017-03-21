    ' When Form2 is activated
    Private Sub Form2_Activate(ByVal sender As Object, _
        ByVal e As EventArgs)
    
        Form2.BackColor = Color.DarkGray
        Form2.ForeColor = Color.White
        Form2.Font.Bold = BooleanOption.True
    End Sub