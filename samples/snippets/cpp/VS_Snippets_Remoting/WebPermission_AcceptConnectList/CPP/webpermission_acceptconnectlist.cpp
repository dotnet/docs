

// System::Net::WebPermission::ConnectList;System::Net::WebPermission::AcceptList;
/**
* This program demonstrates the the use of the ConnectList and AcceptList WebPermission
* class prerties.
* It first creates a WebPermission object with Permissionstate set to None and then
* sets the Connect and Accept access right to some predefined URLs.
* The using the AcceptList and ConnectList properties it displays the URLs that have
* the Accept and Connect permission set, respectively.
*/
#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Security;
using namespace System::Security::Permissions;
using namespace System::Collections;

class WebPermission_AcceptConnectList
{
public:
   void DisplayAcceptConnect()
   {
      // Create a 'WebPermission' object with permission state set to 'None'.
      WebPermission^ myWebPermission1 = gcnew WebPermission( PermissionState::None );

      // Allow 'Connect' access right to first set of URL's.
      myWebPermission1->AddPermission( NetworkAccess::Connect, "http://www.contoso.com" );
      myWebPermission1->AddPermission( NetworkAccess::Connect, "http://www.adventure-works.com" );
      myWebPermission1->AddPermission( NetworkAccess::Connect, "http://www.alpineskihouse.com" );

      // Allow 'Accept' access right to second set of URL's.
      myWebPermission1->AddPermission( NetworkAccess::Accept, "http://www.contoso.com" );
      myWebPermission1->AddPermission( NetworkAccess::Accept, "http://www.adventure-works.com" );
      myWebPermission1->AddPermission( NetworkAccess::Accept, "http://www.alpineskihouse.com" );

      // Check whether all callers higher in the call stack have been granted the permission or not.
      myWebPermission1->Demand();
      Console::WriteLine( "The Attributes, Values and Children of the 'WebPermission' object are :\n" );

      // Display the Attributes, Values and Children of the XML encoded instance.
      PrintKeysAndValues( myWebPermission1->ToXml()->Attributes, myWebPermission1->ToXml()->Children );

      // <Snippet1>
      // Gets all URIs with Connect permission.
      IEnumerator^ myEnum = myWebPermission1->ConnectList;
      Console::WriteLine( "\nThe URIs with Connect permission are :\n" );
      while ( myEnum->MoveNext() )
      {
         Console::WriteLine( "\tThe URI is : {0}", myEnum->Current );
      }
      // </Snippet1>

      // <Snippet2>
      // Get all URI's with Accept permission.
      IEnumerator^ myEnum1 = myWebPermission1->AcceptList;
      Console::WriteLine( "\n\nThe URIs with Accept permission are :\n" );
      while ( myEnum1->MoveNext() )
      {
         Console::WriteLine( "\tThe URI is : {0}", myEnum1->Current );
      }
      // </Snippet2>
   }

private:
   void PrintKeysAndValues( Hashtable^ myHashtable, IEnumerable^ myList )
   {
      // Get the enumerator that can iterate through Hashtabel.
      IDictionaryEnumerator^ myEnumerator = myHashtable->GetEnumerator();
      Console::WriteLine( "\t-Attribute-\t-Value-" );
      while ( myEnumerator->MoveNext() )
            Console::WriteLine( "\t {0}:\t {1}", myEnumerator->Key, myEnumerator->Value );

      Console::WriteLine();
      IEnumerator^ myEnumerator1 = myList->GetEnumerator();
      Console::WriteLine( "The Children are : \n" );
      while ( myEnumerator1->MoveNext() )
            Console::Write( myEnumerator1->Current );
   }

};

int main()
{
   try
   {
      WebPermission_AcceptConnectList * myWebPermission_AcceptConnectList = new WebPermission_AcceptConnectList;
      myWebPermission_AcceptConnectList->DisplayAcceptConnect();
   }
   catch ( SecurityException^ e ) 
   {
      Console::WriteLine( "SecurityException : {0}", e->Message );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception : {0}", e->Message );
   }
}
