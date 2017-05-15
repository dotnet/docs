//<Snippet1>
#using <System.Windows.Forms.dll>
#using <System.Data.dll>
#using <System.Drawing.dll>
#using <System.Design.dll>
#using <System.dll>

using namespace System;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;
using namespace System::Drawing;
using namespace System::Data;
using namespace System::Windows::Forms;
using namespace System::Windows::Forms::Design;
using namespace System::Security::Permissions;

// This designer provides a "Connect testEvent" designer verb shortcut 
// menu command. When invoked, the command attaches a new event-handler 
// method named "testEventHandler" to the "testEvent" event of an 
// associated control.
// If a "testEvent" event of the associated control does not exist, 
// the IEventBindingService declares it.
public ref class EventDesigner: public System::Windows::Forms::Design::ControlDesigner
{
public:
   EventDesigner(){}

   // When the "Connect testEvent" designer verb shortcut menu 
   // command is invoked, this method uses the 
   // IEventBindingService to attach an event handler to a 
   // "textEvent" event of the associated control.
private:
   void ConnectEvent( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      IEventBindingService^ eventservice = dynamic_cast<IEventBindingService^>(this->Component->Site->GetService( System::ComponentModel::Design::IEventBindingService::typeid ));
      if ( eventservice != nullptr )
      {
         // Attempt to obtain a PropertyDescriptor for a 
         // component event named "testEvent".
         EventDescriptorCollection^ edc = TypeDescriptor::GetEvents( this->Component );
         if ( edc == nullptr || edc->Count == 0 )
                  return;
         EventDescriptor^ ed = nullptr;

         // Search for an event named "testEvent".
         IEnumerator^ myEnum = edc->GetEnumerator();
         while ( myEnum->MoveNext() )
         {
            EventDescriptor^ edi = safe_cast<EventDescriptor^>(myEnum->Current);
            if ( edi->Name->Equals( "testEvent" ) )
            {
               ed = edi;
               break;
            }
         }
         if ( ed == nullptr )
                  return;

         // Use the IEventBindingService to get a 
         // PropertyDescriptor for the event.
         PropertyDescriptor^ pd = eventservice->GetEventProperty( ed );
         if ( pd == nullptr )
                  return;

         // Set the value of the event to "testEventHandler".
         pd->SetValue( this->Component, "testEventHandler" );
      }
   }

public:
   property System::ComponentModel::Design::DesignerVerbCollection^ Verbs 
   {
      // Provides a designer verb command for the designer's 
      // shortcut menu.
      [PermissionSetAttribute(SecurityAction::Demand, Name="FullTrust")]
      virtual System::ComponentModel::Design::DesignerVerbCollection^ get() override
      {
         DesignerVerbCollection^ dvc = gcnew DesignerVerbCollection;
         dvc->Add( gcnew DesignerVerb( "Connect testEvent",gcnew EventHandler( this, &EventDesigner::ConnectEvent ) ) );
         return dvc;
      }
   }
};

// EventControl is associated with the EventDesigner and displays 
// instructions for demonstrating the service.

[Designer(EventDesigner::typeid)]
public ref class EventControl: public System::Windows::Forms::UserControl
{
public:
   event System::EventHandler^ testEvent;
   EventControl()
   {
      this->BackColor = Color::White;
      this->Size = System::Drawing::Size( 320, 96 );
   }

public:
   ~EventControl()
   {
   }

protected:
   virtual void OnPaint( System::Windows::Forms::PaintEventArgs^ e ) override
   {
      e->Graphics->DrawString( "IEventBindingService Example Control", gcnew System::Drawing::Font( FontFamily::GenericMonospace,10 ), gcnew SolidBrush( Color::Blue ), 5, 5 );
      e->Graphics->DrawString( "Use the \"Connect testEvent\" command of the", gcnew System::Drawing::Font( FontFamily::GenericMonospace,8 ), gcnew SolidBrush( Color::Black ), 5, 22 );
      e->Graphics->DrawString( "right-click shortcut menu provided by this", gcnew System::Drawing::Font( FontFamily::GenericMonospace,8 ), gcnew SolidBrush( Color::Black ), 5, 32 );
      e->Graphics->DrawString( "control's associated EventDesigner to create", gcnew System::Drawing::Font( FontFamily::GenericMonospace,8 ), gcnew SolidBrush( Color::Black ), 5, 42 );
      e->Graphics->DrawString( "a new event handler linked with the testEvent", gcnew System::Drawing::Font( FontFamily::GenericMonospace,8 ), gcnew SolidBrush( Color::Black ), 5, 52 );
      e->Graphics->DrawString( "of this control in the initialization code", gcnew System::Drawing::Font( FontFamily::GenericMonospace,8 ), gcnew SolidBrush( Color::Black ), 5, 62 );
      e->Graphics->DrawString( "for this control.", gcnew System::Drawing::Font( FontFamily::GenericMonospace,8 ), gcnew SolidBrush( Color::Black ), 5, 72 );
   }
};
//</Snippet1>
