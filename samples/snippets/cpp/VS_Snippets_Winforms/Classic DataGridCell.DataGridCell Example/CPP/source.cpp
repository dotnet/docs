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
   void SetCell()
   {
      // Set the focus to the cell specified by the DataGridCell.
      DataGridCell dc;
      dc.RowNumber = 1;
      dc.ColumnNumber = 1;
      dataGrid1->CurrentCell = dc;
   }
   // </Snippet1>
};
