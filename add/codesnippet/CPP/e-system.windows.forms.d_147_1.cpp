   private:
      void DataGridTableStyle_Sample_Load( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         myDataGridTableStyle1 = gcnew DataGridTableStyle;
         myHeaderLabel->Text = String::Concat( "Header Status : ", myDataGridTableStyle1->ColumnHeadersVisible );
         if ( myDataGridTableStyle1->ColumnHeadersVisible == true )
         {
            btnheader->Text = "Remove Header";
         }
         else
         {
            btnheader->Text = "Add Header";
         }

         AddCustomDataTableStyle();
      }

      void AddCustomDataTableStyle()
      {
         myDataGridTableStyle1->ColumnHeadersVisibleChanged += gcnew System::EventHandler( this, &DataGridTableStyle_Sample::ColumnHeadersVisibleChanged_Handler );

         // Set ColumnheaderVisible property.
         myDataGridTableStyle1->MappingName = "Customers";

         // Add a GridColumnStyle and set its MappingName
         DataGridColumnStyle^ myBoolCol = gcnew DataGridBoolColumn;
         myBoolCol->MappingName = "Current";
         myBoolCol->HeaderText = "IsCurrent Customer";
         myBoolCol->Width = 150;
         myDataGridTableStyle1->GridColumnStyles->Add( myBoolCol );

         // Add a second column style.
         DataGridColumnStyle^ myTextCol = gcnew DataGridTextBoxColumn;
         myTextCol->MappingName = "custName";
         myTextCol->HeaderText = "Customer Name";
         myTextCol->Width = 250;
         myDataGridTableStyle1->GridColumnStyles->Add( myTextCol );

         // Create new ColumnStyle objects
         DataGridColumnStyle^ cOrderDate = gcnew DataGridTextBoxColumn;
         cOrderDate->MappingName = "OrderDate";
         cOrderDate->HeaderText = "Order Date";
         cOrderDate->Width = 100;

         // PropertyDescriptor to create a formatted column.
         PropertyDescriptorCollection^ myPropertyDescriptorCollection =
            this->BindingContext[myDataSet, "Customers::custToOrders"]->GetItemProperties();

         // Create a formatted column using a PropertyDescriptor.
         DataGridColumnStyle^ csOrderAmount =
            gcnew DataGridTextBoxColumn( myPropertyDescriptorCollection[ "OrderAmount" ],"c",true );
         csOrderAmount->MappingName = "OrderAmount";
         csOrderAmount->HeaderText = "Total";
         csOrderAmount->Width = 100;

         // Add the DataGridTableStyle instances to GridTableStylesCollection.
         myDataGrid->TableStyles->Add( myDataGridTableStyle1 );
      }

      void ColumnHeadersVisibleChanged_Handler( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         myHeaderLabel->Text = String::Concat( "Header Status : ", myDataGridTableStyle1->ColumnHeadersVisible );
      }

      void btnheader_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         if ( myDataGridTableStyle1->ColumnHeadersVisible == true )
         {
            myDataGridTableStyle1->ColumnHeadersVisible = false;
            btnheader->Text = "Add Header";
         }
         else
         {
            myDataGridTableStyle1->ColumnHeadersVisible = true;
            btnheader->Text = "Remove Header";
         }
      }