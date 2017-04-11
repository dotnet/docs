

// <Snippet1>
#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Reflection;
using namespace System::Security;
using namespace System::Windows::Forms;

int main()
{
   try
   {
      // Creates a bitmask based on BindingFlags.
      BindingFlags myBindingFlags = static_cast<BindingFlags>(BindingFlags::Instance | BindingFlags::Public | BindingFlags::NonPublic);
      Type^ myTypeBindingFlags = System::Windows::Forms::Button::typeid;
      EventInfo^ myEventBindingFlags = myTypeBindingFlags->GetEvent( "Click", myBindingFlags );
      if ( myEventBindingFlags != nullptr )
      {
         Console::WriteLine( "Looking for the Click event in the Button class with the specified BindingFlags." );
         Console::WriteLine( myEventBindingFlags );
      }
      else
            Console::WriteLine( "The Click event is not available with the Button class." );
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
