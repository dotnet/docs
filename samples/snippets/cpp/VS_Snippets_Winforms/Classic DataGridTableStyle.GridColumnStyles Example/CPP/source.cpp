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
   void WriteMappingNames()
   {
      for each ( DataGridTableStyle^ dgt in myDataGrid->TableStyles )
      {
         Console::WriteLine( dgt->MappingName );
         for each ( DataGridColumnStyle^ dgc in dgt->GridColumnStyles )
         {
            Console::WriteLine( dgc->MappingName );
         }
      }
   }
   // </Snippet1>
};
