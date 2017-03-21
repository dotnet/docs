      private void button1_Click(object sender, System.EventArgs e)
      {
         try
         {
            // Get the 'BindingManagerBase' object.
            BindingManagerBase myBindingManagerBase=BindingContext[myDataTable];
            // Remove the selected row from the grid.
            myBindingManagerBase.RemoveAt(myBindingManagerBase.Position);
         }
         catch(Exception ex)
         {
            MessageBox.Show(ex.Source);
            MessageBox.Show(ex.Message);
         }
      }