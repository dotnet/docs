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
protected:
   DataGridCell dgc;

   void GetRect()
   {
      Rectangle rect;
      dgc.ColumnNumber = 0;
      dgc.RowNumber = 0;
      rect = dataGrid1->GetCellBounds( dgc );
      Console::WriteLine( rect );
   }
   // </Snippet1>
};
