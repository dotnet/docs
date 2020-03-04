

//<Snippet1>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.Design.dll>
#using <System.dll>

using namespace System;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;
using namespace System::Diagnostics;
using namespace System::Drawing;
using namespace System::Windows::Forms;
using namespace System::Windows::Forms::Design;

namespace SampleRootDesigner
{
   ref class SampleRootDesigner;

   // This sample demonstrates how to provide the root designer view, or
   // design mode background view, by overriding IRootDesigner.GetView().
   // The following attribute associates the SampleRootDesigner designer
   // with the SampleComponent component.

   [Designer(SampleRootDesigner::typeid,IRootDesigner::typeid)]
   public ref class RootDesignedComponent: public Component
   {
   public:
      RootDesignedComponent(){}

   };

   public ref class SampleRootDesigner: public ComponentDesigner, public IRootDesigner
   {
   private:
      ref class RootDesignerView;

      // Member field of custom type RootDesignerView, a control that
      // will be shown in the Forms designer view. This member is
      // cached to reduce processing needed to recreate the
      // view control on each call to GetView().
      RootDesignerView^ m_view;

      // This method returns an instance of the view for this root
      // designer. The "view" is the user interface that is presented
      // in a document window for the user to manipulate.
      virtual Object^ GetView( ViewTechnology technology ) sealed = IRootDesigner::GetView
      {
         if ( technology != ViewTechnology::WindowsForms )
         {
            throw gcnew ArgumentException( "Not a supported view technology","technology" );
         }

         if ( m_view == nullptr )
         {
            
            // Some type of displayable Form or control is required
            // for a root designer that overrides GetView(). In this
            // example, a Control of type RootDesignerView is used.
            // Any class that inherits from Control will work.
            m_view = gcnew RootDesignerView( this );
         }

         return m_view;
      }


      // IRootDesigner.SupportedTechnologies is a required override for an
      // IRootDesigner. WindowsForms is the view technology used by this designer.
public:
      property array<ViewTechnology>^ SupportedTechnologies 
      {
		virtual array<ViewTechnology>^ get() 
		{
			return gcnew array<ViewTechnology> {ViewTechnology::Default};
                	
		}
      }
      
      // RootDesignerView is a simple control that will be displayed
      // in the designer window.
      ref class RootDesignerView: public Control
      {
      private:
         SampleRootDesigner^ m_designer;

      public:
         RootDesignerView( SampleRootDesigner^ designer )
         {
            m_designer = designer;
            BackColor = Color::Blue;
            Font = gcnew System::Drawing::Font( Font->FontFamily->Name,24.0f );
         }


      protected:
         virtual void OnPaint( PaintEventArgs^ pe ) override
         {
            Control::OnPaint( pe );
            
            // Draws the name of the component in large letters.
            pe->Graphics->DrawString( m_designer->Component->Site->Name, Font, Brushes::Yellow, ClientRectangle );
         }

      };


   };


   // This sample component inherits from RootDesignedComponent which
   // uses the SampleRootDesigner.
   public ref class RootViewSampleComponent: public RootDesignedComponent
   {
   public:
      RootViewSampleComponent(){}

   };

}

//</Snippet1>
