//<Snippet1>
#using <System.dll>
#using <System.Design.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;
using namespace System::Drawing;
using namespace System::Windows::Forms;

// Provides an example component designer.
ref class ExampleComponentDesigner: public ComponentDesigner
{
public:
   ExampleComponentDesigner()
   {
   }

   // This method provides an opportunity to perform processing when a designer is initialized.
   // The component parameter is the component that the designer is associated with.
   virtual void Initialize( IComponent^ component ) override
   {
      // Always call the base Initialize method in an of this method.
      ComponentDesigner::Initialize( component );
   }

   // This method is invoked when the associated component is double-clicked.
   virtual void DoDefaultAction() override
   {
      MessageBox::Show( "The event handler for the default action was invoked." );
   }

   // This method provides designer verbs.
   property DesignerVerbCollection^ Verbs 
   {
      virtual DesignerVerbCollection^ get() override
      {
         array<DesignerVerb^>^ newDesignerVerbs = {gcnew DesignerVerb( "Example Designer Verb Command", gcnew EventHandler( this, &ExampleComponentDesigner::onVerb ) )};
         return gcnew DesignerVerbCollection( newDesignerVerbs );
      }
   }

private:
   // Event handling method for the example designer verb
   void onVerb( Object^ sender, EventArgs^ e )
   {
      MessageBox::Show( "The event handler for the Example Designer Verb Command was invoked." );
   }
};

// Provides an example component associated with the example component designer.

[DesignerAttribute(ExampleComponentDesigner::typeid, IDesigner::typeid)]
ref class ExampleComponent: public Component
{
public:
   ExampleComponent(){}
};
//</Snippet1>
