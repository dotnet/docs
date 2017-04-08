
//<Snippet1>
using namespace System;
using namespace System::Security;
using namespace System::Security::Permissions;
using namespace System::Security::Cryptography;

public ref class KeyContainerPermissionDemo
{
private:
   static CspParameters^ cspParams = gcnew CspParameters;
   static RSACryptoServiceProvider^ rsa = gcnew RSACryptoServiceProvider;
   static String^ providerName;
   static int providerType;
   static String^ myKeyContainerName;

   // Create three KeyContainerPermissionAccessEntry objects, each with a different constructor.
   //<Snippet2>
   static KeyContainerPermissionAccessEntry^ keyContainerPermAccEntry1 = gcnew KeyContainerPermissionAccessEntry( "MyKeyContainer",KeyContainerPermissionFlags::Create );

   //</Snippet2>
   //<Snippet3>
   static KeyContainerPermissionAccessEntry^ keyContainerPermAccEntry2 = gcnew KeyContainerPermissionAccessEntry( cspParams,KeyContainerPermissionFlags::Open );

   //</Snippet3>
   //<Snippet4>
   static KeyContainerPermissionAccessEntry^ keyContainerPermAccEntry3 = gcnew KeyContainerPermissionAccessEntry( "Machine",providerName,providerType,myKeyContainerName,1,KeyContainerPermissionFlags::Open );

public:

   //</Snippet4>
   static int Main()
   {
      try
      {
         
         // Create a key container for use in the sample.
         GenKey_SaveInContainer( "MyKeyContainer" );
         
         // Initialize property values for creating a KeyContainerPermissionAccessEntry object.
         myKeyContainerName = rsa->CspKeyContainerInfo->KeyContainerName;
         providerName = rsa->CspKeyContainerInfo->ProviderName;
         providerType = rsa->CspKeyContainerInfo->ProviderType;
         cspParams->KeyContainerName = myKeyContainerName;
         cspParams->ProviderName = providerName;
         cspParams->ProviderType = providerType;
         
         // Display the KeyContainerPermissionAccessEntry properties using 
         // the third KeyContainerPermissionAccessEntry object.
         DisplayAccessEntryMembers();
         
         //<Snippet22>
         // Add access entry objects to a key container permission.
         KeyContainerPermission ^ keyContainerPerm1 = gcnew KeyContainerPermission( PermissionState::Unrestricted );
         Console::WriteLine( "Is the permission unrestricted? {0}", keyContainerPerm1->IsUnrestricted() );
         keyContainerPerm1->AccessEntries->Add( keyContainerPermAccEntry1 );
         keyContainerPerm1->AccessEntries->Add( keyContainerPermAccEntry2 );
         
         //</Snippet22>
         // Display the permission.
         System::Console::WriteLine( keyContainerPerm1->ToXml() );
         
         //<Snippet13>
         // Create an array of KeyContainerPermissionAccessEntry objects
         array<KeyContainerPermissionAccessEntry^>^keyContainerPermAccEntryArray = {keyContainerPermAccEntry1,keyContainerPermAccEntry2};
         
         // Create a new KeyContainerPermission using the array.
         KeyContainerPermission ^ keyContainerPerm2 = gcnew KeyContainerPermission( KeyContainerPermissionFlags::AllFlags,keyContainerPermAccEntryArray );
         
         //</Snippet13>
         DisplayPermissionMembers( keyContainerPerm2, keyContainerPermAccEntryArray );
         
         // Demonstrate the effect of a deny for opening a key container.
         DenyOpen();
         
         // Demonstrate the deletion of a key container.           
         DeleteContainer();
         Console::WriteLine( "Press the Enter key to exit." );
         Console::ReadKey();
         return 0;
         
         // Close the current try block that did not expect an exception.
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( "Unexpected exception thrown:  {0}", e->Message );
         return 0;
      }

   }


private:
   static void DisplayAccessEntryMembers()
   {
      
      //<Snippet5>
      Console::WriteLine( "\nKeycontainerName is {0}", keyContainerPermAccEntry3->KeyContainerName );
      
      //</Snippet5>
      //<Snippet6>
      Console::WriteLine( "KeySpec is {0}", (1 == keyContainerPermAccEntry3->KeySpec ? "AT_KEYEXCHANGE " : "AT_SIGNATURE") );
      
      //</Snippet6>
      //<Snippet7>
      Console::WriteLine( "KeyStore is {0}", keyContainerPermAccEntry3->KeyStore );
      
      //</Snippet7>
      //<Snippet8>
      Console::WriteLine( "ProviderName is {0}", keyContainerPermAccEntry3->ProviderName );
      
      //</Snippet8>
      //<Snippet9>
      Console::WriteLine( "ProviderType is {0}", (1 == keyContainerPermAccEntry3->ProviderType ? "PROV_RSA_FULL" : keyContainerPermAccEntry3->ProviderType.ToString()) );
      
      //</Snippet9>
      //<Snippet10>
      Console::WriteLine( "Hashcode = {0}", keyContainerPermAccEntry3->GetHashCode() );
      
      //</Snippet10>
      //<Snippet11>
      Console::WriteLine( "Are the KeyContainerPermissionAccessEntry objects equal? {0}", keyContainerPermAccEntry3->Equals( keyContainerPermAccEntry2 ) );
      
      //</Snippet11>
   }

   static void DisplayPermissionMembers( KeyContainerPermission ^ keyContainerPerm2, array<KeyContainerPermissionAccessEntry^>^keyContainerPermAccEntryArray )
   {
      
      // Display the KeyContainerPermission properties.
      //<Snippet12>
      Console::WriteLine( "\nFlags value is {0}", keyContainerPerm2->Flags );
      
      //</Snippet12>
      //<Snippet14>
      KeyContainerPermission ^ keyContainerPerm3 = dynamic_cast<KeyContainerPermission^>(keyContainerPerm2->Copy());
      Console::WriteLine( "Is the copy equal to the original? {0}", keyContainerPerm3->Equals( keyContainerPerm2 ) );
      
      //</Snippet14>
      //<Snippet15>
      // Perform an XML roundtrip.
      keyContainerPerm3->FromXml( keyContainerPerm2->ToXml() );
      Console::WriteLine( "Was the XML roundtrip successful? {0}", keyContainerPerm3->Equals( keyContainerPerm2 ) );
      
      //</Snippet15>
      KeyContainerPermission ^ keyContainerPerm4 = gcnew KeyContainerPermission( KeyContainerPermissionFlags::Open,keyContainerPermAccEntryArray );
      
      //<Snippet16>
      KeyContainerPermission ^ keyContainerPerm5 = dynamic_cast<KeyContainerPermission^>(keyContainerPerm2->Intersect( keyContainerPerm4 ));
      Console::WriteLine( "Flags value after the intersection is {0}", keyContainerPerm5->Flags );
      
      //</Snippet16>
      //<Snippet17>
      keyContainerPerm5 = dynamic_cast<KeyContainerPermission^>(keyContainerPerm2->Union( keyContainerPerm4 ));
      
      //</Snippet17>
      //<Snippet18>
      Console::WriteLine( "Flags value after the union is {0}", keyContainerPerm5->Flags );
      
      //</Snippet18>
      //<Snippet19>
      Console::WriteLine( "Is one permission a subset of the other? {0}", keyContainerPerm4->IsSubsetOf( keyContainerPerm2 ) );
      
      //</Snippet19>
   }

   static void GenKey_SaveInContainer( String^ containerName )
   {
      
      // Create the CspParameters object and set the key container 
      // name used to store the RSA key pair.
      cspParams = gcnew CspParameters;
      cspParams->KeyContainerName = containerName;
      
      // Create a new instance of RSACryptoServiceProvider that accesses
      // the key container identified by the containerName parameter.
      rsa = gcnew RSACryptoServiceProvider( cspParams );
      
      // Display the key information to the console.
      Console::WriteLine( "\nKey added to container: \n  {0}", rsa->ToXmlString( true ) );
   }

   static void GetKeyFromContainer( String^ containerName )
   {
      try
      {
         cspParams = gcnew CspParameters;
         cspParams->KeyContainerName = containerName;
         
         // Create a new instance of RSACryptoServiceProvider that accesses
         // the key container identified by the containerName parameter.
         // If the key container does not exist, a new one is created.
         rsa = gcnew RSACryptoServiceProvider( cspParams );
         
         // Use the rsa object to access the key. 
         // Display the key information to the console.
         Console::WriteLine( "\nKey retrieved from container : \n {0}", rsa->ToXmlString( true ) );
         Console::WriteLine( "KeycontainerName is {0}", rsa->CspKeyContainerInfo->KeyContainerName );
         Console::WriteLine( "ProviderName is {0}", rsa->CspKeyContainerInfo->ProviderName );
         Console::WriteLine( "ProviderType is {0}", (1 == rsa->CspKeyContainerInfo->ProviderType ? "PROV_RSA_FULL" : rsa->CspKeyContainerInfo->ProviderType.ToString()) );
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( "Exception thrown:  {0}", e->Message );
      }

   }

   static void DeleteKeyContainer( String^ containerName )
   {
      
      // Create the CspParameters object and set the key container 
      // name used to store the RSA key pair.
      cspParams = gcnew CspParameters;
      cspParams->KeyContainerName = containerName;
      
      // Create a new instance of RSACryptoServiceProvider that accesses
      // the key container.
      rsa = gcnew RSACryptoServiceProvider( cspParams );
      
      // Do not persist the key entry, effectively deleting the key.
      rsa->PersistKeyInCsp = false;
      
      // Call Clear to release the key container resources.
      rsa->Clear();
      Console::WriteLine( "\nKey container released." );
   }

   static void DenyOpen()
   {
      try
      {
         
         //<Snippet20>
         // Create a KeyContainerPermission with the right to open the key container.
         KeyContainerPermission ^ keyContainerPerm = gcnew KeyContainerPermission( KeyContainerPermissionFlags::Open );
         
         //</Snippet20>
         // Demonstrate the results of a deny for an open action.
         keyContainerPerm->Deny();
         
         // The next line causes an exception to be thrown when the infrastructure code attempts 
         // to open the key container.
         CspKeyContainerInfo ^ info = gcnew CspKeyContainerInfo( cspParams );
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( "Expected exception thrown: {0}", e->Message );
      }

      
      // Revert the deny.
      CodeAccessPermission::RevertDeny();
   }

   static void DeleteContainer()
   {
      try
      {
         
         // Create a KeyContainerPermission with the right to create a key container.
         KeyContainerPermission ^ keyContainerPerm = gcnew KeyContainerPermission( KeyContainerPermissionFlags::Create );
         
         // Deny the ability to create a key container.
         // This deny is used to show the key container has been successfully deleted.
         keyContainerPerm->Deny();
         
         // Retrieve the key from the container.
         // This code executes successfully because the key container already exists.
         // The deny for permission to create a key container does not affect this method call.
         GetKeyFromContainer( "MyKeyContainer" );
         
         // Delete the key and the container.
         DeleteKeyContainer( "MyKeyContainer" );
         
         // Attempt to obtain the key from the deleted key container.
         // This time the method call results in an exception because of
         // an attempt to create a new key container.
         Console::WriteLine( "\nAttempt to create a new key container with create permission denied." );
         GetKeyFromContainer( "MyKeyContainer" );
      }
      catch ( CryptographicException^ e ) 
      {
         Console::WriteLine( "Expected exception thrown: {0}", e->Message );
      }

   }

};

int main()
{
   return KeyContainerPermissionDemo::Main();
}

//</Snippet1>
