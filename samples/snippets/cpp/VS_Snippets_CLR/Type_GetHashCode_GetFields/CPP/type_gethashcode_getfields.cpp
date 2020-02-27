

// <Snippet1>
#using <system.dll>
#using <system.windows.forms.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Security;
using namespace System::Reflection;

int main()
{
   Type^ myType = System::Net::IPAddress::typeid;
   array<FieldInfo^>^myFields = myType->GetFields( static_cast<BindingFlags>(BindingFlags::Static | BindingFlags::NonPublic) );
   Console::WriteLine( "\nThe IPAddress class has the following nonpublic fields: " );
   System::Collections::IEnumerator^ myEnum = myFields->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      FieldInfo^ myField = safe_cast<FieldInfo^>(myEnum->Current);
      Console::WriteLine( myField );
   }

   Type^ myType1 = System::Net::IPAddress::typeid;
   array<FieldInfo^>^myFields1 = myType1->GetFields();
   Console::WriteLine( "\nThe IPAddress class has the following public fields: " );
   System::Collections::IEnumerator^ myEnum2 = myFields1->GetEnumerator();
   while ( myEnum2->MoveNext() )
   {
      FieldInfo^ myField = safe_cast<FieldInfo^>(myEnum2->Current);
      Console::WriteLine( myField );
   }

   try
   {
      Console::WriteLine( "The HashCode of the System::Windows::Forms::Button type is: {0}", System::Windows::Forms::Button::typeid->GetHashCode() );
   }
   catch ( SecurityException^ e ) 
   {
      Console::WriteLine( "An exception occurred." );
      Console::WriteLine( "Message: {0}", e->Message );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "An exception occurred." );
      Console::WriteLine( "Message: {0}", e->Message );
   }
}
// </Snippet1>
