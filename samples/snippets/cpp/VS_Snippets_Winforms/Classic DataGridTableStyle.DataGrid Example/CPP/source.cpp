#using <System.Xml.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::Drawing;
using namespace System::Windows::Forms;
using namespace System::ComponentModel;

public ref class Form1: public Form
{
protected:
   DataGrid^ myDataGrid;
   DataSet^ myDataSet;

   // <Snippet1>
private:
   void GetSelectedIndex( DataGridTableStyle^ myGridTable )
   {
      /* Get the name of the DataGrid of the DataGridTable 
         passed as an argument. */
      Console::WriteLine( myGridTable->DataGrid->CurrentCell.ToString() );
   }
   // </Snippet1>
};
