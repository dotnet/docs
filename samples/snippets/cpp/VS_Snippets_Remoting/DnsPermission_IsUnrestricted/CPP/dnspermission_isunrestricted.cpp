/*
This program demonstrates the 'IsUnrestricted' method of 'DnsPermission' class.
It checks the overall permission state of the Object* and it will return true if the
'DnsPermission' instance was created with unrestricted permission state otherwise false.
*/

#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Security;
using namespace System::Security::Permissions;
using namespace System::Collections;

public ref class DnsPermissionExample
{
   // <Snippet1>
public:
   void useDns()
   {
      // Create a DnsPermission instance.
      DnsPermission^ permission = gcnew DnsPermission( PermissionState::Unrestricted );
      // Check for permission.
      permission->Demand();
      Console::WriteLine( "Attributes and Values of DnsPermission instance :" );
      // Print the attributes and values.
      PrintKeysAndValues( permission->ToXml()->Attributes );
      // Check the permission state.
      if ( permission->IsUnrestricted() )
      {
         Console::WriteLine( "Overall permissions : Unrestricted" );
      }
      else
      {
         Console::WriteLine( "Overall permissions : Restricted" );
      }
   }

private:
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
