

//<Snippet1>
#using <System.Windows.Forms.dll>
#using <System.Data.dll>
#using <System.Drawing.dll>
#using <System.dll>

using namespace System;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;
using namespace System::Drawing;
using namespace System::Data;
using namespace System::Windows::Forms;

// This control displays the name and type of the primary selection 
// component in design mode, if there is one,
// and uses the IReferenceService interface to display the names of 
// any components of the type of the primary selected component.    
// This control uses the IComponentChangeService to monitor for 
// selection changed events.
public ref class IReferenceServiceControl: public System::Windows::Forms::UserControl
{
private:

   // Indicates the name of the type of the selected component, or "None selected.".
   String^ selected_typename;

   // Indicates the name of the base type of the selected component, or "None selected."
   String^ selected_basetypename;

   // Indicates the name of the selected component.
   String^ selected_componentname;

   // Contains the names of components of the type of the selected 
   // component in design mode.
   array<String^>^typeComponents;

   // Contains the names of components of the base type of the selected component in design mode.
   array<String^>^basetypeComponents;

   // Reference to the IComponentChangeService for the current component.
   ISelectionService^ selectionService;

public:
   IReferenceServiceControl()
   {
      // Initializes the control properties.
      this->BackColor = Color::White;
      this->SetStyle( ControlStyles::ResizeRedraw, true );
      this->Name = "IReferenceServiceControl";
      this->Size = System::Drawing::Size( 500, 250 );

      // Initializes the data properties.
      typeComponents = gcnew array<String^>(0);
      basetypeComponents = gcnew array<String^>(0);
      selected_typename = "None selected.";
      selected_basetypename = "None selected.";
      selected_componentname = "None selected.";
      selectionService = nullptr;
   }


   property System::ComponentModel::ISite^ Site 
   {
      // Registers and unregisters design-mode services when 
      // the component is sited and unsited.
      virtual System::ComponentModel::ISite^ get() override
      {
         // Returns the site for the control.
         return __super::Site;
      }

      virtual void set( System::ComponentModel::ISite^ value ) override
      {
         // The site is set to null when a component is cut or 
         // removed from a design-mode site.
         // If an event handler has already been linked with 
         // an ISelectionService, remove the handler.
         if ( selectionService != nullptr )
                  selectionService->SelectionChanged -= gcnew EventHandler( this, &IReferenceServiceControl::OnSelectionChanged );

         // Sites the control.
         __super::Site = value;

         // Obtains an ISelectionService interface to register 
         // the selection changed event handler with.
         selectionService = dynamic_cast<ISelectionService^>(this->GetService( ISelectionService::typeid ));
         if ( selectionService != nullptr )
         {
            selectionService->SelectionChanged += gcnew EventHandler( this, &IReferenceServiceControl::OnSelectionChanged );

            // Updates the display for the current selection, if any.
            DisplayComponentsOfSelectedComponentType();
         }
      }
   }

private:

   // Updates the display according to the primary selected component, 
   // if any, and the names of design-mode components that the 
   // IReferenceService returns references for when queried for 
   // references to components of the primary selected component's 
   // type and base type.
   void DisplayComponentsOfSelectedComponentType()
   {
      // If a component is selected...
      if ( selectionService->PrimarySelection != nullptr )
      {
         // Sets the selected type name and selected component name to the type and name of the primary selected component.
         selected_typename = selectionService->PrimarySelection->GetType()->FullName;
         selected_basetypename = selectionService->PrimarySelection->GetType()->BaseType->FullName;
         selected_componentname = (dynamic_cast<IComponent^>(selectionService->PrimarySelection))->Site->Name;

         // Obtain an IReferenceService and obtain references to 
         // each component in the design-mode project
         // of the selected component's type and base type.
         IReferenceService^ rs = dynamic_cast<IReferenceService^>(this->GetService( IReferenceService::typeid ));
         if ( rs != nullptr )
         {
            // Get references to design-mode components of the 
            // primary selected component's type.
            array<Object^>^comps = (array<Object^>^)rs->GetReferences( selectionService->PrimarySelection->GetType() );
            typeComponents = gcnew array<String^>(comps->Length);
            for ( int i = 0; i < comps->Length; i++ )
               typeComponents[ i ] = (dynamic_cast<IComponent^>(comps[ i ]))->Site->Name;

            // Get references to design-mode components with a base type 
            // of the primary selected component's base type.
            comps = (array<Object^>^)rs->GetReferences( selectionService->PrimarySelection->GetType()->BaseType );
            basetypeComponents = gcnew array<String^>(comps->Length);
            for ( int i = 0; i < comps->Length; i++ )
               basetypeComponents[ i ] = (dynamic_cast<IComponent^>(comps[ i ]))->Site->Name;
         }
      }
      else
      {
         selected_typename = "None selected.";
         selected_basetypename = "None selected.";
         selected_componentname = "None selected.";
         typeComponents = gcnew array<String^>(0);
         basetypeComponents = gcnew array<String^>(0);
      }

      this->Refresh();
   }

   void OnSelectionChanged( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      DisplayComponentsOfSelectedComponentType();
   }


protected:
   virtual void OnPaint( System::Windows::Forms::PaintEventArgs^ e ) override
   {
      e->Graphics->DrawString( "IReferenceService Example Control", gcnew System::Drawing::Font( FontFamily::GenericMonospace,9 ), gcnew SolidBrush( Color::Blue ), 5, 5 );
      e->Graphics->DrawString( "Primary Selected Component from IComponentChangeService:", gcnew System::Drawing::Font( FontFamily::GenericMonospace,8 ), gcnew SolidBrush( Color::Red ), 5, 20 );
      e->Graphics->DrawString( String::Format( "Name:      {0}", selected_componentname ), gcnew System::Drawing::Font( FontFamily::GenericMonospace,8 ), gcnew SolidBrush( Color::Black ), 10, 32 );
      e->Graphics->DrawString( String::Format( "Type:      {0}", selected_typename ), gcnew System::Drawing::Font( FontFamily::GenericMonospace,8 ), gcnew SolidBrush( Color::Black ), 10, 44 );
      e->Graphics->DrawString( String::Format( "Base Type: {0}", selected_basetypename ), gcnew System::Drawing::Font( FontFamily::GenericMonospace,8 ), gcnew SolidBrush( Color::Black ), 10, 56 );
      e->Graphics->DrawLine( gcnew Pen( gcnew SolidBrush( Color::Black ),1 ), 5, 77, this->Width - 5, 77 );
      e->Graphics->DrawString( "Components of Type from IReferenceService:", gcnew System::Drawing::Font( FontFamily::GenericMonospace,8 ), gcnew SolidBrush( Color::Red ), 5, 85 );
      if (  !selected_typename->Equals( "None selected." ) )
            for ( int i = 0; i < typeComponents->Length; i++ )
         e->Graphics->DrawString( typeComponents[ i ], gcnew System::Drawing::Font( FontFamily::GenericMonospace,8 ), gcnew SolidBrush( Color::Black ), 20.f, 97.f + (i * 12) );

      e->Graphics->DrawString( "Components of Base Type from IReferenceService:", gcnew System::Drawing::Font( FontFamily::GenericMonospace,8 ), gcnew SolidBrush( Color::Red ), 5.f, 109.f + (typeComponents->Length * 12) );
      if (  !selected_typename->Equals( "None selected." ) )
            for ( int i = 0; i < basetypeComponents->Length; i++ )
         e->Graphics->DrawString( basetypeComponents[ i ], gcnew System::Drawing::Font( FontFamily::GenericMonospace,8 ), gcnew SolidBrush( Color::Black ), 20.f, 121.f + (typeComponents->Length * 12) + (i * 12) );
   }
};
//</Snippet1>
