[ToolboxBitmap(StopSignControl2::typeid, "StopSignControl2.bmp")]
public ref class StopSignControl2:
    public System::Windows::Forms::UserControl
{
private:
    Label^ label1;
private:
    Button^ button1;

public:
    StopSignControl2() : UserControl()
    {
        this->label1 = gcnew System::Windows::Forms::Label();
        this->button1 = gcnew System::Windows::Forms::Button();

        this->label1->Font = gcnew System::Drawing::Font(
            "Microsoft Sans Serif", 12.0F,
            System::Drawing::FontStyle::Regular,
            System::Drawing::GraphicsUnit::Point, ((Byte) 0));
        this->label1->ForeColor = System::Drawing::Color::Red;
        this->label1->Location = System::Drawing::Point(24, 56);
        this->label1->Name = "Label1";
        this->label1->TabIndex = 0;
        this->label1->Text = "Stop!";
        this->label1->TextAlign =
            System::Drawing::ContentAlignment::MiddleCenter;
        this->button1->Enabled = false;
        this->button1->Location = System::Drawing::Point(56, 88);
        this->button1->Name = "Button1";
        this->button1->Size = System::Drawing::Size(40, 32);
        this->button1->TabIndex = 1;
        this->button1->Text = "stop";
        this->Controls->Add(this->button1);
        this->Controls->Add(this->label1);
        this->Name = "StopSignControl";

        this->MouseEnter += gcnew EventHandler(this, 
            &StopSignControl2::StopSignControl_MouseEnter);
        this->MouseLeave += gcnew EventHandler(this, 
            &StopSignControl2::StopSignControl_MouseLeave);

    }

private:
    void StopSignControl_MouseEnter(Object^ sender, EventArgs^ e)
    {
        label1->Text = label1->Text->ToUpper();
        label1->Font = gcnew System::Drawing::Font(label1->Font->FontFamily,
            14.0F, FontStyle::Bold);
        button1->Enabled = true;
    }

private:
    void StopSignControl_MouseLeave(Object^ sender, EventArgs^ e)
    {

        label1->Text = label1->Text->ToLower();
        label1->Font = gcnew System::Drawing::Font(label1->Font->FontFamily,
            12.0F, FontStyle::Regular);
        button1->Enabled = false;
    }

};