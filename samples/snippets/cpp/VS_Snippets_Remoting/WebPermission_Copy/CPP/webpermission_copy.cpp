// System::Net::WebPermission::WebPermission(PermissionState);System::Net::WebPermission::Copy;

/**
* This program demonstrates the  WebPermission(PermissionState) constructor and
* Copy method of the WebPermission class .
* It creates a WebPermission instance with Permissionstate set to None and
* sets the access right to one pair of URLs.
* Then it uses the Copy method  to create another instance of WebPermission class
* Finally, the attributes , values and childrens  of both the XML encoded instances
* are displayed.
*/

#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Security;
using namespace System::Security::Permissions;
using namespace System::Collections;

public ref class CopyWebPermission
{
public:
   void CreateCopy()
   {
// <Snippet1>
      // Create a WebPermission instance.
      WebPermission^ myWebPermission1 = gcnew WebPermission( PermissionState::None );
      
      // Allow access to the first set of URL's.
      myWebPermission1->AddPermission( NetworkAccess::Connect, "http://www.microsoft.com/default.htm" );
      myWebPermission1->AddPermission( NetworkAccess::Connect, "http://www.msn.com" );
      
      // Check whether all callers higher in the call stack have been granted the permissionor not.
      myWebPermission1->Demand();
// </Snippet1>

// <Snippet2>
      // Create another WebPermission instance that is the copy of the above WebPermission instance.
      WebPermission^ myWebPermission2 = (WebPermission^)(myWebPermission1->Copy());
      
      // Check whether all callers higher in the call stack have been granted the permissionor not.
      myWebPermission2->Demand();
// </Snippet2>

      Console::WriteLine( "The Attributes and Values are :\n" );
      // Display the Attributes, Values and Children of the XML encoded instance.
      PrintKeysAndValues( myWebPermission1->ToXml()->Attributes, myWebPermission1->ToXml()->Children );
      Console::WriteLine( "\nCopied Instance Attributes and Values are:\n" );
      
      // Display the Attributes, Values and Children of the XML encoded copied instance.
      PrintKeysAndValues( myWebPermission2->ToXml()->Attributes, myWebPermission2->ToXml()->Children );
   }

private:
   void PrintKeysAndValues( Hashtable^ myHashtable, IEnumerable^ myList )
   {
      // Gets the enumerator that can iterate through Hashtable.
      IDictionaryEnumerator^ myEnumerator = myHashtable->GetEnumerator();
      Console::WriteLine( "\t-KEY-\t-VALUE-" );
      while ( myEnumerator->MoveNext() )
      {
         Console::WriteLine( "\t {0}:\t {1}", myEnumerator->Key, myEnumerator->Value );
      }
      Console::WriteLine();

      IEnumerator^ myEnumerator1 = myList->GetEnumerator();
      Console::WriteLine( "The Children are: " );
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
      CopyWebPermission^ myCopyWebPermission = gcnew CopyWebPermission;
      myCopyWebPermission->CreateCopy();
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
