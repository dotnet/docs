Private Sub buttonNewCustomer_Click(sender As Object, _
  e As EventArgs) Handles buttonNewCustomer.Click
   ' Create a new customer form and assign a new 
   ' Customer object to the Tag property. 
   Dim customerForm As New CustomerForm()
   customerForm.Tag = New Customer()
   customerForm.Show()
End Sub