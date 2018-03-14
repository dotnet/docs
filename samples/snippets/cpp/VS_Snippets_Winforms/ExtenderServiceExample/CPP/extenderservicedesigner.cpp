

//<Snippet1>
#using <system.dll>
#using <system.design.dll>
#using <system.windows.forms.dll>
#using <system.drawing.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;
using namespace System::Windows::Forms;
using namespace System::Windows::Forms::Design;

// IExtenderProviderImplementation that adds an integer property
// named "ExtenderIndex" to any design-mode document object.

[ProvidePropertyAttribute("ExtenderIndex",IComponent::typeid)]
public ref class ComponentExtender: public IExtenderProvider
{
public:

   // Stores the value of the property to extend a component with.
   int index;
   ComponentExtender()
   {
      index = 0;
   }

   virtual bool CanExtend( Object^ /*extendee*/ )
   {
      // Extends any type of object.
      return true;
   }

   int GetExtenderIndex( IComponent^ /*component*/ )
   {
      return index;
   }

   void SetExtenderIndex( IComponent^ /*component*/, int index )
   {
      this->index = index;
   }
};


// This designer adds a ComponentExtender extender provider,
// and removes it when the designer is destroyed.
public ref class ExtenderServiceDesigner: public ControlDesigner
{
private:

   // A local reference to an obtained IExtenderProviderService.
   IExtenderProviderService^ localExtenderServiceReference;

   // An IExtenderProvider that this designer supplies.
   ComponentExtender^ extender;

public:
   ExtenderServiceDesigner(){}

   virtual void Initialize( IComponent^ component ) override
   {
      ControlDesigner::Initialize( component );

      // Attempts to obtain an IExtenderProviderService.
      IExtenderProviderService^ extenderService = dynamic_cast<IExtenderProviderService^>(component->Site->GetService( IExtenderProviderService::typeid ));
      if ( extenderService != nullptr )
      {
         // If the service was obtained, adds a ComponentExtender
         // that adds an "ExtenderIndex" integer property to the
         // designer's component.
         extender = gcnew ComponentExtender;
         extenderService->AddExtenderProvider( extender );
         localExtenderServiceReference = extenderService;
      }
      else
            MessageBox::Show( "Could not obtain an IExtenderProviderService." );
   }

   ~ExtenderServiceDesigner()
   {
      // Removes any previously added extender provider.
      if ( localExtenderServiceReference != nullptr )
      {
         localExtenderServiceReference->RemoveExtenderProvider( extender );
         localExtenderServiceReference = nullptr;
      }
   }
};

// Example UserControl associated with the ExtenderServiceDesigner.

[DesignerAttribute(ExtenderServiceDesigner::typeid)]
public ref class ExtenderServiceTestControl: public UserControl
{
public:
   ExtenderServiceTestControl(){}
};
//</Snippet1>
