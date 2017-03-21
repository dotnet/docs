   void SetHeaderText()
   {
      DataGridColumnStyle^ dgCol;
      DataColumn^ dataCol1;
      DataTable^ dataTable1;
      dgCol = dataGrid1->TableStyles[ 0 ]->GridColumnStyles[ 0 ];
      dataTable1 = dataSet1->Tables[ dataGrid1->DataMember ];
      dataCol1 = dataTable1->Columns[ dgCol->MappingName ];
      dgCol->HeaderText = dataCol1->Caption;
   }
