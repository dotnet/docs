

#using <system.dll>
#using <System.Xml.dll>
#using <system.drawing.dll>
#using <system.data.dll>
#using <system.windows.forms.dll>

using namespace System;
using namespace System::Data;
using namespace System::Drawing;
using namespace System::Windows::Forms;
public ref class Form1: public Form
{
protected:
   DataGrid^ DataGrid1;

private:

   // <Snippet1>
   void PrintCellRowAndCol()
   {
      DataGridCell^ myCell;
      myCell = DataGrid1->CurrentCell;
      Console::WriteLine( myCell->RowNumber );
      Console::WriteLine( myCell->ColumnNumber );
      
      // Prints the value of the cell through the DataTable.
      DataTable^ myTable;
      
      // Assumes the DataGrid is bound to a DataTable.
      myTable = dynamic_cast<DataTable^>(DataGrid1->DataSource);
      Console::WriteLine( myTable->Rows[ myCell->RowNumber ][ myCell->ColumnNumber ] );
   }

   // </Snippet1>
};

int main()
{
   return 0;
}
