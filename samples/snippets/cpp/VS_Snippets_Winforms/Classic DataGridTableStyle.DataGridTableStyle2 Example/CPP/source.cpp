

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
   DataGrid^ myDataGrid;
   DataSet^ myDataSet;

   // <Snippet1>
private:
   void CreateDataGridGridTableStyle()
   {
      CurrencyManager^ myCurrencyManager;
      DataGridTableStyle^ myGridTableStyle;
      
      /* Get the CurrencyManager for a DataTable named "Customers"
         found in a DataSet named "myDataSet". */
      myCurrencyManager = dynamic_cast<CurrencyManager^>(BindingContext[myDataSet, "Customers"]);
      myGridTableStyle = gcnew DataGridTableStyle( myCurrencyManager );
      
      // Add the table style to the collection of a DataGrid.
      myDataGrid->TableStyles->Add( myGridTableStyle );
   }

   // </Snippet1>
};
