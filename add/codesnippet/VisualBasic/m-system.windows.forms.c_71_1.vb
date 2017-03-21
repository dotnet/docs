   Delegate Sub InvokeDelegate()
   
   Private Sub Invoke_Click(sender As Object, e As EventArgs)
      myTextBox.BeginInvoke(New InvokeDelegate(AddressOf InvokeMethod))
   End Sub 'Invoke_Click
   
   Public Sub InvokeMethod()
      myTextBox.Text = "Executed the given delegate"
   End Sub 'InvokeMethod