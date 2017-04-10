#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;

public ref class Form1:
    public System::Windows::Forms::Form

{
    #pragma region " Windows Form Designer generated code "

    public:
        Form1()
        {

            //This call is required by the Windows Form Designer.
            InitializeComponent();
            this->ComboBox1->SelectedIndexChanged += gcnew EventHandler(this,
                &Form1::ComboBox1_SelectedIndexChanged);

            //Add any initialization after the InitializeComponent() call

        }

        //Form overrides dispose to clean up the component list.
    protected:
        ~Form1()
        {
			if (components != nullptr)
			{
				delete components;
			}
		}

        //Required by the Windows Form Designer
    private:
        System::ComponentModel::IContainer^ components;

        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.  
        //Do not modify it using the code editor.
    private:
        System::Windows::Forms::ComboBox^ ComboBox1;
    private:
        System::Windows::Forms::Label^ Label1;
    private:
        System::Windows::Forms::Button^ Button1;
    private:
        System::Windows::Forms::Button^ Button2;
    private:
        [System::Diagnostics::DebuggerStepThrough]
        void InitializeComponent()
        {
            this->ComboBox1 = gcnew System::Windows::Forms::ComboBox();
            this->Label1 = gcnew System::Windows::Forms::Label();
            this->Button1 = gcnew System::Windows::Forms::Button();
            this->Button2 = gcnew System::Windows::Forms::Button();
            this->SuspendLayout();
            //
            //ComboBox1
            //
            this->ComboBox1->Items->AddRange
                (gcnew array<System::Object^>{"Smaller", "Bigger"});
            this->ComboBox1->Location = System::Drawing::Point(64, 32);
            this->ComboBox1->Name = "ComboBox1";
            this->ComboBox1->Size = System::Drawing::Size(121, 21);
            this->ComboBox1->TabIndex = 0;
            //
            //Label1
            //
            this->Label1->Location = System::Drawing::Point(48, 136);
            this->Label1->Name = "Label1";
            this->Label1->Size = System::Drawing::Size(184, 88);
            this->Label1->TabIndex = 1;
            this->Label1->Text = "Some text to change.";
            // 
            // Button1
            // 
            this->Button1->Location = System::Drawing::Point(192, 56);
            this->Button1->Name = "Button1";
            this->Button1->TabIndex = 2;
            this->Button1->Text = "Button1";
            this->Button1->Click += 
                gcnew System::EventHandler(this,&Form1::Button1_Click);
            // 
            // Button2
            // 
            this->Button2->Location = System::Drawing::Point(200, 8);
            this->Button2->Name = "Button2";
            this->Button2->TabIndex = 3;
            this->Button2->Text = "Button2";
            this->Button2->Click += 
                gcnew System::EventHandler(this,&Form1::Button2_Click);
            //
            //Form1
            //
            this->AutoScaleBaseSize = System::Drawing::Size(5, 13);
            this->ClientSize = System::Drawing::Size(292, 266);
            this->Controls->Add(this->Label1);
            this->Controls->Add(this->ComboBox1);
            this->Controls->Add(this->Button2);
            this->Controls->Add(this->Button1);
            this->Name = "Form1";
            this->Text = "Form1";
            this->ResumeLayout(false);

        }

#pragma endregion

        // The following code example demonstrates how to use the Size, 
        // SizeInPoints, and Unit properties. This example is designed to
        // be used with a Windows Form that contains a ComboBox named 
        // ComboBox1.  Paste the following code into the form and  
        // associate the ComboBox1_SelectedIndexChange method with the 
        // SelectedIndexChanged event of the ComboBox control.

        //<snippet1> 
    private:
        void ComboBox1_SelectedIndexChanged(System::Object^ sender,
            System::EventArgs^ e)
        {

            // Cast the sender object back to a ComboBox.
            ComboBox^ ComboBox1 = (ComboBox^) sender;

            // Retrieve the selected item.
            String^ selectedString = (String^) ComboBox1->SelectedItem;

            // Convert it to lowercase.
            selectedString = selectedString->ToLower();

            // Declare the current size.
            float currentSize;

            // If Bigger is selected, get the current size from the 
            // Size property and increase it. Reset the font to the
            //  new size, using the current unit.
            if (selectedString == "bigger")
            {
                currentSize = Label1->Font->Size;
                currentSize += 2.0F;
                Label1->Font =gcnew System::Drawing::Font(Label1->Font->Name, 
                    currentSize, Label1->Font->Style, Label1->Font->Unit);

            }
            // If Smaller is selected, get the current size, in
            // points, and decrease it by 2.  Reset the font with
            // the new size in points.
            if (selectedString == "smaller")
            {
                currentSize = Label1->Font->Size;
                currentSize -= 2.0F;
                Label1->Font = gcnew System::Drawing::Font(Label1->Font->Name, 
                    currentSize, Label1->Font->Style);

            }
        }
        //</snippet1> 

        // The following code example demonstrates how to use the 
        // Font.#ctor(Font, FontStyle) constructor. To run this example,
        // paste this code into a Windows Form that contains a button
        // named Button1, and associate the Button1_Click method with the
        // Click event of the button.
        //<snippet2>
    private:
        void Button1_Click(System::Object^ sender,
            System::EventArgs^ e)
        {
            Button1->Font = gcnew System::Drawing::Font
                (this->Font, FontStyle::Italic);
        }
        //</snippet2>

        // The following code example demonstrates how to use 
        // the Font.#ctor(FontFamily, Single, FontStyle, GraphicsUnit)
        // constructor.
        // This example is designed to be used with Windows Forms.
        // To run this example paste this code into a form that contains
        // a button named Button2, and associate the Button2_Click method
        // with the Click event of the button. 
        //<snippet3>

    private:
        void Button2_Click(System::Object^ sender,
            System::EventArgs^ e)
        {
            Button2->Font = gcnew System::Drawing::Font
                (FontFamily::GenericMonospace, 12.0F,
                FontStyle::Italic, GraphicsUnit::Pixel);
        }
        //</snippet3>
};

[STAThread]
int main()
{
    Application::Run(gcnew Form1());
};
