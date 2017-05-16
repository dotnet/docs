

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
using namespace System::Security::Permissions;

public ref class ExampleIDesigner: public System::ComponentModel::Design::IDesigner
{
private:

   // Local reference to the designer's component.
   IComponent^ component;

public:

   property System::ComponentModel::IComponent^ Component 
   {
      // Public accessor to the designer's component.
      virtual System::ComponentModel::IComponent^ get()
      {
         return component;
      }
   }
   ExampleIDesigner(){}

   virtual void Initialize( System::ComponentModel::IComponent^ component )
   {
      // This method is called after a designer for a component is created,
      // and stores a reference to the designer's component.
      this->component = component;
   }

   // This method peforms the 'default' action for the designer. The default action 
   // for a basic IDesigner implementation is invoked when the designer's component 
   // is double-clicked. By default, a component associated with a basic IDesigner 
   // implementation is displayed in the design-mode component tray.
   virtual void DoDefaultAction()
   {
      // Shows a message box indicating that the default action for the designer was invoked.
      MessageBox::Show( "The DoDefaultAction method of an IDesigner implementation was invoked.", "Information" );
   }

   property System::ComponentModel::Design::DesignerVerbCollection^ Verbs 
   {
      // Returns a collection of designer verb menu items to show in the 
      // shortcut menu for the designer's component.
      [PermissionSetAttribute(SecurityAction::Demand, Name="FullTrust")]
      virtual System::ComponentModel::Design::DesignerVerbCollection^ get()
      {
         DesignerVerbCollection^ verbs = gcnew DesignerVerbCollection;
         DesignerVerb^ dv1 = gcnew DesignerVerb( "Display Component Name",gcnew EventHandler( this, &ExampleIDesigner::ShowComponentName ) );
         verbs->Add( dv1 );
         return verbs;
      }
   }

private:

   // Event handler for displaying a message box showing the designer's component's name.
   void ShowComponentName( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      if ( this->Component != nullptr )
            MessageBox::Show( this->Component->Site->Name, "Designer Component's Name" );
   }

public:

   // Provides an opportunity to release resources before object destruction.
   ~ExampleIDesigner(){}

};

// A DesignerAttribute associates the example IDesigner with an example control.

[DesignerAttribute(ExampleIDesigner::typeid)]
public ref class TestControl: public System::Windows::Forms::UserControl
{
public:
   TestControl(){}

};
//</Snippet1>
