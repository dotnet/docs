      Private Sub MyListView_AfterLabelEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.LabelEditEventArgs) Handles listView1.AfterLabelEdit

         ' Determine if label is changed by checking to see if it is equal to Nothing.
         If e.Label Is Nothing Then
            Return
         End If
         ' ASCIIEncoding is used to determine if a number character has been entered.
         Dim AE As New ASCIIEncoding()
         ' Convert the new label to a character array.
         Dim temp As Char() = e.Label.ToCharArray()

         ' Check each character in the new label to determine if it is a number.
         Dim x As Integer
         For x = 0 To temp.Length - 1
            ' Encode the character from the character array to its ASCII code.
            Dim bc As Byte() = AE.GetBytes(temp(x).ToString())

            ' Determine if the ASCII code is within the valid range of numerical values.
            If bc(0) > 47 And bc(0) < 58 Then
               ' Cancel the event and return the lable to its original state.
               e.CancelEdit = True
               ' Display a MessageBox alerting the user that numbers are not allowed.
               MessageBox.Show("The text for the item cannot contain numerical values.")
               ' Break out of the loop and exit.
               Return
            End If
         Next x
      End Sub