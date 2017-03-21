   Private Sub myButton1_Click(sender As Object, e As EventArgs)
      'Set the 'AlternatingBackColor'.
      myDataGridTableStyle.AlternatingBackColor = Color.Blue
   End Sub 'myButton1_Click
   
   Private Sub myButton2_Click(sender As Object, e As EventArgs)
      ' Reset the 'AlternatingBackColor'.
      myDataGridTableStyle.ResetAlternatingBackColor()
   End Sub 'myButton2_Click