

//<SNIPPET1>
#using <System.dll>
#using <System.Security.dll>

using namespace System;
using namespace System::Security::Cryptography;
using namespace System::Security::Cryptography::X509Certificates;
using namespace System::IO;
int main()
{
   
   //Create new X509 store called teststore from the local certificate store.
   X509Store ^ store = gcnew X509Store( "teststore",StoreLocation::CurrentUser );
   store->Open( OpenFlags::ReadWrite );
   X509Certificate2 ^ certificate = gcnew X509Certificate2;
   
   //Create certificates from certificate files.
   //You must put in a valid path to three certificates in the following constructors.
   X509Certificate2 ^ certificate1 = gcnew X509Certificate2( "c:\\mycerts\\*****.cer" );
   X509Certificate2 ^ certificate2 = gcnew X509Certificate2( "c:\\mycerts\\*****.cer" );
   X509Certificate2 ^ certificate5 = gcnew X509Certificate2( "c:\\mycerts\\*****.cer" );
   
   //Create a collection and add two of the certificates.
   X509Certificate2Collection ^ collection = gcnew X509Certificate2Collection;
   collection->Add( certificate2 );
   collection->Add( certificate5 );
   
   //Add certificates to the store.
   store->Add( certificate1 );
   store->AddRange( collection );
   X509Certificate2Collection ^ storecollection = dynamic_cast<X509Certificate2Collection^>(store->Certificates);
   Console::WriteLine( "Store name: {0}", store->Name );
   Console::WriteLine( "Store location: {0}", store->Location );
   System::Collections::IEnumerator^ myEnum = storecollection->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      X509Certificate2 ^ x509 = safe_cast<X509Certificate2 ^>(myEnum->Current);
      Console::WriteLine( "certificate name: {0}", x509->Subject );
   }

   
   //Remove a certificate.
   store->Remove( certificate1 );
   X509Certificate2Collection ^ storecollection2 = dynamic_cast<X509Certificate2Collection^>(store->Certificates);
   Console::WriteLine( "{1}Store name: {0}", store->Name, Environment::NewLine );
   System::Collections::IEnumerator^ myEnum1 = storecollection2->GetEnumerator();
   while ( myEnum1->MoveNext() )
   {
      X509Certificate2 ^ x509 = safe_cast<X509Certificate2 ^>(myEnum1->Current);
      Console::WriteLine( "certificate name: {0}", x509->Subject );
   }

   
   //Remove a range of certificates.
   store->RemoveRange( collection );
   X509Certificate2Collection ^ storecollection3 = dynamic_cast<X509Certificate2Collection^>(store->Certificates);
   Console::WriteLine( "{1}Store name: {0}", store->Name, Environment::NewLine );
   if ( storecollection3->Count == 0 )
   {
      Console::WriteLine( "Store contains no certificates." );
   }
   else
   {
      System::Collections::IEnumerator^ myEnum2 = storecollection3->GetEnumerator();
      while ( myEnum2->MoveNext() )
      {
         X509Certificate2 ^ x509 = safe_cast<X509Certificate2 ^>(myEnum2->Current);
         Console::WriteLine( "certificate name: {0}", x509->Subject );
      }
   }

   
   //Close the store.
   store->Close();
}

//</SNIPPET1>
