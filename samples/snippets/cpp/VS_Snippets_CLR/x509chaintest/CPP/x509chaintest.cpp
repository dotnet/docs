

//<SNIPPET1>
#using <System.dll>
#using <System.Security.dll>

using namespace System;
using namespace System::Security::Cryptography;
using namespace System::Security::Cryptography::X509Certificates;
using namespace System::IO;

int main()
{
   //<SNIPPET2>
   //Create new X509 store from local certificate store.
   X509Store ^ store = gcnew X509Store( "MY",StoreLocation::CurrentUser );
   store->Open( static_cast<OpenFlags>(OpenFlags::OpenExistingOnly | OpenFlags::ReadWrite) );

   //Output store information.
   Console::WriteLine( "Store Information" );
   Console::WriteLine( "Number of certificates in the store: {0}", store->Certificates->Count );
   Console::WriteLine( "Store location: {0}", store->Location );
   Console::WriteLine( "Store name: {0} {1}", store->Name, Environment::NewLine );

   //Put certificates from the store into a collection so user can select one.
   X509Certificate2Collection ^ fcollection = dynamic_cast<X509Certificate2Collection^>(store->Certificates);
   X509Certificate2Collection ^ collection = X509Certificate2UI::SelectFromCollection(fcollection, "Select an X509 Certificate","Choose a certificate to examine.",X509SelectionFlag::SingleSelection);
   X509Certificate2 ^ certificate = collection[ 0 ];
   X509Certificate2UI::DisplayCertificate(certificate);
   //</SNIPPET2>

   //<SNIPPET3>
   //Output chain information of the selected certificate.
   X509Chain ^ ch = gcnew X509Chain;
   ch->Build( certificate );
   Console::WriteLine( "Chain Information" );
   ch->ChainPolicy->RevocationMode = X509RevocationMode::Online;
   Console::WriteLine( "Chain revocation flag: {0}", ch->ChainPolicy->RevocationFlag );
   Console::WriteLine( "Chain revocation mode: {0}", ch->ChainPolicy->RevocationMode );
   Console::WriteLine( "Chain verification flag: {0}", ch->ChainPolicy->VerificationFlags );
   Console::WriteLine( "Chain verification time: {0}", ch->ChainPolicy->VerificationTime );
   Console::WriteLine( "Chain status length: {0}", ch->ChainStatus->Length );
   Console::WriteLine( "Chain application policy count: {0}", ch->ChainPolicy->ApplicationPolicy->Count );
   Console::WriteLine( "Chain certificate policy count: {0} {1}", ch->ChainPolicy->CertificatePolicy->Count, Environment::NewLine );
   //</SNIPPET3>

   //<SNIPPET4>
   //Output chain element information.
   Console::WriteLine( "Chain Element Information" );
   Console::WriteLine( "Number of chain elements: {0}", ch->ChainElements->Count );
   Console::WriteLine( "Chain elements synchronized? {0} {1}", ch->ChainElements->IsSynchronized, Environment::NewLine );
   System::Collections::IEnumerator^ myEnum = ch->ChainElements->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      X509ChainElement ^ element = safe_cast<X509ChainElement ^>(myEnum->Current);
      Console::WriteLine( "Element issuer name: {0}", element->Certificate->Issuer );
      Console::WriteLine( "Element certificate valid until: {0}", element->Certificate->NotAfter );
      Console::WriteLine( "Element certificate is valid: {0}", element->Certificate->Verify() );
      Console::WriteLine( "Element error status length: {0}", element->ChainElementStatus->Length );
      Console::WriteLine( "Element information: {0}", element->Information );
      Console::WriteLine( "Number of element extensions: {0}{1}", element->Certificate->Extensions->Count, Environment::NewLine );
      if ( ch->ChainStatus->Length > 1 )
      {
         for ( int index = 0; index < element->ChainElementStatus->Length; index++ )
         {
            Console::WriteLine( element->ChainElementStatus[ index ].Status );
            Console::WriteLine( element->ChainElementStatus[ index ].StatusInformation );
         }
      }
   }

   store->Close();
   //</SNIPPET4>
}
//</SNIPPET1>