         private void AddCustomColumnStyle()
         {
            myTableStyle = new DataGridTableStyle();
            myColumnStyle = new DataGridTextBoxColumn();
            myColumnStyle.NullTextChanged += new EventHandler(columnStyle_NullTextChanged);
            myTableStyle.GridColumnStyles.Add(myColumnStyle);
            myDataGrid.TableStyles.Add(myTableStyle);
 
         }
         // NullTextChanged event handler of DataGridColumnStyle.
         private void columnStyle_NullTextChanged(object sender, EventArgs e)
         {
            for(int i=0;i<myRowcount;i++)
            {
               myCell.RowNumber = i;
               myDataGrid[myCell] = null;
            }
            MessageBox.Show("NullTextChanged Event is handled");
         }