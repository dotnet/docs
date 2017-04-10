

//<Snippet1>
#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.Design.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;
using namespace System::Drawing;
using namespace System::Windows::Forms;
using namespace System::Windows::Forms::Design;

// Provides an example Form class used by the
// IUIServiceTestDesigner::showDialog method.
ref class ExampleForm: public System::Windows::Forms::Form
{
public:
   ExampleForm()
   {
      this->Text = "Example Form";
      System::Windows::Forms::Button^ okButton = gcnew System::Windows::Forms::Button;
      okButton->Location = Point(this->Width - 70,this->Height - 70);
      okButton->Size = System::Drawing::Size( 50, 20 );
      okButton->Anchor = static_cast<AnchorStyles>(AnchorStyles::Right | AnchorStyles::Bottom);
      okButton->DialogResult = ::DialogResult::OK;
      okButton->Text = "OK";
      this->Controls->Add( okButton );
   }
};

// This designer provides a set of designer verb shortcut menu commands
// that call methods of the IUIService.
public ref class IUIServiceTestDesigner: public System::Windows::Forms::Design::ControlDesigner
{
public:
   IUIServiceTestDesigner(){}

   property System::ComponentModel::Design::DesignerVerbCollection^ Verbs 
   {
      // Provides a set of designer verb menu commands that call IUIService methods.
      virtual System::ComponentModel::Design::DesignerVerbCollection^ get() override
      {
         array<DesignerVerb^>^temp0 = {gcnew DesignerVerb( "Show a test message box using the IUIService",gcnew EventHandler( this, &IUIServiceTestDesigner::showTestMessage ) ),gcnew DesignerVerb( "Show a test error message using the IUIService",gcnew EventHandler( this, &IUIServiceTestDesigner::showErrorMessage ) ),gcnew DesignerVerb( "Show an example Form using the IUIService",gcnew EventHandler( this, &IUIServiceTestDesigner::showDialog ) ),gcnew DesignerVerb( "Show the Task List tool window using the IUIService",gcnew EventHandler( this, &IUIServiceTestDesigner::showToolWindow ) )};
         return gcnew DesignerVerbCollection( temp0 );
      }
   }

private:

   // Displays a message box with message text, caption text
   // and buttons of a particular MessageBoxButtons style.
   void showTestMessage( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      //<Snippet2>
      IUIService^ UIservice = dynamic_cast<IUIService^>(this->GetService( System::Windows::Forms::Design::IUIService::typeid ));
      if ( UIservice != nullptr )
            UIservice->ShowMessage( "Test message", "Test caption", System::Windows::Forms::MessageBoxButtons::AbortRetryIgnore );
      //</Snippet2>
   }


   // Displays an error message box that displays the message
   // contained within a specified exception.
   void showErrorMessage( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      //<Snippet3>
      IUIService^ UIservice = dynamic_cast<IUIService^>(this->GetService( System::Windows::Forms::Design::IUIService::typeid ));
      if ( UIservice != nullptr )
            UIservice->ShowError( gcnew Exception( "This is a message in a test exception, displayed by the IUIService",gcnew ArgumentException( "Test inner exception" ) ) );
      //</Snippet3>
   }

   // Displays an example Windows Form using the
   // IUIService::ShowDialog method.
   void showDialog( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      //<Snippet4>
      IUIService^ UIservice = dynamic_cast<IUIService^>(this->GetService( System::Windows::Forms::Design::IUIService::typeid ));
      if ( UIservice != nullptr )
            UIservice->ShowDialog( gcnew ExampleForm );
      //</Snippet4>
   }

   // Displays a standard tool window window using the
   // IUIService::ShowToolWindow method.
   void showToolWindow( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      //<Snippet5>
      IUIService^ UIservice = dynamic_cast<IUIService^>(this->GetService( System::Windows::Forms::Design::IUIService::typeid ));
      if ( UIservice != nullptr )
            UIservice->ShowToolWindow( StandardToolWindows::TaskList );
      //</Snippet5>
   }
};

// This control is associated with the IUIServiceTestDesigner,
// and can be sited in design mode to use the sample.

[DesignerAttribute(IUIServiceTestDesigner::typeid,IDesigner::typeid)]
ref class IUIServiceExampleControl: public UserControl
{
public:
   IUIServiceExampleControl()
   {
      this->BackColor = Color::Beige;
      this->Width = 255;
      this->Height = 60;
   }

protected:
   virtual void OnPaint( System::Windows::Forms::PaintEventArgs^ e ) override
   {
      if ( this->DesignMode )
      {
         e->Graphics->DrawString( "Right-click this control to display a list of the", gcnew System::Drawing::Font( "Arial",9 ), Brushes::Black, 5, 6 );
         e->Graphics->DrawString( "designer verb menu commands provided", gcnew System::Drawing::Font( "Arial",9 ), Brushes::Black, 5, 20 );
         e->Graphics->DrawString( "by the IUIServiceTestDesigner.", gcnew System::Drawing::Font( "Arial",9 ), Brushes::Black, 5, 34 );
      }
   }
};
//</Snippet1>
