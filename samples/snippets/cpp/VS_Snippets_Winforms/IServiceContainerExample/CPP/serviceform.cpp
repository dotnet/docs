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

// This sample contains a Form class that is configured to demonstrate 
// the behavior of a network of linked service containers.   
// Notes regarding this IServiceContainer and IServiceProvider 
// implementation:
//
// When implementing the IServiceContainer interface, you may want to 
// implement support for a linked service container system
// which enables access to and sharing of services throughout a 
// container tree or network.
//
// To effectively share a service, a GetService, AddService or 
// RemoveService method must be able to locate a service 
// that has been added to a shared service container tree or network.
//        
// One simple approach to sharing services, suitable for container networks 
// where each container has one parent and the tree has
// one parentless container, is to store services only at the top node 
// (the root or grandparent) of a tree.
//
// To store services in the root node of a tree, two types of 
// consistencies must be maintained in the implementation:        
//
//   >   The GetService, AddService and RemoveService implementations 
//       must access the root through some mechanism.
//         The ServiceContainerControl's implementations of these 
//         standard IServiceContainer methods call 
//         the same method of a parent container, if the container 
//         has been parented, to route methods to the root.  
//
//   >   The services must be maintained at the root of the tree; 
//       therefore, any new child's services should be copied to the root.                
ref class ServiceForm;

// forward declaration
public enum class TextServiceState
{
   ServiceNotObtained, ServiceObtained, ServiceProvided, ServiceNotFound
};

// Example service type contains a text string, sufficient to 
// demonstrate service sharing.
public ref class TextService
{
public:
   String^ text;
   TextService()
   {
      this->text = String::Empty;
   }

   TextService( String^ text )
   {
      this->text = text;
   }
};

