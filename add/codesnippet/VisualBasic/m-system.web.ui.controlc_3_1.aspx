         ' Create an event handler that uses the 
         ' ControlCollection.Contains method to verify
         ' the existence of a Radio3 server control in
         ' the ControlCollection of the myForm server control.
         ' When a user clicks the button associated
         ' with this event handler, Radio3 is removed
         ' from the collection.
    Sub RemoveBtn_Click(sender As [Object], e As EventArgs)
          If myForm.Controls.Contains(Radio3) Then
               myForm.Controls.Remove(Radio3)
          End If
    End Sub 'RemoveBtn_Click