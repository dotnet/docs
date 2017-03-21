private:
   void AddGridTable()
   {
      DataGridTableStyle^ myGridTableStyle;
      myGridTableStyle = gcnew DataGridTableStyle;
      myGridTableStyle->MappingName = "Customers";
      dataGrid1->TableStyles->Add( myGridTableStyle );
   }