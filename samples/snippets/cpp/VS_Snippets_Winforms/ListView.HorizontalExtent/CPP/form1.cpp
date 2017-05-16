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

namespace ListBoxHorizExtentEx
{
   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public ref class Form1: public System::Windows::Forms::Form
   {
   private:
      System::Windows::Forms::ListBox^ listBox1;
      System::Windows::Forms::Button^ button1;

      /// <summary>
      /// Required designer variable.
      /// </summary>
      System::ComponentModel::Container^ components;

   public:
      Form1()
      {
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
         this->listBox1 = gcnew System::Windows::Forms::ListBox;
         this->button1 = gcnew System::Windows::Forms::Button;
         this->SuspendLayout();

         //
         // listBox1
         //
         this->listBox1->Location = System::Drawing::Point( 56, 48 );
         this->listBox1->Name = "listBox1";
         this->listBox1->Size = System::Drawing::Size( 160, 69 );
         this->listBox1->TabIndex = 0;

         //
         // button1
         //
         this->button1->Location = System::Drawing::Point( 272, 56 );
         this->button1->Name = "button1";
         this->button1->TabIndex = 1;
         this->button1->Text = "button1";
         this->button1->Click += gcnew System::EventHandler( this, &Form1::button1_Click );

         //
         // Form1
         //
         this->ClientSize = System::Drawing::Size( 464, 334 );
         array<System::Windows::Forms::Control^>^temp0 = {this->button1,this->listBox1};
         this->Controls->AddRange( temp0 );
         this->Name = "Form1";
         this->Text = "Form1";
         this->ResumeLayout( false );
      }

      void button1_Click( Object^ sender, System::EventArgs^ e )
      {
         DisplayHScroll();
      }

      //<Snippet1>
   private:
      void DisplayHScroll()
      {
         // Make sure no items are displayed partially.
         listBox1->IntegralHeight = true;

         // Add items that are wide to the ListBox.
         for ( int x = 0; x < 10; x++ )
         {
            listBox1->Items->Add( String::Format( "Item {0} is a very large value that requires scroll bars", x ) );

         }

         // Display a horizontal scroll bar.
         listBox1->HorizontalScrollbar = true;

         // Create a Graphics object to use when determining the size of the largest item in the ListBox.
         Graphics^ g = listBox1->CreateGraphics();

         // Determine the size for HorizontalExtent using the MeasureString method using the last item in the list.
         int hzSize = (int)g->MeasureString( dynamic_cast<String^>(listBox1->Items[ listBox1->Items->Count - 1 ]), listBox1->Font ).Width;

         // Set the HorizontalExtent property.
         listBox1->HorizontalExtent = hzSize;
      }
      //</Snippet1>
   };
}

/// <summary>
/// The main entry point for the application.
/// </summary>

[STAThread]
int main()
{
   Application::Run( gcnew ListBoxHorizExtentEx::Form1 );
}
