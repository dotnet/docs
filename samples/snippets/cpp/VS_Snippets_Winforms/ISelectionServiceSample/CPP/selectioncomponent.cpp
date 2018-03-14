

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

/*  This sample demonstrates using the ISelectionService
interface to receive notification of selection change events.  
The SelectionComponent control attempts to retrieve an instance 
of the ISelectionService when it is sited. If it can, it attaches 
event handlers for events provided by the service that display
a message when a component is selected or deselected.

To run this sample, add the SelectionComponent control to a Form and
then select or deselect components in design mode to see the behavior 
of the component change event handlers. */
namespace ISelectionServiceExample
{
   public ref class SelectionComponent: public System::Windows::Forms::UserControl
   {
   private:
      System::Windows::Forms::TextBox^ tbox1;
      ISelectionService^ selectionService;

   public:
      SelectionComponent()
      {
         // Initialize control
         this->SuspendLayout();
         this->Name = "SelectionComponent";
         this->Size = System::Drawing::Size( 608, 296 );
         this->tbox1 = gcnew System::Windows::Forms::TextBox;
         this->tbox1->Location = System::Drawing::Point( 24, 16 );
         this->tbox1->Name = "listBox1";
         this->tbox1->Multiline = true;
         this->tbox1->Size = System::Drawing::Size( 560, 251 );
         this->tbox1->TabIndex = 0;
         this->Controls->Add( this->tbox1 );
         this->ResumeLayout();
      }

      property ISite^ Site 
      {
         virtual ISite^ get() override
         {
            return __super::Site;
         }

         virtual void set( ISite^ value ) override
         {
            // The ISelectionService is available in design mode 
            // only, and only after the component is sited.
            if ( selectionService != nullptr )
            {
               // Because the selection service has been 
               // previously obtained, the component may be in 
               // the process of being resited. 
               // Detatch the previous selection change event 
               // handlers in case the new selection
               // service is a new service instance belonging to 
               // another design mode service host.
               selectionService->SelectionChanged -= gcnew EventHandler( this, &SelectionComponent::OnSelectionChanged );
               selectionService->SelectionChanging -= gcnew EventHandler( this, &SelectionComponent::OnSelectionChanging );
            }

            // Establish the new site for the component.
            __super::Site = value;
            if ( __super::Site == nullptr )
                        return;

            // The selection service is not available outside of 
            // design mode. A call requesting the service 
            // using GetService while not in design mode will 
            // return null.
            selectionService = dynamic_cast<ISelectionService^>(this->Site->GetService( ISelectionService::typeid ));

            // If an instance of the ISelectionService was obtained, 
            // attach event handlers for the selection 
            // changing and selection changed events.
            if ( selectionService != nullptr )
            {
               // Add an event handler for the SelectionChanging 
               // and SelectionChanged events.
               selectionService->SelectionChanging += gcnew EventHandler( this, &SelectionComponent::OnSelectionChanging );
               selectionService->SelectionChanged += gcnew EventHandler( this, &SelectionComponent::OnSelectionChanged );
            }
         }
      }

   private:
      void OnSelectionChanged( Object^ /*sender*/, EventArgs^ /*args*/ )
      {
         tbox1->AppendText( String::Format( "The selected component was changed.  Selected components:\r\n    {0}\r\n", GetSelectedComponents() ) );
      }

      void OnSelectionChanging( Object^ /*sender*/, EventArgs^ /*args*/ )
      {
         tbox1->AppendText( String::Format( "The selected component is changing. Selected components:\r\n    {0}\r\n", GetSelectedComponents() ) );
      }

      String^ GetSelectedComponents()
      {
         String^ selectedString = String::Empty;
         array<Object^>^components = gcnew array<Object^>((dynamic_cast<ICollection^>(selectionService->GetSelectedComponents()))->Count);
         (dynamic_cast<ICollection^>(selectionService->GetSelectedComponents()))->CopyTo( components, 0 );
         for ( int i = 0; i < components->Length; i++ )
         {
            if ( i != 0 )
                        selectedString = selectedString + "&& ";

            if ( (dynamic_cast<IComponent^>(selectionService->PrimarySelection)) == (dynamic_cast<IComponent^>(components[ i ])) )
                        selectedString = selectedString + "PrimarySelection:";

            selectedString = selectedString + (dynamic_cast<IComponent^>(components[ i ]))->Site->Name + " ";

         }
         return selectedString;
      }

      // Clean up any resources being used.
   public:
      ~SelectionComponent()
      {
         // Detach the event handlers for the selection service.
         if ( selectionService != nullptr )
         {
            selectionService->SelectionChanging -= gcnew EventHandler( this, &SelectionComponent::OnSelectionChanging );
            selectionService->SelectionChanged -= gcnew EventHandler( this, &SelectionComponent::OnSelectionChanged );
         }
      }
   };
}
//</Snippet1>
