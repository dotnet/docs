
//<SNIPPET1>
#using <System.Security.dll>
#using <System.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;
using namespace System::Security::Cryptography;
using namespace System::Security::Cryptography::Xml;
using namespace System::Security::Cryptography::X509Certificates;
static void Encrypt( XmlDocument^ Doc, String^ ElementToEncrypt, X509Certificate2^ Cert )
{

   // Check the arguments.
   if ( Doc == nullptr )
      throw gcnew ArgumentNullException( L"Doc" );

   if ( ElementToEncrypt == nullptr )
      throw gcnew ArgumentNullException( L"ElementToEncrypt" );

   if ( Cert == nullptr )
      throw gcnew ArgumentNullException( L"Cert" );


   ////////////////////////////////////////////////
   // Find the specified element in the XmlDocument
   // object and create a new XmlElemnt object.
   ////////////////////////////////////////////////
   XmlElement^ elementToEncrypt = dynamic_cast<XmlElement^>(Doc->GetElementsByTagName( ElementToEncrypt )->Item( 0 ));

   // Throw an XmlException if the element was not found.
   if ( elementToEncrypt == nullptr )
   {
      throw gcnew XmlException( L"The specified element was not found" );
   }


   //////////////////////////////////////////////////
   // Create a new instance of the EncryptedXml class
   // and use it to encrypt the XmlElement with the
   // X.509 Certificate.
   //////////////////////////////////////////////////
   EncryptedXml^ eXml = gcnew EncryptedXml;

   // Encrypt the element.
   EncryptedData^ edElement = eXml->Encrypt( elementToEncrypt, Cert );

   ////////////////////////////////////////////////////
   // Replace the element from the original XmlDocument
   // object with the EncryptedData element.
   ////////////////////////////////////////////////////
   EncryptedXml::ReplaceElement( elementToEncrypt, edElement, false );
}

static void Decrypt( XmlDocument^ Doc )
{

   // Check the arguments.
   if ( Doc == nullptr )
      throw gcnew ArgumentNullException( L"Doc" );


   // Create a new EncryptedXml object.
   EncryptedXml^ exml = gcnew EncryptedXml( Doc );

   // Decrypt the XML document.
   exml->DecryptDocument();
}

int main()
{

   // Create an XmlDocument object.
   XmlDocument^ xmlDoc = gcnew XmlDocument;

   // Load an XML file into the XmlDocument object.
   try
   {
      xmlDoc->PreserveWhitespace = true;
      xmlDoc->Load( L"test.xml" );
   }
   catch ( Exception^ e )
   {
      Console::WriteLine( e->Message );
      return 0;
   }


   // Create a new X509Certificate2 object by loading
   // an X.509 certificate file.  To use XML encryption
   // with an X.509 certificate, use an X509Certificate2
   // object to encrypt, but use a certificate in a certificate
   // store to decrypt.
   // You can create a new test certificate file using the
   // makecert.exe tool.
   // Create an X509Certificate2 object for encryption.
   X509Certificate2^ cert = gcnew X509Certificate2( L"test.pfx" );

   // Put the certificate in certificate store for decryption.
   X509Store^ store = gcnew X509Store( StoreLocation::CurrentUser );
   store->Open( OpenFlags::ReadWrite );
   store->Add( cert );
   store->Close();
   try
   {

      // Encrypt the "creditcard" element.
      Encrypt( xmlDoc, L"creditcard", cert );

      // Display the encrypted XML to the console.
      Console::WriteLine( L"Encrypted XML:" );
      Console::WriteLine();
      Console::WriteLine( xmlDoc->OuterXml );

      // Decrypt the "creditcard" element.
      Decrypt( xmlDoc );

      // Display the encrypted XML to the console.
      Console::WriteLine();
      Console::WriteLine( L"Decrypted XML:" );
      Console::WriteLine();
      Console::WriteLine( xmlDoc->OuterXml );
   }
   catch ( Exception^ e )
   {
      Console::WriteLine( e->Message );
   }

   return 1;
}

//</SNIPPET1>
