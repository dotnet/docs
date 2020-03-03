#using <System.dll>
#using <System.Xml.dll>
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
   void EditGrid( DataGrid^ dataGrid1 )
   {
      // Get the selected row and column through the CurrentCell.
      int colNum;
      int rowNum;
      colNum = dataGrid1->CurrentCell.ColumnNumber;
      rowNum = dataGrid1->CurrentCell.RowNumber;
      // Get the selected DataGridColumnStyle.
      DataGridColumnStyle^ dgCol;
      dgCol = dataGrid1->TableStyles[ 0 ]->GridColumnStyles[ colNum ];
      // Invoke the BeginEdit method to see if editing can begin.
      if ( dataGrid1->BeginEdit( dgCol, rowNum ) )
      {
         // Edit row value. Get the DataTable and selected row.
         DataTable^ myTable;
         DataRow^ myRow;
         // Assuming the DataGrid is bound to a DataTable.
         myTable = (DataTable^)(dataGrid1->DataSource);
         myRow = myTable->Rows[ rowNum ];
         // Invoke the Row object's BeginEdit method.
         myRow->BeginEdit();
         myRow[ colNum ] = "New Value";
         // You must accept changes on both DataRow and DataTable.
         myRow->AcceptChanges();
         myTable->AcceptChanges();
         dataGrid1->EndEdit( dgCol, rowNum, false );
      }
      else
      {
         Console::WriteLine( "BeginEdit failed" );
      }
   }
   // </Snippet1>
};
