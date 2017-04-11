// System::Windows::Forms::Control::VisibleChanged

/*
The following program demonstrates 'VisibleChanged' event for the 'Control' class.
The 'VisibleChanged' event is raised when the 'Visible' property value of
'Label' control has changed.
*/

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
using namespace System::Data;

namespace MyControlExample
{
   public ref class MyForm: public Form
   {
   private:
      Label^ myLabel;
      Button^ myButton;
      System::ComponentModel::Container^ components;

   public:
      MyForm()
      {
         components = nullptr;
         InitializeComponent();
      }

   protected:
      ~MyForm()
      {
         if ( components != nullptr )
         {
            delete components;
         }
      }

   private:
      void InitializeComponent()
      {
         this->myLabel = gcnew Label;
         this->myButton = gcnew Button;
         this->SuspendLayout();

         //
         // myLabel
         //
         this->myLabel->Location = System::Drawing::Point( 24, 8 );
         this->myLabel->Name = "myLabel";
         this->myLabel->Size = System::Drawing::Size( 240, 40 );
         this->myLabel->Text = String::Concat( this->myLabel->Text, "Welcome to .NET." );

         //
         // myButton
         //
         this->myButton->Location = System::Drawing::Point( 54, 50 );
         this->myButton->Name = "myLabel";
         this->myButton->Size = System::Drawing::Size( 100, 40 );
         this->myButton->TabIndex = 0;
         this->myButton->Text = "Hide Label";
         this->myButton->Click += gcnew EventHandler( this, &MyForm::Button_HideLabel );

         //
         // MyForm
         //
         this->ClientSize = System::Drawing::Size( 292, 273 );
         this->Controls->Add( this->myLabel );
         this->Controls->Add( this->myButton );
         this->Name = "MyForm";
         this->Text = "VisibleChanged example";
         this->ResumeLayout( false );
         AddVisibleChangedEventHandler();
      }

      // <Snippet1>
   private:
      void Button_HideLabel( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         myLabel->Visible = false;
      }

      void AddVisibleChangedEventHandler()
      {
         myLabel->VisibleChanged += gcnew EventHandler( this, &MyForm::Label_VisibleChanged );
      }

      void Label_VisibleChanged( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         MessageBox::Show( "Visible change event raised!!!" );
      }
      // </Snippet1>
   };
}

[STAThread]
int main()
{
   Application::Run( gcnew MyControlExample::MyForm );
}
