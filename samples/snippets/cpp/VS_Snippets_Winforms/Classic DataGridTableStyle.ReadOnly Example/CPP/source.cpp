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
   void PrintReadOnlyValues()
   {
      for each ( DataGridTableStyle^ tableStyle in dataGrid1->TableStyles )
      {
         Console::WriteLine( tableStyle->ReadOnly );
      }
   }
   // </Snippet1>
};
