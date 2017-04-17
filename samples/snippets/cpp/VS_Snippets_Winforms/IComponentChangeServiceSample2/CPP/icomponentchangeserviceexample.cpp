//<Snippet1>
#using <system.dll>
#using <system.windows.forms.dll>
#using <system.drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;
using namespace System::Windows::Forms;

/*  This sample illustrates how to use the IComponentChangeService interface
    to handle component change events.  The ComponentClass control attaches
    event handlers when it is sited in a document, and displays a message
    when notification that a component has been added, removed, or changed
    is received from the IComponentChangeService.

    To run this sample, add the ComponentClass control to a Form and
    add, remove, or change components to see the behavior of the
    component change event handlers. */

public ref class ComponentClass: public UserControl
{
private:
   System::ComponentModel::Container^ components;
   ListBox^ listBox1;
   IComponentChangeService^ m_changeService;
   void InitializeComponent()
   {
      this->listBox1 = gcnew ListBox;
      this->SuspendLayout();

      // listBox1.
      this->listBox1->Location = System::Drawing::Point( 24, 16 );
      this->listBox1->Name = "listBox1";
      this->listBox1->Size = System::Drawing::Size( 576, 277 );
      this->listBox1->TabIndex = 0;

      // ComponentClass.
      array<Control^>^myArray = {listBox1};
      this->Controls->AddRange( myArray );
      this->Name = "ComponentClass";
      this->Size = System::Drawing::Size( 624, 320 );
      this->ResumeLayout( false );
   }

   void ClearChangeNotifications()
   {
      // The m_changeService value is 0 when not in design mode,
      // as the IComponentChangeService is only available at design time.
      m_changeService = dynamic_cast<IComponentChangeService^>(GetService( IComponentChangeService::typeid ));

      // Clear our the component change events to prepare for re-siting.
      if ( m_changeService != nullptr )
      {
         m_changeService->ComponentChanged -= gcnew ComponentChangedEventHandler( this, &ComponentClass::OnComponentChanged );
         m_changeService->ComponentChanging -= gcnew ComponentChangingEventHandler( this, &ComponentClass::OnComponentChanging );
         m_changeService->ComponentAdded -= gcnew ComponentEventHandler( this, &ComponentClass::OnComponentAdded );
         m_changeService->ComponentAdding -= gcnew ComponentEventHandler( this, &ComponentClass::OnComponentAdding );
         m_changeService->ComponentRemoved -= gcnew ComponentEventHandler( this, &ComponentClass::OnComponentRemoved );
         m_changeService->ComponentRemoving -= gcnew ComponentEventHandler( this, &ComponentClass::OnComponentRemoving );
         m_changeService->ComponentRename -= gcnew ComponentRenameEventHandler( this, &ComponentClass::OnComponentRename );
      }
   }

   void RegisterChangeNotifications()
   {
      // Register the event handlers for the IComponentChangeService events
      if ( m_changeService != nullptr )
      {
         m_changeService->ComponentChanged += gcnew ComponentChangedEventHandler( this, &ComponentClass::OnComponentChanged );
         m_changeService->ComponentChanging += gcnew ComponentChangingEventHandler( this, &ComponentClass::OnComponentChanging );
         m_changeService->ComponentAdded += gcnew ComponentEventHandler( this, &ComponentClass::OnComponentAdded );
         m_changeService->ComponentAdding += gcnew ComponentEventHandler( this, &ComponentClass::OnComponentAdding );
         m_changeService->ComponentRemoved += gcnew ComponentEventHandler( this, &ComponentClass::OnComponentRemoved );
         m_changeService->ComponentRemoving += gcnew ComponentEventHandler( this, &ComponentClass::OnComponentRemoving );
         m_changeService->ComponentRename += gcnew ComponentRenameEventHandler( this, &ComponentClass::OnComponentRename );
      }
   }

   /* This method handles the OnComponentChanged event to display a notification. */
   void OnComponentChanged( Object^ /*sender*/, ComponentChangedEventArgs^ ce )
   {
      if ( ce->Component != nullptr && static_cast<IComponent^>(ce->Component)->Site != nullptr && ce->Member != nullptr )
            OnUserChange( "The " + ce->Member->Name + " member of the " + static_cast<IComponent^>(ce->Component)->Site->Name + " component has been changed." );
   }


   /* This method handles the OnComponentChanging event to display a notification. */
   void OnComponentChanging( Object^ /*sender*/, ComponentChangingEventArgs^ ce )
   {
      if ( ce->Component != nullptr && static_cast<IComponent^>(ce->Component)->Site != nullptr && ce->Member != nullptr )
            OnUserChange( "The " + ce->Member->Name + " member of the " + static_cast<IComponent^>(ce->Component)->Site->Name + " component is being changed." );
   }

   /* This method handles the OnComponentAdded event to display a notification. */
   void OnComponentAdded( Object^ /*sender*/, ComponentEventArgs^ ce )
   {
      OnUserChange( "A component, " + ce->Component->Site->Name + ", has been added." );
   }

   /* This method handles the OnComponentAdding event to display a notification. */
   void OnComponentAdding( Object^ /*sender*/, ComponentEventArgs^ ce )
   {
      OnUserChange( "A component of type " + ce->Component->GetType()->FullName + " is being added." );
   }

   /* This method handles the OnComponentRemoved event to display a notification. */
   void OnComponentRemoved( Object^ /*sender*/, ComponentEventArgs^ ce )
   {
      OnUserChange( "A component, " + ce->Component->Site->Name + ", has been removed." );
   }

   /* This method handles the OnComponentRemoving event to display a notification. */
   void OnComponentRemoving( Object^ /*sender*/, ComponentEventArgs^ ce )
   {
      OnUserChange( "A component, " + ce->Component->Site->Name + ", is being removed." );
   }

   /* This method handles the OnComponentRename event to display a notification. */
   void OnComponentRename( Object^ /*sender*/, ComponentRenameEventArgs^ ce )
   {
      OnUserChange( "A component, " + ce->OldName + ", was renamed to " + ce->NewName + "." );
   }

   // This method adds a specified notification message to the control's listbox.
   void OnUserChange( String^ text )
   {
      listBox1->Items->Add( text );
   }

public:
   ComponentClass()
   {
      InitializeComponent();
   }

   property ISite^ Site 
   {
      // This override allows the control to register event handlers for IComponentChangeService events
      // at the time the control is sited, which happens only in design mode.
      virtual ISite^ get() override
      {
         return Site;
      }

      virtual void set( ISite^ value ) override
      {
         // Clear any component change event handlers.
         ClearChangeNotifications();

         // Set the new Site value.
         Site = value;
         m_changeService = static_cast<IComponentChangeService^>(GetService( IComponentChangeService::typeid ));

         // Register event handlers for component change events.
         RegisterChangeNotifications();
      }
   }

   // Clean up any resources being used.
public:
   ~ComponentClass()
   {
      ClearChangeNotifications();
      if ( components != nullptr )
      {
         delete components;
      }
   }
};
//</Snippet1>
