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
using namespace System::Collections::Generic;
using namespace System::ComponentModel;
using namespace System::Data;
using namespace System::Data::Common;
using namespace System::Data::SqlClient;
using namespace System::Diagnostics;
using namespace System::Drawing;
using namespace System::Windows::Forms;
// </snippet2>

// <snippet9>
// This class implements a simple customer type.
public ref class DemoCustomer
{
private:
   // These fields hold the values for the public properties.
   Guid idValue;
   String^ customerName;
   String^ companyNameValue;
   String^ phoneNumberValue;

   // The constructor is private to enforce the factory pattern.
   DemoCustomer()
   {
      idValue = Guid::NewGuid();
      customerName = L"no data";
      companyNameValue = L"no data";
      phoneNumberValue = L"no data";
   }

public:
   // This is the public factory method.
   static DemoCustomer^ CreateNewCustomer()
   {
      return gcnew DemoCustomer;
   }

   property Guid ID 
   {
      // This property represents an ID, suitable
      // for use as a primary key in a database.
      Guid get()
      {
         return this->idValue;
      }
   }

   property String^ CompanyName 
   {
      String^ get()
      {
         return this->companyNameValue;
      }

      void set( String^ value )
      {
         this->companyNameValue = value;
      }
   }

   property String^ PhoneNumber 
   {
      String^ get()
      {
         return this->phoneNumberValue;
      }

      void set( String^ value )
      {
         this->phoneNumberValue = value;
      }
   }
};
// </snippet9>

// <snippet3>
// This form demonstrates using a BindingSource to bind
// a list to a DataGridView control. The list does not
// raise change notifications, so the ResetItem method
// on the BindingSource is used.
public ref class Form1: public System::Windows::Forms::Form
{
private:
   // <snippet4>
   // This button causes the value of a list element to be changed.
   Button^ changeItemBtn;

   // This is the DataGridView control that displays the contents
   // of the list.
   DataGridView^ customersDataGridView;

   // This is the BindingSource used to bind the list to the
   // DataGridView control.
   BindingSource^ customersBindingSource;
   // </snippet4>

public:
   // <snippet5>
   Form1()
   {
      changeItemBtn = gcnew Button;
      customersDataGridView = gcnew DataGridView;
      customersBindingSource = gcnew BindingSource;

      // Set up the "Change Item" button.
            this->changeItemBtn->Text = L"Change Item";
      this->changeItemBtn->Dock = DockStyle::Bottom;
      this->changeItemBtn->Click += gcnew EventHandler(
         this, &Form1::changeItemBtn_Click );
      this->Controls->Add( this->changeItemBtn );
      
      // Set up the DataGridView.
      customersDataGridView->Dock = DockStyle::Top;
      this->Controls->Add( customersDataGridView );
      this->Size = System::Drawing::Size( 800, 200 );
      this->Load += gcnew EventHandler( this, &Form1::Form1_Load );
   }
   // </snippet5>

private:
   // <snippet6>
   void Form1_Load( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // Create and populate the list of DemoCustomer objects
      // which will supply data to the DataGridView.
      List< DemoCustomer^ >^ customerList = gcnew List< DemoCustomer^ >;
      customerList->Add( DemoCustomer::CreateNewCustomer() );
      customerList->Add( DemoCustomer::CreateNewCustomer() );
      customerList->Add( DemoCustomer::CreateNewCustomer() );
      
      // Bind the list to the BindingSource.
      this->customersBindingSource->DataSource = customerList;
      
      // Attach the BindingSource to the DataGridView.
      this->customersDataGridView->DataSource =
         this->customersBindingSource;
   }
   // </snippet6>

   // <snippet7>
   // This event handler changes the value of the CompanyName
   // property for the first item in the list.
   void changeItemBtn_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // Get a reference to the list from the BindingSource.
      List< DemoCustomer^ >^ customerList =
         static_cast<List< DemoCustomer^ >^>(
           this->customersBindingSource->DataSource);
      
      // Change the value of the CompanyName property for the
      // first item in the list.
      customerList->default[ 0 ]->CompanyName = L"Tailspin Toys";
      
      // Call ResetItem to alert the BindingSource that the
      // list has changed.
      this->customersBindingSource->ResetItem( 0 );
   }
   // </snippet7>
};

int main()
{
   Application::EnableVisualStyles();
   Application::Run( gcnew Form1 );
}
// </snippet3>
// </snippet1>
