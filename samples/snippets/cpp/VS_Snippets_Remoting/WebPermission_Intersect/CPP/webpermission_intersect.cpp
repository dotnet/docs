// System::Net::WebPermission::WebPermission();
// System::Net::WebPermission->AddPermission(NetworkAccess, stringuri);
// System::Net::WebPermission::Intersect;

/**
* This program shows the use of the WebPermission() constructor, the AddPermission,
* and Intersect' methods of the WebPermission' class.
* It first creates two WebPermission objects with no arguments, with each of them
* setting the access rights to one pair of URLs.
* Then it displays the attributes , values and childrens of the XML encoded instances.
* Finally, it creates a third WebPermission Object* using the logical intersection of the
* first two objects. It does so by using the Intersect method.
* It then displays the attributes , values and childrens of the related XML encoded
* instances.
*/

#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Security;
using namespace System::Security::Permissions;
using namespace System::Collections;

class WebPermissionIntersect
{
public:
   void CreateIntersect()
   {
// <Snippet1>
      // Create two WebPermission instances.
      WebPermission^ myWebPermission1 = gcnew WebPermission;
      WebPermission^ myWebPermission2 = gcnew WebPermission;
      
// <Snippet2>
      // Allow access to the first set of resources.
      myWebPermission1->AddPermission( NetworkAccess::Connect, "http://www.contoso.com/default.htm" );
      myWebPermission1->AddPermission( NetworkAccess::Connect, "http://www.adventure-works.com/default.htm" );
      
      // Check whether if the callers higher in the call stack have been granted
      // access permissions.
      myWebPermission1->Demand();
// </Snippet2>

      // Allow access right to the second set of resources.
      myWebPermission2->AddPermission( NetworkAccess::Connect, "http://www.alpineskihouse.com/default.htm" );
      myWebPermission2->AddPermission( NetworkAccess::Connect, "http://www.baldwinmuseumofscience.com/default.htm" );
      myWebPermission2->Demand();
      
// </Snippet1>
      // Display the attributes , values and childrens of the XML encoded instances.
      Console::WriteLine( "Attributes and values of  first 'WebPermission' instance are :" );
      PrintKeysAndValues( myWebPermission1->ToXml()->Attributes, myWebPermission2->ToXml()->Children );

      Console::WriteLine( "\nAttributes and values of second 'WebPermission' instance are : " );
      PrintKeysAndValues( myWebPermission2->ToXml()->Attributes, myWebPermission2->ToXml()->Children );
      
// <Snippet3>
      // Create a third WebPermission instance via the logical intersection of the previous
      // two WebPermission instances.
      WebPermission^ myWebPermission3 = (WebPermission^)(myWebPermission1->Intersect( myWebPermission2 ));

      Console::WriteLine( "\nAttributes and Values of  the WebPermission instance after the Intersect are:\n" );
      Console::WriteLine( myWebPermission3->ToXml() );
// </Snippet3>
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
      WebPermissionIntersect * myWebPermissionIntersect = new WebPermissionIntersect;
      myWebPermissionIntersect->CreateIntersect();
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
