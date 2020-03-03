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
protected:
   Object^ source;

private:
   void SetSourceAndMember()
   {
      DataSet^ myDataSet = gcnew DataSet( "myDataSet" );
      DataTable^ tableCustomers = gcnew DataTable( "Customers" );
      myDataSet->Tables->Add( tableCustomers );
      // Insert code to populate the DataSet.

      // Set DataSource and DataMember with SetDataBinding method.
      String^ member;
      
      // The name of a DataTable is Customers.
      member = "Customers";
      dataGrid1->SetDataBinding( myDataSet, member );
   }
   // </Snippet1>
};
