

//<SNIPPET1>
#using <System.dll>
#using <System.Security.dll>

using namespace System;
using namespace System::Security::Cryptography;
using namespace System::Security::Permissions;
using namespace System::IO;
using namespace System::Security::Cryptography::X509Certificates;
int main()
{
   try
   {
      X509Store ^ store = gcnew X509Store( "MY",StoreLocation::CurrentUser );
      store->Open( static_cast<OpenFlags>(OpenFlags::ReadOnly | OpenFlags::OpenExistingOnly) );
      X509Certificate2Collection ^ collection = dynamic_cast<X509Certificate2Collection^>(store->Certificates);
      X509Certificate2Collection ^ fcollection = dynamic_cast<X509Certificate2Collection^>(collection->Find( X509FindType::FindByTimeValid, DateTime::Now, false ));
      X509Certificate2Collection ^ scollection = X509Certificate2UI::SelectFromCollection(fcollection, "Test Certificate Select","Select a certificate from the following list to get information on that certificate",X509SelectionFlag::MultiSelection);
      Console::WriteLine( "Number of certificates: {0}{1}", scollection->Count, Environment::NewLine );
      System::Collections::IEnumerator^ myEnum = scollection->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         X509Certificate2 ^ x509 = safe_cast<X509Certificate2 ^>(myEnum->Current);
         array<Byte>^rawdata = x509->RawData;
         Console::WriteLine( "Content Type: {0}{1}", X509Certificate2::GetCertContentType( rawdata ), Environment::NewLine );
         Console::WriteLine( "Friendly Name: {0}{1}", x509->FriendlyName, Environment::NewLine );
         Console::WriteLine( "Certificate Verified?: {0}{1}", x509->Verify(), Environment::NewLine );
         Console::WriteLine( "Simple Name: {0}{1}", x509->GetNameInfo( X509NameType::SimpleName, true ), Environment::NewLine );
         Console::WriteLine( "Signature Algorithm: {0}{1}", x509->SignatureAlgorithm->FriendlyName, Environment::NewLine );
         Console::WriteLine( "Private Key: {0}{1}", x509->PrivateKey->ToXmlString( false ), Environment::NewLine );
         Console::WriteLine( "Public Key: {0}{1}", x509->PublicKey->Key->ToXmlString( false ), Environment::NewLine );
         Console::WriteLine( "Certificate Archived?: {0}{1}", x509->Archived, Environment::NewLine );
         Console::WriteLine( "Length of Raw Data: {0}{1}", x509->RawData->Length, Environment::NewLine );
         x509->Reset();
      }
      store->Close();
   }
   catch ( CryptographicException^ ) 
   {
      Console::WriteLine( "Information could not be written out for this certificate." );
   }

}

//</SNIPPET1>
