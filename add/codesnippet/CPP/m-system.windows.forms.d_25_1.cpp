private:
   Hashtable^ myHashTable;

public:
   Form1()
   {
      myHashTable = gcnew Hashtable;
   }

private:
   void Grid_MouseUp( Object^ sender, System::Windows::Forms::MouseEventArgs^ /*e*/ )
   {
      DataGrid^ dg = dynamic_cast<DataGrid^>(sender);
      DataGridCell myCell = dg->CurrentCell;
      String^ tempkey = myCell.ToString();
      Console::WriteLine( "Temp {0}", tempkey );
      if ( myHashTable->Contains( tempkey ) )
      {
         return;
      }
      myHashTable->Add( tempkey, myCell.GetHashCode() );
      Console::WriteLine( "Hashcode: {0}", myCell.GetHashCode() );
   }