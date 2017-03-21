      private void DataGridTableStyle_Sample_Load(object sender,
                                             EventArgs e)
      {
         myDataGridTableStyle1 = new DataGridTableStyle();

         mylabel.Text = "Sorting Status :" + 
               myDataGridTableStyle1.AllowSorting.ToString();
         if(myDataGridTableStyle1.AllowSorting == true)
         {
            btnApplyStyles.Text = "Remove Sorting";
         }
         else
         {
            btnApplyStyles.Text = "Apply Sorting";
         }
         // Attach custom event handlers.
         myDataGridTableStyle1.AllowSortingChanged += 
                     new System.EventHandler(AllowSortingChanged_Handler);
         myDataGridTableStyle1.MappingName = "Customers";
      } 
      private void AllowSortingChanged_Handler(object sender,EventArgs e)
      {         
         mylabel.Text = "Sorting Status :" 
               + myDataGridTableStyle1.AllowSorting.ToString();
      }     
      private void btnApplyStyles_Click(object sender, EventArgs e)
      {       

         if(myDataGridTableStyle1.AllowSorting == true)
         {            
            // Remove sorting.
            myDataGridTableStyle1.AllowSorting = false; 
            btnApplyStyles.Text = "Allow Sorting";
         }
         else
         {
            // Allow sorting.
            myDataGridTableStyle1.AllowSorting = true;
            btnApplyStyles.Text = "Remove Sorting";
         } 

         mylabel.Text = "Sorting Status :" + myDataGridTableStyle1.AllowSorting;
         // Add the DataGridTableStyle to DataGrid.
         myDataGrid.TableStyles.Add(myDataGridTableStyle1);
      }