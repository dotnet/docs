private void EnterNull() {
   // Creates an instance of a class derived from DataGridBoolColumn.
   MyDataGridBoolColumn colBool;
   colBool = (MyDataGridBoolColumn)dataGrid1.TableStyles[0].GridColumnStyles[2];
   colBool.CallEnterNullValue();
}

// Class derived from DataGridBoolColumn.
internal class MyDataGridBoolColumn : DataGridBoolColumn {

   public void CallEnterNullValue() {
      this.EnterNullValue();
   }
}
   