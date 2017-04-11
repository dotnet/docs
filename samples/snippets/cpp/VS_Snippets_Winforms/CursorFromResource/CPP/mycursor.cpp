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
using namespace System::IO;
using namespace System::Resources;

namespace MyCursors
{
   public ref class MyCursor: public System::Windows::Forms::Form
   {
   private:
      System::Windows::Forms::Button^ button1;
      System::Windows::Forms::Button^ myButton;
      System::ComponentModel::Container^ components;

   public:
      MyCursor()
      {
         components = nullptr;
         InitializeComponent();
      }

   protected:
      ~MyCursor()
      {
         if ( components != nullptr )
         {
            delete components;
         }
      }

      // <snippet1>
   private:
      void SetCursor()
      {
         // Display an OpenFileDialog so the user can select a cursor.
         OpenFileDialog^ openFileDialog1 = gcnew OpenFileDialog;
         openFileDialog1->Filter = "Cursor Files|*.cur";
         openFileDialog1->Title = "Select a Cursor File";
         openFileDialog1->ShowDialog();

         // If a .cur file was selected, open it.
         if (  !openFileDialog1->FileName->Equals( "" ) )
         {
            // Assign the cursor in the stream to the form's Cursor property.
            this->Cursor = gcnew System::Windows::Forms::Cursor( openFileDialog1->OpenFile() );
         }
      }
      // </snippet1>

      // <snippet2>
   private:
      void myButton_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         /* Call the CursorFromResource method and
           display the embedded cursor resource. */
         this->Cursor = CursorFromResource( MyCursors::MyCursor::typeid, "MyWaitCursor::cur" );
      }

      System::Windows::Forms::Cursor^ CursorFromResource( Type^ type, String^ resource )
      {
         // Create a cursor from the resource.
         try
         {
            return gcnew System::Windows::Forms::Cursor( type,resource );
         }
         // If the cursor cannot be created, message the user.
         catch ( Exception^ ex ) 
         {
            MessageBox::Show( ex->ToString() );
            return nullptr;
         }
      }
      // </snippet2>

      // <snippet3>
   private:
      void myButton_MouseEnter( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         // Hide the cursor when the mouse pointer enters the button.
         ::Cursor::Hide();
      }

      void myButton_MouseLeave( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         // Show the cursor when the mouse pointer leaves the button.
         ::Cursor::Show();
      }
      // </snippet3>

      void InitializeComponent()
      {
         this->button1 = gcnew System::Windows::Forms::Button;
         this->myButton = gcnew System::Windows::Forms::Button;
         this->SuspendLayout();

         //
         // button1
         //
         this->button1->Location = System::Drawing::Point( 104, 192 );
         this->button1->Name = "button1";
         this->button1->TabIndex = 0;
         this->button1->Text = "button1";
         this->button1->Click += gcnew System::EventHandler( this, &MyCursor::button1_Click );
         this->myButton->MouseEnter += gcnew System::EventHandler( this, &MyCursor::myButton_MouseEnter );
         this->myButton->MouseLeave += gcnew System::EventHandler( this, &MyCursor::myButton_MouseLeave );

         //
         // myButton
         //
         this->myButton->Location = System::Drawing::Point( 40, 32 );
         this->myButton->Name = "myButton";
         this->myButton->TabIndex = 1;
         this->myButton->Text = "myButton";
         this->myButton->Click += gcnew System::EventHandler( this, &MyCursor::myButton_Click );

         //
         // Form1
         //
         this->ClientSize = System::Drawing::Size( 292, 273 );
         array<System::Windows::Forms::Control^>^temp0 = {this->myButton,this->button1};
         this->Controls->AddRange( temp0 );
         this->Name = "Form1";
         this->Text = "Form1";
         this->ResumeLayout( false );
      }

      void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         this->SetCursor();
      }
   };
}
// end class
// end namespace

[STAThread]
int main()
{
   Application::Run( gcnew MyCursors::MyCursor );
}

//Output:
//System::Globalization::NumberFormatInfo
//This instance is a read-only.
