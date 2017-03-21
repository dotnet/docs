protected:
   Object^ source;

private:
   void SetSourceAndMember()
   {
      DataSet^ myDataSet = gcnew DataSet( "myDataSet" );
      DataTable^ tableCustomers = gcnew DataTable( "Customers" );
      myDataSet->Tables->Add( tableCustomers );
      // Insert code to populate the DataSet.

      // Set DataSource and DataMember with SetDataBinding method.
      String^ member;
      
      // The name of a DataTable is Customers.
      member = "Customers";
      dataGrid1->SetDataBinding( myDataSet, member );
   }