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
   // <Snippet1>
private:
   System::Windows::Forms::DataGrid^ dataGrid1;

   void CreateDataGrid()
   {
      dataGrid1 = gcnew DataGrid;
      // Add the handler for the DataSourceChanged event.
      dataGrid1->DataSourceChanged += gcnew EventHandler(
         this, &Form1::DataGrid1_DataSourceChanged );
   }

   void DataGrid1_DataSourceChanged( Object^ sender, EventArgs^ /*e*/ )
   {
      DataGrid^ thisGrid = dynamic_cast<DataGrid^>(sender);
   }
   // </Snippet1>
};
