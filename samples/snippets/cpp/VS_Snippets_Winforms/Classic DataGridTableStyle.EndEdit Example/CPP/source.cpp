

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
   void EditTable()
   {
      DataGridTableStyle^ dgt = myDataGrid->TableStyles[ 0 ];
      DataGridColumnStyle^ myCol = dgt->GridColumnStyles[ 0 ];
      dgt->BeginEdit( myCol, 1 );
      dgt->EndEdit( myCol, 1, true );
   }

   // </Snippet1>
};
