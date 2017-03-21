   Private Sub AddCustomColumnStyle()
      ' Set the TableStyle Mapping name.
      myTableStyle.MappingName = "customerTable"
      myTableStyle.BackColor = Color.Pink
      
      ' Set the ColumnStyle properties and add to TableStyle.
      myColumnStyle.MappingName = "Customers"
      myColumnStyle.HeaderText = "Customer Name"
      myColumnStyle.Width = 250
      myTableStyle.GridColumnStyles.Add(myColumnStyle)
      myDataGrid.TableStyles.Add(myTableStyle)
   End Sub 'AddCustomColumnStyle
   
   
   Private Sub myButton1_Click(sender As Object, e As EventArgs)
      ' Reset the background color.
      myTableStyle.ResetBackColor()
   End Sub 'myButton1_Click