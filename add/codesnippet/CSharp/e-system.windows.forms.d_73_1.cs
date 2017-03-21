      protected void AddTableStyle()
      {
         // Create a new DataGridTableStyle.
         myDataGridTableStyle = new DataGridTableStyle();
         myDataGridTableStyle.MappingName = myDataSet1.Tables[0].TableName;
         myDataGrid1.DataSource=myDataSet1.Tables[0];
         myDataGridTableStyle.ReadOnlyChanged+=new EventHandler(MyReadOnlyChangedEventHandler);
         myDataGrid1.TableStyles.Add(myDataGridTableStyle);
      }

      // Handle the 'ReadOnlyChanged' event.
      private void MyReadOnlyChangedEventHandler(object sender, EventArgs e)
      {
         MessageBox.Show("ReadOnly property is changed");
      }

      // Handle the check box's CheckedChanged event
      private void myCheckBox1_CheckedChanged(object sender, EventArgs e)
      {
         if(myDataGridTableStyle.ReadOnly)
         {
            myDataGridTableStyle.ReadOnly=false;
         }
         else
         {
            myDataGridTableStyle.ReadOnly=true;
         }
      }