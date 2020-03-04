//<Snippet1>
#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Windows::Forms;

namespace Win32Form1Namespace
{
   public ref class Win32Form1: public System::Windows::Forms::Form
   {
   private:
      System::Windows::Forms::Button^ addButton;
      System::Windows::Forms::TextBox^ textBox2;
      System::Windows::Forms::Button^ addGrandButton;
      System::Windows::Forms::ComboBox^ comboBox1;
      System::Windows::Forms::Button^ showSelectedButton;
      System::Windows::Forms::TextBox^ textBox1;
      System::Windows::Forms::Button^ findButton;
      System::Windows::Forms::Label ^ label1;

   public:
      Win32Form1()
      {
         this->InitializeComponent();
      }

   private:
      void InitializeComponent()
      {
         this->addButton = gcnew System::Windows::Forms::Button;
         this->textBox2 = gcnew System::Windows::Forms::TextBox;
         this->addGrandButton = gcnew System::Windows::Forms::Button;
         this->comboBox1 = gcnew System::Windows::Forms::ComboBox;
         this->showSelectedButton = gcnew System::Windows::Forms::Button;
         this->textBox1 = gcnew System::Windows::Forms::TextBox;
         this->findButton = gcnew System::Windows::Forms::Button;
         this->label1 = gcnew System::Windows::Forms::Label;
         this->addButton->Location = System::Drawing::Point( 248, 32 );
         this->addButton->Size = System::Drawing::Size( 40, 24 );
         this->addButton->TabIndex = 1;
         this->addButton->Text = "Add";
         this->addButton->Click += gcnew System::EventHandler(
            this, &Win32Form1::addButton_Click );
         this->textBox2->Location = System::Drawing::Point( 8, 64 );
         this->textBox2->Size = System::Drawing::Size( 232, 20 );
         this->textBox2->TabIndex = 6;
         this->textBox2->Text = "";
         this->addGrandButton->Location = System::Drawing::Point( 8, 96 );
         this->addGrandButton->Size = System::Drawing::Size( 280, 23 );
         this->addGrandButton->TabIndex = 2;
         this->addGrandButton->Text = "Add 1, 000 Items";
         this->addGrandButton->Click += gcnew System::EventHandler(
            this, &Win32Form1::addGrandButton_Click );
         this->comboBox1->Anchor = (System::Windows::Forms::AnchorStyles)(
            (System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Left) |
             System::Windows::Forms::AnchorStyles::Right);
         this->comboBox1->DropDownWidth = 280;
         array<Object^>^ objectArray = {"Item 1",
            "Item 2",
            "Item 3",
            "Item 4",
            "Item 5"};
         this->comboBox1->Items->AddRange( objectArray );
         this->comboBox1->Location = System::Drawing::Point( 8, 248 );
         this->comboBox1->Size = System::Drawing::Size( 280, 21 );
         this->comboBox1->TabIndex = 7;
         this->showSelectedButton->Location = System::Drawing::Point( 8, 128 );
         this->showSelectedButton->Size = System::Drawing::Size( 280, 24 );
         this->showSelectedButton->TabIndex = 4;
         this->showSelectedButton->Text = "What Item is Selected?";
         this->showSelectedButton->Click += gcnew System::EventHandler( 
            this, &Win32Form1::showSelectedButton_Click );
         this->textBox1->Location = System::Drawing::Point( 8, 32 );
         this->textBox1->Size = System::Drawing::Size( 232, 20 );
         this->textBox1->TabIndex = 5;
         this->textBox1->Text = "";
         this->findButton->Location = System::Drawing::Point( 248, 64 );
         this->findButton->Size = System::Drawing::Size( 40, 24 );
         this->findButton->TabIndex = 3;
         this->findButton->Text = "Find";
         this->findButton->Click += gcnew System::EventHandler( 
            this, &Win32Form1::findButton_Click );
         this->label1->Location = System::Drawing::Point( 8, 224 );
         this->label1->Size = System::Drawing::Size( 144, 23 );
         this->label1->TabIndex = 0;
         this->label1->Text = "Test ComboBox";
         this->ClientSize = System::Drawing::Size( 292, 273 );
         array<System::Windows::Forms::Control^>^ controlsArray = {this->comboBox1,
            this->textBox2,
            this->textBox1,
            this->showSelectedButton,
            this->findButton,
            this->addGrandButton,
            this->addButton,
            this->label1};
         this->Controls->AddRange( controlsArray );
         this->Text = "ComboBox Sample";
      }

      void addButton_Click( Object^ sender, System::EventArgs^ e )
      {
         comboBox1->Items->Add( textBox1->Text );
      }

      void addGrandButton_Click( Object^ sender, System::EventArgs^ e )
      {
         comboBox1->BeginUpdate();
         for ( int i = 0; i < 1000; i++ )
         {
            comboBox1->Items->Add( "Item 1 " + i.ToString() );

         }
         comboBox1->EndUpdate();
      }

      void findButton_Click( Object^ sender, System::EventArgs^ e )
      {
         int index = comboBox1->FindString( textBox2->Text );
         comboBox1->SelectedIndex = index;
      }

      void showSelectedButton_Click( Object^ sender, System::EventArgs^ e )
      {
         int selectedIndex = comboBox1->SelectedIndex;
         Object^ selectedItem = comboBox1->SelectedItem;
         MessageBox::Show( "Selected Item Text: " + selectedItem->ToString() + "\n" +
            "Index: " + selectedIndex.ToString() );
      }
   };
}


[System::STAThreadAttribute]
int main()
{
   System::Windows::Forms::Application::Run( gcnew Win32Form1Namespace::Win32Form1 );
}
//</Snippet1>
