

//<Snippet1>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;
using namespace System::Drawing;
using namespace System::Drawing::Design;
using namespace System::Windows::Forms;
using namespace System::Windows::Forms::Design;
using namespace System::Security::Permissions;

namespace IWindowsFormsEditorServiceExample
{
   // Example control for entering a string.
   private ref class StringInputControl: public UserControl
   {
   public:
      System::Windows::Forms::TextBox^ inputTextBox;

   private:
      System::Windows::Forms::Button^ ok_button;
      System::Windows::Forms::Button^ cancel_button;
      IWindowsFormsEditorService^ edSvc;

   public:
      StringInputControl( String^ text, IWindowsFormsEditorService^ edSvc )
      {
         InitializeComponent();
         inputTextBox->Text = text;
         
         // Stores IWindowsFormsEditorService reference to use to
         // close the control.
         this->edSvc = edSvc;
      }

   private:
      void InitializeComponent()
      {
         this->inputTextBox = gcnew System::Windows::Forms::TextBox;
         this->ok_button = gcnew System::Windows::Forms::Button;
         this->cancel_button = gcnew System::Windows::Forms::Button;
         this->SuspendLayout();
         this->inputTextBox->Anchor = static_cast<AnchorStyles>(System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Left | System::Windows::Forms::AnchorStyles::Right);
         this->inputTextBox->Location = System::Drawing::Point( 6, 7 );
         this->inputTextBox->Name = "inputTextBox";
         this->inputTextBox->Size = System::Drawing::Size( 336, 20 );
         this->inputTextBox->TabIndex = 0;
         this->inputTextBox->Text = "";
         this->ok_button->Anchor = static_cast<AnchorStyles>(System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Right);
         this->ok_button->DialogResult = System::Windows::Forms::DialogResult::OK;
         this->ok_button->Location = System::Drawing::Point( 186, 38 );
         this->ok_button->Name = "ok_button";
         this->ok_button->TabIndex = 1;
         this->ok_button->Text = "OK";
         this->ok_button->Click += gcnew EventHandler( this, &StringInputControl::CloseControl );
         this->cancel_button->Anchor = static_cast<AnchorStyles>(System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Right);
         this->cancel_button->DialogResult = System::Windows::Forms::DialogResult::Cancel;
         this->cancel_button->Location = System::Drawing::Point( 267, 38 );
         this->cancel_button->Name = "cancel_button";
         this->cancel_button->TabIndex = 2;
         this->cancel_button->Text = "Cancel";
         this->cancel_button->Click += gcnew EventHandler( this, &StringInputControl::CloseControl );
         array<System::Windows::Forms::Control^>^temp0 = {this->cancel_button,this->ok_button,this->inputTextBox};
         this->Controls->AddRange( temp0 );
         this->Name = "StringInputControl";
         this->Size = System::Drawing::Size( 350, 70 );
         this->ResumeLayout( false );
      }

      void CloseControl( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         edSvc->CloseDropDown();
      }
   };

   // Example UITypeEditor that uses the IWindowsFormsEditorService to
   // display a drop-down control.
   [PermissionSet(SecurityAction::Demand, Name = "FullTrust")]
   public ref class TestDropDownEditor: public System::Drawing::Design::UITypeEditor
   {
   public:
      TestDropDownEditor(){}

      virtual System::Drawing::Design::UITypeEditorEditStyle GetEditStyle( System::ComponentModel::ITypeDescriptorContext^ /*context*/ ) override
      {
         // Indicates that this editor can display a control-based
         // drop-down interface.
         return UITypeEditorEditStyle::DropDown;
      }

      virtual Object^ EditValue( System::ComponentModel::ITypeDescriptorContext^ /*context*/, System::IServiceProvider^ provider, Object^ value ) override
      {
         // Attempts to obtain an IWindowsFormsEditorService.
         IWindowsFormsEditorService^ edSvc = dynamic_cast<IWindowsFormsEditorService^>(provider->GetService( IWindowsFormsEditorService::typeid ));
         if ( edSvc == nullptr )
                  return value;

         // Displays a drop-down control.
         StringInputControl^ inputControl = gcnew StringInputControl( dynamic_cast<String^>(value),edSvc );
         edSvc->DropDownControl( inputControl );
         return inputControl->inputTextBox->Text;
      }
   };

   // Provides an example control that displays instructions in design mode,
   // with which the example UITypeEditor is associated.
   public ref class WinFormsEdServiceDropDownExampleControl: public UserControl
   {
   public:

      property String^ TestDropDownString 
      {
         [EditorAttribute(IWindowsFormsEditorServiceExample::TestDropDownEditor::typeid,UITypeEditor::typeid)]
         String^ get()
         {
            return localDropDownTestString;
         }

         void set( String^ value )
         {
            localDropDownTestString = value;
         }
      }

   private:
      String^ localDropDownTestString;

   public:
      WinFormsEdServiceDropDownExampleControl()
      {
         localDropDownTestString = "Test String";
         this->Size = System::Drawing::Size( 210, 74 );
         this->BackColor = Color::Beige;
      }

   protected:
      virtual void OnPaint( System::Windows::Forms::PaintEventArgs^ e ) override
      {
         if ( this->DesignMode )
         {
            e->Graphics->DrawString( "Use the Properties window to show", gcnew System::Drawing::Font( "Arial",8 ), gcnew SolidBrush( Color::Black ), 5, 5 );
            e->Graphics->DrawString( "a drop-down control, using the", gcnew System::Drawing::Font( "Arial",8 ), gcnew SolidBrush( Color::Black ), 5, 17 );
            e->Graphics->DrawString( "IWindowsFormsEditorService, for", gcnew System::Drawing::Font( "Arial",8 ), gcnew SolidBrush( Color::Black ), 5, 29 );
            e->Graphics->DrawString( "configuring this control's", gcnew System::Drawing::Font( "Arial",8 ), gcnew SolidBrush( Color::Black ), 5, 41 );
            e->Graphics->DrawString( "TestDropDownString property.", gcnew System::Drawing::Font( "Arial",8 ), gcnew SolidBrush( Color::Black ), 5, 53 );
         }
         else
         {
            e->Graphics->DrawString( "This example requires design mode.", gcnew System::Drawing::Font( "Arial",8 ), gcnew SolidBrush( Color::Black ), 5, 5 );
         }
      }
   };
}
//</Snippet1>
