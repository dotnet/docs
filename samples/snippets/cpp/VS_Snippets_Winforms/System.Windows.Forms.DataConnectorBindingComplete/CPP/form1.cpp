#using <System.Windows.Forms.dll>
#using <System.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;
using namespace System::Globalization;

namespace DataConnectorBindingCompleteExample
{	
    //<snippet3>
    //<snippet2>
    // Represents a business object that throws exceptions when 
    // invalid values are entered for some of its properties.
    public ref class Part
    {
    private:
        String^ name;
        int number;
        double price;

    public:
        Part(String^ name, int number, double price)
        {
            PartName = name;
            PartNumber = number;
            PartPrice = price;
        }

        property String^ PartName 
        {
            String^ get()
            {
                return name;
            }

            void set(String^ value)
            {
                if (value->Length <= 0)
                {
                    throw gcnew Exception(
                        "Each part must have a name.");
                }
                else
                {
                    name = value;
                }
            }
        }

        property double PartPrice 
        {
            double get()
            {
                return price;
            }

            void set(double value)
            {
                price = value;
            }
        }

        property int PartNumber 
        {
            int get()
            {
                return number;
            }

            void set(int value)
            {
                if (value < 100)
                {
                    throw gcnew Exception(
                        "Invalid part number." \
                        "Part numbers must be " \
                        "greater than 100.");
                }
                else
                {
                    number = value;
                }
            }
        }

    };

    ref class MainForm: public Form
    {
    private:
        BindingSource^ bindingSource;
        TextBox^ partNameTextBox;
        TextBox^ partNumberTextBox;
        TextBox^ partPriceTextBox;

    public:
        MainForm()
        {
            bindingSource = gcnew BindingSource;
            partNameTextBox = gcnew TextBox;
            partNumberTextBox = gcnew TextBox;
            partPriceTextBox = gcnew TextBox;
                
            //Set up the textbox controls.
            this->partNameTextBox->Location = Point(82, 13);
            this->partNameTextBox->TabIndex = 1;
            this->partNumberTextBox->Location = Point(81, 47);
            this->partNumberTextBox->TabIndex = 2;
            this->partPriceTextBox->Location = Point(81, 83);
            this->partPriceTextBox->TabIndex = 3;
            
            // Add the textbox controls to the form
            this->Controls->Add(this->partNumberTextBox);
            this->Controls->Add(this->partNameTextBox);
            this->Controls->Add(this->partPriceTextBox);
            
            // Handle the form's Load event.
            this->Load += gcnew EventHandler(this, 
                &MainForm::OnMainFormLoad);
        }

    private:

        //<snippet1>
        void OnMainFormLoad(Object^ sender, EventArgs^ e)
        {   
            // Set the DataSource of bindingSource to the Part type.
            bindingSource->DataSource = Part::typeid;
            
            // Bind the textboxes to the properties of the Part type,
            // enabling formatting.
            partNameTextBox->DataBindings->Add(
                "Text", bindingSource, "PartName", true);
            partNumberTextBox->DataBindings->Add(
                "Text", bindingSource, "PartNumber", true);
            
            //Bind the textbox to the PartPrice value 
            // with currency formatting.
            partPriceTextBox->DataBindings->Add("Text", bindingSource, "PartPrice", true,
               DataSourceUpdateMode::OnPropertyChanged, nullptr, "C");

            // Handle the BindingComplete event for bindingSource and
            // the partNameBinding.
            bindingSource->BindingComplete += 
                gcnew BindingCompleteEventHandler(this, 
                &MainForm::OnBindingSourceBindingComplete);
            bindingSource->BindingComplete += 
                gcnew BindingCompleteEventHandler(this, 
                &MainForm::OnPartNameBindingBindingComplete);
            
            // Add a new part to bindingSource.
            bindingSource->Add(gcnew Part("Widget", 1234, 12.45));
        }

        // Handle the BindingComplete event to catch errors and 
        // exceptions in binding process.
        void OnBindingSourceBindingComplete(Object^ sender, 
            BindingCompleteEventArgs^ e)
        {
            if (e->BindingCompleteState == 
                BindingCompleteState::Exception)
            {
                MessageBox::Show(String::Format(
                    CultureInfo::CurrentCulture,
                    "bindingSource: {0}", e->Exception->Message));
            }

            if (e->BindingCompleteState == 
                BindingCompleteState::DataError)
            {
                MessageBox::Show(String::Format(
                    CultureInfo::CurrentCulture,
                    "bindingSource: {0}", e->Exception->Message));
            }
        }

        // Handle the BindingComplete event to catch errors and 
        // exceptions in binding process.
        void OnPartNameBindingBindingComplete(Object^ sender, 
            BindingCompleteEventArgs^ e)
        {
            if (e->BindingCompleteState == 
                BindingCompleteState::Exception)
            {
                MessageBox::Show(String::Format(
                    CultureInfo::CurrentCulture,
                    "PartNameBinding: {0}", e->Exception->Message));
            }

            if (e->BindingCompleteState == 
                BindingCompleteState::DataError)
            {
                MessageBox::Show(String::Format(
                    CultureInfo::CurrentCulture,
                    "PartNameBinding: {0}", e->Exception->Message));
            }
        }
        //</snippet1>
    };

//</snippet2>
//</snippet3>
}

[STAThread]
int main()
{
    Application::EnableVisualStyles();
    Application::Run(gcnew 
        DataConnectorBindingCompleteExample::MainForm());    
}


