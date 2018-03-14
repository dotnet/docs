//<Snippet1>
#using <System.Windows.Forms.dll>
#using <System.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;
using namespace System::Windows::Forms;
using namespace System::Windows::Forms::Design;

ref class ServiceObjectControl;

// Example form provides UI for demonstrating service sharing behavior
// of a network of IServiceContainer/IServiceProvider controls.
public ref class ServiceForm: public System::Windows::Forms::Form
{
private:

   // Root service container control for tree.
   ServiceObjectControl^ root;

   // Button for clearing any provided services and resetting tree states.
   System::Windows::Forms::Button^ reset_button;

   // Color list used to color code controls.
   array<Color>^colorkeys;

   // Strings used to reflect text service.
   array<String^>^keystrings;

public:
   ServiceForm()
   {
      InitializeComponent();
      CreateServiceControlTree();
      colorkeys = gcnew array<Color>(6);
      colorkeys[ 0 ] = Color::Beige;
      colorkeys[ 1 ] = Color::SeaShell;
      colorkeys[ 2 ] = Color::LightGreen;
      colorkeys[ 3 ] = Color::LightBlue;
      colorkeys[ 4 ] = Color::Khaki;
      colorkeys[ 5 ] = Color::CadetBlue;
      array<String^>^stringstemp = {"No service use","Service not accessible","Service provided",
            "Service obtained","Service accessible","No further access"};
      keystrings = stringstemp;
   }

private:
   void CreateServiceControlTree();
   void InitializeComponent();

internal:
   void ResetServiceTree( Object^ sender, EventArgs^ e );
public:
   void UpdateServiceCoverage();

protected:
   virtual void OnPaint( System::Windows::Forms::PaintEventArgs^ e ) override;
};

// Example service type contains a text string, sufficient
// to demonstrate service sharing.
public ref class TextService
{
public:
   String^ text;
   TextService()
      : text( String::Empty )
   {}

   TextService( String^ text )
   {
      this->text = text;
   }
};

public enum class TextServiceState
{
   ServiceNotObtained, ServiceObtained, ServiceProvided, ServiceNotFound
};

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
      this->ok_button->Anchor = static_cast<AnchorStyles>(System::Windows::Forms::AnchorStyles::Bottom |
            System::Windows::Forms::AnchorStyles::Right);
      this->ok_button->Location = System::Drawing::Point( 180, 43 );
      this->ok_button->Name = "ok_button";
      this->ok_button->TabIndex = 1;
      this->ok_button->Text = "OK";
      this->ok_button->DialogResult = System::Windows::Forms::DialogResult::OK;
      this->cancel_button->Anchor = static_cast<AnchorStyles>(System::Windows::Forms::AnchorStyles::Bottom |
            System::Windows::Forms::AnchorStyles::Right);
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
      this->inputTextBox->Anchor = static_cast<AnchorStyles>((System::Windows::Forms::AnchorStyles::Top |
            System::Windows::Forms::AnchorStyles::Left) | System::Windows::Forms::AnchorStyles::Right);
      this->ClientSize = System::Drawing::Size( 342, 73 );
      array<System::Windows::Forms::Control^>^temp0 = {this->inputTextBox,this->cancel_button,this->ok_button};
      this->Controls->AddRange( temp0 );
      this->MinimumSize = System::Drawing::Size( 350, 100 );
      this->Name = "StringInputDialog";
      this->Text = "Text Service Provide String Dialog";
      this->ResumeLayout( false );
   }
};


