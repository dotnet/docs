   private:
      void DataGridTableStyle_Sample_Load( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         myDataGridTableStyle1 = gcnew DataGridTableStyle;
         mylabel->Text = String::Concat( "Sorting Status : ", myDataGridTableStyle1->AllowSorting );
         if ( myDataGridTableStyle1->AllowSorting == true )
         {
            btnApplyStyles->Text = "Remove Sorting";
         }
         else
         {
            btnApplyStyles->Text = "Apply Sorting";
         }

         myDataGridTableStyle1->AllowSortingChanged += gcnew System::EventHandler(
            this, &DataGridTableStyle_Sample::AllowSortingChanged_Handler );
         myDataGridTableStyle1->MappingName = "Customers";
      }

      void AllowSortingChanged_Handler( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         mylabel->Text = String::Concat( "Sorting Status : ", myDataGridTableStyle1->AllowSorting );
      }

      void btnApplyStyles_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         if ( myDataGridTableStyle1->AllowSorting == true )
         {
            // Remove sorting.
            myDataGridTableStyle1->AllowSorting = false;
            btnApplyStyles->Text = "Allow Sorting";
         }
         else
         {
            // Allow sorting.
            myDataGridTableStyle1->AllowSorting = true;
            btnApplyStyles->Text = "Remove Sorting";
         }

         mylabel->Text = String::Concat( "Sorting Status : ", myDataGridTableStyle1->AllowSorting );

         // Add the DataGridTableStyle to DataGrid.
         myDataGrid->TableStyles->Add( myDataGridTableStyle1 );
      }