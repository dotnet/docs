   void TestContains()
   {
      bool isContained;
      isContained = myDataGrid->TableStyles->Contains( "Customers" );
      Console::WriteLine( isContained );
   }