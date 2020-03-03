

//<Snippet1>
#using <System.Design.dll>
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

namespace IDictionaryServiceControl
{
   ref class IDictionaryServiceDesigner;

   // This example control works with the IDictionaryServiceDesigner to demonstrate
   // using the IDictionaryService for storing data provided by a designer, and
   // accessing it from a control. The IDictionaryService provides a Site-specific 
   // key-based dictionary. An IDictionaryServiceDesigner sets an ArrayList of strings 
   // to the dictionary with a "DesignerData" key, and its contents are accessed and
   // displayed once the Update box is clicked at design time.

   [DesignerAttribute(IDictionaryServiceDesigner::typeid,IDesigner::typeid)]
   public ref class IDictionaryServiceControl: public System::Windows::Forms::UserControl
   {
   public:
      ArrayList^ al;
      IDictionaryServiceControl()
      {
         // Initializes the example control.
         al = gcnew ArrayList;
         this->Size = System::Drawing::Size( 344, 88 );
         this->BackColor = Color::White;
      }

   protected:

      // Draws the instructions and user interface, and any strings contained 
      // in a local ArrayList.
      virtual void OnPaint( System::Windows::Forms::PaintEventArgs^ e ) override
      {
         if ( this->DesignMode )
         {
            e->Graphics->DrawString( "IDictionaryServiceDesigner Control", gcnew System::Drawing::Font( FontFamily::GenericMonospace,9 ), gcnew SolidBrush( Color::Blue ), 5, 4 );
            e->Graphics->DrawString( "Click the Update box to update display strings", gcnew System::Drawing::Font( FontFamily::GenericMonospace,8 ), gcnew SolidBrush( Color::DarkGreen ), 5, 17 );
            e->Graphics->DrawString( "from the IDictionaryService.", gcnew System::Drawing::Font( FontFamily::GenericMonospace,8 ), gcnew SolidBrush( Color::DarkGreen ), 5, 29 );
            e->Graphics->FillRectangle( gcnew SolidBrush( Color::Beige ), 270, 7, 60, 10 );
            e->Graphics->DrawRectangle( gcnew Pen( gcnew SolidBrush( Color::Black ),1 ), 270, 7, 60, 10 );
            e->Graphics->DrawString( "Update", gcnew System::Drawing::Font( FontFamily::GenericMonospace,7 ), gcnew SolidBrush( Color::Black ), 282, 7 );
            for ( int i = 0; i < al->Count; i++ )
               e->Graphics->DrawString( dynamic_cast<String^>(al[ i ]), gcnew System::Drawing::Font( FontFamily::GenericMonospace,8 ), gcnew SolidBrush( Color::Black ), 5.0f, 44.0f + (i * 12) );
         }
      }

      // On mouse down, this method attempts to access the IDictionaryService and 
      // obtain an ArrayList with a key of "DesignerData" in the dictionary.
      // If successful, this ArrayList is set to the local ArrayList.
      virtual void OnMouseDown( System::Windows::Forms::MouseEventArgs^ /*e*/ ) override
      {
         //<Snippet2>
         // Attempts to obtain the IDictionaryService using the Control.GetService method.
         IDictionaryService^ ds = dynamic_cast<IDictionaryService^>(GetService( IDictionaryService::typeid ));

         // If the service was obtained...
         if ( ds != nullptr )
         {
            // Attempts to retrieve a list with a key of "DesignerData".
            ArrayList^ list = dynamic_cast<ArrayList^>(ds->GetValue( "DesignerData" ));
            
            //</Snippet2>
            // If the list exists, sets the list obtained by the 
            // IDictionaryService to the local list.
            if ( list != nullptr )
                        this->al = list;
            this->Refresh();
         }
      }

   };

   // This designer uses the IDictionaryService to store an ArrayList of
   // information strings that the associated control can access and 
   // display. The IDictionaryService creates a new dictionary for each Site.
   public ref class IDictionaryServiceDesigner: public System::Windows::Forms::Design::ControlDesigner
   {
   public:
      IDictionaryServiceDesigner(){}

      // On designer initialization, this method attempts to obtain 
      // the IDictionaryService, and populates an ArrayList
      // associated with a "DesignerData" key in the dictionary with 
      // designer- and control-related information strings.
      virtual void Initialize( System::ComponentModel::IComponent^ component ) override
      {
         ControlDesigner::Initialize( component );
         IDictionaryService^ ds = dynamic_cast<IDictionaryService^>(component->Site->GetService( IDictionaryService::typeid ));
         if ( ds != nullptr )
         {
            // If the dictionary service does not contain a 
            // DesignerData key, adds an ArrayList for that key.
            if ( ds->GetValue( "DesignerData" ) == nullptr )
            {
               ds->SetValue( "DesignerData", gcnew ArrayList );
               ds->SetValue( "DesignerData", gcnew ArrayList );
            }

            // Obtains the ArrayList with the "DesignerData" key 
            // from the dictionary service.
            ArrayList^ al = dynamic_cast<ArrayList^>(ds->GetValue( "DesignerData" ));
            if ( al != nullptr )
            {
               al->Clear();

               // Populates the array list with designer and 
               // control information strings.
               al->Add( String::Format( "Designer type: {0}", this->GetType()->Name ) );
               al->Add( String::Format( "Control type:  {0}", this->Control->GetType()->Name ) );
               al->Add( String::Format( "Control name:  {0}", this->Control->Name ) );
            }
         }
      }

   protected:
      virtual bool GetHitTest( System::Drawing::Point point ) override
      {
         // Translates the point to client coordinates and passes the 
         // messages to the control while over the click box.
         Point translated = this->Control->PointToClient( point );
         if ( translated.X > 269 && translated.X < 331 && translated.Y > 7 && translated.Y < 18 )
                  return true;
         else
                  return ControlDesigner::GetHitTest( point );
      }
   };
}
//</Snippet1>
