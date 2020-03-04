#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
protected:
   DataGrid^ dataGrid1;

   // <Snippet1>
private:
   void ClearAndAdd()
   {
      GridTableStylesCollection^ gts = dataGrid1->TableStyles;
      gts->Clear();
   }
   // </Snippet1>
};
