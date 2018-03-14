

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

private:

   // <Snippet1>
   void AddDataGridBoolColumnStyle()
   {
      DataGridBoolColumn^ myColumn = gcnew DataGridBoolColumn;
      myColumn->MappingName = "Current";
      myColumn->Width = 200;
      dataGrid1->TableStyles[ "Customers" ]->GridColumnStyles->Add( myColumn );
   }

   // </Snippet1>
};

int main(){}
