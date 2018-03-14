#using <System.Data.dll>
#using <System.Windows.Forms.dll>
#using <System.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
using namespace System::Data;

namespace Screen_Example_cs
{

   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public ref class Form1: public System::Windows::Forms::Form
   {
   private:
      System::Windows::Forms::Button^ button1;
      System::Windows::Forms::ListBox^ listBox1;

      /// <summary>
      /// Required designer variable.
      /// </summary>
      System::ComponentModel::Container^ components;

   public:
      Form1()
      {
         components = nullptr;

         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

         //
         // TODO: Add any constructor code after InitializeComponent call
         //
      }


   public:

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      ~Form1()
      {
         if ( components != nullptr )
         {
            delete components;
         }
      }

   private:

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      void InitializeComponent()
      {
         this->button1 = gcnew System::Windows::Forms::Button;
         this->listBox1 = gcnew System::Windows::Forms::ListBox;
         this->SuspendLayout();

         //
         // button1
         //
         this->button1->Location = System::Drawing::Point( 56, 16 );
         this->button1->Name = "button1";
         this->button1->Size = System::Drawing::Size( 168, 23 );
         this->button1->TabIndex = 0;
         this->button1->Text = "Get Screen Info";
         this->button1->Click += gcnew System::EventHandler( this, &Form1::button1_Click );

         //
         // listBox1
         //
         this->listBox1->Location = System::Drawing::Point( 8, 48 );
         this->listBox1->Name = "listBox1";
         this->listBox1->Size = System::Drawing::Size( 280, 186 );
         this->listBox1->TabIndex = 1;

         //
         // Form1
         //
         this->ClientSize = System::Drawing::Size( 292, 273 );
         array<System::Windows::Forms::Control^>^formControls = {this->listBox1,this->button1};
         this->Controls->AddRange( formControls );
         this->Name = "Form1";
         this->Text = "Form1";
         this->ResumeLayout( false );
      }

      //<snippet1>
	private:
		void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
		{
			// For each screen, add the screen properties to a list box.
			for each (Screen^ screen in Screen::AllScreens) {
				listBox1->Items->Add( 
					String::Concat("Device Name: ", screen->DeviceName));
				listBox1->Items->Add( 
					String::Concat("Bounds: ", screen->Bounds));
				listBox1->Items->Add( 
					String::Concat("Type: ", screen->GetType()));
				listBox1->Items->Add( 
					String::Concat("Working Area: ", screen->WorkingArea));
				listBox1->Items->Add( 
					String::Concat("Primary Screen: ", screen->Primary));
			}
		}
      //</snippet1>
   };
}

/// <summary>
/// The main entry point for the application.
/// </summary>

[STAThread]
int main()
{
   Application::Run( gcnew Screen_Example_cs::Form1 );
}
