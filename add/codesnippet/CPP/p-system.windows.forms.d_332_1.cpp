   void SetAllowNull()
   {
      DataGridBoolColumn^ myGridColumn = dynamic_cast<DataGridBoolColumn^>(dataGrid1->TableStyles[ 0 ]->GridColumnStyles[ 0 ]);
      myGridColumn->AllowNull = false;
   }
