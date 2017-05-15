

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

private:

   // <snippet1>
   void CreateNewDataGridColumn()
   {
      System::Windows::Forms::GridColumnStylesCollection^ myGridColumnCol;
      myGridColumnCol = dataGrid1->TableStyles[ 0 ]->GridColumnStyles;
      
      // Get the CurrencyManager for the table.
      CurrencyManager^ myCurrencyManager = dynamic_cast<CurrencyManager^>(this->BindingContext[ ds->Tables[ "Products" ] ]);
      
      /* Get the PropertyDescriptor for the DataColumn of the new column.
         The column should contain a Boolean value. */
      PropertyDescriptor^ pd = myCurrencyManager->GetItemProperties()[ "Discontinued" ];
      DataGridColumnStyle^ myColumn = gcnew System::Windows::Forms::DataGridBoolColumn( pd );
      myColumn->MappingName = "Discontinued";
      myGridColumnCol->Add( myColumn );
   }

   // </snippet1>
};
