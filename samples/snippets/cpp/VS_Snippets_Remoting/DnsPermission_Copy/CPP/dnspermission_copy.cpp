/*
This program demonstrates the 'Copy' method of 'DnsPermission' class.
It creates an identical copy of 'DnsPermission' instance.
*/

#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Security;
using namespace System::Security::Permissions;
using namespace System::Collections;

class DnsPermissionExample
{
   // <Snippet1>
public:
   void UseDns()
   {
      // Create a DnsPermission instance.
      DnsPermission^ myPermission = gcnew DnsPermission( PermissionState::Unrestricted );
      // Check for permission.
      myPermission->Demand();
      // Create an identical copy of the above 'DnsPermission' Object*.
      DnsPermission^ myPermissionCopy = dynamic_cast<DnsPermission^>(myPermission->Copy());
      Console::WriteLine( "Attributes and Values of 'DnsPermission' instance :" );
      // Print the attributes and values.
      PrintKeysAndValues( myPermission->ToXml()->Attributes );
      Console::WriteLine( "Attribute and values of copied instance :" );
      PrintKeysAndValues( myPermissionCopy->ToXml()->Attributes );
   }

private:
   void PrintKeysAndValues( Hashtable^ myHashtable )
   {
      // Get the enumerator that can iterate through the hash table.
      IDictionaryEnumerator^ myEnumerator = myHashtable->GetEnumerator();
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
      DnsPermissionExample * dnsPermissionExampleObj = new DnsPermissionExample;
      dnsPermissionExampleObj->UseDns();
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
