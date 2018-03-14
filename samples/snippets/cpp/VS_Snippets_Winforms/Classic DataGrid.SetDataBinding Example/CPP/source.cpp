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

   // <Snippet1>
private:
   void BindControls()
   {
      // Creates a DataSet named SuppliersProducts.
      DataSet^ SuppliersProducts = gcnew DataSet( "SuppliersProducts" );
      // Adds two DataTable objects, Suppliers and Products.
      SuppliersProducts->Tables->Add( gcnew DataTable( "Suppliers" ) );
      SuppliersProducts->Tables->Add( gcnew DataTable( "Products" ) );
      // Insert code to add DataColumn objects.
      // Insert code to fill tables with columns and data.
      // Binds the DataGrid to the DataSet, displaying the Suppliers table.
      dataGrid1->SetDataBinding( SuppliersProducts, "Suppliers" );
   }
   // </Snippet1>
};
