//<SNIPPET1>
#pragma region Using directives

#using <System.dll>
#using <System.Data.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.Xml.dll>
#using <System.EnterpriseServices.dll>
#using <System.Transactions.dll>

using namespace System;
using namespace System::Collections::Generic;
using namespace System::ComponentModel;
using namespace System::Data;
using namespace System::Drawing;
using namespace System::Windows::Forms;
using namespace System::Data::SqlClient;

#pragma endregion

namespace MaskedTextBoxDataCSharp
{
    public ref class Form1 : public Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
    private:
        System::ComponentModel::IContainer^ components;

    public:
        Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
    protected:
        ~Form1()
        {
            if (components != nullptr)
            {
                delete components;
            }
        }



#pragma region Windows Form Designer generated code

               /// <summary>
               /// Required method for Designer support - do not modify
               /// the contents of this method with the code editor.
               /// </summary>
    private:
        void InitializeComponent()
        {
            employeesTable = gcnew DataSet();
            components = nullptr;
            this->firstName = gcnew System::Windows::Forms::TextBox();
            this->lastName = gcnew System::Windows::Forms::TextBox();
            this->phoneMask = gcnew System::Windows::Forms::MaskedTextBox();
            this->previousButton = gcnew System::Windows::Forms::Button();
            this->nextButton = gcnew System::Windows::Forms::Button();
            this->SuspendLayout();
            //
            // firstName
            //
            this->firstName->Location = System::Drawing::Point(13, 14);
            this->firstName->Name = "firstName";
            this->firstName->Size = System::Drawing::Size(184, 20);
            this->firstName->TabIndex = 0;
            //
            // lastName
            //
            this->lastName->Location = System::Drawing::Point(204, 14);
            this->lastName->Name = "lastName";
            this->lastName->Size = System::Drawing::Size(184, 20);
            this->lastName->TabIndex = 1;
            //
            // phoneMask
            //
            this->phoneMask->Location = System::Drawing::Point(441, 14);
            this->phoneMask->Mask = "(009) 000-0000 x9999";
            this->phoneMask->Name = "phoneMask";
            this->phoneMask->Size = System::Drawing::Size(169, 20);
            this->phoneMask->TabIndex = 2;
            //
            // previousButton
            //
            this->previousButton->Location = System::Drawing::Point(630, 14);
            this->previousButton->Name = "previousButton";
            this->previousButton->TabIndex = 3;
            this->previousButton->Text = "Previous";
            this->previousButton->Click += gcnew System::EventHandler(this,&Form1::previousButton_Click);
            //
            // nextButton
            //
            this->nextButton->Location = System::Drawing::Point(723, 14);
            this->nextButton->Name = "nextButton";
            this->nextButton->TabIndex = 4;
            this->nextButton->Text = "Next";
            this->nextButton->Click += gcnew System::EventHandler(this,&Form1::nextButton_Click);
            //
            // Form1
            //
            this->AutoScaleBaseSize = System::Drawing::Size(5, 13);
            this->ClientSize = System::Drawing::Size(887, 46);
            this->Controls->Add(this->nextButton);
            this->Controls->Add(this->previousButton);
            this->Controls->Add(this->phoneMask);
            this->Controls->Add(this->lastName);
            this->Controls->Add(this->firstName);
            this->Name = "Form1";
            this->Text = "Form1";
            this->Load += gcnew System::EventHandler(this,&Form1::Form1_Load);
            this->ResumeLayout(false);
            this->PerformLayout();
        }

#pragma endregion

    private:
        System::Windows::Forms::TextBox^ firstName;
        System::Windows::Forms::TextBox^ lastName;
        System::Windows::Forms::MaskedTextBox^ phoneMask;
        System::Windows::Forms::Button^ previousButton;
        System::Windows::Forms::Button^ nextButton;

    private:
        Binding^ currentBinding;
        Binding^ phoneBinding;
        DataSet^ employeesTable;
        SqlConnection^ sc;
        SqlDataAdapter^ dataConnect;

    private:
        void Form1_Load(Object^ sender, EventArgs^ e)
        {
            DoMaskBinding();
        }

    private:
        void DoMaskBinding()
        {
            try
            {
                sc = gcnew SqlConnection("Data Source=localhost;" +
                    "Initial Catalog=NORTHWIND;Integrated Security=SSPI");
                sc->Open();
            }
            catch (Exception^ ex)
            {
                MessageBox::Show(ex->Message);
                return;
            }

            dataConnect = gcnew SqlDataAdapter("SELECT * FROM Employees", sc);
            dataConnect->Fill(employeesTable, "Employees");


            // Now bind MaskedTextBox to appropriate field. Note that we must
            // create the Binding objects before adding them to the control -
            // otherwise, we won't get a Format event on the initial load.
            try
            {
                currentBinding = gcnew Binding("Text", employeesTable,
                    "Employees.FirstName");
                firstName->DataBindings->Add(currentBinding);

                currentBinding = gcnew Binding("Text", employeesTable,
                    "Employees.LastName");
                lastName->DataBindings->Add(currentBinding);

                phoneBinding = gcnew Binding("Text", employeesTable, 
                    "Employees.HomePhone");
                // We must add the event handlers before we bind, or the
                // Format event will not get called for the first record.
                phoneBinding->Format += gcnew
                    ConvertEventHandler(this, &Form1::phoneBinding_Format);
                phoneBinding->Parse += gcnew
                    ConvertEventHandler(this, &Form1::phoneBinding_Parse);
                phoneMask->DataBindings->Add(phoneBinding);
            }
            catch (Exception^ ex)
            {
                MessageBox::Show(ex->Message);
                return;
            }
        }

    private:
        void phoneBinding_Format(Object^ sender, ConvertEventArgs^ e)
        {
            String^ ext;

            DataRowView^ currentRow = (DataRowView^) BindingContext[
                employeesTable, "Employees"]->Current;
                if (currentRow["Extension"] == nullptr)
                {
                    ext = "";
                }
                else
                {
                    ext = currentRow["Extension"]->ToString();
                }

                e->Value = e->Value->ToString()->Trim() + " x" + ext;
        }

    private:
        void phoneBinding_Parse(Object^ sender, ConvertEventArgs^ e)
        {
            String^ phoneNumberAndExt = e->Value->ToString();

            int extIndex = phoneNumberAndExt->IndexOf("x");
            String^ ext = phoneNumberAndExt->Substring(extIndex)->Trim();
            String^ phoneNumber = 
                phoneNumberAndExt->Substring(0, extIndex)->Trim();

            //Get the current binding object, and set the new extension 
            //manually.
            DataRowView^ currentRow = 
                (DataRowView^ ) BindingContext[employeesTable,
                "Employees"]->Current;
            // Remove the "x" from the extension.
            currentRow["Extension"] = ext->Substring(1);

            //Return the phone number.
            e->Value = phoneNumber;
        }

    private:
        void previousButton_Click(Object^ sender, EventArgs^ e)
        {
            BindingContext[employeesTable, "Employees"]->Position =
                BindingContext[employeesTable, "Employees"]->Position - 1;
        }

    private:
        void nextButton_Click(Object^ sender, EventArgs^ e)
        {
            BindingContext[employeesTable, "Employees"]->Position =
                BindingContext[employeesTable, "Employees"]->Position + 1;
        }
    };
}

[STAThread]
int main()
{
    Application::EnableVisualStyles();
    Application::Run(gcnew MaskedTextBoxDataCSharp::Form1());
}
//</SNIPPET1>
