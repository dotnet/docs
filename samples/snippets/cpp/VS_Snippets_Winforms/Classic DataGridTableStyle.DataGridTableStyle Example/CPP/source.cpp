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
   DataGrid^ dataGrid1;
   DataSet^ myDataSet;

   // <Snippet1>
private:
   void AddGridTable()
   {
      DataGridTableStyle^ myGridTableStyle;
      myGridTableStyle = gcnew DataGridTableStyle;
      myGridTableStyle->MappingName = "Customers";
      dataGrid1->TableStyles->Add( myGridTableStyle );
   }
   // </Snippet1>
};
