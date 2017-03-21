      private void MySetButton_Click(object sender, EventArgs e)
      {
         // Set the 'HeaderFont' property of the DataGridTableStyle instance.
         myTableStyle.HeaderFont=new Font("Impact",10);
         // Add the DataGridTableStyle instance to the GridTableStylesCollection. 
         myDataGrid.TableStyles.Add(myTableStyle);
      }
      private void MyResetButton_Click(object sender, EventArgs e)
      {
         // Reset the Header Font to its default value.
         myTableStyle.ResetHeaderFont();
      }