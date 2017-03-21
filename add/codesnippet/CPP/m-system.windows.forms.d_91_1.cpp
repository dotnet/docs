private:

   void EnterNull()
   {
      
      // Creates an instance of a class derived from DataGridBoolColumn.
      MyDataGridBoolColumn^ colBool;
      colBool = dynamic_cast<MyDataGridBoolColumn^>(dataGrid1->TableStyles[ 0 ]->GridColumnStyles[ 2 ]);
      colBool->CallEnterNullValue();
   }


internal:

   // Class derived from DataGridBoolColumn.
   ref class MyDataGridBoolColumn: public DataGridBoolColumn
   {
   public:
      void CallEnterNullValue()
      {
         this->EnterNullValue();
      }

   };
