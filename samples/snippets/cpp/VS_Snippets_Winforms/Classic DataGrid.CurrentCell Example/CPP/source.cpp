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

   // <Snippet1>
private:
   void SetCellWithFocus( DataGrid^ myGrid )
   {
      // Set the current cell to cell1, row 1.
      myGrid->CurrentCell = DataGridCell( 1, 1 );
   }

   void dataGrid1_GotFocus( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      Console::WriteLine( "{0} {1}", dataGrid1->CurrentCell.ColumnNumber,
         dataGrid1->CurrentCell.RowNumber );
   }
   // </Snippet1>
};
