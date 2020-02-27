

#using <System.Windows.Forms.dll>
#using <System.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;

namespace ControlMembers
{
   public ref class Form1: public System::Windows::Forms::Form
   {
   private:
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

      /// <summary>
      /// Required method for Designer support; do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      void InitializeComponent()
      {
         this->button1 = gcnew System::Windows::Forms::Button;
         this->SuspendLayout();
         
         //
         // button1
         //
         this->button1->Anchor = static_cast<AnchorStyles>(System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Right);
         this->button1->Location = System::Drawing::Point( 104, 104 );
         this->button1->Name = "button1";
         this->button1->TabIndex = 0;
         this->button1->Text = "button1";
         this->button1->Click += gcnew System::EventHandler( this, &Form1::button_Click );
         
         //
         // Form1
         //
         this->ClientSize = System::Drawing::Size( 292, 273 );
         array<System::Windows::Forms::Control^>^temp0 = {this->button1};
         this->Controls->AddRange( temp0 );
         this->Name = "Form1";
         this->Text = "Form1";
         this->ResumeLayout( false );
      }

      // <snippet1>
      // Create three buttons and place them on a form using
      // several size and location related properties.
      void AddOKCancelButtons()
      {
         
         // Set the button size and location using
         // the Size and Location properties.
         Button^ buttonOK = gcnew Button;
         buttonOK->Location = Point(136,248);
         buttonOK->Size = System::Drawing::Size( 75, 25 );
         
         // Set the Text property and make the
         // button the form's default button.
         buttonOK->Text = "&OK";
         this->AcceptButton = buttonOK;
         
         // Set the button size and location using the Top,
         // Left, Width, and Height properties.
         Button^ buttonCancel = gcnew Button;
         buttonCancel->Top = buttonOK->Top;
         buttonCancel->Left = buttonOK->Right + 5;
         buttonCancel->Width = buttonOK->Width;
         buttonCancel->Height = buttonOK->Height;
         
         // Set the Text property and make the
         // button the form's cancel button.
         buttonCancel->Text = "&Cancel";
         this->CancelButton = buttonCancel;
         
         // Set the button size and location using
         // the Bounds property.
         Button^ buttonHelp = gcnew Button;
         buttonHelp->Bounds = Rectangle(10,10,75,25);
         
         // Set the Text property of the button.
         buttonHelp->Text = "&Help";
         
         // Add the buttons to the form.
         array<Control^>^temp1 = {buttonOK,buttonCancel,buttonHelp};
         this->Controls->AddRange( temp1 );
      }
      // </snippet1>

      void button_Click( Object^ sender, System::EventArgs^ /*e*/ )
      {
         Control^ ctrl = dynamic_cast<Control^>(sender);
         array<Object^>^temp2 = {ctrl->Top,ctrl->Bottom,ctrl->Left,ctrl->Right,ctrl->Width,ctrl->Height,ctrl->Size,ctrl->Location};
         MessageBox::Show( String::Format( "Top: {0}\n Bottom: {1}\n Left: {2}\n Right: {3}\n Width: {4}\n Height: {5}\n Size: {6}\n Location: {7}", temp2 ), "button1 Position", MessageBoxButtons::OKCancel );
         this->AddOKCancelButtons();
      }
   };
}

[STAThread]
int main()
{
   Application::Run( gcnew ControlMembers::Form1 );
}