// ServiceContainerControl provides an example user control implmentation 
// of the IServiceContainer interface. This implementation of 
// IServiceContainer supports a root-node linked service distribution, 
// access. and removal architecture.
public ref class ServiceContainerControl: public System::Windows::Forms::UserControl, public IServiceContainer
{
private:

   // List of service instances sorted by key of service type's full name.
   SortedList^ localServices;

   // List that contains the Type for each service sorted by each 
   // service type's full name.
   SortedList^ localServiceTypes;

   // The parent IServiceContainer, or null.
   IServiceContainer^ parentServiceContainer;

public:

   property IServiceContainer^ serviceParent 
   {
      IServiceContainer^ get()
      {
         return parentServiceContainer;
      }

      void set( IServiceContainer^ value )
      {
         parentServiceContainer = value;

         // Move any services to parent.
         for ( int i = 0; i < localServices->Count; i++ )
            parentServiceContainer->AddService( dynamic_cast<Type^>(localServiceTypes->GetByIndex( i )), localServices->GetByIndex( i ) );
         localServices->Clear();
         localServiceTypes->Clear();
      }
   }

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

private:

   // Parent form reference for main program function access.
   ServiceForm^ parent;

public:

   // String for label displayed on the control to indicate 
   // the control's current service-related configuration state.
   String^ label;
   ServiceContainerControl( IServiceContainer^ ParentServiceContainer, System::Drawing::Size size, Point location, ServiceForm^ parent )
   {
      this->state_ = TextServiceState::ServiceNotObtained;
      localServices = gcnew SortedList;
      localServiceTypes = gcnew SortedList;
      this->BackColor = Color::Beige;
      this->label = String::Empty;
      this->Size = size;
      this->Location = location;
      this->parent = parent;
      this->serviceParent = ParentServiceContainer;

      // If a parent is specified, set the parent property of this 
      // linkable IServiceContainer implementation.
      if ( ParentServiceContainer != nullptr )
            serviceParent = ParentServiceContainer;
   }

   // IServiceProvider.GetService implementation for a linked 
   // service container architecture.
   virtual Object^ GetService( System::Type^ serviceType ) override
   {
      if ( parentServiceContainer != nullptr )
            return parentServiceContainer->GetService( serviceType );

      Object^ serviceInstance = localServices[ serviceType->FullName ];
      if ( serviceInstance == nullptr )
            return nullptr;
      else
      if ( serviceInstance->GetType() == ServiceCreatorCallback::typeid )
      {
         // If service instance is a ServiceCreatorCallback, invoke 
         // it to create the service.
         return (dynamic_cast<ServiceCreatorCallback^>(serviceInstance));
         (this,serviceType);
      }

      return serviceInstance;
   }

   // IServiceContainer.AddService implementation for a linked 
   // service container architecture.
   virtual void AddService( System::Type^ serviceType, System::ComponentModel::Design::ServiceCreatorCallback^ callback, bool promote )
   {
      if ( promote && parentServiceContainer != nullptr )
            parentServiceContainer->AddService( serviceType, callback, true );
      else
      {
         localServiceTypes[ serviceType->FullName ] = serviceType;
         localServices[ serviceType->FullName ] = callback;
      }
   }

   // IServiceContainer.AddService implementation for a linked 
   // service container architecture.
   virtual void AddService( System::Type^ serviceType, System::ComponentModel::Design::ServiceCreatorCallback^ callback )
   {
      AddService( serviceType, callback, true );
   }

   // IServiceContainer.AddService implementation for a linked 
   // service container architecture.
   virtual void AddService( System::Type^ serviceType, Object^ serviceInstance, bool promote )
   {
      if ( promote && parentServiceContainer != nullptr )
            parentServiceContainer->AddService( serviceType, serviceInstance, true );
      else
      {
         localServiceTypes[ serviceType->FullName ] = serviceType;
         localServices[ serviceType->FullName ] = serviceInstance;
      }
   }

   // IServiceContainer.AddService (defaults to promote service addition).
   virtual void AddService( System::Type^ serviceType, Object^ serviceInstance )
   {
      AddService( serviceType, serviceInstance, true );
   }

   // IServiceContainer.RemoveService implementation for a linked 
   // service container architecture.
   virtual void RemoveService( System::Type^ serviceType, bool promote )
   {
      if ( localServices[ serviceType->FullName ] != nullptr )
      {
         localServices->Remove( serviceType->FullName );
         localServiceTypes->Remove( serviceType->FullName );
      }

      if ( promote )
      {
         if ( parentServiceContainer != nullptr )
                  parentServiceContainer->RemoveService( serviceType );
      }
   }

   // IServiceContainer.RemoveService (defaults to promote 
   // service removal)
   virtual void RemoveService( System::Type^ serviceType )
   {
      RemoveService( serviceType, true );
   }

protected:

   // Paint method override draws the label string on the control.
   virtual void OnPaint( System::Windows::Forms::PaintEventArgs^ e ) override
   {
      e->Graphics->DrawString( label, gcnew System::Drawing::Font( "Arial",8 ), gcnew SolidBrush( Color::Black ), 5, 5 );
   }

   // Process mouse-down behavior for click.
   virtual void OnMouseDown( System::Windows::Forms::MouseEventArgs^ e ) override;

public:

   // Method accesses the TextService to test the visibility of the 
   // service from the control, and sets the UI state accordingly.
   void ReflectServiceVisibility()
   {
      if ( state_ == TextServiceState::ServiceObtained )
      {
         if ( GetService( TextService::typeid ) == nullptr )
                  this->BackColor = Color::CadetBlue;
      }
      else
      if ( state_ != TextServiceState::ServiceProvided )
      {
         if ( GetService( TextService::typeid ) == nullptr )
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

private:

   // ServiceCreatorCallback method creates a text service.
   Object^ CreateTextService( IServiceContainer^ /*container*/, System::Type^ /*serviceType*/ )
   {
      return gcnew TextService( "Test Callback" );
   }
};

// Example form provides UI for demonstrating service sharing behavior 
// of a network of IServiceContainer/IServiceProvider controls.
public ref class ServiceForm: public System::Windows::Forms::Form
{
private:

   // Root service container control for tree.
   ServiceContainerControl^ root;

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
      colorkeys = gcnew array<Color>(6);
      colorkeys[ 0 ] = Color::Beige;
      colorkeys[ 1 ] = Color::SeaShell;
      colorkeys[ 2 ] = Color::LightGreen;
      colorkeys[ 3 ] = Color::LightBlue;
      colorkeys[ 4 ] = Color::Khaki;
      colorkeys[ 5 ] = Color::CadetBlue;
      array<String^>^temp3 = {"No service use","Service not accessible","Service provided","Service obtained","Service accessible","No further access"};
      keystrings = temp3;
      CreateServiceControlTree();
   }

private:
   void CreateServiceControlTree()
   {
      // Create root service control
      ServiceContainerControl^ control1 = gcnew ServiceContainerControl( nullptr,System::Drawing::Size( 300, 40 ),Point(10,80),this );
      root = control1;

      // Create first tier - pass parent with service object control 1.
      ServiceContainerControl^ control2 = gcnew ServiceContainerControl( control1,System::Drawing::Size( 200, 30 ),Point(50,160),this );
      ServiceContainerControl^ control3 = gcnew ServiceContainerControl( control1,System::Drawing::Size( 200, 30 ),Point(50,240),this );

      // Create second tier A - pass parent with service object control 2.
      ServiceContainerControl^ control4 = gcnew ServiceContainerControl( control2,System::Drawing::Size( 180, 20 ),Point(300,145),this );
      ServiceContainerControl^ control5 = gcnew ServiceContainerControl( control2,System::Drawing::Size( 180, 20 ),Point(300,185),this );

      // Create second tier B - pass parent with service object control 3.
      ServiceContainerControl^ control6 = gcnew ServiceContainerControl( control3,System::Drawing::Size( 180, 20 ),Point(300,225),this );
      ServiceContainerControl^ control7 = gcnew ServiceContainerControl( control3,System::Drawing::Size( 180, 20 ),Point(300,265),this );

      // Add controls
      array<Control^>^temp0 = {control1,control2,control3,control4,control5,control6,control7};
      this->Controls->AddRange( temp0 );
   }

internal:
   void ResetServiceTree( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // Remove the service from the service tree.
      if ( root->GetService( TextService::typeid ) != nullptr )
            root->RemoveService( TextService::typeid, true );

      // Set all controls to "not obtained" and clear their labels.
      for ( int i = 0; i < Controls->Count; i++ )
         if (  !Controls[ i ]->Equals( reset_button ) )
         {
            (dynamic_cast<ServiceContainerControl^>(Controls[ i ]))->state = TextServiceState::ServiceNotObtained;
            (dynamic_cast<ServiceContainerControl^>(Controls[ i ]))->label = String::Empty;
            (dynamic_cast<ServiceContainerControl^>(Controls[ i ]))->BackColor = Color::Beige;
         }
   }

public:
   void UpdateServiceCoverage()
   {
      // Have each control set state to reflect service availability.
      for ( int i = 0; i < Controls->Count; i++ )
         if (  !Controls[ i ]->Equals( reset_button ) )
                  (dynamic_cast<ServiceContainerControl^>(Controls[ i ]))->ReflectServiceVisibility();
   }

private:
   void InitializeComponent()
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
      array<System::Windows::Forms::Control^>^temp1 = {this->reset_button};
      this->Controls->AddRange( temp1 );
      this->MinimumSize = System::Drawing::Size( 520, 400 );
      this->Name = "ServiceForm";
      this->Text = "Service Container Architecture Example";
      this->ResumeLayout( false );
   }

protected:
   virtual void OnPaint( System::Windows::Forms::PaintEventArgs^ e ) override
   {
      e->Graphics->DrawString( "The following tree diagram represents a "
      "hierarchy of linked service containers in controls.", gcnew System::Drawing::Font( "Arial",9 ), gcnew SolidBrush( Color::Black ), 4, 4 );
      e->Graphics->DrawString( "This example demonstrates the propagation "
      "behavior of services through a linked service object tree.", gcnew System::Drawing::Font( "Arial",8 ), gcnew SolidBrush( Color::Black ), 4, 26 );
      e->Graphics->DrawString( "Right-click a component to add or replace a "
      "text service, or to remove it if the component provided it.", gcnew System::Drawing::Font( "Arial",8 ), gcnew SolidBrush( Color::Black ), 4, 38 );
      e->Graphics->DrawString( "Left-click a component to update text from "
      "the text service if available.", gcnew System::Drawing::Font( "Arial",8 ), gcnew SolidBrush( Color::Black ), 4, 50 );

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
         e->Graphics->DrawString( keystrings[ y ], gcnew System::Drawing::Font( "Arial",8 ), gcnew SolidBrush( Color::Black ), 50.0f + (i * 140), 315.0f );
         y++;
         e->Graphics->FillRectangle( gcnew SolidBrush( colorkeys[ y ] ), 25 + (i * 140), 340, 20, 20 );
         e->Graphics->DrawRectangle( gcnew Pen( gcnew SolidBrush( Color::Black ),1 ), 25 + (i * 140), 340, 20, 20 );
         e->Graphics->DrawString( keystrings[ y ], gcnew System::Drawing::Font( "Arial",8 ), gcnew SolidBrush( Color::Black ), 50.0f + (i * 140), 345.0f );
         y++;

      }
   }
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
      this->ok_button->Anchor = static_cast<System::Windows::Forms::AnchorStyles>(System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Right);
      this->ok_button->Location = System::Drawing::Point( 180, 43 );
      this->ok_button->Name = "ok_button";
      this->ok_button->TabIndex = 1;
      this->ok_button->Text = "OK";
      this->ok_button->DialogResult = System::Windows::Forms::DialogResult::OK;
      this->cancel_button->Anchor = static_cast<System::Windows::Forms::AnchorStyles>(System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Right);
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
      this->inputTextBox->Anchor = static_cast<System::Windows::Forms::AnchorStyles>(System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Left | System::Windows::Forms::AnchorStyles::Right);
      this->ClientSize = System::Drawing::Size( 342, 73 );
      array<System::Windows::Forms::Control^>^temp4 = {this->inputTextBox,this->cancel_button,this->ok_button};
      this->Controls->AddRange( temp4 );
      this->MinimumSize = System::Drawing::Size( 350, 100 );
      this->Name = "StringInputDialog";
      this->Text = "Text Service Provide String Dialog";
      this->ResumeLayout( false );
   }
};

