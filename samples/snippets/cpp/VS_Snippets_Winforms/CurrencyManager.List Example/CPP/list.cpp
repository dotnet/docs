#using <System.Xml.dll>
#using <System.Transactions.dll>
#using <System.EnterpriseServices.dll>
#using <System.Drawing.dll>
#using <System.Data.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;
using namespace System::Data::SqlClient;
using namespace System::Data;

public ref class MyGridForm: public Form
{
private:
   DataGrid^ grid;

public:
   MyGridForm()
   {
      grid = gcnew DataGrid;
      grid->Size = this->Size;
      String^ connstr = "Data Source=localhost;Initial Catalog=NORTHWIND;Integrated Security=SSPI";
      SqlDataAdapter^ custAdapter;
      SqlDataAdapter^ orderAdapter;
      custAdapter = gcnew SqlDataAdapter( "select * from customers",connstr );
      orderAdapter = gcnew SqlDataAdapter( "select * from orders",connstr );
      DataSet^ ds = gcnew DataSet;
      custAdapter->Fill( ds, "Customers" );
      orderAdapter->Fill( ds, "Orders" );
      ds->Relations->Add( "CustOrders", ds->Tables[ "Customers" ]->Columns[ "CustomerID" ],
         ds->Tables[ "Orders" ]->Columns[ "CustomerID" ] );
      Controls->Add( grid );
      grid->SetDataBinding( ds, "Customers" );
      grid->Navigate += gcnew NavigateEventHandler( this, &MyGridForm::Grid_Navigate );
   }

   //<Snippet1>
private:
   void Grid_Navigate( Object^ /*sender*/, NavigateEventArgs^ e )
   {
      if ( e->Forward )
      {
         DataSet^ ds = dynamic_cast<DataSet^>(grid->DataSource);
         CurrencyManager^ cm = dynamic_cast<CurrencyManager^>(BindingContext[ds, "Customers::CustOrders"]);
         
         // Cast the IList* to a DataView to set the AllowNew property.
         DataView^ dv = dynamic_cast<DataView^>(cm->List);
         dv->AllowNew = false;
      }
   }
   //</Snippet1>
};

int main()
{
   Application::Run( gcnew MyGridForm );
}

/* 
This code produces the following output.

$123, 456, 789, 012, 345.00
$12, 3456, 7890, 123, 45.00
$1234567890, 123, 45.00
*/
