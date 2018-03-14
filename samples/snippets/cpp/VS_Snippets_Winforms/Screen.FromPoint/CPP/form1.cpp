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

namespace WindowsApplication2
{

   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public ref class Form1: public System::Windows::Forms::Form
   {
   private:

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
         //
         // Form1
         //
         this->ClientSize = System::Drawing::Size( 292, 273 );
         this->Name = "Form1";
         this->Text = "Form1";
         this->MouseDown += gcnew System::Windows::Forms::MouseEventHandler( this, &Form1::Form1_MouseDown );
         this->Load += gcnew System::EventHandler( this, &Form1::Form1_Load );
      }

      void Form1_Load( Object^ /*sender*/, System::EventArgs^ /*e*/ ){}

      //<snippet1>
   private:
      void Form1_MouseDown( Object^ /*sender*/, System::Windows::Forms::MouseEventArgs^ e )
      {
         Point p = Point(e->X,e->Y);
         Screen^ s = Screen::FromPoint( p );
         if ( s->Primary )
         {
            MessageBox::Show( "You clicked the primary screen" );
         }
         else
         {
            MessageBox::Show( "This isn't the primary screen" );
         }
         //</snippet1>
      }
   };
}

/// <summary>
/// The main entry point for the application.
/// </summary>

[STAThread]
int main()
{
   Application::Run( gcnew WindowsApplication2::Form1 );
}
