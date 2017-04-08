
//<SNIPPET1>
using namespace System;
using namespace System::Security::Cryptography;
using namespace System::Text;
int main()
{
   RSACryptoServiceProvider^ rsa = gcnew RSACryptoServiceProvider;
   try
   {
      
      // Note: In cases where a random key is generated,   
      // a key container is not created until you call  
      // a method that uses the key.  This example calls
      // the Encrypt method before calling the
      // CspKeyContainerInfo property so that a key
      // container is created.  
      // Create some data to encrypt and display it.
      String^ data = L"Here is some data to encrypt.";
      Console::WriteLine( L"Data to encrypt: {0}", data );
      
      // Convert the data to an array of bytes and 
      // encrypt it.
      array<Byte>^byteData = Encoding::ASCII->GetBytes( data );
      array<Byte>^encData = rsa->Encrypt( byteData, false );
      
      // Display the encrypted value.
      Console::WriteLine( L"Encrypted Data: {0}", Encoding::ASCII->GetString( encData ) );
      Console::WriteLine();
      Console::WriteLine( L"CspKeyContainerInfo information:" );
      Console::WriteLine();
      
      // Create a new CspKeyContainerInfo object.
      CspKeyContainerInfo^ keyInfo = rsa->CspKeyContainerInfo;
      
      // Display the value of each property.
      Console::WriteLine( L"Accessible property: {0}", keyInfo->Accessible );
      Console::WriteLine( L"Exportable property: {0}", keyInfo->Exportable );
      Console::WriteLine( L"HardwareDevice property: {0}", keyInfo->HardwareDevice );
      Console::WriteLine( L"KeyContainerName property: {0}", keyInfo->KeyContainerName );
      Console::WriteLine( L"KeyNumber property: {0}", keyInfo->KeyNumber );
      Console::WriteLine( L"MachineKeyStore property: {0}", keyInfo->MachineKeyStore );
      Console::WriteLine( L"Protected property: {0}", keyInfo->Protected );
      Console::WriteLine( L"ProviderName property: {0}", keyInfo->ProviderName );
      Console::WriteLine( L"ProviderType property: {0}", keyInfo->ProviderType );
      Console::WriteLine( L"RandomlyGenerated property: {0}", keyInfo->RandomlyGenerated );
      Console::WriteLine( L"Removable property: {0}", keyInfo->Removable );
      Console::WriteLine( L"UniqueKeyContainerName property: {0}", keyInfo->UniqueKeyContainerName );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( e );
   }
   finally
   {
      
      // Clear the key.
      rsa->Clear();
   }

}

//</SNIPPET1>
