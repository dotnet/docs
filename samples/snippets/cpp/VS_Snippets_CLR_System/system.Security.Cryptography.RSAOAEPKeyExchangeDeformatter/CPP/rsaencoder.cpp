// This sample demonstrates how to encode and decode a string using
// the RSAOAEPKeyExchangeFormatter and RSAOAEPKeyExchangeDeformatter classes.
//<Snippet2>
using namespace System;
using namespace System::Security::Cryptography;
using namespace System::Text;

ref class RSAEncoder
{
private:
   // Use a member variable to hold the RSA key for encoding and decoding.
   RSA^ rsaKey;

public:
   [STAThread]
   static void Main()
   {
      String^ message = L"A phrase to be encoded.";
      RSAEncoder^ rsaEncoder = gcnew RSAEncoder;
      rsaEncoder->InitializeKey( RSA::Create() );
      Console::WriteLine( L"Encoding the following message:" );
      Console::WriteLine( message );
      array<Byte>^encodedMessage = rsaEncoder->EncodeMessage( message );
      Console::WriteLine( L"Resulting message encoded:" );
      Console::WriteLine( Encoding::ASCII->GetString( encodedMessage ) );
      String^ decodedMessage = rsaEncoder->DecodeMessage( encodedMessage );
      Console::WriteLine( L"Resulting message decoded:" );
      Console::WriteLine( decodedMessage );
      
      // Construct a formatter to demonstrate how to set each property.
      rsaEncoder->ConstructFormatter();
      
      // Construct a deformatter to demonstrate how to set each property.
      rsaEncoder->ConstructDeformatter();
      Console::WriteLine( L"This sample completed successfully, "
         L" press enter to continue." );
      Console::ReadLine();
   }


private:
   // Initialize an rsaKey member variable with the specified RSA key.
   void InitializeKey( RSA^ key )
   {
      rsaKey = key;
   }

   // Use the RSAOAEPKeyExchangeDeformatter class to decode the
   // specified message.
   array<Byte>^ EncodeMessage( String^ message )
   {
      array<Byte>^encodedMessage = nullptr;
      try
      {
         
         // Construct a formatter with the specified RSA key.
         //<Snippet3>
         RSAOAEPKeyExchangeFormatter^ keyEncryptor =
            gcnew RSAOAEPKeyExchangeFormatter( rsaKey );
         //</Snippet3>

         // Convert the message to bytes to create the encrypted data.
         //<Snippet4>
         array<Byte>^byteMessage = Encoding::ASCII->GetBytes( message );
         encodedMessage = keyEncryptor->CreateKeyExchange( byteMessage );
         //</Snippet4>
      }
      catch ( Exception^ ex ) 
      {
         Console::WriteLine( L"Unexpected exception caught:{0}", ex );
      }

      return encodedMessage;
   }

   // Use the RSAOAEPKeyExchangeDeformatter class to decode the
   // specified message.
   String^ DecodeMessage( array<Byte>^encodedMessage )
   {
      String^ decodedMessage = nullptr;
      try
      {
         // Construct a deformatter with the specified RSA key.
         //<Snippet8>
         RSAOAEPKeyExchangeDeformatter^ keyDecryptor =
            gcnew RSAOAEPKeyExchangeDeformatter( rsaKey );
         //</Snippet8>

         // Decrypt the encoded message.
         //<Snippet9>
         array<Byte>^decodedBytes = keyDecryptor->DecryptKeyExchange( encodedMessage );
         //</Snippet9>

         // Retrieve a string representation of the decoded message.
         decodedMessage = Encoding::ASCII->GetString( decodedBytes );
      }
      catch ( Exception^ ex ) 
      {
         Console::WriteLine( L"Unexpected exception caught:{0}", ex );
      }

      return decodedMessage;
   }


   // Create an RSAOAEPKeyExchangeFormatter object with a new RSA key.
   // Display its properties to the console.
   void ConstructFormatter()
   {
      // Construct an empty Optimal Asymmetric Encryption Padding (OAEP)
      // key exchange.
      //<Snippet1>
      RSAOAEPKeyExchangeFormatter^ rsaFormatter = gcnew RSAOAEPKeyExchangeFormatter;
      //</Snippet1>

      // Create an RSA and set it into the specified
      // RSAOAEPKeyExchangeFormatter.
      //<Snippet5>
      RSA^ key = RSA::Create();
      rsaFormatter->SetKey( key );
      //</Snippet5>

      // Create a random number using the RNGCryptoServiceProvider provider.
      //<Snippet6>
      RNGCryptoServiceProvider^ ring = gcnew RNGCryptoServiceProvider;
      rsaFormatter->Rng = ring;
      //</Snippet6>

      // Export InverseQ and set it into the RSAOAEPKeyExchangeFormatter.
      //<Snippet7>
      rsaFormatter->Parameter = key->ExportParameters( true ).InverseQ;
      //</Snippet7>

      Console::WriteLine();
      Console::WriteLine( L"**{0}**", rsaFormatter );
      Console::Write( L"The following random number was generated using the " );
      Console::WriteLine( L"class:" );
      Console::WriteLine( rsaFormatter->Rng );
      Console::WriteLine();
      Console::Write( L"The RSA formatter contains the following InverseQ" );
      Console::WriteLine( L" parameter:" );
      Console::WriteLine( Encoding::ASCII->GetString( rsaFormatter->Parameter ) );
      Console::WriteLine();
      
      //<Snippet13>
      String^ xmlParameters = rsaFormatter->Parameters;
      //</Snippet13>

      Console::WriteLine( L"The RSA formatter has the following parameters:" );
      Console::WriteLine( xmlParameters );
   }

   // Create an RSAOAEPKeyExchangeDeformatter object with a new RSA key.
   // Display its properties to the console.
   void ConstructDeformatter()
   {
      // Construct an empty OAEP key exchange.
      //<Snippet10>
      RSAOAEPKeyExchangeDeformatter^ rsaDeformatter =
         gcnew RSAOAEPKeyExchangeDeformatter;
      //</Snippet10>

      // Create an RSAKey and set it into the specified
      // RSAOAEPKeyExchangeFormatter.
      //<Snippet11>
      RSA^ key = RSA::Create();
      rsaDeformatter->SetKey( key );
      //</Snippet11>

      Console::WriteLine();
      Console::WriteLine( L"**{0}**", rsaDeformatter );
      
      //<Snippet12>
      String^ xmlParameters = rsaDeformatter->Parameters;
      //</Snippet12>

      Console::WriteLine();
      Console::WriteLine( L"The RSA deformatter has the following " );
      Console::WriteLine( L"parameters:{0}", xmlParameters );
   }
};

int main()
{
   RSAEncoder::Main();
}

//
// This sample produces the following output:
//
// Encoding the following message:
// A phrase to be encoded.
// Resulting message encoded: %?}T:v??xu?eD)YucItjwu¦ALH HB,Uj??2xq?.?s45
// ?f?L2?=X?CPzWx???"q5?6&N"AE,Z+T?(]S?_7~,?G{?VV!:S?df?
// Resulting message decoded:
// A phrase to be encoded.
//
// **System.Security.Cryptography.RSAOAEPKeyExchangeFormatter**
// The following random number was generated using the class:
// System.Security.Cryptography.RNGCryptoServiceProvider
//
// The RSA formatter contains the following InverseQ parameter:
// 3MM??]D#?mBq_;:ws^1?ko??,_ ??A[hyWcP$?`v.>@?^!dU%\?H0N'??Ca?Ns
//
// The RSA formatter has the following parameters:
//
//
// **System.Security.Cryptography.RSAOAEPKeyExchangeDeformatter**
//
// The RSA deformatter has the following
// parameters:
// This sample completed successfully,  press enter to continue.
//</Snippet2>
