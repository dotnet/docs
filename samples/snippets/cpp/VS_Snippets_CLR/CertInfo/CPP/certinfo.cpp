

//<SNIPPET1>
#using <System.dll>

using namespace System;
using namespace System::Security::Cryptography;
using namespace System::Security::Permissions;
using namespace System::IO;
using namespace System::Security::Cryptography::X509Certificates;

//Reads a file.
array<Byte>^ ReadFile( String^ fileName )
{
   FileStream^ f = gcnew FileStream( fileName,FileMode::Open,FileAccess::Read );
   int size = (int)f->Length;
   array<Byte>^data = gcnew array<Byte>(size);
   size = f->Read( data, 0, size );
   f->Close();
   return data;
}

[SecurityPermissionAttribute(SecurityAction::LinkDemand, Unrestricted = true)]
int main()
{
   array<String^>^args = Environment::GetCommandLineArgs();

   //Test for correct number of arguments.
   if ( args->Length < 2 )
   {
      Console::WriteLine( "Usage: CertInfo <filename>" );
      return  -1;
   }

   try
   {
      System::Security::Cryptography::X509Certificates::X509Certificate2 ^ x509 =
            gcnew System::Security::Cryptography::X509Certificates::X509Certificate2;

      //Create X509Certificate2 object from .cer file.
      array<Byte>^rawData = ReadFile( args[ 1 ] );

      x509->Import(rawData);

      //Print to console information contained in the certificate.
      Console::WriteLine( "{0}Subject: {1}{0}", Environment::NewLine, x509->Subject );
      Console::WriteLine( "{0}Issuer: {1}{0}", Environment::NewLine, x509->Issuer );
      Console::WriteLine( "{0}Version: {1}{0}", Environment::NewLine, x509->Version );
      Console::WriteLine( "{0}Valid Date: {1}{0}", Environment::NewLine, x509->NotBefore );
      Console::WriteLine( "{0}Expiry Date: {1}{0}", Environment::NewLine, x509->NotAfter );
      Console::WriteLine( "{0}Thumbprint: {1}{0}", Environment::NewLine, x509->Thumbprint );
      Console::WriteLine( "{0}Serial Number: {1}{0}", Environment::NewLine, x509->SerialNumber );
      Console::WriteLine( "{0}Friendly Name: {1}{0}", Environment::NewLine, x509->PublicKey->Oid->FriendlyName );
      Console::WriteLine( "{0}Public Key Format: {1}{0}", Environment::NewLine, x509->PublicKey->EncodedKeyValue->Format(true) );
      Console::WriteLine( "{0}Raw Data Length: {1}{0}", Environment::NewLine, x509->RawData->Length );
      Console::WriteLine( "{0}Certificate to string: {1}{0}", Environment::NewLine, x509->ToString( true ) );
      Console::WriteLine( "{0}Certificate to XML String: {1}{0}", Environment::NewLine, x509->PublicKey->Key->ToXmlString( false ) );

      //Add the certificate to a X509Store.
      X509Store ^ store = gcnew X509Store;
      store->Open( OpenFlags::MaxAllowed );
      store->Add( x509 );
      store->Close();
   }
   catch ( DirectoryNotFoundException^ )
   {
      Console::WriteLine( "Error: The directory specified could not be found." );
   }
   catch ( IOException^ )
   {
      Console::WriteLine( "Error: A file in the directory could not be accessed." );
   }
   catch ( NullReferenceException^ )
   {
      Console::WriteLine( "File must be a .cer file. Program does not have access to that type of file." );
   }

}

//</SNIPPET1>
