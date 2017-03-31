
//<SNIPPET1>
#using <System.Xml.dll>
#using <System.Security.dll>
#using <System.dll>

using namespace System;
using namespace System::Xml;
using namespace System::Security::Cryptography;
using namespace System::Security::Cryptography::Xml;
static void Encrypt( XmlDocument^ Doc, String^ ElementToEncrypt, RSA^ Alg, String^ KeyName )
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
   // a new random symmetric key.
   //////////////////////////////////////////////////
   // Create a 256 bit Rijndael key.
   RijndaelManaged^ sessionKey = gcnew RijndaelManaged;
   sessionKey->KeySize = 256;
   EncryptedXml^ eXml = gcnew EncryptedXml;
   array<Byte>^encryptedElement = eXml->EncryptData( elementToEncrypt, sessionKey, false );

   ////////////////////////////////////////////////
   // Construct an EncryptedData object and populate
   // it with the desired encryption information.
   ////////////////////////////////////////////////
   EncryptedData^ edElement = gcnew EncryptedData;
   edElement->Type = EncryptedXml::XmlEncElementUrl;

   // Create an EncryptionMethod element so that the
   // receiver knows which algorithm to use for decryption.
   edElement->EncryptionMethod = gcnew EncryptionMethod( EncryptedXml::XmlEncAES256Url );

   // Encrypt the session key and add it to an EncryptedKey element.
   EncryptedKey^ ek = gcnew EncryptedKey;
   array<Byte>^encryptedKey = EncryptedXml::EncryptKey( sessionKey->Key, Alg, false );
   ek->CipherData = gcnew CipherData( encryptedKey );
   ek->EncryptionMethod = gcnew EncryptionMethod( EncryptedXml::XmlEncRSA15Url );

   // Set the KeyInfo element to specify the
   // name of the RSA key.
   // Create a new KeyInfo element.
   edElement->KeyInfo = gcnew KeyInfo;

   // Create a new KeyInfoName element.
   KeyInfoName^ kin = gcnew KeyInfoName;

   // Specify a name for the key.
   kin->Value = KeyName;

   // Add the KeyInfoName element to the
   // EncryptedKey object.
   ek->KeyInfo->AddClause( kin );

   // Add the encrypted key to the
   // EncryptedData object.
   edElement->KeyInfo->AddClause( gcnew KeyInfoEncryptedKey( ek ) );

   // Add the encrypted element data to the
   // EncryptedData object.
   edElement->CipherData->CipherValue = encryptedElement;

   ////////////////////////////////////////////////////
   // Replace the element from the original XmlDocument
   // object with the EncryptedData element.
   ////////////////////////////////////////////////////
   EncryptedXml::ReplaceElement( elementToEncrypt, edElement, false );
}

static void Decrypt( XmlDocument^ Doc, RSA^ Alg, String^ KeyName )
{

   // Check the arguments.
   if ( Doc == nullptr )
      throw gcnew ArgumentNullException( L"Doc" );

   if ( Alg == nullptr )
      throw gcnew ArgumentNullException( L"Alg" );

   if ( KeyName == nullptr )
      throw gcnew ArgumentNullException( L"KeyName" );


   // Create a new EncryptedXml object.
   EncryptedXml^ exml = gcnew EncryptedXml( Doc );

   // Add a key-name mapping.
   // This method can only decrypt documents
   // that present the specified key name.
   exml->AddKeyNameMapping( KeyName, Alg );

   // Decrypt the element.
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


   // Create a new RSA key.  This key will encrypt a symmetric key,
   // which will then be imbedded in the XML document.
   RSA^ rsaKey = gcnew RSACryptoServiceProvider;
   try
   {

      // Encrypt the "creditcard" element.
      Encrypt( xmlDoc, L"creditcard", rsaKey, L"rsaKey" );

      // Display the encrypted XML to the console.
      Console::WriteLine( L"Encrypted XML:" );
      Console::WriteLine();
      Console::WriteLine( xmlDoc->OuterXml );
	  xmlDoc->Save( L"test.xml" );

      // Decrypt the "creditcard" element.
      Decrypt( xmlDoc, rsaKey, L"rsaKey" );

      // Display the encrypted XML to the console.
      Console::WriteLine();
      Console::WriteLine( L"Decrypted XML:" );
      Console::WriteLine();
      Console::WriteLine( xmlDoc->OuterXml );
	  xmlDoc->Save( L"test.xml" );
   }
   catch ( Exception^ e )
   {
      Console::WriteLine( e->Message );
   }
   finally
   {

      // Clear the RSA key.
      rsaKey->Clear();
   }

   return 1;
}
//</SNIPPET1>
