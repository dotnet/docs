/*
This program demonstrates the  'IsSubsetOf' method of 'DnsPermission' class.
'IsSubsetOf' method returns true, if the current DnsPermission instance allows no
more access to DNS servers than does the specified 'DnsPermission' instance.
*/

#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Security;
using namespace System::Security::Permissions;
using namespace System::Collections;

public ref class DnsPermissionExample
{
private:
   DnsPermission^ permission;

   // <Snippet1>
public:
   void useDns()
   {
      // Create a DnsPermission instance.
      permission = gcnew DnsPermission( PermissionState::Unrestricted );
      DnsPermission^ dnsPermission1 = gcnew DnsPermission( PermissionState::None );
      // Check for permission.
      permission->Demand();
      dnsPermission1->Demand();
      // Print the attributes and values.
      Console::WriteLine( "Attributes and Values of 'DnsPermission' instance :" );
      PrintKeysAndValues( permission->ToXml()->Attributes );
      Console::WriteLine( "Attributes and Values of specified 'DnsPermission' instance :" );
      PrintKeysAndValues( dnsPermission1->ToXml()->Attributes );
      Subset( dnsPermission1 );
   }

private:
   void Subset( DnsPermission^ Permission1 )
   {
      if ( permission->IsSubsetOf( Permission1 ) )
      {
         Console::WriteLine( "Current 'DnsPermission' instance is a subset of specified 'DnsPermission' instance." );
      }
      else
      {
         Console::WriteLine( "Current 'DnsPermission' instance is not a subset of specified 'DnsPermission' instance." );
      }
   }

   void PrintKeysAndValues( Hashtable^ myList )
   {
      // Get the enumerator that can iterate through the hash table.
      IDictionaryEnumerator^ myEnumerator = myList->GetEnumerator();
      Console::WriteLine( "\t-KEY-\t-VALUE-" );
      while ( myEnumerator->MoveNext() )
      {
         Console::WriteLine( "\t {0}:\t {1}", myEnumerator->Key, myEnumerator->Value );
      }
      Console::WriteLine();
   }
   // </Snippet1>
};

int main()
{
   try
   {
      DnsPermissionExample^ dnsPermissionExampleObj = gcnew DnsPermissionExample;
      dnsPermissionExampleObj->useDns();
   }
   catch ( SecurityException^ e ) 
   {
      Console::WriteLine( "SecurityException caught!!!" );
      Console::WriteLine( "Source : {0}", e->Source );
      Console::WriteLine( "Message : {0}", e->Message );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception caught!!!" );
      Console::WriteLine( "Source : {0}", e->Source );
      Console::WriteLine( "Message : {0}", e->Message );
   }
}
