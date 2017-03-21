   private void button4_Click(object sender, EventArgs e)
   {
      try
      {
         BindingManagerBase myBindingManager2=BindingContext [myDataSet, "Customers"];
         myBindingManager2.ResumeBinding();
      }
      catch(Exception ex)
      {
         MessageBox.Show(ex.Source);
         MessageBox.Show(ex.Message);
      }
   }