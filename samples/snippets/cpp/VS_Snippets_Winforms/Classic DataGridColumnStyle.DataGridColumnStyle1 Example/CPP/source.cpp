

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

private:

   // <Snippet1>
   void CreateNewDataGridColumnStyle()
   {
      DataSet^ myDataSet = gcnew DataSet( "myDataSet" );
      
      // Insert code to populate the DataSet.
      // Get the CurrencyManager for the table you want to add a column to.
      CurrencyManager^ myCurrencyManager = dynamic_cast<CurrencyManager^>(this->BindingContext[myDataSet, "Suppliers"]);
      
      // Get the PropertyDescriptor for the DataColumn.
      PropertyDescriptor^ pd = myCurrencyManager->GetItemProperties()[ "City" ];
      
      // Construct the DataGridColumnStyle with the PropertyDescriptor.
      DataGridColumnStyle^ myColumn = gcnew DataGridTextBoxColumn( pd );
      myColumn->MappingName = "City";
      dataGrid1->TableStyles[ 0 ]->GridColumnStyles->Add( myColumn );
   }

   // </Snippet1>
};