// An example user control that uses ServiceContainer to add, remove,
// and access services through a linkable service container network.
public ref class ServiceObjectControl: public System::Windows::Forms::UserControl
{
public:

   // This example user control implementation provides a wrapper for
   // ServiceContainer, supporting a linked service container network.
   ServiceContainer^ serviceContainer;

private:

   // Parent form reference for main program function access.
   ServiceForm^ parent;

public:

   // String for label displayed on the control to indicate the
   // control's current service-related configuration state.
   String^ label;

private:

   // The current state of the control reflecting whether it has
   // obtained or provided a text service.
   TextServiceState state_;

public:

   property TextServiceState state 
   {
      TextServiceState get()
      {
         return state_;
      }

      void set( TextServiceState value )
      {
         if ( (TextServiceState)value == TextServiceState::ServiceProvided )
                  this->BackColor = Color::LightGreen;
         else
         if ( (TextServiceState)value == TextServiceState::ServiceNotObtained )
                  this->BackColor = Color::White;
         else
         if ( (TextServiceState)value == TextServiceState::ServiceObtained )
                  this->BackColor = Color::LightBlue;
         else
         if ( (TextServiceState)value == TextServiceState::ServiceNotFound )
                  this->BackColor = Color::SeaShell;

         state_ = value;
      }
   }
   ServiceObjectControl( ServiceObjectControl^ serviceContainerParent, System::Drawing::Size size,
         Point location, ServiceForm^ parent )
   {
      this->state_ = TextServiceState::ServiceNotObtained;
      this->BackColor = Color::Beige;
      this->label = String::Empty;
      this->Size = size;
      this->Location = location;
      this->parent = parent;
      if ( serviceContainerParent == nullptr )
            serviceContainer = gcnew ServiceContainer;
      else
            serviceContainer = gcnew ServiceContainer( serviceContainerParent->serviceContainer );
   }

protected:

   // Paint method override draws the label string on the control.
   virtual void OnPaint( System::Windows::Forms::PaintEventArgs^ e ) override
   {
      e->Graphics->DrawString( label, gcnew System::Drawing::Font( "Arial",8 ), gcnew SolidBrush( Color::Black ), 5, 5 );
   }

   // Process mouse-down behavior for click.
   virtual void OnMouseDown( System::Windows::Forms::MouseEventArgs^ e ) override
   {
      if ( e->Button == ::MouseButtons::Left )
      {
         if ( state_ != TextServiceState::ServiceProvided )
         {
            // Attempt to update text from service, and set color
            // state accordingly.
            TextService^ ts = dynamic_cast<TextService^>(serviceContainer->GetService( TextService::typeid ));
            if ( ts != nullptr )
            {
               this->label = ts->text;
               state = TextServiceState::ServiceObtained;
            }
            else
            {
               this->label = "Service Not Found";
               state = TextServiceState::ServiceNotFound;
            }
         }
      }

      if ( e->Button == ::MouseButtons::Right )
      {
         if ( state_ == TextServiceState::ServiceProvided )
         {
            // Remove service if the container provided it.
            if ( serviceContainer->GetService( TextService::typeid ) != nullptr )
            {
               serviceContainer->RemoveService( TextService::typeid, true );
               state = TextServiceState::ServiceNotObtained;
               this->label = "Service Removed";
            }
         }
         else
         {
            // Obtain string and provide text service.
            StringInputDialog^ form = gcnew StringInputDialog( "Test String" );
            form->StartPosition = FormStartPosition::CenterParent;
            if ( form->ShowDialog() == DialogResult::OK )
            {
               if ( serviceContainer->GetService( TextService::typeid ) != nullptr )
                              serviceContainer->RemoveService( TextService::typeid, true );
               parent->ResetServiceTree( this, gcnew EventArgs );
               serviceContainer->AddService( TextService::typeid, gcnew TextService( form->inputTextBox->Text ), true );
               state = TextServiceState::ServiceProvided;
               this->label = String::Format( "Provided Text: {0}", form->inputTextBox->Text );
            }
         }
      }

      parent->UpdateServiceCoverage();
   }

public:

   // Method accesses the TextService to test the visibility of the service
   // from the control, and sets the UI state accordingly.
   void ReflectServiceVisibility()
   {
      if ( state_ == TextServiceState::ServiceObtained )
      {
         if ( serviceContainer->GetService( TextService::typeid ) == nullptr )
                  this->BackColor = Color::CadetBlue;
      }
      else
      if ( state_ != TextServiceState::ServiceProvided )
      {
         if ( serviceContainer->GetService( TextService::typeid ) == nullptr )
         {
            this->BackColor = Color::White;
            return;
         }
         
         // Service available.
         if ( state_ == TextServiceState::ServiceNotFound )
                  this->BackColor = Color::Khaki;
         else
         if ( state_ == TextServiceState::ServiceNotObtained &&  !label->Equals( "Service Removed" ) )
                  this->BackColor = Color::Khaki;
      }
   }
};

