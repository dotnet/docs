

// <Snippet1>
#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Reflection;
using namespace System::Security;

int main()
{
   try
   {
      Type^ myType = System::Windows::Forms::Button::typeid;
      array<EventInfo^>^myEvents = myType->GetEvents();
      Console::WriteLine( "The events on the Button class are: " );
      for ( int index = 0; index < myEvents->Length; index++ )
      {
         Console::WriteLine( myEvents[ index ] );

      }
   }
   catch ( SecurityException^ e ) 
   {
      Console::WriteLine( "SecurityException: {0}", e->Message );
   }
   catch ( ArgumentNullException^ e ) 
   {
      Console::WriteLine( "ArgumentNullException: {0}", e->Message );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception: {0}", e->Message );
   }
}
// </Snippet1>
