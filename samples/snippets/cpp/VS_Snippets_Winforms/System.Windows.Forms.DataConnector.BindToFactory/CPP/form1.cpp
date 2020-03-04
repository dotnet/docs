// <snippet1>
// <snippet2>
#using <System.dll>
#using <System.Data.dll>
#using <System.Drawing.dll>
#using <System.EnterpriseServices.dll>
#using <System.Transactions.dll>
#using <System.Windows.Forms.dll>
#using <System.Xml.dll>
using namespace System;
using namespace System::Collections;
using namespace System::Collections::Generic;
using namespace System::ComponentModel;
using namespace System::Data;
using namespace System::Data::Common;
using namespace System::Data::SqlClient;
using namespace System::Diagnostics;
using namespace System::Drawing;
using namespace System::Windows::Forms;
// </snippet2>

// <snippet3>
// This form demonstrates using a BindingSource to bind to a factory
// object.
public ref class Form1: public System::Windows::Forms::Form
{
private:

   // <snippet4>
   // This is the TextBox for entering CustomerID values.
   static TextBox^ customerIdTextBox = gcnew TextBox;

   // This is the DataGridView that displays orders for the
   // specified customer.
   static DataGridView^ customersDataGridView = gcnew DataGridView;

   // This is the BindingSource for binding the database query
   // result set to the DataGridView.
   static BindingSource^ ordersBindingSource = gcnew BindingSource;
   // </snippet4>

public:
   // <snippet5>
   Form1()
   {
      // Set up the CustomerID TextBox.
      this->customerIdTextBox->Dock = DockStyle::Bottom;
      this->customerIdTextBox->Text =
         L"Enter a valid Northwind CustomerID, for example: ALFKI,"

      L" then TAB or click outside the TextBox";
      this->customerIdTextBox->Leave += gcnew EventHandler(
         this, &Form1::customerIdTextBox_Leave );
      this->Controls->Add( this->customerIdTextBox );
      
      // Set up the DataGridView.
      customersDataGridView->Dock = DockStyle::Top;
      this->Controls->Add( customersDataGridView );
      
      // Set up the form.
      this->Size = System::Drawing::Size( 800, 800 );
      this->Load += gcnew EventHandler( this, &Form1::Form1_Load );
   }
   // </snippet5>

private:
   // <snippet6>
   // This event handler binds the BindingSource to the DataGridView
   // control's DataSource property.
   void Form1_Load(
      System::Object^ /*sender*/,
      System::EventArgs^ /*e*/ )
   {
      // Attach the BindingSource to the DataGridView.
      this->customersDataGridView->DataSource =
         this->ordersBindingSource;
   }
   // </snippet6>

public:
   // <snippet7>
   // This is a static factory method. It queries the Northwind
   // database for the orders belonging to the specified
   // customer and returns an IList.
   static System::Collections::IList^ GetOrdersByCustomerId( String^ id )
   {
      // Open a connection to the database.
      String^ connectString = L"Integrated Security=SSPI;"
      L"Persist Security Info=False;Initial Catalog=Northwind;"
      L"Data Source= localhost";
      SqlConnection^ connection = gcnew SqlConnection;
      connection->ConnectionString = connectString;
      connection->Open();
      
      // Execute the query.
      String^ queryString = String::Format(
         L"Select * From Orders where CustomerID = '{0}'", id );
      SqlCommand^ command = gcnew SqlCommand( queryString,connection );
      SqlDataReader^ reader = command->ExecuteReader(
         CommandBehavior::CloseConnection );
      
      // Build an IList from the result set.
      List< DbDataRecord^ >^ list = gcnew List< DbDataRecord^ >;
      System::Collections::IEnumerator^ e = reader->GetEnumerator();
      while ( e->MoveNext() )
      {
         list->Add( dynamic_cast<DbDataRecord^>(e->Current) );
      }

      return list;
   }
   // </snippet7>

   // <snippet8>
   // This event handler is called when the user tabs or clicks
   // out of the customerIdTextBox. The database is then queried
   // with the CustomerID in the customerIdTextBox.Text property.
private:
   void customerIdTextBox_Leave( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // Attach the data source to the BindingSource control.
      this->ordersBindingSource->DataSource = GetOrdersByCustomerId(
         this->customerIdTextBox->Text );
   }
   // </snippet8>

public:
   [STAThread]
   static void main()
   {
      Application::EnableVisualStyles();
      Application::Run( gcnew Form1 );
   }
};
// </snippet3>
// </snippet1>
