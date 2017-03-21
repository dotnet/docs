private:
   void PrintReadOnlyValues()
   {
      for each ( DataGridTableStyle^ tableStyle in dataGrid1->TableStyles )
      {
         Console::WriteLine( tableStyle->ReadOnly );
      }
   }