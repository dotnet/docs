

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
   DataSet^ dataSet1;

private:

   // <Snippet1>
   void SetHeaderText()
   {
      DataGridColumnStyle^ dgCol;
      DataColumn^ dataCol1;
      DataTable^ dataTable1;
      dgCol = dataGrid1->TableStyles[ 0 ]->GridColumnStyles[ 0 ];
      dataTable1 = dataSet1->Tables[ dataGrid1->DataMember ];
      dataCol1 = dataTable1->Columns[ dgCol->MappingName ];
      dgCol->HeaderText = dataCol1->Caption;
   }

   // </Snippet1>
};
