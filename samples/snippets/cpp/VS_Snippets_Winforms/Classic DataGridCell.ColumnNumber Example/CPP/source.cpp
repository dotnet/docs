

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
   DataGrid^ DataGrid1;

private:

   // <Snippet1>
   void PrintCell( Object^ sender, MouseEventArgs^ /*e*/ )
   {
      DataGrid^ thisGrid = dynamic_cast<DataGrid^>(sender);
      DataGridCell myDataGridCell = thisGrid->CurrentCell;
      BindingManagerBase^ bm = BindingContext[ thisGrid->DataSource,thisGrid->DataMember ];
      DataRowView^ drv = dynamic_cast<DataRowView^>(bm->Current);
      Console::WriteLine( drv[ myDataGridCell.ColumnNumber ] );
      Console::WriteLine( myDataGridCell.RowNumber );
   }

   // </Snippet1>
};

int main(){}
