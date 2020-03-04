

//<Snippet1>
#using <system.dll>
#using <system.design.dll>
#using <system.windows.forms.dll>
#using <system.drawing.dll>

using namespace System;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;
using namespace System::Diagnostics;
using namespace System::Drawing;
using namespace System::Windows::Forms;
using namespace System::Windows::Forms::Design;

// This example demonstrates adding localization support to a component hierarchy from a
// custom IRootDesigner using the LocalizationExtenderProvider class.
namespace LocalizationExtenderProviderExample
{

   // Example IRootDesigner implementation demonstrates LocalizationExtenderProvider support.
   private ref class SampleRootDesigner: public IRootDesigner
   {
   private:

      // RootDesignerView is a simple control that will be displayed in the designer window.
      ref class RootDesignerView: public Control
      {
      private:
         SampleRootDesigner^ m_designer;
         IComponent^ comp;

      public:
         RootDesignerView( SampleRootDesigner^ designer, IComponent^ component )
         {
            m_designer = designer;
            this->comp = component;
            BackColor = Color::Blue;
            Font = gcnew System::Drawing::Font( FontFamily::GenericMonospace,12 );
         }


      protected:

         // Displays the name of the component and the name of the assembly of the component
         // that this root designer is providing support for.
         virtual void OnPaint( PaintEventArgs^ pe ) override
         {
            Control::OnPaint( pe );
            if ( m_designer != 0 && comp != 0 )
            {
               
               // Draws the name of the component in large letters.
               pe->Graphics->DrawString( "Root Designer View", Font, Brushes::Yellow, 8, 4 );
               pe->Graphics->DrawString( String::Concat( "Design Name  : ", comp->Site->Name ), gcnew System::Drawing::Font( "Arial",10 ), Brushes::Yellow, 8, 28 );
               pe->Graphics->DrawString( String::Concat( "Assembly    : ", comp->GetType()->AssemblyQualifiedName ), gcnew System::Drawing::Font( "Arial",10 ), Brushes::Yellow, System::Drawing::RectangleF( System::Drawing::Point( 8, 44 ), System::Drawing::Size( ClientRectangle.Width - 8, ClientRectangle.Height - 44 ) ) );
               
               // Uses the site of the component to acquire an ISelectionService and sets the property grid focus to the component.
               ISelectionService^ selectionService = dynamic_cast<ISelectionService^>(comp->Site->GetService( typeid<ISelectionService^> ));
               if ( selectionService != nullptr )
               {
                  array<IComponent^>^myArray = {m_designer->component};
                  selectionService->SetSelectedComponents( static_cast<Array^>(myArray) );
               }
            }
         }

      };


   protected:

      // RootDesignerView Control provides a full region designer view for this root designer's associated component.
      RootDesignerView^ m_view;

      // Stores reference to the LocalizationExtenderProvider this designer adds, in order to remove it on Dispose.
      LocalizationExtenderProvider^ extender;

      // Internally stores the IDesigner's component reference
      IComponent^ component;

      // Provides a RootDesignerView object that supports ViewTechnology.WindowsForms.
      Object^ GetView( ViewTechnology technology )
      {
         if ( technology != ViewTechnology::WindowsForms )
         {
            throw gcnew ArgumentException( "Not a supported view technology", "technology" );
         }

         if ( m_view == nullptr )
         {
            
            // Create the view control. In this example, a Control of type RootDesignerView is used.
            // A WindowsForms ViewTechnology view provider requires a class that inherits from Control.
            m_view = gcnew RootDesignerView( this,this->Component );
         }

         return m_view;
      }


      property array<ViewTechnology>^ SupportedTechnologies 
      {

         // This designer supports the WindowsForms view technology.
         array<ViewTechnology>^ IRootDesigner::get()
         {
            ViewTechnology myArray[] = {ViewTechnology::WindowsForms};
            return myArray;
         }

      }

   public:

      // Adds a LocalizationExtenderProvider for the component this designer is initialized to support.
      void Initialize( IComponent^ component )
      {
         this->component = component;
         
         // If no extender from this designer is active...
         if ( extender == nullptr )
         {
            
            //<Snippet2>
            // Adds a LocalizationExtenderProvider that provides localization support properties to the specified component.
            extender = gcnew LocalizationExtenderProvider( this->component->Site,this->component );
            
            //</Snippet2>
         }
      }


      property DesignerVerbCollection^ Verbs 
      {

         // Empty IDesigner interface property and method implementations
         DesignerVerbCollection^ get()
         {
            return nullptr;
         }

      }

      property IComponent^ Component 
      {
         IComponent^ get()
         {
            return this->component;
         }

      }
      void DoDefaultAction(){}

      void Dispose(){}


   protected:

      // If a LocalizationExtenderProvider has been added, removes the extender provider.
      void Dispose( bool disposing )
      {
         
         // If an extender has been added, remove it
         if ( extender != nullptr )
         {
            
            // Disposes of the extender provider.  The extender
            // provider removes itself from the extender provider
            // service when it is disposed.
            extender->Dispose();
            extender = nullptr;
         }
      }

   };


   // The following attribute associates the RootDesignedComponent with the RootDesignedComponent component.

   [Designer(__typeof(SampleRootDesigner),__typeof(IRootDesigner))]
   public ref class RootDesignedComponent: public Component
   {
   public:
      RootDesignedComponent(){}

   };


   // RootViewDesignerComponent is a component associated with the SampleRootDesigner
   // IRootDesigner that provides LocalizationExtenderProvider localization support.
   // This derived class is included at the top of this example to enable
   // easy launching of designer view without having to put the class in its own file.
   public ref class RootViewDesignerComponent: public RootDesignedComponent
   {
   public:
      RootViewDesignerComponent(){}

   };

}

//</Snippet1>
