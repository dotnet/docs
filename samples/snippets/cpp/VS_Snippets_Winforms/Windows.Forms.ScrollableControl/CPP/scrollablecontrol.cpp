

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

namespace ScrollableControl
{
   public ref class Form1: public System::Windows::Forms::Form
   {
   private:
      System::Windows::Forms::Panel^ panel1;
      System::Windows::Forms::Button^ button1;
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
         this->panel1 = gcnew System::Windows::Forms::Panel;
         this->button1 = gcnew System::Windows::Forms::Button;
         this->panel1->SuspendLayout();
         this->SuspendLayout();

         //
         // panel1
         //
         this->panel1->AutoScroll = true;
         this->panel1->AutoScrollMargin = System::Drawing::Size( 5, 5 );
         this->panel1->BorderStyle = System::Windows::Forms::BorderStyle::Fixed3D;
         array<System::Windows::Forms::Control^>^temp0 = {this->button1};
         this->panel1->Controls->AddRange( temp0 );
         this->panel1->DockPadding->All = 10;
         this->panel1->Location = System::Drawing::Point( 40, 64 );
         this->panel1->Name = "panel1";
         this->panel1->Size = System::Drawing::Size( 272, 104 );
         this->panel1->TabIndex = 0;

         //
         // button1
         //
         this->button1->Location = System::Drawing::Point( 416, 184 );
         this->button1->Name = "button1";
         this->button1->Size = System::Drawing::Size( 104, 40 );
         this->button1->TabIndex = 1;
         this->button1->Text = "button1";
         this->button1->Click += gcnew System::EventHandler( this, &Form1::button1_Click );

         //
         // Form1
         //
         this->ClientSize = System::Drawing::Size( 336, 205 );
         array<System::Windows::Forms::Control^>^temp1 = {this->panel1};
         this->Controls->AddRange( temp1 );
         this->Name = "Form1";
         this->Text = "Form1";
         this->panel1->ResumeLayout( false );
         this->ResumeLayout( false );
      }

      // <snippet1>
   private:
      void button1_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         /* Add a button to top left corner of the
               * scrollable area, allowing for the offset. */
         panel1->AutoScroll = true;
         Button^ myButton = gcnew Button;
         myButton->Location = Point(0 + panel1->AutoScrollPosition.X,0 + panel1->AutoScrollPosition.Y);
         panel1->Controls->Add( myButton );
      }
      // </snippet1>
   };
}

[STAThread]
int main()
{
   Application::Run( gcnew ::ScrollableControl::Form1 );
}