void ServiceContainerControl::OnMouseDown( System::Windows::Forms::MouseEventArgs^ e )
{
   //  This example control responds to mouse clicks as follows:
   //
   //      Left click - control attempts to obtain a text service 
   //      and sets its label text to the text provided by the service
   //      Right click - if the control has already provided a text 
   //      service, this control does nothing. Otherwise, the control 
   //      shows a dialog box to specify text to provide as a new text 
   //      service, after clearing the tree's services.
   if ( e->Button == ::MouseButtons::Left )
   {
      if ( state_ != TextServiceState::ServiceProvided )
      {
         // Attempt to update text from service, and set 
         // color state accordingly.
         TextService^ ts = dynamic_cast<TextService^>(GetService( TextService::typeid ));
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
         // Remove the service if the container provided it.
         if ( GetService( TextService::typeid ) != nullptr )
         {
            RemoveService( TextService::typeid, true );
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
            if ( GetService( TextService::typeid ) != nullptr )
                        RemoveService( TextService::typeid, true );
            parent->ResetServiceTree( this, gcnew EventArgs );
            AddService( TextService::typeid, gcnew TextService( form->inputTextBox->Text ), true );

            // The following commented method uses a service creator callback.
            // AddService(typeof(TextService), 
            //  new ServiceCreatorCallback(this.CreateTextService));                                                
            state = TextServiceState::ServiceProvided;
            this->label = String::Format( "Provided Text: {0}", form->inputTextBox->Text );
         }
      }
   }

   parent->UpdateServiceCoverage();
}

[STAThread]
int main()
{
   Application::Run( gcnew ServiceForm );
}
//</Snippet1>
