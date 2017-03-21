         private void Button_Click(Object sender, EventArgs e)
         { 
            if (myButton.Text == "Make column read/write")
            {
               myDataGridColumnStyle.ReadOnly = false;
               myButton.Text = "Make column read only";
            }
            else
            {
               myDataGridColumnStyle.ReadOnly = true;
               myButton.Text = "Make column read/write";
            }
         }

         private void AddCustomDataTableStyle()
         {
            myDataGridTableStyle = new DataGridTableStyle();
            myDataGridTableStyle.MappingName = "Customers";
            myDataGridColumnStyle = new DataGridTextBoxColumn();
            myDataGridColumnStyle.MappingName= "CustName";
            // Add EventHandler function for readonlychanged event.
            myDataGridColumnStyle.ReadOnlyChanged += new EventHandler(myDataGridColumnStyle_ReadOnlyChanged);
            myDataGridColumnStyle.HeaderText = "Customer";
            myDataGridTableStyle.GridColumnStyles.Add(myDataGridColumnStyle);
            // Add the 'DataGridTableStyle' instance to the 'DataGrid'.
            myDataGrid.TableStyles.Add(myDataGridTableStyle);
         }
         private void myDataGridColumnStyle_ReadOnlyChanged(Object sender, EventArgs e)
         {
            MessageBox.Show("'Readonly' property is changed");
         }