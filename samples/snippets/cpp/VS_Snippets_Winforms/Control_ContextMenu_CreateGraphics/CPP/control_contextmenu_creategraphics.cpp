
// System.Windows.Forms.Control.ContextMenu
// System.Windows.Forms.Control.ContextMenuChanged
// System.Windows.Forms.Control.CreateGraphics
/*
   The following program demonstrates the 'ContextMenu' property, 'ContextMenuChanged'
   event handler and 'CreateGraphics' method of 'Control' class.
   It displays the 'TextBox' and 'Button' controls on the form. When mouse is clicked inside
   the 'TextBox' control, an instance of 'ContextMenu' is created and assigned to 'TextBox'
   control by using 'ContextMenu' property. The shortcut menu pops-up when right button of
   mouse is clicked inside the 'TextBox' control. When the 'Button' is clicked, an
   instance of 'Graphics' class is obtained by calling 'CreateGraphics' method and draws an
   ellipse inside the 'TextBox' control.
*/
#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;

namespace MyApplication
{
   public ref class MyForm: public Form
   {
   private:
      System::Windows::Forms::TextBox^ myTextBox;
      System::ComponentModel::Container^ components;
      System::Windows::Forms::Label^ myLabel;
      System::Windows::Forms::Button^ myButton;

   public:
      MyForm()
      {
         components = nullptr;
         InitializeComponent();
         AddClickHandler();
         AddContextMenuChangedHandler();
      }

   public:
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
         this->myButton = gcnew System::Windows::Forms::Button;
         this->myLabel = gcnew System::Windows::Forms::Label;
         this->myTextBox = gcnew System::Windows::Forms::TextBox;
         this->SuspendLayout();

         //
         // myButton
         //
         this->myButton->Location = System::Drawing::Point( 48, 232 );
         this->myButton->Name = L"myButton";
         this->myButton->Size = System::Drawing::Size( 96, 23 );
         this->myButton->TabIndex = 2;
         this->myButton->Text = L"CreateGraphics";
         this->myButton->Click += gcnew System::EventHandler( this, &MyForm::CreateGraphicsButton_Click );

         //
         // myLabel
         //
         this->myLabel->Location = System::Drawing::Point( 24, 16 );
         this->myLabel->Name = L"myLabel";
         this->myLabel->Size = System::Drawing::Size( 256, 40 );
         this->myLabel->TabIndex = 1;
         this->myLabel->Text = L"Click inside the TextBox to set the ContextMenu and then"
         L" click the right mouse button inside the TextBox to popup the ContextMenu.";

         //
         // myTextBox
         //
         this->myTextBox->Location = System::Drawing::Point( 16, 80 );
         this->myTextBox->Multiline = true;
         this->myTextBox->Name = L"myTextBox";
         this->myTextBox->Size = System::Drawing::Size( 240, 112 );
         this->myTextBox->TabIndex = 0;
         this->myTextBox->Text = L"Welcome to .NET";

         //
         // MyForm
         //
         this->ClientSize = System::Drawing::Size( 292, 273 );
         array<System::Windows::Forms::Control^>^myFormControls = {this->myButton,this->myLabel,this->myTextBox};
         this->Controls->AddRange( myFormControls );
         this->Name = L"MyForm";
         this->Text = L"ContextMenu Example";
         this->ResumeLayout( false );
      }

      // <Snippet1>
   private:
      void AddClickHandler()
      {
         this->myTextBox->Click += gcnew EventHandler( this, &MyForm::TextBox_Click );
      }

      void TextBox_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         array<MenuItem^>^myMenuItems = gcnew array<MenuItem^>(2);
         myMenuItems[ 0 ] = gcnew MenuItem( L"New",gcnew EventHandler( this, &MyForm::MenuItem_New ) );
         myMenuItems[ 1 ] = gcnew MenuItem( L"Open",gcnew EventHandler( this, &MyForm::MenuItem_Open ) );
         this->myTextBox->ContextMenu = gcnew System::Windows::Forms::ContextMenu( myMenuItems );
      }

      void MenuItem_New( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         MessageBox::Show( L"New MenuItem is selected from TextBox's shortcut menu." );
      }

      void MenuItem_Open( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         MessageBox::Show( L"Open MenuItem is selected from TextBox's shortcut menu." );
      }
      // </Snippet1>

      // <Snippet2>
   private:
      void AddContextMenuChangedHandler()
      {
         this->myTextBox->ContextMenuChanged += gcnew EventHandler( this, &MyForm::TextBox_ContextMenuChanged );
      }

      void TextBox_ContextMenuChanged( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         MessageBox::Show( L"Shortcut menu of TextBox is changed." );
      }
      // </Snippet2>

      void CreateGraphicsButton_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         // <Snippet3>
         Graphics^ myGraphics = myTextBox->CreateGraphics();
         myGraphics->DrawEllipse( gcnew Pen( Color::Black,3 ), 0.0F, 0.0F, 230.0F, 105.0F );
         myGraphics->FillEllipse( Brushes::Goldenrod, 0.0F, 0.0F, 230.0F, 105.0F );
         // </Snippet3>
      }

      [STAThread]
      int main()
      {
         Application::Run( gcnew MyForm );
         return 1;
      }
   };
}

