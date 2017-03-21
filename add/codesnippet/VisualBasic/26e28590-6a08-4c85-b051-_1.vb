 Private Sub RemoveBackColorBinding()
     Dim colorBinding As Binding = textBox1.DataBindings("BackColor")
     textBox1.DataBindings.Remove(colorBinding)
 End Sub