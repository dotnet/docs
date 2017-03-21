 Private Sub RemoveThirdBinding()
     If textBox1.DataBindings.Count < 3 Then
         Return
     End If
     textBox1.DataBindings.RemoveAt(2)
 End Sub