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