void ServiceForm::CreateServiceControlTree()
{
   // Create root service control.
   ServiceObjectControl^ control1 = gcnew ServiceObjectControl( nullptr,System::Drawing::Size( 300, 40 ),Point(10,80),this );
   root = control1;

   // Create first tier - pass parent with service object control 1
   ServiceObjectControl^ control2 = gcnew ServiceObjectControl( control1,System::Drawing::Size( 200, 30 ),Point(50,160),this );
   ServiceObjectControl^ control3 = gcnew ServiceObjectControl( control1,System::Drawing::Size( 200, 30 ),Point(50,240),this );

   // Create second tier A - pass parent with service object control 2
   ServiceObjectControl^ control4 = gcnew ServiceObjectControl( control2,System::Drawing::Size( 180, 20 ),Point(300,145),this );
   ServiceObjectControl^ control5 = gcnew ServiceObjectControl( control2,System::Drawing::Size( 180, 20 ),Point(300,185),this );

   // Create second tier B - pass parent with service object control 3
   ServiceObjectControl^ control6 = gcnew ServiceObjectControl( control3,System::Drawing::Size( 180, 20 ),Point(300,225),this );
   ServiceObjectControl^ control7 = gcnew ServiceObjectControl( control3,System::Drawing::Size( 180, 20 ),Point(300,265),this );

   // Add controls.
   array<Control^>^temp1 = {control1,control2,control3,control4,control5,control6,control7};
   this->Controls->AddRange( temp1 );
}

void ServiceForm::ResetServiceTree( Object^ /*sender*/, EventArgs^ /*e*/ )
{
   // Remove the service from the service tree.
   if ( root->serviceContainer->GetService( TextService::typeid ) != nullptr )
      root->serviceContainer->RemoveService( TextService::typeid, true );

   // Set all controls to "not obtained" and clear their labels.
   for ( int i = 0; i < Controls->Count; i++ )
      if (  !Controls[ i ]->Equals( reset_button ) )
      {
         (dynamic_cast<ServiceObjectControl^>(Controls[ i ]))->state = TextServiceState::ServiceNotObtained;
         (dynamic_cast<ServiceObjectControl^>(Controls[ i ]))->label = String::Empty;
         (dynamic_cast<ServiceObjectControl^>(Controls[ i ]))->BackColor = Color::Beige;
      }
}

void ServiceForm::UpdateServiceCoverage()
{
   // Have each control set state to reflect service availability.
   for ( int i = 0; i < Controls->Count; i++ )
      if (  !Controls[ i ]->Equals( reset_button ) )
            (dynamic_cast<ServiceObjectControl^>(Controls[ i ]))->ReflectServiceVisibility();
}

void ServiceForm::InitializeComponent()
{
   this->reset_button = gcnew System::Windows::Forms::Button;
   this->SuspendLayout();

   //
   // reset_button
   //
   this->reset_button->Location = System::Drawing::Point( 392, 88 );
   this->reset_button->Name = "reset_button";
   this->reset_button->TabIndex = 0;
   this->reset_button->TabStop = false;
   this->reset_button->Text = "Reset";
   this->reset_button->Click += gcnew System::EventHandler( this, &ServiceForm::ResetServiceTree );

   //
   // ServiceForm
   //
   this->ClientSize = System::Drawing::Size( 512, 373 );
   array<System::Windows::Forms::Control^>^temp2 = {this->reset_button};
   this->Controls->AddRange( temp2 );
   this->MinimumSize = System::Drawing::Size( 520, 400 );
   this->Name = "ServiceForm";
   this->Text = "Service Container Architecture Example";
   this->ResumeLayout( false );
}

