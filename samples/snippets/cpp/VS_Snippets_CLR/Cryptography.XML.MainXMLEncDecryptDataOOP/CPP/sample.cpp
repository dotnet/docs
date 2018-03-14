
//<SNIPPET1>
#using <System.Security.dll>
#using <System.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;
using namespace System::Security::Cryptography;
using namespace System::Security::Cryptography::Xml;

ref class TrippleDESDocumentEncryption
{
protected:
   XmlDocument^ docValue;
   TripleDES^ algValue;

public:
   TrippleDESDocumentEncryption( XmlDocument^ Doc, TripleDES^ Key )
   {
      if ( Doc != nullptr )
      {
         docValue = Doc;
      }
      else
      {
         throw gcnew ArgumentNullException( L"Doc" );
      }

      if ( Key != nullptr )
      {
         algValue = Key;
      }
      else
      {
         throw gcnew ArgumentNullException( L"Key" );
      }
   }


   property XmlDocument^ Doc
   {
      XmlDocument^ get()
      {
         return docValue;
      }

      void set( XmlDocument^ value )
      {
         docValue = value;
      }

   }

   property TripleDES^ Alg
   {
      TripleDES^ get()
      {
         return algValue;
      }

      void set( TripleDES^ value )
      {
         algValue = value;
      }

   }
   void Clear()
   {
      if ( algValue != nullptr )
      {
         algValue->Clear();
      }
      else
      {
         throw gcnew Exception( L"No TripleDES key was found to clear." );
      }
   }

   void Encrypt( String^ Element )
   {

      // Find the element by name and create a new
      // XmlElement object.
      XmlElement^ inputElement = dynamic_cast<XmlElement^>(docValue->GetElementsByTagName( Element )->Item( 0 ));

      // If the element was not found, throw an exception.
      if ( inputElement == nullptr )
      {
         throw gcnew Exception( L"The element was not found." );
      }


      // Create a new EncryptedXml object.
      EncryptedXml^ exml = gcnew EncryptedXml( docValue );

      // Encrypt the element using the symmetric key.
      array<Byte>^rgbOutput = exml->EncryptData( inputElement, algValue, false );

      // Create an EncryptedData object and populate it.
      EncryptedData^ ed = gcnew EncryptedData;

      // Specify the namespace URI for XML encryption elements.
      ed->Type = EncryptedXml::XmlEncElementUrl;

      // Specify the namespace URI for the TrippleDES algorithm.
      ed->EncryptionMethod = gcnew EncryptionMethod( EncryptedXml::XmlEncTripleDESUrl );

      // Create a CipherData element.
      ed->CipherData = gcnew CipherData;

      // Set the CipherData element to the value of the encrypted XML element.
      ed->CipherData->CipherValue = rgbOutput;

      // Replace the plaintext XML elemnt with an EncryptedData element.
      EncryptedXml::ReplaceElement( inputElement, ed, false );
   }

   void Decrypt()
   {

      // XmlElement object.
      XmlElement^ encryptedElement = dynamic_cast<XmlElement^>(docValue->GetElementsByTagName( L"EncryptedData" )->Item( 0 ));

      // If the EncryptedData element was not found, throw an exception.
      if ( encryptedElement == nullptr )
      {
         throw gcnew Exception( L"The EncryptedData element was not found." );
      }


      // Create an EncryptedData object and populate it.
      EncryptedData^ ed = gcnew EncryptedData;
      ed->LoadXml( encryptedElement );

      // Create a new EncryptedXml object.
      EncryptedXml^ exml = gcnew EncryptedXml;

      // Decrypt the element using the symmetric key.
      array<Byte>^rgbOutput = exml->DecryptData( ed, algValue );

      // Replace the encryptedData element with the plaintext XML elemnt.
      exml->ReplaceData( encryptedElement, rgbOutput );
   }

};

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

   // Create a new instance of the TrippleDESDocumentEncryption object
   // defined in this sample.
   TrippleDESDocumentEncryption^ xmlTDES = gcnew TrippleDESDocumentEncryption( xmlDoc,tDESkey );
   try
   {

      // Encrypt the "creditcard" element.
      xmlTDES->Encrypt( L"creditcard" );

      // Display the encrypted XML to the console.
      Console::WriteLine( L"Encrypted XML:" );
      Console::WriteLine();
      Console::WriteLine( xmlTDES->Doc->OuterXml );

      // Decrypt the "creditcard" element.
      xmlTDES->Decrypt();

      // Display the encrypted XML to the console.
      Console::WriteLine();
      Console::WriteLine( L"Decrypted XML:" );
      Console::WriteLine();
      Console::WriteLine( xmlTDES->Doc->OuterXml );
   }
   catch ( Exception^ e )
   {
      Console::WriteLine( e->Message );
   }
   finally
   {

      // Clear the TripleDES key.
      xmlTDES->Clear();
   }

   return 1;
}

//</SNIPPET1>
