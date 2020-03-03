

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
   void SetAllowNull()
   {
      DataGridBoolColumn^ myGridColumn = dynamic_cast<DataGridBoolColumn^>(dataGrid1->TableStyles[ 0 ]->GridColumnStyles[ 0 ]);
      myGridColumn->AllowNull = false;
   }

   // </Snippet1>
};
