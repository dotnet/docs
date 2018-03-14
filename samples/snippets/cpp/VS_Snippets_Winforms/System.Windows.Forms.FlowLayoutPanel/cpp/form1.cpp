// <snippet1>

// <snippet2>
#using <System.Windows.Forms.dll>
#using <System.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Windows::Forms;
// </snippet2>

public ref class Form1 : public System::Windows::Forms::Form
{
    // <snippet3>
private:
    void wrapContentsCheckBox_CheckedChanged(
        System::Object^ sender, System::EventArgs^ e)
    {
        this->flowLayoutPanel1->WrapContents =
            this->wrapContentsCheckBox->Checked;
    }
    // </snippet3>

    // <snippet4>
private:
    void flowTopDownBtn_CheckedChanged(System::Object^ sender,
        System::EventArgs^ e)
    {
        this->flowLayoutPanel1->FlowDirection = FlowDirection::TopDown;
    }

private:
    void flowBottomUpBtn_CheckedChanged(System::Object^ sender,
        System::EventArgs^ e)
    {
        this->flowLayoutPanel1->FlowDirection = FlowDirection::BottomUp;
    }

private:
    void flowLeftToRight_CheckedChanged(System::Object^ sender,
        System::EventArgs^ e)
    {
        this->flowLayoutPanel1->FlowDirection =
            FlowDirection::LeftToRight;
    }

private:
    void flowRightToLeftBtn_CheckedChanged(
        System::Object^ sender, System::EventArgs^ e)
    {
        this->flowLayoutPanel1->FlowDirection =
            FlowDirection::RightToLeft;
    }
    // </snippet4>

#pragma region " Windows Form Designer generated code "

public:
    Form1(void)
    {

        // This call is required by the Windows Form Designer.
        InitializeComponent();

        // Add any initialization after the InitializeComponent()
        // call

    }

    // Form overrides dispose to clean up the component list.
protected:
    ~Form1()
    {
        if (components != nullptr)
        {
            delete components;
        }
    }

private:
    System::Windows::Forms::FlowLayoutPanel^ flowLayoutPanel1;
private:
    System::Windows::Forms::CheckBox^ wrapContentsCheckBox;
private:
    System::Windows::Forms::RadioButton^ flowTopDownBtn;
private:
    System::Windows::Forms::RadioButton^ flowBottomUpBtn;
private:
    System::Windows::Forms::RadioButton^ flowLeftToRight;
private:
    System::Windows::Forms::RadioButton^ flowRightToLeftBtn;
private:
    System::Windows::Forms::Button^ button1;
private:
    System::Windows::Forms::Button^ button2;
private:
    System::Windows::Forms::Button^ button3;
private:
    System::Windows::Forms::Button^ button4;

    // Required by the Windows Form Designer
private:
    System::ComponentModel::IContainer^ components;

    // NOTE: The following procedure is required by the Windows Form
    // Designer
    // It can be modified using the Windows Form Designer.
    // Do not modify it using the code editor.
private:
    [System::Diagnostics::DebuggerNonUserCode]
    void InitializeComponent()
    {
        this->flowLayoutPanel1 =
            gcnew System::Windows::Forms::FlowLayoutPanel();
        this->button1 = gcnew System::Windows::Forms::Button();
        this->button2 = gcnew System::Windows::Forms::Button();
        this->button3 = gcnew System::Windows::Forms::Button();
        this->button4 = gcnew System::Windows::Forms::Button();
        this->wrapContentsCheckBox =
            gcnew System::Windows::Forms::CheckBox();
        this->flowTopDownBtn = gcnew System::Windows::Forms::RadioButton();
        this->flowBottomUpBtn =
            gcnew System::Windows::Forms::RadioButton();
        this->flowLeftToRight =
            gcnew System::Windows::Forms::RadioButton();
        this->flowRightToLeftBtn =
            gcnew System::Windows::Forms::RadioButton();
        this->flowLayoutPanel1->SuspendLayout();
        this->SuspendLayout();
        //
        // flowLayoutPanel1
        //
        this->flowLayoutPanel1->Controls->Add(this->button1);
        this->flowLayoutPanel1->Controls->Add(this->button2);
        this->flowLayoutPanel1->Controls->Add(this->button3);
        this->flowLayoutPanel1->Controls->Add(this->button4);
        this->flowLayoutPanel1->Location =
            System::Drawing::Point(47, 55);
        this->flowLayoutPanel1->Name = "flowLayoutPanel1";
        this->flowLayoutPanel1->TabIndex = 0;
        //
        // button1
        //
        this->button1->Location = System::Drawing::Point(3, 3);
        this->button1->Name = "button1";
        this->button1->TabIndex = 0;
        this->button1->Text = "button1";
        //
        // button2
        //
        this->button2->Location = System::Drawing::Point(84, 3);
        this->button2->Name = "button2";
        this->button2->TabIndex = 1;
        this->button2->Text = "button2";
        //
        // button3
        //
        this->button3->Location = System::Drawing::Point(3, 32);
        this->button3->Name = "button3";
        this->button3->TabIndex = 2;
        this->button3->Text = "button3";
        //
        // button4
        //
        this->button4->Location = System::Drawing::Point(84, 32);
        this->button4->Name = "button4";
        this->button4->TabIndex = 3;
        this->button4->Text = "button4";
        //
        // wrapContentsCheckBox
        //
        this->wrapContentsCheckBox->Location =
            System::Drawing::Point(46, 162);
        this->wrapContentsCheckBox->Name = "wrapContentsCheckBox";
        this->wrapContentsCheckBox->TabIndex = 1;
        this->wrapContentsCheckBox->Text = "Wrap Contents";
        this->wrapContentsCheckBox->CheckedChanged +=
            gcnew System::EventHandler(
            this, &Form1::wrapContentsCheckBox_CheckedChanged);
        //
        // flowTopDownBtn
        //
        this->flowTopDownBtn->Location =
            System::Drawing::Point(45, 193);
        this->flowTopDownBtn->Name = "flowTopDownBtn";
        this->flowTopDownBtn->TabIndex = 2;
        this->flowTopDownBtn->Text = "Flow TopDown";
        this->flowTopDownBtn->CheckedChanged +=
            gcnew System::EventHandler(
            this, &Form1::flowTopDownBtn_CheckedChanged);
        //
        // flowBottomUpBtn
        //
        this->flowBottomUpBtn->Location =
            System::Drawing::Point(44, 224);
        this->flowBottomUpBtn->Name = "flowBottomUpBtn";
        this->flowBottomUpBtn->TabIndex = 3;
        this->flowBottomUpBtn->Text = "Flow BottomUp";
        this->flowBottomUpBtn->CheckedChanged +=
            gcnew System::EventHandler(
            this, &Form1::flowBottomUpBtn_CheckedChanged);
        //
        // flowLeftToRight
        //
        this->flowLeftToRight->Location =
            System::Drawing::Point(156, 193);
        this->flowLeftToRight->Name = "flowLeftToRight";
        this->flowLeftToRight->TabIndex = 4;
        this->flowLeftToRight->Text = "Flow LeftToRight";
        this->flowLeftToRight->CheckedChanged +=
            gcnew System::EventHandler(
            this, &Form1::flowLeftToRight_CheckedChanged);
        //
        // flowRightToLeftBtn
        //
        this->flowRightToLeftBtn->Location =
            System::Drawing::Point(155, 224);
        this->flowRightToLeftBtn->Name = "flowRightToLeftBtn";
        this->flowRightToLeftBtn->TabIndex = 5;
        this->flowRightToLeftBtn->Text = "Flow RightToLeft";
        this->flowRightToLeftBtn->CheckedChanged +=
            gcnew System::EventHandler(
            this, &Form1::flowRightToLeftBtn_CheckedChanged);
        //
        // Form1
        //
        this->AutoScaleBaseSize = System::Drawing::Size(5, 13);
        this->ClientSize = System::Drawing::Size(292, 266);
        this->Controls->Add(this->flowRightToLeftBtn);
        this->Controls->Add(this->flowLeftToRight);
        this->Controls->Add(this->flowBottomUpBtn);
        this->Controls->Add(this->flowTopDownBtn);
        this->Controls->Add(this->wrapContentsCheckBox);
        this->Controls->Add(this->flowLayoutPanel1);
        this->Name = "Form1";
        this->Text = "Form1";
        this->flowLayoutPanel1->ResumeLayout(false);
        this->ResumeLayout(false);
    }

#pragma endregion
};
// </snippet1>
