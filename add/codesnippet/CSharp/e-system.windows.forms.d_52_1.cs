   private void CallEventLoader()
   {
      this.Load += new EventHandler(
         this.DataGridTableStyle_RowHeaderWidth_Load);
   }

   public void AttachRowHeaderWidthChanged()
   {
      myDataGridTableStyle.RowHeaderWidthChanged += 
                               new EventHandler(MyDelegateRowHeaderChanged);
   }
   private void MyDelegateRowHeaderChanged(object sender, EventArgs e)
   {
      MessageBox.Show("Row header width is changed");
   }

   private void button1_Click(object sender, System.EventArgs e)
   {  
      myDataGridTableStyle.RowHeaderWidth = 30;
   }

   private void button2_Click(object sender, System.EventArgs e)
   {
      MessageBox.Show("Row header width is: " + 
                          myDataGridTableStyle.RowHeaderWidth);
   }