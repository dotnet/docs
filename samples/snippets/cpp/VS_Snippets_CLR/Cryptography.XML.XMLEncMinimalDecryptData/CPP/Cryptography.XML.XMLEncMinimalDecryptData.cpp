
//<SNIPPET1>
#using <System.Security.dll>
#using <System.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;
using namespace System::Security::Cryptography;
using namespace System::Security::Cryptography::Xml;
static void Encrypt( XmlDocument^ Doc, String^ ElementToEncrypt, SymmetricAlgorithm^ Alg )
{

   // Check the arguments.
   if ( Doc == nullptr )
      throw gcnew ArgumentNullException( L"Doc" );

   if ( ElementToEncrypt == nullptr )
      throw gcnew ArgumentNullException( L"ElementToEncrypt" );

   if ( Alg == nullptr )
      throw gcnew ArgumentNullException( L"Alg" );


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
   // symmetric key.
   //////////////////////////////////////////////////
   EncryptedXml^ eXml = gcnew EncryptedXml;
   array<Byte>^encryptedElement = eXml->EncryptData( elementToEncrypt, Alg, false );

   ////////////////////////////////////////////////
   // Construct an EncryptedData object and populate
   // it with the desired encryption information.
   ////////////////////////////////////////////////
   EncryptedData^ edElement = gcnew EncryptedData;
   edElement->Type = EncryptedXml::XmlEncElementUrl;

   // Create an EncryptionMethod element so that the
   // receiver knows which algorithm to use for decryption.
   // Determine what kind of algorithm is being used and
   // supply the appropriate URL to the EncryptionMethod element.
   String^ encryptionMethod = nullptr;
   if ( dynamic_cast<TripleDES^>(Alg) )
   {
      encryptionMethod = EncryptedXml::XmlEncTripleDESUrl;
   }
   else
   if ( dynamic_cast<DES^>(Alg) )
   {
      encryptionMethod = EncryptedXml::XmlEncDESUrl;
   }
   else
   if ( dynamic_cast<Rijndael^>(Alg) )
   {
      switch ( Alg->KeySize )
      {
         case 128:
            encryptionMethod = EncryptedXml::XmlEncAES128Url;
            break;

         case 192:
            encryptionMethod = EncryptedXml::XmlEncAES192Url;
            break;

         case 256:
            encryptionMethod = EncryptedXml::XmlEncAES256Url;
            break;
      }
   }
   else
   {

      // Throw an exception if the transform is not in the previous categories
      throw gcnew CryptographicException( L"The specified algorithm is not supported for XML Encryption." );
   }



   edElement->EncryptionMethod = gcnew EncryptionMethod( encryptionMethod );

   // Add the encrypted element data to the
   // EncryptedData object.
   edElement->CipherData->CipherValue = encryptedElement;

   ////////////////////////////////////////////////////
   // Replace the element from the original XmlDocument
   // object with the EncryptedData element.
   ////////////////////////////////////////////////////
   EncryptedXml::ReplaceElement( elementToEncrypt, edElement, false );
}

static void Decrypt( XmlDocument^ Doc, SymmetricAlgorithm^ Alg )
{

   // Check the arguments.
   if ( Doc == nullptr )
      throw gcnew ArgumentNullException( L"Doc" );

   if ( Alg == nullptr )
      throw gcnew ArgumentNullException( L"Alg" );


   // Find the EncryptedData element in the XmlDocument.
   XmlElement^ encryptedElement = dynamic_cast<XmlElement^>(Doc->GetElementsByTagName( L"EncryptedData" )->Item( 0 ));

   // If the EncryptedData element was not found, throw an exception.
   if ( encryptedElement == nullptr )
   {
      throw gcnew XmlException( L"The EncryptedData element was not found." );
   }


   // Create an EncryptedData object and populate it.
   EncryptedData^ edElement = gcnew EncryptedData;
   edElement->LoadXml( encryptedElement );

   // Create a new EncryptedXml object.
   EncryptedXml^ exml = gcnew EncryptedXml;

   // Decrypt the element using the symmetric key.
   array<Byte>^rgbOutput = exml->DecryptData( edElement, Alg );

   // Replace the encryptedData element with the plaintext XML element.
   exml->ReplaceData( encryptedElement, rgbOutput );
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


   // Create a new TripleDES key.
   TripleDESCryptoServiceProvider^ tDESkey = gcnew TripleDESCryptoServiceProvider;
   try
   {

      // Encrypt the "creditcard" element.
      Encrypt( xmlDoc, L"creditcard", tDESkey );

      // Display the encrypted XML to the console.
      Console::WriteLine( L"Encrypted XML:" );
      Console::WriteLine();
      Console::WriteLine( xmlDoc->OuterXml );

      // Decrypt the "creditcard" element.
      Decrypt( xmlDoc, tDESkey );

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
   finally
   {

      // Clear the TripleDES key.
      tDESkey->Clear();
   }

}

//</SNIPPET1>
