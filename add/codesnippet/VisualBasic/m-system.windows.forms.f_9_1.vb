   Private Sub Form1_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
      ' Determine if text has changed in the textbox by comparing to original text.
      If textBox1.Text <> strMyOriginalText Then
         ' Display a MsgBox asking the user to save changes or abort.
         If MessageBox.Show("Do you want to save changes to your text?", "My Application", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            ' Cancel the Closing event from closing the form.
            e.Cancel = True
         End If ' Call method to save file...
      End If
   End Sub 'Form1_Closing
End Class 'Form1