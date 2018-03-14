

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

namespace CursorStuff
{
   public ref class Form1: public System::Windows::Forms::Form
   {
   private:
      System::Windows::Forms::Button^ button1;
      System::Windows::Forms::Button^ button2;
      System::ComponentModel::Container^ components;

   public:
      Form1()
      {
         InitializeComponent();
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
      void InitializeComponent()
      {
         this->button1 = gcnew System::Windows::Forms::Button;
         this->button2 = gcnew System::Windows::Forms::Button;
         this->SuspendLayout();
         
         //
         // button1
         //
         this->button1->Cursor = System::Windows::Forms::Cursors::Default;
         this->button1->Location = System::Drawing::Point( 40, 184 );
         this->button1->Name = "button1";
         this->button1->TabIndex = 2;
         this->button1->Text = "button1";
         this->button1->Click += gcnew System::EventHandler( this, &Form1::button1_Click );
         
         //
         // button2
         //
         this->button2->Cursor = System::Windows::Forms::Cursors::Default;
         this->button2->Location = System::Drawing::Point( 56, 232 );
         this->button2->Name = "button2";
         this->button2->TabIndex = 3;
         this->button2->Text = "button2";
         this->button2->Click += gcnew System::EventHandler( this, &Form1::button2_Click );
         
         //
         // Form1
         //
         this->ClientSize = System::Drawing::Size( 292, 273 );
         array<System::Windows::Forms::Control^>^temp0 = {this->button2,this->button1};
         this->Controls->AddRange( temp0 );
         this->Cursor = System::Windows::Forms::Cursors::Hand;
         this->Name = "Form1";
         this->Text = "Form1";
         this->ResumeLayout( false );
      }

      void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         this->MoveCursor();
      }

      //<snippet1>
      void MoveCursor()
      {
         // Set the Current cursor, move the cursor's Position,
         // and set its clipping rectangle to the form.

         this->Cursor = gcnew System::Windows::Forms::Cursor( ::Cursor::Current->Handle );
         ::Cursor::Position = Point(::Cursor::Position.X - 50,::Cursor::Position.Y - 50);
         ::Cursor::Clip = Rectangle(this->Location,this->Size);

      }
      //</snippet1>

      //<snippet2>
      void DrawCursorsOnForm( System::Windows::Forms::Cursor^ cursor )
      {
         
         // If the form's cursor is not the Hand cursor and the
         // Current cursor is the Default, Draw the specified
         // cursor on the form in normal size and twice normal size.
         if ( this->Cursor != Cursors::Hand && System::Windows::Forms::Cursor::Current == Cursors::Default )
         {
            
            // Draw the cursor stretched.
            Graphics^ graphics = this->CreateGraphics();
            Rectangle rectangle = Rectangle(Point(10,10),System::Drawing::Size( cursor->Size.Width * 2, cursor->Size.Height * 2 ));
            cursor->DrawStretched( graphics, rectangle );
            
            // Draw the cursor in normal size.
            rectangle.Location = Point(rectangle.Width + rectangle.Location.X,rectangle.Height + rectangle.Location.Y);
            rectangle.Size = cursor->Size;
            cursor->Draw( graphics, rectangle );
            
            // Dispose of the cursor.
            delete cursor;
         }
      }
      //</snippet2>

      void button2_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         this->DrawCursorsOnForm( gcnew System::Windows::Forms::Cursor( "c:\\MyCursor.cur" ) );
      }

   };
}

[STAThread]
int main()
{
   Application::Run( gcnew CursorStuff::Form1 );
}
