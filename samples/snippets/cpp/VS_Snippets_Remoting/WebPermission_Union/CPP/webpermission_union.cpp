// System::Net::WebPermission::WebPermission(NetworkAccess, uriString);System::Net::WebPermission::Union;

/**
* This program shows the use of the WebPermission(NetworkAccess access, String* uriString)
* constructor and Union method of the WebPermission' class.
* It creates two instance of the WebPermission class with the  specified access
* rights to the predefined URIs.
* It displays the attributes , values and childrens of those XML encoded
* instances.
* Then, using the Union method, it creates a third WebPermission instance
* via a logical union of the first two.
* Finally, it displays the attributes , values and childrens of those XML encoded
* instances.
*/

#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Security;
using namespace System::Security::Permissions;
using namespace System::Collections;

public ref class WebPermissionUnion
{
public:
   void CreateUnion()
   {
// <Snippet1>
      // Create a WebPermission::instance.
      WebPermission^ myWebPermission1 = gcnew WebPermission( NetworkAccess::Connect,"http://www.contoso.com/default.htm" );
      myWebPermission1->Demand();
// </Snippet1>

      // Create another WebPermission instance.
      WebPermission^ myWebPermission2 = gcnew WebPermission( NetworkAccess::Connect,"http://www.adventure-works.com" );
      myWebPermission2->Demand();
      
      // Print the attributes, values and childrens of the XML encoded instances.
      Console::WriteLine( "Attributes and values of the first WebPermission are : " );
      PrintKeysAndValues( myWebPermission1->ToXml()->Attributes, myWebPermission1->ToXml()->Children );

      Console::WriteLine( "\nAttributes and values of the second WebPermission are : " );
      PrintKeysAndValues( myWebPermission2->ToXml()->Attributes, myWebPermission2->ToXml()->Children );
      
// <Snippet2>
      // Create another WebPermission that is the Union of previous two WebPermission
      // instances.
      WebPermission^ myWebPermission3 = (WebPermission^)(myWebPermission1->Union( myWebPermission2 ));
      Console::WriteLine( "\nAttributes and values of the WebPermission after the Union are : " );
      // Display the attributes, values and children.
      Console::WriteLine( myWebPermission3->ToXml() );
// </Snippet2>
   }

private:
   void PrintKeysAndValues( Hashtable^ myHashtable, IEnumerable^ myList )
   {
      // Get the enumerator that can iterate through Hashtable.
      IDictionaryEnumerator^ myEnumerator = myHashtable->GetEnumerator();
      Console::WriteLine( "\t-KEY-\t-VALUE-" );
      while ( myEnumerator->MoveNext() )
      {
         Console::WriteLine( "\t {0}:\t {1}", myEnumerator->Key, myEnumerator->Value );
      }

      Console::WriteLine();
      IEnumerator^ myEnumerator1 = myList->GetEnumerator();
      Console::WriteLine( "The Children are : " );
      while ( myEnumerator1->MoveNext() )
      {
         Console::Write( "\t {0}", myEnumerator1->Current );
      }
   }
};

int main()
{
   try
   {
      WebPermissionUnion^ myWebPermissionUnion = gcnew WebPermissionUnion;
      myWebPermissionUnion->CreateUnion();
   }
   catch ( SecurityException^ e ) 
   {
      Console::WriteLine( "SecurityException: {0}", e->Message );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception: {0}", e->Message );
   }
}
