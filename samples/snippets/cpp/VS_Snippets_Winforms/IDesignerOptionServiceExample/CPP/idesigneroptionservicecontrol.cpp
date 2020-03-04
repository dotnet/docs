

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
using namespace System::Windows::Forms::Design;

namespace IDesignerOptionServiceExample
{
   // This control demonstrates retrieving the standard 
   // designer option service values in design mode.
   public ref class IDesignerOptionServiceControl: public System::Windows::Forms::UserControl
   {
   private:
      IDesignerOptionService^ designerOptionService;

   public:
      IDesignerOptionServiceControl()
      {
         this->BackColor = Color::Beige;
         this->Size = System::Drawing::Size( 404, 135 );
      }

      property System::ComponentModel::ISite^ Site 
      {
         virtual System::ComponentModel::ISite^ get() override
         {
            return __super::Site;
         }

         virtual void set( System::ComponentModel::ISite^ value ) override
         {
            __super::Site = value;
            
            // If siting component, attempt to obtain an IDesignerOptionService.
            if ( __super::Site != nullptr )
                        designerOptionService = dynamic_cast<IDesignerOptionService^>(this->GetService( IDesignerOptionService::typeid ));
         }
      }

   protected:

      // Displays control information and current IDesignerOptionService 
      // values, if available.

      virtual void OnPaint( System::Windows::Forms::PaintEventArgs^ e ) override
      {
         e->Graphics->DrawString( "IDesignerOptionServiceControl", gcnew System::Drawing::Font( "Arial",9 ), gcnew SolidBrush( Color::Blue ), 4, 4 );
         if ( this->DesignMode )
                  e->Graphics->DrawString( "Currently in design mode", gcnew System::Drawing::Font( "Arial",8 ), gcnew SolidBrush( Color::Black ), 4, 18 );
         else
                  e->Graphics->DrawString( "Not in design mode. Cannot access IDesignerOptionService.", gcnew System::Drawing::Font( "Arial",8 ), gcnew SolidBrush( Color::Red ), 4, 18 );

         if ( __super::Site != nullptr && designerOptionService != nullptr )
         {
            e->Graphics->DrawString( "IDesignerOptionService provides access to the table of option values listed when", gcnew System::Drawing::Font( "Arial",8 ), gcnew SolidBrush( Color::Black ), 4, 38 );
            e->Graphics->DrawString( "the Windows Forms Designer\\General tab of the Tools\\Options menu is selected.", gcnew System::Drawing::Font( "Arial",8 ), gcnew SolidBrush( Color::Black ), 4, 50 );
            e->Graphics->DrawString( "Table of standard value names and current values", gcnew System::Drawing::Font( "Arial",8 ), gcnew SolidBrush( Color::Red ), 4, 76 );
            
            // Displays a table of the standard value names and current values.
            int ypos = 90;
            
            // <snippet2>
            // Obtains and shows the size of the standard design-mode grid square.
            System::Drawing::Size size =  *dynamic_cast<System::Drawing::Size^>(designerOptionService->GetOptionValue( "WindowsFormsDesigner\\General", "GridSize" ));
            // </snippet2>
            e->Graphics->DrawString( "GridSize", gcnew System::Drawing::Font( "Arial",8 ), gcnew SolidBrush( Color::Black ), 4, (float)ypos );
            e->Graphics->DrawString( size.ToString(), gcnew System::Drawing::Font( "Arial",8 ), gcnew SolidBrush( Color::Black ), 100, (float)ypos );
            ypos += 12;

            // Obtains and shows whether the design mode surface grid is enabled.
            bool showGrid =  *dynamic_cast<bool^>(designerOptionService->GetOptionValue( "WindowsFormsDesigner\\General", "ShowGrid" ));
            e->Graphics->DrawString( "ShowGrid", gcnew System::Drawing::Font( "Arial",8 ), gcnew SolidBrush( Color::Black ), 4, (float)ypos );
            e->Graphics->DrawString( showGrid.ToString(), gcnew System::Drawing::Font( "Arial",8 ), gcnew SolidBrush( Color::Black ), 100, (float)ypos );
            ypos += 12;

            // Obtains and shows whether components should be aligned with the surface grid.
            bool snapToGrid =  *dynamic_cast<bool^>(designerOptionService->GetOptionValue( "WindowsFormsDesigner\\General", "SnapToGrid" ));
            e->Graphics->DrawString( "SnapToGrid", gcnew System::Drawing::Font( "Arial",8 ), gcnew SolidBrush( Color::Black ), 4, (float)ypos );
            e->Graphics->DrawString( snapToGrid.ToString(), gcnew System::Drawing::Font( "Arial",8 ), gcnew SolidBrush( Color::Black ), 100, (float)ypos );
         }
      }
   };
}
//</Snippet1>
