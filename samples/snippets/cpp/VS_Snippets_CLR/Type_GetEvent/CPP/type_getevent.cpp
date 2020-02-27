

// <Snippet1>
#using <system.dll>
#using <system.windows.forms.dll>
#using <system.drawing.dll>

using namespace System;
using namespace System::Reflection;
using namespace System::Security;

int main()
{
   try
   {
      Type^ myType = System::Windows::Forms::Button::typeid;
      EventInfo^ myEvent = myType->GetEvent( "Click" );
      if ( myEvent != nullptr )
      {
         Console::WriteLine( "Looking for the Click event in the Button class." );
         Console::WriteLine( myEvent );
      }
      else
            Console::WriteLine( "The Click event is not available in the Button class." );
   }
   catch ( SecurityException^ e ) 
   {
      Console::WriteLine( "An exception occurred." );
      Console::WriteLine( "Message : {0}", e->Message );
   }
   catch ( ArgumentNullException^ e ) 
   {
      Console::WriteLine( "An exception occurred." );
      Console::WriteLine( "Message : {0}", e->Message );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "The following exception was raised : {0}", e->Message );
   }
}
// </Snippet1>
