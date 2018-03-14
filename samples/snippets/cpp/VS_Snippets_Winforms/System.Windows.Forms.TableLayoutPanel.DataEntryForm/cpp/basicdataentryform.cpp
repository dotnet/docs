// <snippet1>
#using <System.dll>
#using <System.Data.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Collections::Generic;
using namespace System::ComponentModel;
using namespace System::Data;
using namespace System::Drawing;
using namespace System::Text;
using namespace System::Windows::Forms;

// This form demonstrates how to build a form layout that adjusts well
// when the user resizes the form. It also demonstrates a layout that 
// responds well to localization.
ref class BasicDataEntryForm : public System::Windows::Forms::Form
{
public:
    BasicDataEntryForm()
    {
        InitializeComponent();
        components = nullptr;
    }

private:
    System::ComponentModel::IContainer^ components;

protected:
    ~BasicDataEntryForm()
    {
        if (components != nullptr)
        {
            delete components;
        }
    }

public:
    virtual String^ ToString() override
    {
        return "Basic Data Entry Form";
    }

private:
    void okBtn_Click(Object^ sender, EventArgs^ e)
    {
        this->Close();
    }

private:
    void cancelBtn_Click(Object^ sender, EventArgs^ e)
    {
        this->Close();
    }

private:
    void InitializeComponent()
    {
        this->tableLayoutPanel1 = gcnew 
            System::Windows::Forms::TableLayoutPanel();
        this->lblFirstName = gcnew System::Windows::Forms::Label();
        this->lblLastName = gcnew System::Windows::Forms::Label();
        this->lblAddress1 = gcnew System::Windows::Forms::Label();
        this->lblAddress2 = gcnew System::Windows::Forms::Label();
        this->lblCity = gcnew System::Windows::Forms::Label();
        this->lblState = gcnew System::Windows::Forms::Label();
        this->lblPhoneH = gcnew System::Windows::Forms::Label();
        this->txtAddress1 = gcnew System::Windows::Forms::TextBox();
        this->txtAddress2 = gcnew System::Windows::Forms::TextBox();
        this->txtCity = gcnew System::Windows::Forms::TextBox();
        this->txtLastName = gcnew System::Windows::Forms::TextBox();
        this->maskedTxtPhoneW = gcnew System::Windows::Forms::MaskedTextBox();
        this->maskedTxtPhoneH = gcnew System::Windows::Forms::MaskedTextBox();
        this->cboState = gcnew System::Windows::Forms::ComboBox();
        this->txtFirstName = gcnew System::Windows::Forms::TextBox();
        this->lblNotes = gcnew System::Windows::Forms::Label();
        this->lblPhoneW = gcnew System::Windows::Forms::Label();
        this->richTxtNotes = gcnew System::Windows::Forms::RichTextBox();
        this->cancelBtn = gcnew System::Windows::Forms::Button();
        this->okBtn = gcnew System::Windows::Forms::Button();
        this->tableLayoutPanel1->SuspendLayout();
        this->SuspendLayout();
        // 
        // tableLayoutPanel1
        // 
        this->tableLayoutPanel1->Anchor = 
            System::Windows::Forms::AnchorStyles::Top |
            System::Windows::Forms::AnchorStyles::Bottom|
            System::Windows::Forms::AnchorStyles::Left |
            System::Windows::Forms::AnchorStyles::Right;
        this->tableLayoutPanel1->ColumnCount = 4;
        this->tableLayoutPanel1->ColumnStyles->Add(gcnew 
            System::Windows::Forms::ColumnStyle());
        this->tableLayoutPanel1->ColumnStyles->Add(gcnew 
            System::Windows::Forms::ColumnStyle(
            System::Windows::Forms::SizeType::Percent, 50.0));
        this->tableLayoutPanel1->ColumnStyles->Add(gcnew 
            System::Windows::Forms::ColumnStyle());
        this->tableLayoutPanel1->ColumnStyles->Add(gcnew 
            System::Windows::Forms::ColumnStyle(
            System::Windows::Forms::SizeType::Percent, 50.0));
        this->tableLayoutPanel1->Controls->Add(this->lblFirstName, 0, 0);
        this->tableLayoutPanel1->Controls->Add(this->lblLastName, 2, 0);
        this->tableLayoutPanel1->Controls->Add(this->lblAddress1, 0, 1);
        this->tableLayoutPanel1->Controls->Add(this->lblAddress2, 0, 2);
        this->tableLayoutPanel1->Controls->Add(this->lblCity, 0, 3);
        this->tableLayoutPanel1->Controls->Add(this->lblState, 2, 3);
        this->tableLayoutPanel1->Controls->Add(this->lblPhoneH, 2, 4);
        this->tableLayoutPanel1->Controls->Add(this->txtAddress1, 1, 1);
        this->tableLayoutPanel1->Controls->Add(this->txtAddress2, 1, 2);
        this->tableLayoutPanel1->Controls->Add(this->txtCity, 1, 3);
        this->tableLayoutPanel1->Controls->Add(this->txtLastName, 3, 0);
        this->tableLayoutPanel1->Controls->Add(this->maskedTxtPhoneW, 1, 4);
        this->tableLayoutPanel1->Controls->Add(this->maskedTxtPhoneH, 3, 4);
        this->tableLayoutPanel1->Controls->Add(this->cboState, 3, 3);
        this->tableLayoutPanel1->Controls->Add(this->txtFirstName, 1, 0);
        this->tableLayoutPanel1->Controls->Add(this->lblNotes, 0, 5);
        this->tableLayoutPanel1->Controls->Add(this->lblPhoneW, 0, 4);
        this->tableLayoutPanel1->Controls->Add(this->richTxtNotes, 1, 5);
        this->tableLayoutPanel1->Location = System::Drawing::Point(13, 13);
        this->tableLayoutPanel1->Name = "tableLayoutPanel1";
        this->tableLayoutPanel1->RowCount = 6;
        this->tableLayoutPanel1->RowStyles->Add(gcnew 
            System::Windows::Forms::RowStyle(
            System::Windows::Forms::SizeType::Absolute, 28.0));
        this->tableLayoutPanel1->RowStyles->Add(gcnew 
            System::Windows::Forms::RowStyle(
            System::Windows::Forms::SizeType::Absolute, 28.0));
        this->tableLayoutPanel1->RowStyles->Add(gcnew 
            System::Windows::Forms::RowStyle(
            System::Windows::Forms::SizeType::Absolute, 28.0));
        this->tableLayoutPanel1->RowStyles->Add(gcnew
            System::Windows::Forms::RowStyle(
            System::Windows::Forms::SizeType::Absolute, 28.0));
        this->tableLayoutPanel1->RowStyles->Add(gcnew 
            System::Windows::Forms::RowStyle(
            System::Windows::Forms::SizeType::Absolute, 28.0));
        this->tableLayoutPanel1->RowStyles->Add(gcnew 
            System::Windows::Forms::RowStyle(
            System::Windows::Forms::SizeType::Percent, 80.0));
        this->tableLayoutPanel1->RowStyles->Add(gcnew 
            System::Windows::Forms::RowStyle(
            System::Windows::Forms::SizeType::Absolute, 20.0));
        this->tableLayoutPanel1->Size = System::Drawing::Size(623, 286);
        this->tableLayoutPanel1->TabIndex = 0;
        // 
        // lblFirstName
        // 
        this->lblFirstName->Anchor = 
            System::Windows::Forms::AnchorStyles::Right;
        this->lblFirstName->AutoSize = true;
        this->lblFirstName->Location = System::Drawing::Point(3, 7);
        this->lblFirstName->Name = "lblFirstName";
        this->lblFirstName->Size = System::Drawing::Size(59, 14);
        this->lblFirstName->TabIndex = 20;
        this->lblFirstName->Text = "First Name";
        // 
        // lblLastName
        // 
        this->lblLastName->Anchor = 
            System::Windows::Forms::AnchorStyles::Right;
        this->lblLastName->AutoSize = true;
        this->lblLastName->Location = System::Drawing::Point(323, 7);
        this->lblLastName->Name = "lblLastName";
        this->lblLastName->Size = System::Drawing::Size(59, 14);
        this->lblLastName->TabIndex = 21;
        this->lblLastName->Text = "Last Name";
        // 
        // lblAddress1
        // 
        this->lblAddress1->Anchor = 
            System::Windows::Forms::AnchorStyles::Right;
        this->lblAddress1->AutoSize = true;
        this->lblAddress1->Location = System::Drawing::Point(10, 35);
        this->lblAddress1->Name = "lblAddress1";
        this->lblAddress1->Size = System::Drawing::Size(52, 14);
        this->lblAddress1->TabIndex = 22;
        this->lblAddress1->Text = "Address1";
        // 
        // lblAddress2
        // 
        this->lblAddress2->Anchor = 
            System::Windows::Forms::AnchorStyles::Right;
        this->lblAddress2->AutoSize = true;
        this->lblAddress2->Location = System::Drawing::Point(7, 63);
        this->lblAddress2->Name = "lblAddress2";
        this->lblAddress2->Size = System::Drawing::Size(55, 14);
        this->lblAddress2->TabIndex = 23;
        this->lblAddress2->Text = "Address 2";
        // 
        // lblCity
        // 
        this->lblCity->Anchor = 
            System::Windows::Forms::AnchorStyles::Right;
        this->lblCity->AutoSize = true;
        this->lblCity->Location = System::Drawing::Point(38, 91);
        this->lblCity->Name = "lblCity";
        this->lblCity->Size = System::Drawing::Size(24, 14);
        this->lblCity->TabIndex = 24;
        this->lblCity->Text = "City";
        // 
        // lblState
        // 
        this->lblState->Anchor = 
            System::Windows::Forms::AnchorStyles::Right;
        this->lblState->AutoSize = true;
        this->lblState->Location = System::Drawing::Point(351, 91);
        this->lblState->Name = "lblState";
        this->lblState->Size = System::Drawing::Size(31, 14);
        this->lblState->TabIndex = 25;
        this->lblState->Text = "State";
        // 
        // lblPhoneH
        // 
        this->lblPhoneH->Anchor = 
            System::Windows::Forms::AnchorStyles::Right;
        this->lblPhoneH->AutoSize = true;
        this->lblPhoneH->Location = System::Drawing::Point(326, 119);
        this->lblPhoneH->Name = "lblPhoneH";
        this->lblPhoneH->Size = System::Drawing::Size(56, 14);
        this->lblPhoneH->TabIndex = 33;
        this->lblPhoneH->Text = "Phone (H)";
        // 
        // txtAddress1
        // 
        this->txtAddress1->Anchor = 
            System::Windows::Forms::AnchorStyles::Left | 
            System::Windows::Forms::AnchorStyles::Right;
        this->tableLayoutPanel1->SetColumnSpan(this->txtAddress1, 3);
        this->txtAddress1->Location = System::Drawing::Point(68, 32);
        this->txtAddress1->Name = "txtAddress1";
        this->txtAddress1->Size = System::Drawing::Size(552, 20);
        this->txtAddress1->TabIndex = 2;
        // 
        // txtAddress2
        // 
        this->txtAddress2->Anchor = 
            System::Windows::Forms::AnchorStyles::Left |
            System::Windows::Forms::AnchorStyles::Right;
        this->tableLayoutPanel1->SetColumnSpan(this->txtAddress2, 3);
        this->txtAddress2->Location = System::Drawing::Point(68, 60);
        this->txtAddress2->Name = "txtAddress2";
        this->txtAddress2->Size = System::Drawing::Size(552, 20);
        this->txtAddress2->TabIndex = 3;
        // 
        // txtCity
        // 
        this->txtCity->Anchor = 
            System::Windows::Forms::AnchorStyles::Left |
            System::Windows::Forms::AnchorStyles::Right;
        this->txtCity->Location = System::Drawing::Point(68, 88);
        this->txtCity->Name = "txtCity";
        this->txtCity->Size = System::Drawing::Size(249, 20);
        this->txtCity->TabIndex = 4;
        // 
        // txtLastName
        // 
        this->txtLastName->Anchor = 
            System::Windows::Forms::AnchorStyles::Left |
            System::Windows::Forms::AnchorStyles::Right;
        this->txtLastName->Location = System::Drawing::Point(388, 4);
        this->txtLastName->Name = "txtLastName";
        this->txtLastName->Size = System::Drawing::Size(232, 20);
        this->txtLastName->TabIndex = 1;
        // 
        // maskedTxtPhoneW
        // 
        this->maskedTxtPhoneW->Anchor = 
            System::Windows::Forms::AnchorStyles::Left;
        this->maskedTxtPhoneW->Location = System::Drawing::Point(68, 116);
        this->maskedTxtPhoneW->Mask = "(999)000-0000";
        this->maskedTxtPhoneW->Name = "maskedTxtPhoneW";
        this->maskedTxtPhoneW->TabIndex = 6;
        // 
        // maskedTxtPhoneH
        // 
        this->maskedTxtPhoneH->Anchor = 
            System::Windows::Forms::AnchorStyles::Left;
        this->maskedTxtPhoneH->Location = System::Drawing::Point(388, 116);
        this->maskedTxtPhoneH->Mask = "(999)000-0000";
        this->maskedTxtPhoneH->Name = "maskedTxtPhoneH";
        this->maskedTxtPhoneH->TabIndex = 7;
        // 
        // cboState
        // 
        this->cboState->Anchor = System::Windows::Forms::AnchorStyles::Left;
        this->cboState->FormattingEnabled = true;
        this->cboState->Items->AddRange(gcnew array<Object^> {
            "AK - Alaska",
            "WA - Washington"});
        this->cboState->Location = System::Drawing::Point(388, 87);
        this->cboState->Name = "cboState";
        this->cboState->Size = System::Drawing::Size(100, 21);
        this->cboState->TabIndex = 5;
            // 
            // txtFirstName
            // 
            this->txtFirstName->Anchor = 
                System::Windows::Forms::AnchorStyles::Left |
                System::Windows::Forms::AnchorStyles::Right;
            this->txtFirstName->Location = System::Drawing::Point(68, 4);
            this->txtFirstName->Name = "txtFirstName";
            this->txtFirstName->Size = System::Drawing::Size(249, 20);
            this->txtFirstName->TabIndex = 0;
            // 
            // lblNotes
            // 
            this->lblNotes->Anchor = 
                System::Windows::Forms::AnchorStyles::Top |
                System::Windows::Forms::AnchorStyles::Right;
            this->lblNotes->AutoSize = true;
            this->lblNotes->Location = System::Drawing::Point(28, 143);
            this->lblNotes->Name = "lblNotes";
            this->lblNotes->Size = System::Drawing::Size(34, 14);
            this->lblNotes->TabIndex = 26;
            this->lblNotes->Text = "Notes";
            // 
            // lblPhoneW
            // 
            this->lblPhoneW->Anchor = 
                System::Windows::Forms::AnchorStyles::Right;
            this->lblPhoneW->AutoSize = true;
            this->lblPhoneW->Location = System::Drawing::Point(4, 119);
            this->lblPhoneW->Name = "lblPhoneW";
            this->lblPhoneW->Size = System::Drawing::Size(58, 14);
            this->lblPhoneW->TabIndex = 32;
            this->lblPhoneW->Text = "Phone (W)";
            // 
            // richTxtNotes
            // 
            this->tableLayoutPanel1->SetColumnSpan(this->richTxtNotes, 3);
            this->richTxtNotes->Dock = System::Windows::Forms::DockStyle::Fill;
            this->richTxtNotes->Location = System::Drawing::Point(68, 143);
            this->richTxtNotes->Name = "richTxtNotes";
            this->richTxtNotes->Size = System::Drawing::Size(552, 140);
            this->richTxtNotes->TabIndex = 8;
            this->richTxtNotes->Text = "";
            // 
            // cancelBtn
            // 
            this->cancelBtn->Anchor = 
                System::Windows::Forms::AnchorStyles::Bottom |
                System::Windows::Forms::AnchorStyles::Right;
            this->cancelBtn->DialogResult = 
                System::Windows::Forms::DialogResult::Cancel;
            this->cancelBtn->Location = System::Drawing::Point(558, 306);
            this->cancelBtn->Name = "cancelBtn";
            this->cancelBtn->TabIndex = 1;
            this->cancelBtn->Text = "Cancel";
            this->cancelBtn->Click += gcnew System::EventHandler(
                this, &BasicDataEntryForm::cancelBtn_Click);
            // 
            // okBtn
            // 
            this->okBtn->Anchor = 
                System::Windows::Forms::AnchorStyles::Bottom |
                System::Windows::Forms::AnchorStyles::Right;
            this->okBtn->DialogResult = 
                System::Windows::Forms::DialogResult::OK;
            this->okBtn->Location = System::Drawing::Point(476, 306);
            this->okBtn->Name = "okBtn";
            this->okBtn->TabIndex = 0;
            this->okBtn->Text = "OK";
            this->okBtn->Click += gcnew System::EventHandler(
                this, &BasicDataEntryForm::okBtn_Click);
            // 
            // BasicDataEntryForm
            // 
            this->AutoScaleBaseSize = System::Drawing::Size(5, 13);
            this->ClientSize = System::Drawing::Size(642, 338);
            this->Controls->Add(this->okBtn);
            this->Controls->Add(this->cancelBtn);
            this->Controls->Add(this->tableLayoutPanel1);
            this->Name = "BasicDataEntryForm";
            this->Padding = System::Windows::Forms::Padding(9);
            this->StartPosition = 
                System::Windows::Forms::FormStartPosition::Manual;
            this->Text = "Basic Data Entry";
            this->tableLayoutPanel1->ResumeLayout(false);
            this->tableLayoutPanel1->PerformLayout();
            this->ResumeLayout(false);

    }

private:
    System::Windows::Forms::TableLayoutPanel^ tableLayoutPanel1;
    System::Windows::Forms::Label^ lblFirstName;
    System::Windows::Forms::Label^ lblLastName;
    System::Windows::Forms::Label^ lblAddress1;
    System::Windows::Forms::Label^ lblAddress2;
    System::Windows::Forms::Label^ lblCity;
    System::Windows::Forms::Label^ lblState;
    System::Windows::Forms::Label^ lblNotes;
    System::Windows::Forms::Label^ lblPhoneW;
    System::Windows::Forms::Label^ lblPhoneH;
    System::Windows::Forms::Button^ cancelBtn;
    System::Windows::Forms::Button^ okBtn;
    System::Windows::Forms::TextBox^ txtFirstName;
    System::Windows::Forms::TextBox^ txtAddress1;
    System::Windows::Forms::TextBox^ txtAddress2;
    System::Windows::Forms::TextBox^ txtCity;
    System::Windows::Forms::TextBox^ txtLastName;
    System::Windows::Forms::MaskedTextBox^ maskedTxtPhoneW;
    System::Windows::Forms::MaskedTextBox^ maskedTxtPhoneH;
    System::Windows::Forms::ComboBox^ cboState;
    System::Windows::Forms::RichTextBox^ richTxtNotes;
};

[STAThread]
int main()
{
    Application::EnableVisualStyles();
    Application::Run(gcnew BasicDataEntryForm());
}
// </snippet1>
