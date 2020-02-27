// <snippet1>
// <snippet2>
#using <System.dll>
#using <System.Data.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
using namespace System;
using namespace System::Collections::Generic;
using namespace System::ComponentModel;
using namespace System::Data;
using namespace System::Data::SqlClient;
using namespace System::Drawing;
using namespace System::Windows::Forms;
// </snippet2>

// <snippet4>
// This class implements a simple customer type.
public ref class DemoCustomer
{
private:
   // These fields hold the values for the public properties.
   static Guid idValue = Guid::NewGuid();
   static String^ customerName = String::Empty;
   static String^ companyNameValue = String::Empty;
   static String^ phoneNumberValue = String::Empty;

   // The constructor is private to enforce the factory pattern.
   DemoCustomer()
   {
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
// </snippet4>

// <snippet3>
// This form demonstrates using the ItemChangedEventMode property
// of the BindingSource component to control which ListChanged
// events are raised when BindingSource component's underlying
// list is changed.
public ref class Form1: public System::Windows::Forms::Form
{
private:
   // <snippet5>
   // This is the BindingSource that will provide data for
   // the DataGridView control.
   static BindingSource^ customersBindingSource = gcnew BindingSource;

   // This is the DataGridView control that will display our data.
   static DataGridView^ customersDataGridView = gcnew DataGridView;

   // This panel holds the RadioButton controls.
   static Panel^ buttonPanel = gcnew Panel;

   // These RadioButton controls manage the ItemChangedEventMode
   // state of the BindingSource.
   static RadioButton^ allRadioBtn = gcnew RadioButton;
   static RadioButton^ currentRadioBtn = gcnew RadioButton;
   static RadioButton^ noneRadioBtn = gcnew RadioButton;

   // this StatusBar control will display the ListChanged events.
   static StatusBar^ status = gcnew StatusBar;
   // </snippet5>

public:
   // <snippet6>
   Form1()
   {
      // Set up the form.
      this->Size = System::Drawing::Size( 800, 800 );
      this->Load += gcnew EventHandler( this, &Form1::Form1_Load );
      
      // Set up the RadioButton controls.
      this->allRadioBtn->Text = L"All";
      this->allRadioBtn->Checked = true;
      this->allRadioBtn->CheckedChanged += gcnew EventHandler(
         this, &Form1::allRadioBtn_CheckedChanged );
      this->allRadioBtn->Dock = DockStyle::Top;
      this->currentRadioBtn->Text = L"Current";
      this->currentRadioBtn->CheckedChanged += gcnew EventHandler(
         this, &Form1::currentRadioBtn_CheckedChanged );
      this->currentRadioBtn->Dock = DockStyle::Top;
      this->noneRadioBtn->Text = L"None";
      this->noneRadioBtn->CheckedChanged += gcnew EventHandler(
         this, &Form1::noneRadioBtn_CheckedChanged );
      this->noneRadioBtn->Dock = DockStyle::Top;
      this->buttonPanel->Controls->Add( this->allRadioBtn );
      this->buttonPanel->Controls->Add( this->currentRadioBtn );
      this->buttonPanel->Controls->Add( this->noneRadioBtn );
      this->buttonPanel->Dock = DockStyle::Bottom;
      this->Controls->Add( this->buttonPanel );
      
      // Set up the DataGridView control.
      this->customersDataGridView->AllowUserToAddRows = true;
      this->customersDataGridView->Dock = DockStyle::Fill;
      this->Controls->Add( customersDataGridView );
      
      // Add the StatusBar control to the form.
      this->Controls->Add( status );
      
      // Allow the user to add new items.
      this->customersBindingSource->AllowNew = true;
      
      // Attach an event handler for the AddingNew event.
      this->customersBindingSource->AddingNew +=
         gcnew AddingNewEventHandler(
            this, &Form1::customersBindingSource_AddingNew );
      
      // Attach an eventhandler for the ListChanged event.
      this->customersBindingSource->ListChanged +=
         gcnew ListChangedEventHandler(
            this, &Form1::customersBindingSource_ListChanged );
      
      // Set the initial value of the ItemChangedEventMode property
      // to report all ListChanged events.
      this->customersBindingSource->ItemChangedEventMode = 
        ItemChangedEventMode::All;
      
      // Attach the BindingSource to the DataGridView.
      this->customersDataGridView->DataSource =
         this->customersBindingSource;
   }
   // </snippet6>

private:
   // <snippet7>
   void Form1_Load( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      // Create and populate the list of DemoCustomer objects
      // which will supply data to the DataGridView.
      List< DemoCustomer^ >^ customerList = gcnew List< DemoCustomer^ >;
      customerList->Add( DemoCustomer::CreateNewCustomer() );
      customerList->Add( DemoCustomer::CreateNewCustomer() );
      customerList->Add( DemoCustomer::CreateNewCustomer() );
      
      // Bind the list to the BindingSource.
      this->customersBindingSource->DataSource = customerList;
   }
   // </snippet7>

   // <snippet8>
   // This event handler provides custom item-creation behavior.
   void customersBindingSource_AddingNew(
      Object^ /*sender*/,
      AddingNewEventArgs^ e )
   {
      e->NewObject = DemoCustomer::CreateNewCustomer();
   }
   // </snippet8>

   // <snippet9>
   // This event handler detects changes in the BindingSource
   // list or changes to items within the list.
   void customersBindingSource_ListChanged(
      Object^ /*sender*/,
      ListChangedEventArgs^ e )
   {
      status->Text = e->ListChangedType.ToString();
   }
   // </snippet9>

   // <snippet10>
   // These event handlers change the state of the BindingSource
   // component's ItemChangedEventMode property.
   void allRadioBtn_CheckedChanged(
      Object^ /*sender*/,
      EventArgs^ /*e*/ )
   {
      if ( this->allRadioBtn->Checked )
      {
         this->customersBindingSource->ItemChangedEventMode = 
           ItemChangedEventMode::All;
      }
   }

   void currentRadioBtn_CheckedChanged(
      Object^ /*sender*/,
      EventArgs^ /*e*/ )
   {
      if ( this->currentRadioBtn->Checked )
      {
         this->customersBindingSource->ItemChangedEventMode =
            ItemChangedEventMode::Current;
      }
   }

   void noneRadioBtn_CheckedChanged(
      Object^ /*sender*/,
      EventArgs^ /*e*/ )
   {
      if ( this->noneRadioBtn->Checked )
      {
         this->customersBindingSource->ItemChangedEventMode =
            ItemChangedEventMode::None;
      }
   }
   // </snippet10>

public:
   [STAThread]
   static void main()
   {
      Application::EnableVisualStyles();
      Application::EnableRTLMirroring();
      Application::Run( gcnew Form1 );
   }
};
// </snippet3>
// </snippet1>
