

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
      
      // Create a bitmask based on BindingFlags.
      BindingFlags myBindingFlags = static_cast<BindingFlags>(BindingFlags::Instance | BindingFlags::Public);
      Type^ myTypeEvent = System::Windows::Forms::Button::typeid;
      array<EventInfo^>^myEventsBindingFlags = myTypeEvent->GetEvents( myBindingFlags );
      Console::WriteLine( "\nThe events on the Button class with the specified BindingFlags are:" );
      for ( int index = 0; index < myEventsBindingFlags->Length; index++ )
      {
         Console::WriteLine( myEventsBindingFlags[ index ] );

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
