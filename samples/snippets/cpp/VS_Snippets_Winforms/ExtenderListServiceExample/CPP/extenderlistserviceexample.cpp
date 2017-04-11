//<Snippet1>
#using <system.dll>
#using <system.drawing.dll>
#using <system.windows.forms.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;
using namespace System::Windows::Forms;

namespace ExtenderListServiceExample
{
   // This control lists any active extender providers.
   public ref class ExtenderListServiceControl: public UserControl
   {
   private:
      IExtenderListService^ extenderListService;
      array<String^>^extenderNames;

   public:
      ExtenderListServiceControl()
      {
         this->Width = 600;
      }

      property ISite^ Site 
      {
         // Queries the IExtenderListService when the control is sited
         // in design mode.
         virtual ISite^ get() override
         {
            return __super::Site;
         }

         virtual void set( ISite^ value ) override
         {
            __super::Site = value;
            if ( this->DesignMode )
            {
               extenderListService = dynamic_cast<IExtenderListService^>(this->GetService( IExtenderListService::typeid ));
               if ( extenderListService != nullptr )
               {
                  array<IExtenderProvider^>^extenders = extenderListService->GetExtenderProviders();
                  extenderNames = gcnew array<String^>(extenders->Length);
                  for ( int i = 0; i < extenders->Length; i++ )
                     extenderNames[ i ] = String::Concat( "ExtenderProvider #", i.ToString(), ":  ", extenders[ i ]->GetType()->FullName );
               }
            }
            else
            {
               extenderListService = nullptr;
            }
         }
      }

   protected:

      // Draws a list of any active extender providers
      virtual void OnPaint( PaintEventArgs^ e ) override
      {
         if ( extenderNames->Length == 0 )
                  e->Graphics->DrawString( "No active extender providers", gcnew System::Drawing::Font( "Arial",9 ), gcnew SolidBrush( Color::Black ), 10, 10 );
         else
                  e->Graphics->DrawString( "List of types of active extender providers", gcnew System::Drawing::Font( "Arial",9 ), gcnew SolidBrush( Color::Black ), 10, 10 );

         for ( int i = 0; i < extenderNames->Length; i++ )
            e->Graphics->DrawString( extenderNames[ i ], gcnew System::Drawing::Font( "Arial",8 ), gcnew SolidBrush( Color::Black ), 10, 25 + (i * 10) );
      }
   };
}
//</Snippet1>
