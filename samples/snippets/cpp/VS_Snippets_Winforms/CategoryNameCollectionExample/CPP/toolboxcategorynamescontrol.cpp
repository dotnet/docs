

//<Snippet2>
#using <System.Windows.Forms.dll>
#using <System.Data.dll>
#using <System.Drawing.dll>
#using <System.dll>

using namespace System;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;
using namespace System::Drawing;
using namespace System::Drawing::Design;
using namespace System::Data;
using namespace System::Windows::Forms;

namespace ToolboxCategoryNamesControl
{
   public ref class ToolboxCategoryNamesControl: public System::Windows::Forms::UserControl
   {
   private:
      System::Drawing::Design::IToolboxService^ toolboxService;
      System::Drawing::Design::CategoryNameCollection^ categoryNames;

   public:
      ToolboxCategoryNamesControl()
      {
         this->BackColor = System::Drawing::Color::Beige;
         this->Name = "Category Names Display Control";
         this->Size = System::Drawing::Size( 264, 200 );
      }

      property System::ComponentModel::ISite^ Site 
      {
         // Obtain or reset IToolboxService^ reference on each siting of control.
         virtual System::ComponentModel::ISite^ get() override
         {
            return __super::Site;
         }

         virtual void set( System::ComponentModel::ISite^ value ) override
         {
            __super::Site = value;
            
            // If the component was sited, attempt to obtain
            // an IToolboxService^ instance.
            if ( __super::Site != nullptr )
            {
               toolboxService = dynamic_cast<IToolboxService^>(this->GetService( IToolboxService::typeid ));
               
               // If an IToolboxService* was located, update the category list.
               if ( toolboxService != nullptr )
                              categoryNames = toolboxService->CategoryNames;
            }
            else
                        toolboxService = nullptr;
         }
      }

   protected:
      [System::Security::Permissions::PermissionSetAttribute(System::Security::Permissions::SecurityAction::Demand, Name="FullTrust")]
      virtual void OnPaint( System::Windows::Forms::PaintEventArgs^ e ) override
      {
         if ( categoryNames != nullptr )
         {
            e->Graphics->DrawString( "IToolboxService category names list:", gcnew System::Drawing::Font( "Arial",9 ), Brushes::Black, 10, 10 );
            
            //<Snippet1>
            // categoryNames is a CategoryNameCollection obtained from
            // the IToolboxService*. CategoryNameCollection is a read-only
            // String* collection.
            // Output each category name in the CategoryNameCollection.
            for ( int i = 0; i < categoryNames->Count; i++ )
               e->Graphics->DrawString( categoryNames[ i ], gcnew System::Drawing::Font( "Arial",8 ), Brushes::Black, (float)10, (float)24 + (10 * i) );
            //</Snippet1>
         }
      }
   };
}
//</Snippet2>
