

//<Snippet1>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.Design.dll>
#using <System.dll>

using namespace System;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;
using namespace System::Drawing;
using namespace System::Globalization;
using namespace System::Resources;
using namespace System::Windows::Forms;
using namespace System::Windows::Forms::Design;
ref class ResourceTestControlDesigner;

// Associates the ResourceTestControlDesigner with the
// ResourceTestControl class.

[Designer(ResourceTestControlDesigner::typeid)]
public ref class ResourceTestControl: public System::Windows::Forms::UserControl
{
public:

   // Initializes a string array used to store strings that
   // this control displays.
   array<String^>^resource_strings;
   ResourceTestControl()
   {
      array<String^>^temp = {"Initial Default String #1","Initial Default String #2"};
      resource_strings = temp;
      this->BackColor = Color::White;
      this->Size = System::Drawing::Size( 408, 160 );
   }

protected:

   // Draws the strings contained in the string array.
   virtual void OnPaint( System::Windows::Forms::PaintEventArgs^ e ) override
   {
      e->Graphics->DrawString( "IResourceService Example Designer Control", gcnew System::Drawing::Font( FontFamily::GenericMonospace,10 ), gcnew SolidBrush( Color::Blue ), 2, 2 );
      e->Graphics->DrawString( "String list:  (use shortcut menu in design mode)", gcnew System::Drawing::Font( FontFamily::GenericMonospace,8 ), gcnew SolidBrush( Color::Black ), 2, 20 );
      for ( int i = 0; i < resource_strings->Length; i++ )
      {
         e->Graphics->DrawString( resource_strings[ i ], gcnew System::Drawing::Font( FontFamily::GenericMonospace,8 ), gcnew SolidBrush( Color::SeaGreen ), 2.f, 38.f + (i * 18) );

      }
   }

};

// This designer offers several menu commands for the
// shortcut menu for the associated control.
// These commands can be used to reset the control's string
// list, to generate a default resources file, or to load the string
// list for the control from the default resources file.
public ref class ResourceTestControlDesigner: public System::Windows::Forms::Design::ControlDesigner
{
public:
   ResourceTestControlDesigner(){}

   property System::ComponentModel::Design::DesignerVerbCollection^ Verbs 
   {
      virtual System::ComponentModel::Design::DesignerVerbCollection^ get() override
      {
         // Creates a collection of designer verb menu commands
         // that link to event handlers in this designer.
         array<DesignerVerb^>^temp0 = {gcnew DesignerVerb( "Load Strings from Default Resources File",gcnew EventHandler( this, &ResourceTestControlDesigner::LoadResources ) ),gcnew DesignerVerb( "Create Default Resources File",gcnew EventHandler( this, &ResourceTestControlDesigner::CreateResources ) ),gcnew DesignerVerb( "Clear ResourceTestControl String List",gcnew EventHandler( this, &ResourceTestControlDesigner::ClearStrings ) )};
         return gcnew DesignerVerbCollection( temp0 );
      }
   }

private:

   // Sets the string list for the control to the strings
   // loaded from a resource file.
   void LoadResources( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      IResourceService^ rs = dynamic_cast<IResourceService^>(this->Component->Site->GetService( IResourceService::typeid ));
      if ( rs == nullptr )
            throw gcnew System::Exception( "Could not obtain IResourceService." );

      IResourceReader^ rr = rs->GetResourceReader( CultureInfo::CurrentUICulture );
      if ( rr == nullptr )
            throw gcnew System::Exception( "Resource file could not be obtained. You may need to create one first." );

      IDictionaryEnumerator^ de = rr->GetEnumerator();
      if ( this->Control->GetType() == ResourceTestControl::typeid )
      {
         ResourceTestControl^ rtc = dynamic_cast<ResourceTestControl^>(this->Control);
         String^ s1;
         String^ s2;
         String^ s3;
         de->MoveNext();
         s1 = dynamic_cast<String^>(( *dynamic_cast<DictionaryEntry^>(de->Current)).Value);
         de->MoveNext();
         s2 = dynamic_cast<String^>(( *dynamic_cast<DictionaryEntry^>(de->Current)).Value);
         de->MoveNext();
         s3 = dynamic_cast<String^>(( *dynamic_cast<DictionaryEntry^>(de->Current)).Value);
         de->MoveNext();
         array<String^>^temp = {s1,s2,s3};
         rtc->resource_strings = temp;
         this->Control->Refresh();
      }
   }

   // Creates a default resource file for the current
   // CultureInfo and adds 3 strings to it.
   void CreateResources( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      IResourceService^ rs = dynamic_cast<IResourceService^>(this->Component->Site->GetService( IResourceService::typeid ));
      if ( rs == nullptr )
            throw gcnew System::Exception( "Could not obtain IResourceService." );

      IResourceWriter^ rw = rs->GetResourceWriter( CultureInfo::CurrentUICulture );
      rw->AddResource( "string1", "Persisted resource string #1" );
      rw->AddResource( "string2", "Persisted resource string #2" );
      rw->AddResource( "string3", "Persisted resource string #3" );
      rw->Generate();
      rw->Close();
   }

   // Clears the string list of the associated ResourceTestControl.
   void ClearStrings( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      if ( this->Control->GetType() == ResourceTestControl::typeid )
      {
         ResourceTestControl^ rtc = dynamic_cast<ResourceTestControl^>(this->Control);
         array<String^>^temp = {"Test String #1","Test String #2"};
         rtc->resource_strings = temp;
         this->Control->Refresh();
      }
   }
};
//</Snippet1>
