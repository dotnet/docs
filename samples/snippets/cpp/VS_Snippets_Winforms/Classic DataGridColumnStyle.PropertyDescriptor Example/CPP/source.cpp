

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
   DataSet^ ds;

   // <Snippet1>
private:
   void GetPropertyDescriptor()
   {
      PropertyDescriptor^ pd;
      pd = dataGrid1->TableStyles[ 0 ]->GridColumnStyles[ 0 ]->PropertyDescriptor;
      Console::WriteLine( pd );
   }

   void CreateNewDataGridColumnStyle()
   {
      GridColumnStylesCollection^ myGridColumnCol;
      myGridColumnCol = dataGrid1->TableStyles[ 0 ]->GridColumnStyles;
      
      // Get the CurrencyManager for the table you want to add a column to.
      CurrencyManager^ myCurrencyManager = dynamic_cast<CurrencyManager^>(this->BindingContext[ ds->Tables[ "Suppliers" ] ]);
      
      // Get the PropertyDescriptor for the DataColumn of the new column.
      PropertyDescriptor^ pd = myCurrencyManager->GetItemProperties()[ "City" ];
      DataGridColumnStyle^ myColumn = gcnew DataGridTextBoxColumn( pd );
      myGridColumnCol->Add( myColumn );
   }

   // </Snippet1>
};
