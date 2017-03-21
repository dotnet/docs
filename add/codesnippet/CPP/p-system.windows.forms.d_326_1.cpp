private:
   void AddCustomDataTableStyle()
   {
      myDataGridTableStyle1 = gcnew DataGridTableStyle;

      // EventHandlers
      myDataGridTableStyle1->GridLineColorChanged += gcnew System::EventHandler( this, &DataGridTableStyle_Sample::GridLineColorChanged_Handler );
      myDataGridTableStyle1->MappingName = "Customers";

      // Set other properties.
      myDataGridTableStyle1->AlternatingBackColor = System::Drawing::Color::Gold;
      myDataGridTableStyle1->BackColor = System::Drawing::Color::White;
      myDataGridTableStyle1->GridLineStyle = System::Windows::Forms::DataGridLineStyle::Solid;
      myDataGridTableStyle1->GridLineColor = Color::Red;

      // Set the HeaderText and Width properties.
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

      // Use a PropertyDescriptor to create a formatted column.
      PropertyDescriptorCollection^ myPropertyDescriptorCollection =
         BindingContext[myDataSet, "Customers::custToOrders"]->GetItemProperties();

      // Create a formatted column using a PropertyDescriptor.
      DataGridColumnStyle^ csOrderAmount = gcnew DataGridTextBoxColumn( myPropertyDescriptorCollection[ "OrderAmount" ],"c",true );
      csOrderAmount->MappingName = "OrderAmount";
      csOrderAmount->HeaderText = "Total";
      csOrderAmount->Width = 100;

      // Add the DataGridTableStyle instances to the GridTableStylesCollection.
      myDataGrid->TableStyles->Add( myDataGridTableStyle1 );
   }

   void GridLineColorChanged_Handler( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      MessageBox::Show( "GridLineColor Changed", "DataGridTableStyle" );
   }