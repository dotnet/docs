
// <Snippet1>
using namespace System;
using namespace System::Reflection;

// Define a property.
public ref class TestClass
{
private:
   String^ caption;

public:
   TestClass()
   {
      caption = "A Default caption";
   }


   property String^ Caption 
   {
      String^ get()
      {
         return caption;
      }

      void set( String^ value )
      {
         if ( caption != value )
         {
            caption = value;
         }
      }

   }

};

int main()
{
   TestClass^ t = gcnew TestClass;
   
   // Get the type and PropertyInfo.
   Type^ myType = t->GetType();
   PropertyInfo^ pinfo = myType->GetProperty( "Caption" );
   
   // Display the property value, using the GetValue method.
   Console::WriteLine( "\nGetValue: {0}", pinfo->GetValue( t, nullptr ) );
   
   // Use the SetValue method to change the caption.
   pinfo->SetValue( t, "This caption has been changed.", nullptr );
   
   // Display the caption again.
   Console::WriteLine( "GetValue: {0}", pinfo->GetValue( t, nullptr ) );
   Console::WriteLine( "\nPress the Enter key to continue." );
   Console::ReadLine();
   return 0;
}

/*
This example produces the following output:
 
GetValue: A Default caption
GetValue: This caption has been changed

Press the Enter key to continue.
*/
// </Snippet1>
