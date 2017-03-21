 Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
     ' Check to see if the change made does not return the
     ' control to its original state. 
     If originalText <> textBox1.Text Then
         ' Set the Modified property to true to reflect the change.
         textBox1.Modified = True
         ' Contents of textBox1 have not changed, reset the Modified property.
     Else
         textBox1.Modified = False
     End If
 End Sub
