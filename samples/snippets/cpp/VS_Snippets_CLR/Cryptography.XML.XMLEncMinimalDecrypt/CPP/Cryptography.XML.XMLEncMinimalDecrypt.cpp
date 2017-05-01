
//<SNIPPET1>
#using <System.Security.dll>
#using <System.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;
using namespace System::Security::Cryptography;
using namespace System::Security::Cryptography::Xml;
static void Encrypt( XmlDocument^ Doc, String^ ElementToEncrypt, SymmetricAlgorithm^ Alg, String^ KeyName )
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
   
   // Add the key mapping.
   eXml->AddKeyNameMapping( KeyName, Alg );
   
   // Encrypt the element.
   EncryptedData^ edElement = eXml->Encrypt( elementToEncrypt, KeyName );
   
   ////////////////////////////////////////////////////
   // Replace the element from the original XmlDocument
   // object with the EncryptedData element.
   ////////////////////////////////////////////////////
   EncryptedXml::ReplaceElement( elementToEncrypt, edElement, false );
}

static void Decrypt( XmlDocument^ Doc, SymmetricAlgorithm^ Alg, String^ KeyName )
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
   
   // Add the key name mapping.
   exml->AddKeyNameMapping( KeyName, Alg );
   
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
   }

   
   // Create a new TripleDES key. 
   TripleDESCryptoServiceProvider^ tDESkey = gcnew TripleDESCryptoServiceProvider;
   try
   {
      
      // Encrypt the "creditcard" element.
      Encrypt( xmlDoc, L"creditcard", tDESkey, L"tDesKey" );
      
      // Display the encrypted XML to the console.
      Console::WriteLine( L"Encrypted XML:" );
      Console::WriteLine();
      Console::WriteLine( xmlDoc->OuterXml );
      
      // Decrypt the "creditcard" element.
      Decrypt( xmlDoc, tDESkey, L"tDesKey" );
      
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
