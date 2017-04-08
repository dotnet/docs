
//<SNIPPET1>
#using <System.dll>
#using <system.security.dll>

using namespace System;
using namespace System::Security::Cryptography;
using namespace System::Security::Cryptography::X509Certificates;
int main()
{
   try
   {
      X509Store^ store = gcnew X509Store( L"MY",StoreLocation::CurrentUser );
      store->Open( static_cast<OpenFlags>(OpenFlags::ReadOnly | OpenFlags::OpenExistingOnly) );
      X509Certificate2Collection^ collection = dynamic_cast<X509Certificate2Collection^>(store->Certificates);
      for ( int i = 0; i < collection->Count; i++ )
      {
         System::Collections::IEnumerator^ myEnum = collection[ i ]->Extensions->GetEnumerator();
         while ( myEnum->MoveNext() )
         {
            X509Extension^ extension = safe_cast<X509Extension^>(myEnum->Current);
            Console::WriteLine( L"{0}({1})", extension->Oid->FriendlyName, extension->Oid->Value );
            if ( extension->Oid->FriendlyName == L"Key Usage" )
            {
               X509KeyUsageExtension^ ext = dynamic_cast<X509KeyUsageExtension^>(extension);
               Console::WriteLine( ext->KeyUsages );
            }
            if ( extension->Oid->FriendlyName == L"Basic Constraints" )
            {
               X509BasicConstraintsExtension^ ext = dynamic_cast<X509BasicConstraintsExtension^>(extension);
               Console::WriteLine( ext->CertificateAuthority );
               Console::WriteLine( ext->HasPathLengthConstraint );
               Console::WriteLine( ext->PathLengthConstraint );
            }
            if ( extension->Oid->FriendlyName == L"Subject Key Identifier" )
            {
               X509SubjectKeyIdentifierExtension^ ext = dynamic_cast<X509SubjectKeyIdentifierExtension^>(extension);
               Console::WriteLine( ext->SubjectKeyIdentifier );
            }
            if ( extension->Oid->FriendlyName == L"Enhanced Key Usage" )
            {
               X509EnhancedKeyUsageExtension^ ext = dynamic_cast<X509EnhancedKeyUsageExtension^>(extension);
               OidCollection^ oids = ext->EnhancedKeyUsages;
               System::Collections::IEnumerator^ myEnum1 = oids->GetEnumerator();
               while ( myEnum1->MoveNext() )
               {
                  Oid^ oid = safe_cast<Oid^>(myEnum1->Current);
                  Console::WriteLine( L"{0}({1})", oid->FriendlyName, oid->Value );
               }
            }
         }

      }
      store->Close();
   }
   catch ( CryptographicException^ ) 
   {
      Console::WriteLine( L"Information could not be written out for this certificate." );
   }

}

//</SNIPPET1>
