// System::Net::WebPermission::WebPermission(NetworkAccess, Regex);

/*
This program demonstrates the  'WebPermission(NetworkAccess, Regex)' constructor of 'WebPermission' class.
First  a 'Regex' Object* is created that will accept all the urls which is having the hostfragment of
'www.contoso.com'.Then a 'WebPermission' Object* created by passing the 'NetworkAccess' permission and
'Regex' Object* as parameters. It  checks the 'WebPermission' for all the url's having the host fragment
as 'www.contoso.com'.
*/

#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Security;
using namespace System::Security::Permissions;
using namespace System::Text::RegularExpressions;
using namespace System::Collections;

class WebPermission_regexConstructor
{
public:
   void CreateRegexConstructor()
   {
// <Snippet1>
      // Create an instance of 'Regex' that accepts all URL's containing the host
      // fragment 'www.contoso.com'.
      Regex^ myRegex = gcnew Regex( "http://www.contoso.com/.*" );
      
      // Create a WebPermission that gives the permissions to all the hosts containing
      // the same fragment.
      WebPermission^ myWebPermission = gcnew WebPermission( NetworkAccess::Connect,myRegex );
      
      // Checks all callers higher in the call stack have been granted the permission.
      myWebPermission->Demand();
// </Snippet1>

      Console::WriteLine( "Attribute and Values of WebPermission are : \n" );
      // Display the Attributes, Values and Children of the XML encoded copied instance.
      PrintKeysAndValues( myWebPermission->ToXml()->Attributes, myWebPermission->ToXml()->Children );
   }

private:
   void PrintKeysAndValues( Hashtable^ myHashtable, IEnumerable^ myList )
   {
      // Get the enumerator that can iterate through Hashtable.
      IDictionaryEnumerator^ myEnumerator = myHashtable->GetEnumerator();
      Console::WriteLine( "\t-ATTRIBUTES-\t-VALUE-" );
      while ( myEnumerator->MoveNext() )
      {
         Console::WriteLine( "\t {0}:\t {1}", myEnumerator->Key, myEnumerator->Value );
      }

      Console::WriteLine();

      IEnumerator^ myEnumerator1 = myList->GetEnumerator();
      Console::WriteLine( "\nThe Children are : " );
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
      WebPermission_regexConstructor * myWebPermissionRegex = new WebPermission_regexConstructor;
      myWebPermissionRegex->CreateRegexConstructor();
   }
   catch ( SecurityException^ e ) 
   {
      Console::WriteLine( "SecurityException raised: {0}", e->Message );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception raised: {0}", e->Message );
   }
}
