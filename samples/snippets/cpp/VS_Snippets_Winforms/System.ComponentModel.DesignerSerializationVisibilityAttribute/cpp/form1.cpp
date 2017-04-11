// <snippet1>
// <snippet2>
#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Collections::Generic;
using namespace System::ComponentModel;
using namespace System::Drawing;
using namespace System::Text;
using namespace System::Windows::Forms;
// </snippet2>

// This sample demonstrates the use of the 
// DesignerSerializationVisibility attribute
// to serialize a collection of strings
// at design time.
namespace SerializationDemo
{

    // <snippet3>
    public ref class SerializationDemoControl : 
        public System::Windows::Forms::UserControl
    {
        // This is the TextBox contained by 
        // the SerializationDemoControl.
    private:
        System::Windows::Forms::TextBox^ demoControlTextBox;

        // <snippet4>
        // This field backs the Strings property.
    private:
        array<String^>^ stringsValue;


        // </snippet4>

    public:
        SerializationDemoControl()
        {
            InitializeComponent();
            stringsValue = gcnew array<String^>(1);
        }

        // <snippet5>
        // When the DesignerSerializationVisibility attribute has
        // a value of "Content" or "Visible" the designer will 
        // serialize the property. This property can also be edited 
        // at design time with a CollectionEditor.
    public:
        [DesignerSerializationVisibility(
            DesignerSerializationVisibility::Content)]
        property array<String^>^ Strings
        {
            array<String^>^ get()
            {
                return this->stringsValue;
            }
            void set(array<String^>^ value)
            {
                this->stringsValue = value;

                // Populate the contained TextBox with the values
                // in the stringsValue array.
                StringBuilder^ sb =
                    gcnew StringBuilder(this->stringsValue->Length);

                for (int i = 0; i < this->stringsValue->Length; i++)
                {
                    sb->Append(this->stringsValue[i]);
                    sb->Append(Environment::NewLine);
                }

                this->demoControlTextBox->Text = sb->ToString();
            }
        }
        // </snippet5>

    private:
        void InitializeComponent()
        {
            this->demoControlTextBox = 
                gcnew System::Windows::Forms::TextBox();
            this->SuspendLayout();

            // Settings for the contained TextBox control.
            this->demoControlTextBox->AutoSize = false;
            this->demoControlTextBox->Dock = 
                System::Windows::Forms::DockStyle::Fill;
            this->demoControlTextBox->Location = 
                System::Drawing::Point(5, 5);
            this->demoControlTextBox->Margin =
                System::Windows::Forms::Padding(0);
            this->demoControlTextBox->Multiline = true;
            this->demoControlTextBox->Name = "textBox1";
            this->demoControlTextBox->ReadOnly = true;
            this->demoControlTextBox->ScrollBars = ScrollBars::Vertical;
            this->demoControlTextBox->Size = 
                System::Drawing::Size(140, 140);
            this->demoControlTextBox->TabIndex = 0;

            // Settings for SerializationDemoControl.
            this->Controls->Add(this->demoControlTextBox);
            this->Name = "SerializationDemoControl";
            this->Padding = System::Windows::Forms::Padding(5);
            this->ResumeLayout(false);
        }
    };
    // </snippet3>

    public ref class SerializationDemoForm : 
        public System::Windows::Forms::Form
    {

        SerializationDemoControl^ serializationDemoControl;


    public:
        SerializationDemoForm()
        {
            InitializeComponent();
            serializationDemoControl = nullptr;
        }

        // The Windows Forms Designer emits code to this method. 
        // If an instance of SerializationDemoControl is added 
        // to the form, the Strings will be serialized here.
    private:
        void InitializeComponent()
        {
            this->serializationDemoControl =
                gcnew SerializationDemo::SerializationDemoControl();
            this->SuspendLayout();
            // 
            // serializationDemoControl
            // 
            this->serializationDemoControl->Location =
                System::Drawing::Point(0, 0);
            this->serializationDemoControl->Name = 
                "serializationDemoControl";
            this->serializationDemoControl->Padding =
                System::Windows::Forms::Padding(5);
            this->serializationDemoControl->TabIndex = 0;
            // 
            // SerializationDemoForm
            // 
            this->AutoScaleBaseSize = System::Drawing::Size(5, 13);
            this->ClientSize = System::Drawing::Size(292, 273);
            this->Controls->Add(this->serializationDemoControl);
            this->Name = "SerializationDemoForm";
            this->Text = "Form1";
            this->ResumeLayout(false);

        }
    };
};

[STAThread]
int main()
{
    Application::EnableVisualStyles();
    Application::Run(gcnew SerializationDemo::SerializationDemoForm());
}
// </snippet1>
