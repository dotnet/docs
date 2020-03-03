

#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
public ref class Form1: public Form
{
protected:
   DataGrid^ dataGrid1;

private:

   // <Snippet1>
   void AddStyleRange()
   {
      
      // Create two DataGridColumnStyle objects.
      DataGridColumnStyle^ col1 = gcnew DataGridTextBoxColumn;
      col1->MappingName = "FirstName";
      DataGridColumnStyle^ col2 = gcnew DataGridBoolColumn;
      col2->MappingName = "Current";
      
      // Create an array and use AddRange to add to collection.
      array<DataGridColumnStyle^>^cols = {col1,col2};
      dataGrid1->TableStyles[ 0 ]->GridColumnStyles->AddRange( cols );
   }
   // </Snippet1>
};
