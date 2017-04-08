

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
   // Example Form for entering a string.
   private ref class StringInputDialog: public System::Windows::Forms::Form
   {
   private:
      System::Windows::Forms::Button^ ok_button;
      System::Windows::Forms::Button^ cancel_button;

   public:
      System::Windows::Forms::TextBox^ inputTextBox;
      StringInputDialog( String^ text )
      {
         InitializeComponent();
         inputTextBox->Text = text;
      }

   private:
      void InitializeComponent()
      {
         this->ok_button = gcnew System::Windows::Forms::Button;
         this->cancel_button = gcnew System::Windows::Forms::Button;
         this->inputTextBox = gcnew System::Windows::Forms::TextBox;
         this->SuspendLayout();
         this->ok_button->Anchor = static_cast<AnchorStyles>(System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Right);
         this->ok_button->Location = System::Drawing::Point( 180, 43 );
         this->ok_button->Name = "ok_button";
         this->ok_button->TabIndex = 1;
         this->ok_button->Text = "OK";
         this->ok_button->DialogResult = System::Windows::Forms::DialogResult::OK;
         this->cancel_button->Anchor = static_cast<AnchorStyles>(System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Right);
         this->cancel_button->Location = System::Drawing::Point( 260, 43 );
         this->cancel_button->Name = "cancel_button";
         this->cancel_button->TabIndex = 2;
         this->cancel_button->Text = "Cancel";
         this->cancel_button->DialogResult = System::Windows::Forms::DialogResult::Cancel;
         this->inputTextBox->Location = System::Drawing::Point( 6, 9 );
         this->inputTextBox->Name = "inputTextBox";
         this->inputTextBox->Size = System::Drawing::Size( 327, 20 );
         this->inputTextBox->TabIndex = 0;
         this->inputTextBox->Text = "";
         this->inputTextBox->Anchor = static_cast<AnchorStyles>(System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Left | System::Windows::Forms::AnchorStyles::Right);
         this->ClientSize = System::Drawing::Size( 342, 73 );
         array<System::Windows::Forms::Control^>^temp0 = {this->inputTextBox,this->cancel_button,this->ok_button};
         this->Controls->AddRange( temp0 );
         this->MinimumSize = System::Drawing::Size( 350, 100 );
         this->Name = "StringInputDialog";
         this->Text = "String Input Dialog";
         this->ResumeLayout( false );
      }
   };

   // Example UITypeEditor that uses the IWindowsFormsEditorService
   // to display a Form.
   [PermissionSet(SecurityAction::Demand, Name = "FullTrust")]
   public ref class TestDialogEditor: public System::Drawing::Design::UITypeEditor
   {
   public:
      TestDialogEditor(){}

      virtual System::Drawing::Design::UITypeEditorEditStyle GetEditStyle( System::ComponentModel::ITypeDescriptorContext^ context ) override
      {
         // Indicates that this editor can display a Form-based interface.
         return UITypeEditorEditStyle::Modal;
      }

      virtual Object^ EditValue( System::ComponentModel::ITypeDescriptorContext^ context, System::IServiceProvider^ provider, Object^ value ) override
      {
         // Attempts to obtain an IWindowsFormsEditorService.
         IWindowsFormsEditorService^ edSvc = dynamic_cast<IWindowsFormsEditorService^>(provider->GetService( IWindowsFormsEditorService::typeid ));
         if ( edSvc == nullptr )
                  return nullptr;
         
         // Displays a StringInputDialog Form to get a user-adjustable
         // string value.
         StringInputDialog^ form = gcnew StringInputDialog( dynamic_cast<String^>(value) );
         if ( edSvc->ShowDialog( form ) == DialogResult::OK )
                  return form->inputTextBox->Text;

         // If OK was not pressed, return the original value
         return value;
      }
   };

   // Provides an example control that displays instructions in design mode,
   // with which the example UITypeEditor is associated.
   public ref class WinFormsEdServiceDialogExampleControl: public UserControl
   {
   public:

      property String^ TestDialogString 
      {
         [EditorAttribute(IWindowsFormsEditorServiceExample::TestDialogEditor::typeid,UITypeEditor::typeid)]
         String^ get()
         {
            return localDialogTestString;
         }

         void set( String^ value )
         {
            localDialogTestString = value;
         }
      }

   private:
      String^ localDialogTestString;

   public:
      WinFormsEdServiceDialogExampleControl()
      {
         localDialogTestString = "Test String";
         this->Size = System::Drawing::Size( 210, 74 );
         this->BackColor = Color::Beige;
      }

   protected:
      virtual void OnPaint( System::Windows::Forms::PaintEventArgs^ e ) override
      {
         if ( this->DesignMode )
         {
            e->Graphics->DrawString( "Use the Properties window to show", gcnew System::Drawing::Font( "Arial",8 ), gcnew SolidBrush( Color::Black ), 5, 5 );
            e->Graphics->DrawString( "a Form dialog box, using the", gcnew System::Drawing::Font( "Arial",8 ), gcnew SolidBrush( Color::Black ), 5, 17 );
            e->Graphics->DrawString( "IWindowsFormsEditorService, for", gcnew System::Drawing::Font( "Arial",8 ), gcnew SolidBrush( Color::Black ), 5, 29 );
            e->Graphics->DrawString( "configuring this control's", gcnew System::Drawing::Font( "Arial",8 ), gcnew SolidBrush( Color::Black ), 5, 41 );
            e->Graphics->DrawString( "TestDialogString property.", gcnew System::Drawing::Font( "Arial",8 ), gcnew SolidBrush( Color::Black ), 5, 53 );
         }
         else
         {
            e->Graphics->DrawString( "This example requires design mode.", gcnew System::Drawing::Font( "Arial",8 ), gcnew SolidBrush( Color::Black ), 5, 5 );
         }
      }
   };
}
//</Snippet1>
