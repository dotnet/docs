// <snippet1>
// <snippet2>
#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::Drawing;
using namespace System::Globalization;
using namespace System::Windows::Forms;
// </snippet2>

namespace DataConnectorAddingNewExample
{
    // <snippet4>
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
            customerName = String::Empty;
            companyNameValue = String::Empty;
            phoneNumberValue = String::Empty;
            customerName = "no data";
            companyNameValue = "no data";
            phoneNumberValue = "no data";
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

            void set(String^ value)
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

            void set(String^ value)
            {
                this->phoneNumberValue = value;
            }
        }
    };
    // </snippet4>

    // <snippet3>
    // This form demonstrates using a BindingSource to provide
    // data from a collection of custom types 
    // to a DataGridView control.
    public ref class MainForm: public System::Windows::Forms::Form
    {
	// <snippet5>
    private:
        
        // This is the BindingSource that will provide data for
        // the DataGridView control.
        BindingSource^ customersBindingSource;

        // This is the DataGridView control 
        // that will display our data.
        DataGridView^ customersDataGridView;

        // Set up the StatusBar for displaying ListChanged events.
        StatusBar^ status;
	// </snippet5>
	
	// <snippet6>
    public:
        
        MainForm()
        {
            customersBindingSource = gcnew BindingSource;
            customersDataGridView = gcnew DataGridView;
            status = gcnew StatusBar;

            // Set up the form.
            this->Size = System::Drawing::Size(600, 400);
            this->Text = "BindingSource.AddingNew sample";
            this->Load += 
                gcnew EventHandler(this, &MainForm::OnMainFormLoad);
            this->Controls->Add(status);
              
            // Set up the DataGridView control.
            this->customersDataGridView->Dock = DockStyle::Fill;
            this->Controls->Add(this->customersDataGridView);
              
            // Attach an event handler for the AddingNew event.
            this->customersBindingSource->AddingNew += 
                gcnew AddingNewEventHandler(this, 
                &MainForm::OnCustomersBindingSourceAddingNew);
              
            // Attach an event handler for the ListChanged event.
            this->customersBindingSource->ListChanged += 
                gcnew ListChangedEventHandler(this, 
                &MainForm::OnCustomersBindingSourceListChanged);
        }
	// </snippet6>

 	// <snippet7>
    private:
       
        void OnMainFormLoad(Object^ sender, EventArgs^ e)
        {
            // Add a DemoCustomer to cause a row to be displayed.
            this->customersBindingSource->AddNew();
              
            // Bind the BindingSource to the DataGridView 
            // control's DataSource.
            this->customersDataGridView->DataSource = 
                this->customersBindingSource;
        }
	// </snippet7>

		// <snippet8>
        // This event handler provides custom item-creation behavior.
        void OnCustomersBindingSourceAddingNew(Object^ sender, 
            AddingNewEventArgs^ e)
        {
            e->NewObject = DemoCustomer::CreateNewCustomer();
        }
        // </snippet8>

        // <snippet9>
        // This event handler detects changes in the BindingSource 
        // list or changes to items within the list.
        void OnCustomersBindingSourceListChanged(Object^ sender, 
            ListChangedEventArgs^ e)
        {   
            status->Text = Convert::ToString(e->ListChangedType, 
                CultureInfo::CurrentCulture);
        }
        // </snippet9>
    };
    // </snippet3>
}

[STAThread]
int main()
{
    Application::EnableVisualStyles();
    Application::Run(gcnew DataConnectorAddingNewExample::MainForm);
}
// </snippet1>
