

#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::Drawing;
using namespace System::Windows::Forms;
public ref class Form1: public Form
{
protected:
   DataGrid^ dataGrid1;

private:

   // <Snippet1>
   void SetCellValue( DataGrid^ myGrid )
   {
      DataGridCell myCell;
      
      // Use an arbitrary cell.
      myCell.RowNumber = 1;
      myCell.ColumnNumber = 1;
      
      // Change the cell's value using the CurrentCell.
      myGrid[ myCell ] = "New Value";
   }

   void GetCellValue( DataGrid^ myGrid )
   {
      DataGridCell myCell;
      
      // Use and arbitrary cell.
      myCell.RowNumber = 1;
      myCell.ColumnNumber = 1;
      Console::WriteLine( myGrid[ myCell ] );
   }

   // </Snippet1>
};

int main(){}
