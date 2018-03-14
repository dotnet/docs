

#using <System.Drawing.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>

using namespace System::Windows::Forms;
public ref class Form1: public System::Windows::Forms::Form
{
public:
   Form1()
      : Form()
   {
      
      //This call is required by the Windows Form Designer.
      InitializeComponent();
      
      //Add any initialization after the InitializeComponent() call
   }


protected:

   ~Form1()
   {
      if ( components != nullptr )
      {
         delete components;
      }
   }

private:

   //Required by the Windows Form Designer
   System::ComponentModel::IContainer^ components;

internal:

   //NOTE: The following procedure is required by the Windows Form Designer
   //It can be modified using the Windows Form Designer.  
   //Do not modify it using the code editor.
   System::Windows::Forms::Button^ Button1;
   System::Windows::Forms::TextBox^ TextBox1;
   System::Windows::Forms::Label ^ Label1;
   System::Windows::Forms::Button^ Button2;

private:

   [System::Diagnostics::DebuggerStepThrough]
   void InitializeComponent()
   {
      this->Button1 = gcnew System::Windows::Forms::Button;
      this->TextBox1 = gcnew System::Windows::Forms::TextBox;
      this->Label1 = gcnew System::Windows::Forms::Label;
      this->Button2 = gcnew System::Windows::Forms::Button;
      this->SuspendLayout();
      
      //
      //Button1
      //
      this->Button1->Location = System::Drawing::Point( 32, 160 );
      this->Button1->Name = "Button1";
      this->Button1->Size = System::Drawing::Size( 80, 32 );
      this->Button1->TabIndex = 0;
      this->Button1->Text = "Help";
      this->Button1->Click += gcnew System::EventHandler( this, &Form1::Button1_Click );
      
      //
      //TextBox1
      //
      this->TextBox1->Location = System::Drawing::Point( 152, 72 );
      this->TextBox1->Name = "TextBox1";
      this->TextBox1->TabIndex = 1;
      this->TextBox1->Text = "";
      
      //
      //Label1
      //
      this->Label1->Location = System::Drawing::Point( 40, 72 );
      this->Label1->Name = "Label1";
      this->Label1->TabIndex = 2;
      this->Label1->Text = "Name";
      
      //
      //Button2
      //
      this->Button2->Location = System::Drawing::Point( 168, 168 );
      this->Button2->Name = "Button2";
      this->Button2->TabIndex = 3;
      this->Button2->Text = "More Help";
      this->Button2->Click += gcnew System::EventHandler( this, &Form1::Button2_Click );
      
      //
      //Form1
      //
      this->ClientSize = System::Drawing::Size( 292, 266 );
      this->Controls->Add( this->Button2 );
      this->Controls->Add( this->Label1 );
      this->Controls->Add( this->TextBox1 );
      this->Controls->Add( this->Button1 );
      this->Name = "Form1";
      this->Text = "Register";
      this->ResumeLayout( false );
   }

   //<snippet1>
   // Open the Help file for the Character Map topic.  
   void Button1_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      Help::ShowHelp( TextBox1, "file://c:\\charmap.chm" );
   }
   //</snippet1>

   //<snippet2>
   // Open the Help file for the Character Map topic and 
   // display the Index page.
   void Button2_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      Help::ShowHelp( TextBox1, "file://c:\\charmap.chm", HelpNavigator::Index );
   }
   //</snippet2>
};

[System::STAThreadAttribute]
int main()
{
   Application::Run( gcnew Form1 );
}
