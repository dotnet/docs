   public void AttachSelectionBackColorChanged()
   {
      // Handle the 'SelectionBackColorChanged' event.
      myGridTableStyle.SelectionBackColorChanged  += new EventHandler(this.MyDataGrid_SelectedBackColorChanged);      
   }
   
   private void MyDataGrid_SelectedBackColorChanged(object sender, System.EventArgs e)  
   {
      MessageBox.Show("SelectionBackColorChanged event was raised, Color changed to "+ myGridTableStyle.SelectionBackColor);
   }