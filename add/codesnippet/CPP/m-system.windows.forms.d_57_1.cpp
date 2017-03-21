private:
   void BindControls()
   {
      // Creates a DataSet named SuppliersProducts.
      DataSet^ SuppliersProducts = gcnew DataSet( "SuppliersProducts" );
      // Adds two DataTable objects, Suppliers and Products.
      SuppliersProducts->Tables->Add( gcnew DataTable( "Suppliers" ) );
      SuppliersProducts->Tables->Add( gcnew DataTable( "Products" ) );
      // Insert code to add DataColumn objects.
      // Insert code to fill tables with columns and data.
      // Binds the DataGrid to the DataSet, displaying the Suppliers table.
      dataGrid1->SetDataBinding( SuppliersProducts, "Suppliers" );
   }