void ServiceForm::OnPaint( System::Windows::Forms::PaintEventArgs^ e )
{
   e->Graphics->DrawString( "The following tree diagram represents a hierarchy of linked service containers in controls.",
         gcnew System::Drawing::Font( "Arial",9 ), gcnew SolidBrush( Color::Black ), 4, 4 );
   e->Graphics->DrawString( "This example demonstrates the propagation behavior of services through a linked service object tree.",
         gcnew System::Drawing::Font( "Arial",8 ), gcnew SolidBrush( Color::Black ), 4, 26 );
   e->Graphics->DrawString( "Right-click a component to add or replace a text service, or to remove it if the component provided it.",
         gcnew System::Drawing::Font( "Arial",8 ), gcnew SolidBrush( Color::Black ), 4, 38 );
   e->Graphics->DrawString( "Left-click a component to update text from the text service if available.",
         gcnew System::Drawing::Font( "Arial",8 ), gcnew SolidBrush( Color::Black ), 4, 50 );

   // Draw lines to represent tree branches.
   e->Graphics->DrawLine( gcnew Pen( gcnew SolidBrush( Color::Black ),1 ), 20, 125, 20, 258 );
   e->Graphics->DrawLine( gcnew Pen( gcnew SolidBrush( Color::Black ),1 ), 21, 175, 45, 175 );
   e->Graphics->DrawLine( gcnew Pen( gcnew SolidBrush( Color::Black ),1 ), 21, 258, 45, 258 );
   e->Graphics->DrawLine( gcnew Pen( gcnew SolidBrush( Color::Black ),1 ), 255, 175, 285, 175 );
   e->Graphics->DrawLine( gcnew Pen( gcnew SolidBrush( Color::Black ),1 ), 255, 258, 285, 258 );
   e->Graphics->DrawLine( gcnew Pen( gcnew SolidBrush( Color::Black ),1 ), 285, 155, 285, 195 );
   e->Graphics->DrawLine( gcnew Pen( gcnew SolidBrush( Color::Black ),1 ), 285, 238, 285, 278 );
   e->Graphics->DrawLine( gcnew Pen( gcnew SolidBrush( Color::Black ),1 ), 285, 155, 290, 155 );
   e->Graphics->DrawLine( gcnew Pen( gcnew SolidBrush( Color::Black ),1 ), 285, 195, 290, 195 );
   e->Graphics->DrawLine( gcnew Pen( gcnew SolidBrush( Color::Black ),1 ), 285, 238, 290, 238 );
   e->Graphics->DrawLine( gcnew Pen( gcnew SolidBrush( Color::Black ),1 ), 285, 278, 290, 278 );

   // Draw color key.
   e->Graphics->DrawRectangle( gcnew Pen( gcnew SolidBrush( Color::Black ),1 ), 20, 305, 410, 60 );
   int y = 0;
   for ( int i = 0; i < 3; i++ )
   {
      e->Graphics->FillRectangle( gcnew SolidBrush( colorkeys[ y ] ), 25 + (i * 140), 310, 20, 20 );
      e->Graphics->DrawRectangle( gcnew Pen( gcnew SolidBrush( Color::Black ),1 ), 25 + (i * 140), 310, 20, 20 );
      e->Graphics->DrawString( keystrings[ y ], gcnew System::Drawing::Font( "Arial",8 ), gcnew SolidBrush( Color::Black ),
            (float)50 + (i * 140), 315 );
      y++;
      e->Graphics->FillRectangle( gcnew SolidBrush( colorkeys[ y ] ), 25 + (i * 140), 340, 20, 20 );
      e->Graphics->DrawRectangle( gcnew Pen( gcnew SolidBrush( Color::Black ),1 ), 25 + (i * 140), 340, 20, 20 );
      e->Graphics->DrawString( keystrings[ y ], gcnew System::Drawing::Font( "Arial",8 ), gcnew SolidBrush( Color::Black ),
            (float)50 + (i * 140), 345 );
      y++;
   }
}

[STAThread]
int main()
{
   Application::Run( gcnew ServiceForm );
}
//</Snippet1>
