   Private Sub RegisterEventHandler()
      AddHandler myButton1.SizeChanged, AddressOf MyButton1_SizeChanged
   End Sub 'RegisterEventHandler

   Private Sub MyButton2_Click(sender As Object, e As EventArgs) 
      ' Set the scale for the control to the value provided.
      Dim scale As Single = CSng(myNumericUpDown1.Value)
      myButton1.Scale(scale)
   End Sub 'MyButton2_Click
   
   Private Sub MyButton1_SizeChanged(sender As Object, e As EventArgs)
      MessageBox.Show("The size of the 'Button' control has changed")
   End Sub 'MyButton1_SizeChanged