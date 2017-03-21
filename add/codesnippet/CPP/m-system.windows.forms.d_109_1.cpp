private:
   void Grid_MouseUp(
      Object^ sender, System::Windows::Forms::MouseEventArgs^ /*e*/ )
   {
      DataGrid^ dg = (DataGrid^)(sender);
      DataGridCell myCell = dg->CurrentCell;
      Console::WriteLine( myCell.ToString() );
   }