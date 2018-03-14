
// <SNIPPET1>
using namespace System;
using namespace System::Security::Cryptography;
using namespace System::Text;
using namespace System::IO;
void EncryptTextToFile( String^ Data, String^ FileName, array<Byte>^Key, array<Byte>^IV )
{
   try
   {
      
      // Create or open the specified file.
      FileStream^ fStream = File::Open( FileName, FileMode::OpenOrCreate );
      
      // Create a new TripleDES object.
      TripleDES^ tripleDESalg = TripleDES::Create();
      
      // Create a CryptoStream using the FileStream 
      // and the passed key and initialization vector (IV).
      CryptoStream^ cStream = gcnew CryptoStream( fStream,tripleDESalg->CreateEncryptor( Key, IV ),CryptoStreamMode::Write );
      
      // Create a StreamWriter using the CryptoStream.
      StreamWriter^ sWriter = gcnew StreamWriter( cStream );
      
      // Write the data to the stream 
      // to encrypt it.
      sWriter->WriteLine( Data );
      
      // Close the streams and
      // close the file.
      sWriter->Close();
      cStream->Close();
      fStream->Close();
   }
   catch ( CryptographicException^ e ) 
   {
      Console::WriteLine( "A Cryptographic error occurred: {0}", e->Message );
   }
   catch ( UnauthorizedAccessException^ e ) 
   {
      Console::WriteLine( "A file error occurred: {0}", e->Message );
   }

}

String^ DecryptTextFromFile( String^ FileName, array<Byte>^Key, array<Byte>^IV )
{
   try
   {
      
      // Create or open the specified file. 
      FileStream^ fStream = File::Open( FileName, FileMode::OpenOrCreate );
      
      // Create a new TripleDES object.
      TripleDES^ tripleDESalg = TripleDES::Create();
      
      // Create a CryptoStream using the FileStream 
      // and the passed key and initialization vector (IV).
      CryptoStream^ cStream = gcnew CryptoStream( fStream,tripleDESalg->CreateDecryptor( Key, IV ),CryptoStreamMode::Read );
      
      // Create a StreamReader using the CryptoStream.
      StreamReader^ sReader = gcnew StreamReader( cStream );
      
      // Read the data from the stream 
      // to decrypt it.
      String^ val = sReader->ReadLine();
      
      // Close the streams and
      // close the file.
      sReader->Close();
      cStream->Close();
      fStream->Close();
      
      // Return the string. 
      return val;
   }
   catch ( CryptographicException^ e ) 
   {
      Console::WriteLine( "A Cryptographic error occurred: {0}", e->Message );
      return nullptr;
   }
   catch ( UnauthorizedAccessException^ e ) 
   {
      Console::WriteLine( "A file error occurred: {0}", e->Message );
      return nullptr;
   }

}

int main()
{
   try
   {
      
      // Create a new TripleDES object to generate a key 
      // and initialization vector (IV).  Specify one 
      // of the recognized simple names for this 
      // algorithm.
      TripleDES^ TripleDESalg = TripleDES::Create( "TripleDES" );
      
      // Create a string to encrypt.
      String^ sData = "Here is some data to encrypt.";
      String^ FileName = "CText.txt";
      
      // Encrypt text to a file using the file name, key, and IV.
      EncryptTextToFile( sData, FileName, TripleDESalg->Key, TripleDESalg->IV );
      
      // Decrypt the text from a file using the file name, key, and IV.
      String^ Final = DecryptTextFromFile( FileName, TripleDESalg->Key, TripleDESalg->IV );
      
      // Display the decrypted string to the console.
      Console::WriteLine( Final );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( e->Message );
   }

}

// </SNIPPET1>
