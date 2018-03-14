

//<Snippet1>
#using <system.dll>
#using <system.design.dll>
#using <system.windows.forms.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;
using namespace System::Windows::Forms;

/* This sample demonstrates a designer that adds menu commands
to the design-time shortcut menu for a component.

To test this sample, build the code for the component as a class library,
add the resulting component to the toolbox, open a form in design mode,
and drag the component from the toolbox onto the form.

The component should appear in the component tray beneath the form.
Right-click the component.  The verbs should appear in the shortcut menu.
*/
// This is a designer class which provides designer verb menu commands for
// the associated component. This code is called by the design environment at design-time.
private ref class MyDesigner: public ComponentDesigner
{
public:

   property DesignerVerbCollection^ Verbs 
   {
      // DesignerVerbCollection is overridden from ComponentDesigner
      virtual DesignerVerbCollection^ get() override
      {
         if ( m_Verbs == nullptr )
         {
            // Create and initialize the collection of verbs
            m_Verbs = gcnew DesignerVerbCollection;
            m_Verbs->Add( gcnew DesignerVerb( "First Designer Verb",gcnew EventHandler( this, &MyDesigner::OnFirstItemSelected ) ) );
            m_Verbs->Add( gcnew DesignerVerb( "Second Designer Verb",gcnew EventHandler( this, &MyDesigner::OnSecondItemSelected ) ) );
         }

         return m_Verbs;
      }
   }
   MyDesigner(){}

private:
   DesignerVerbCollection^ m_Verbs;
   void OnFirstItemSelected( Object^ /*sender*/, EventArgs^ /*args*/ )
   {
      // Display a message
      MessageBox::Show( "The first designer verb was invoked." );
   }

   void OnSecondItemSelected( Object^ /*sender*/, EventArgs^ /*args*/ )
   {
      // Display a message
      MessageBox::Show( "The second designer verb was invoked." );
   }
};

// Associate MyDesigner with this component type using a DesignerAttribute
[Designer(MyDesigner::typeid)]
public ref class Component1: public System::ComponentModel::Component{};
//</Snippet1>
