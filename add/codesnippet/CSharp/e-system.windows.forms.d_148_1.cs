
   private void RegisterEventHandlers(DataGridBoolColumn myDataGridBoolColumn)
   {
      myDataGridBoolColumn.AllowNullChanged += 
         new System.EventHandler(myDataGridBoolColumn_AllowNullChanged);
      myDataGridBoolColumn.TrueValueChanged += 
         new System.EventHandler(myDataGridBoolColumn_TrueValueChanged);
      myDataGridBoolColumn.FalseValueChanged +=
         new System.EventHandler(myDataGridBoolColumn_FalseValueChanged);
   }

   // Event handler for event when 'TrueValue' is property changed.
   private void myDataGridBoolColumn_TrueValueChanged(object sender, EventArgs e)
   {
      MessageBox.Show("The TrueValue property of the DataGridBoolColumn has been changed to "
         + myDataGridBoolColumn.TrueValue);
   }

   // Event handler for event when 'FalseValue' is property changed.
   private void myDataGridBoolColumn_FalseValueChanged(object sender, EventArgs e)
   {
      MessageBox.Show("The FalseValue property of the DataGridBoolColumn has been changed to "
         + myDataGridBoolColumn.FalseValue);
   }

   // Event handler for event when 'AllowNull' is property changed.
   private void myDataGridBoolColumn_AllowNullChanged(object sender, EventArgs e)
   {
      MessageBox.Show("The AllowNull property of DataGridBoolColumn has been changed to "
         + myDataGridBoolColumn.AllowNull);
   }
