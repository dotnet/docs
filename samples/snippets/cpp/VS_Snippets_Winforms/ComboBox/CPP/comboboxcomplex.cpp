#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
public ref class Win32Form1: public System::Windows::Forms::Form
{
private:
   System::Windows::Forms::ComboBox^ comboBox1;
   System::Windows::Forms::Button^ button1;
   System::Windows::Forms::TextBox^ textBox2;
   System::Windows::Forms::Label ^ label1;
   System::Windows::Forms::Label ^ label4;
   System::Windows::Forms::TextBox^ textBox1;
   System::Windows::Forms::RadioButton^ radioButton1;
   System::Windows::Forms::RadioButton^ radioButton2;
   System::Windows::Forms::Label ^ label2;
   System::Windows::Forms::Label ^ label3;

public:
   Win32Form1()
   {
      this->InitializeComponent();
      comboBox1->DisplayMember = "String1";
   }

private:
   void InitializeComponent()
   {
      this->textBox2 = gcnew System::Windows::Forms::TextBox;
      this->button1 = gcnew System::Windows::Forms::Button;
      this->comboBox1 = gcnew System::Windows::Forms::ComboBox;
      this->label1 = gcnew System::Windows::Forms::Label;
      this->label4 = gcnew System::Windows::Forms::Label;
      this->textBox1 = gcnew System::Windows::Forms::TextBox;
      this->radioButton1 = gcnew System::Windows::Forms::RadioButton;
      this->radioButton2 = gcnew System::Windows::Forms::RadioButton;
      this->label2 = gcnew System::Windows::Forms::Label;
      this->label3 = gcnew System::Windows::Forms::Label;
      this->textBox2->Location = System::Drawing::Point( 48, 72 );
      this->textBox2->Size = System::Drawing::Size( 208, 20 );
      this->textBox2->TabIndex = 4;
      this->textBox2->Text = "";
      this->button1->Location = System::Drawing::Point( 184, 104 );
      this->button1->TabIndex = 1;
      this->button1->Text = "Add";
      this->button1->Click += gcnew System::EventHandler( this, &Win32Form1::button1_Click );
      this->comboBox1->DropDownWidth = 280;
      this->comboBox1->Location = System::Drawing::Point( 8, 248 );
      this->comboBox1->Size = System::Drawing::Size( 280, 21 );
      this->comboBox1->TabIndex = 0;
      this->label1->Location = System::Drawing::Point( 48, 16 );
      this->label1->Size = System::Drawing::Size( 100, 16 );
      this->label1->TabIndex = 6;
      this->label1->Text = "Add new item";
      this->label4->Location = System::Drawing::Point( 8, 152 );
      this->label4->Size = System::Drawing::Size( 216, 23 );
      this->label4->TabIndex = 9;
      this->label4->Text = "Select field to display in the ComboBox";
      this->textBox1->Location = System::Drawing::Point( 48, 40 );
      this->textBox1->Size = System::Drawing::Size( 208, 20 );
      this->textBox1->TabIndex = 3;
      this->textBox1->Text = "";
      this->radioButton1->Location = System::Drawing::Point( 8, 184 );
      this->radioButton1->Size = System::Drawing::Size( 128, 24 );
      this->radioButton1->TabIndex = 5;
      this->radioButton1->Text = "String 1";
      this->radioButton1->CheckedChanged += gcnew System::EventHandler( this, &Win32Form1::radioButton1_CheckedChanged );
      this->radioButton2->Location = System::Drawing::Point( 8, 216 );
      this->radioButton2->Size = System::Drawing::Size( 128, 24 );
      this->radioButton2->TabIndex = 5;
      this->radioButton2->Text = "String 2";
      this->label2->Location = System::Drawing::Point( 0, 40 );
      this->label2->Size = System::Drawing::Size( 48, 24 );
      this->label2->TabIndex = 7;
      this->label2->Text = "Sring 1";
      this->label2->TextAlign = System::Drawing::ContentAlignment::MiddleRight;
      this->label3->Location = System::Drawing::Point( 0, 72 );
      this->label3->Size = System::Drawing::Size( 48, 23 );
      this->label3->TabIndex = 8;
      this->label3->Text = "String 2";
      this->label3->TextAlign = System::Drawing::ContentAlignment::MiddleRight;
      this->ClientSize = System::Drawing::Size( 292, 273 );
      array<System::Windows::Forms::Control^>^ controlArray = {this->label4,
         this->label3,
         this->label2,
         this->label1,
         this->radioButton2,
         this->radioButton1,
         this->textBox2,
         this->textBox1,
         this->button1,
         this->comboBox1};
      this->Controls->AddRange( controlArray );
      this->Text = "Win32Form1";
   }

   //<Snippet6>
private:
   //Sample class to use for the ComboBox item.
   ref class Item
   {
   private:
      String^ string1;
      String^ string2;

   public:
      Item( String^ s1, String^ s2 )
      {
         string1 = s1;
         string2 = s2;
      }

      property String^ String1 
      {
         String^ get()
         {
            return string1;
         }
         void set( String^ value )
         {
            string1 = value;
         }
      }

      property String^ String2 
      {
         String^ get()
         {
            return string2;
         }
         void set( String^ value )
         {
            string2 = value;
         }
      }
   };

   void button1_Click( Object^ sender, System::EventArgs^ e )
   {
      //Adds a new instance ot the Item class to the ComboBox
      Item^ newItem = gcnew Item( textBox1->Text, textBox2->Text );
      comboBox1->Items->Add( newItem );
   }

   void radioButton1_CheckedChanged( Object^ sender, System::EventArgs^ e )
   {
      //swaps the ComboBox's DisplayMember
      if ( radioButton1->Checked )
      {
         comboBox1->DisplayMember = "String1";
      }
      else
      {
         comboBox1->DisplayMember = "String2";
      }
   }
   //</Snippet6>
};

[System::STAThreadAttribute]
void main()
{
   System::Windows::Forms::Application::Run( gcnew Win32Form1 );
}
