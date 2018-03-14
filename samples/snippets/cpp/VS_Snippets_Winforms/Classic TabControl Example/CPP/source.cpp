

#using <System.Drawing.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Windows::Forms;

// <Snippet1>
public ref class Form1: public System::Windows::Forms::Form
{
private:

   // Required designer variable.
   System::ComponentModel::Container^ components;

   // Declare variables.
   System::Windows::Forms::RadioButton^ tab3RadioButton2;
   System::Windows::Forms::RadioButton^ tab3RadioButton1;
   System::Windows::Forms::CheckBox^ tab2CheckBox3;
   System::Windows::Forms::CheckBox^ tab2CheckBox2;
   System::Windows::Forms::CheckBox^ tab2CheckBox1;
   System::Windows::Forms::Label ^ tab1Label1;
   System::Windows::Forms::Button^ tab1Button1;
   System::Windows::Forms::TabPage^ tabPage3;
   System::Windows::Forms::TabPage^ tabPage2;
   System::Windows::Forms::TabPage^ tabPage1;
   System::Windows::Forms::TabControl^ tabControl1;

public:
   Form1()
   {
      
      // This call is required for Windows Form Designer support.
      InitializeComponent();
   }


private:

   // This method is required for Designer support.
   void InitializeComponent()
   {
      this->components = gcnew System::ComponentModel::Container;
      this->tabPage1 = gcnew System::Windows::Forms::TabPage;
      this->tab2CheckBox3 = gcnew System::Windows::Forms::CheckBox;
      this->tab3RadioButton2 = gcnew System::Windows::Forms::RadioButton;
      this->tabControl1 = gcnew System::Windows::Forms::TabControl;
      this->tab2CheckBox2 = gcnew System::Windows::Forms::CheckBox;
      this->tab2CheckBox1 = gcnew System::Windows::Forms::CheckBox;
      this->tab3RadioButton1 = gcnew System::Windows::Forms::RadioButton;
      this->tab1Label1 = gcnew System::Windows::Forms::Label;
      this->tabPage3 = gcnew System::Windows::Forms::TabPage;
      this->tabPage2 = gcnew System::Windows::Forms::TabPage;
      this->tab1Button1 = gcnew System::Windows::Forms::Button;
      tabPage1->Text = "tabPage1";
      tabPage1->Size = System::Drawing::Size( 256, 214 );
      tabPage1->TabIndex = 0;
      tab2CheckBox3->Location = System::Drawing::Point( 32, 136 );
      tab2CheckBox3->Text = "checkBox3";
      tab2CheckBox3->Size = System::Drawing::Size( 176, 32 );
      tab2CheckBox3->TabIndex = 2;
      tab2CheckBox3->Visible = true;
      tab3RadioButton2->Location = System::Drawing::Point( 40, 72 );
      tab3RadioButton2->Text = "radioButton2";
      tab3RadioButton2->Size = System::Drawing::Size( 152, 24 );
      tab3RadioButton2->TabIndex = 1;
      tab3RadioButton2->Visible = true;
      tabControl1->Location = System::Drawing::Point( 16, 16 );
      tabControl1->Size = System::Drawing::Size( 264, 240 );
      tabControl1->SelectedIndex = 0;
      tabControl1->TabIndex = 0;
      tab2CheckBox2->Location = System::Drawing::Point( 32, 80 );
      tab2CheckBox2->Text = "checkBox2";
      tab2CheckBox2->Size = System::Drawing::Size( 176, 32 );
      tab2CheckBox2->TabIndex = 1;
      tab2CheckBox2->Visible = true;
      tab2CheckBox1->Location = System::Drawing::Point( 32, 24 );
      tab2CheckBox1->Text = "checkBox1";
      tab2CheckBox1->Size = System::Drawing::Size( 176, 32 );
      tab2CheckBox1->TabIndex = 0;
      tab3RadioButton1->Location = System::Drawing::Point( 40, 32 );
      tab3RadioButton1->Text = "radioButton1";
      tab3RadioButton1->Size = System::Drawing::Size( 152, 24 );
      tab3RadioButton1->TabIndex = 0;
      tab1Label1->Location = System::Drawing::Point( 16, 24 );
      tab1Label1->Text = "label1";
      tab1Label1->Size = System::Drawing::Size( 224, 96 );
      tab1Label1->TabIndex = 1;
      tabPage3->Text = "tabPage3";
      tabPage3->Size = System::Drawing::Size( 256, 214 );
      tabPage3->TabIndex = 2;
      tabPage2->Text = "tabPage2";
      tabPage2->Size = System::Drawing::Size( 256, 214 );
      tabPage2->TabIndex = 1;
      tab1Button1->Location = System::Drawing::Point( 88, 144 );
      tab1Button1->Size = System::Drawing::Size( 80, 40 );
      tab1Button1->TabIndex = 0;
      tab1Button1->Text = "button1";
      tab1Button1->Click += gcnew System::EventHandler( this, &Form1::tab1Button1_Click );
      this->Text = "Form1";
      
      // Adds controls to the second tab page.
      tabPage2->Controls->Add( this->tab2CheckBox3 );
      tabPage2->Controls->Add( this->tab2CheckBox2 );
      tabPage2->Controls->Add( this->tab2CheckBox1 );
      
      // Adds controls to the third tab page.
      tabPage3->Controls->Add( this->tab3RadioButton2 );
      tabPage3->Controls->Add( this->tab3RadioButton1 );
      
      // Adds controls to the first tab page.
      tabPage1->Controls->Add( this->tab1Label1 );
      tabPage1->Controls->Add( this->tab1Button1 );
      
      // Adds the TabControl to the form.
      this->Controls->Add( this->tabControl1 );
      
      // Adds the tab pages to the TabControl.
      tabControl1->Controls->Add( this->tabPage1 );
      tabControl1->Controls->Add( this->tabPage2 );
      tabControl1->Controls->Add( this->tabPage3 );
   }

   void tab1Button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      
      // Inserts the code that should run when the button is clicked.
   }

};

int main()
{
   Application::Run( gcnew Form1 );
}

// </Snippet1>
