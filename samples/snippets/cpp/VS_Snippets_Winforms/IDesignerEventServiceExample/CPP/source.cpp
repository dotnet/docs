//<Snippet1>
#using <system.dll>
#using <system.design.dll>
#using <system.windows.forms.dll>
#using <system.drawing.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;
using namespace System::Collections;
using namespace System::Drawing;
using namespace System::Windows::Forms;
using namespace System::Windows::Forms::Design;

namespace DesignerEventServiceExample
{
   ref class DesignerMonitorDesigner;

   // DesignerMonitor provides a display for designer event notifications.

   [Designer(DesignerEventServiceExample::DesignerMonitorDesigner::typeid)]
   public ref class DesignerMonitor: public UserControl
   {
   public:

      // List to contain strings that describe designer events.
      ArrayList^ updates;
      bool monitoring_events;
      DesignerMonitor()
      {
         monitoring_events = false;
         updates = gcnew ArrayList;
         this->BackColor = Color::White;
         this->Size = System::Drawing::Size( 450, 300 );
      }

   protected:

      // Display the message for the current mode, and any event messages if event monitoring is active.
      virtual void OnPaint( PaintEventArgs^ e ) override
      {
         e->Graphics->DrawString( "IDesignerEventService DesignerMonitor Control", gcnew System::Drawing::Font( FontFamily::GenericMonospace,10 ), gcnew SolidBrush( Color::Blue ), 5, 4 );
         int yoffset = 10;
         if (  !monitoring_events )
         {
            yoffset += 10;
            e->Graphics->DrawString( "Currently not monitoring designer events.", gcnew System::Drawing::Font( FontFamily::GenericMonospace,10 ), gcnew SolidBrush( Color::Black ), 5.f, yoffset + 10.f );
            e->Graphics->DrawString( "Use the shortcut menu commands", gcnew System::Drawing::Font( FontFamily::GenericMonospace,10 ), gcnew SolidBrush( Color::Black ), 5.f, yoffset + 30.f );
            e->Graphics->DrawString( "provided by an associated DesignerMonitorDesigner", gcnew System::Drawing::Font( FontFamily::GenericMonospace,10 ), gcnew SolidBrush( Color::Black ), 5.f, yoffset + 40.f );
            e->Graphics->DrawString( "to start or stop monitoring.", gcnew System::Drawing::Font( FontFamily::GenericMonospace,10 ), gcnew SolidBrush( Color::Black ), 5.f, yoffset + 50.f );
         }
         else
         {
            e->Graphics->DrawString( "Currently monitoring designer events.", gcnew System::Drawing::Font( FontFamily::GenericMonospace,10 ), gcnew SolidBrush( Color::DarkBlue ), 5.f, yoffset + 10.f );
            e->Graphics->DrawString( "Designer created, changed and disposed events:", gcnew System::Drawing::Font( FontFamily::GenericMonospace,9 ), gcnew SolidBrush( Color::Brown ), 5.f, yoffset + 35.f );
            for ( int i = 0; i < updates->Count; i++ )
            {
               e->Graphics->DrawString( static_cast<String^>(updates[ i ]), gcnew System::Drawing::Font( FontFamily::GenericMonospace,8 ), gcnew SolidBrush( Color::Black ), 5.f, yoffset + 55.f + (10 * i) );
               yoffset += 10;
            }
         }
      }
   };

   // DesignerMonitorDesigner uses the IDesignerEventService to send event information
   // to an associated DesignerMonitor control's updates collection.
   public ref class DesignerMonitorDesigner: public ControlDesigner
   {
   private:
      DesignerMonitor^ dm;
      DesignerVerbCollection^ dvc;
      int eventcount;
      void StopMonitoring( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         IDesignerEventService^ des = dynamic_cast<IDesignerEventService^>(this->Control->Site->GetService( IDesignerEventService::typeid ));
         if ( des != nullptr )
         {
            // Remove event handlers for event notification methods.
            des->DesignerCreated -= gcnew DesignerEventHandler( this, &DesignerMonitorDesigner::DesignerCreated );
            des->DesignerDisposed -= gcnew DesignerEventHandler( this, &DesignerMonitorDesigner::DesignerDisposed );
            des->ActiveDesignerChanged -= gcnew ActiveDesignerEventHandler( this, &DesignerMonitorDesigner::DesignerChanged );
            des->SelectionChanged -= gcnew EventHandler( this, &DesignerMonitorDesigner::SelectionChanged );
            dm->monitoring_events = false;

            // Rebuild menu with "Start monitoring" command.
            array<DesignerVerb^>^myArray = {gcnew DesignerVerb( "Start monitoring",gcnew EventHandler( this, &DesignerMonitorDesigner::StartMonitoring ) )};
            dvc = gcnew DesignerVerbCollection( myArray );
            dm->Refresh();
         }
      }

      void StartMonitoring( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         IDesignerEventService^ des = dynamic_cast<IDesignerEventService^>(this->Control->Site->GetService( IDesignerEventService::typeid ));
         if ( des != nullptr )
         {
            // Add event handlers for event notification methods.
            des->DesignerCreated += gcnew DesignerEventHandler( this, &DesignerMonitorDesigner::DesignerCreated );
            des->DesignerDisposed += gcnew DesignerEventHandler( this, &DesignerMonitorDesigner::DesignerDisposed );
            des->ActiveDesignerChanged += gcnew ActiveDesignerEventHandler( this, &DesignerMonitorDesigner::DesignerChanged );
            des->SelectionChanged += gcnew EventHandler( this, &DesignerMonitorDesigner::SelectionChanged );
            dm->monitoring_events = false;

            // Rebuild menu with "Stop monitoring" command.
            array<DesignerVerb^>^myArray = {gcnew DesignerVerb( "Stop monitoring",gcnew EventHandler( this, &DesignerMonitorDesigner::StopMonitoring ) )};
            dvc = gcnew DesignerVerbCollection( myArray );
            dm->Refresh();
         }
      }

      void DesignerCreated( Object^ /*sender*/, DesignerEventArgs^ e )
      {
         UpdateStatus( "Designer for " + e->Designer->RootComponent->Site->Name + " was created." );
      }

      void DesignerDisposed( Object^ /*sender*/, DesignerEventArgs^ e )
      {
         UpdateStatus( "Designer for " + e->Designer->RootComponent->Site->Name + " was disposed." );
      }

      void DesignerChanged( Object^ /*sender*/, ActiveDesignerEventArgs^ e )
      {
         UpdateStatus( "Active designer moved from " + e->OldDesigner->RootComponent->Site->Name + " to " + e->NewDesigner->RootComponent->Site->Name + "." );
      }

      void SelectionChanged( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         UpdateStatus("A component selection was changed.");
      }

      // Update message buffer on DesignerMonitor control.
      void UpdateStatus( String^ newmsg )
      {
         if ( dm->updates->Count > 10 )
                  dm->updates->RemoveAt( 10 );

         dm->updates->Insert( 0, "Event #" + eventcount.ToString() + ": " + newmsg );
         eventcount++;
         dm->Refresh();
      }
   };
}
//</Snippet1>
