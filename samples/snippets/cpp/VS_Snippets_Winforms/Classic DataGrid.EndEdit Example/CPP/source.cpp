

#using <System.Xml.dll>
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
   DataSet^ ds;

private:

   // <Snippet1>
   void EditValue()
   {
      int rowtoedit = 1;
      CurrencyManager^ myCurrencyManager = dynamic_cast<CurrencyManager^>(this->BindingContext[ ds->Tables[ "Suppliers" ] ]);
      myCurrencyManager->Position = rowtoedit;
      DataGridColumnStyle^ dgc = dataGrid1->TableStyles[ 0 ]->GridColumnStyles[ 0 ];
      dataGrid1->BeginEdit( dgc, rowtoedit );
      
      // Insert code to edit the value.
      dataGrid1->EndEdit( dgc, rowtoedit, false );
   }

   // </Snippet1>
};
