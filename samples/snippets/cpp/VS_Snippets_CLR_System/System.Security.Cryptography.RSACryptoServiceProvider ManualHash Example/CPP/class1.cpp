

//<snippet1>
#using <System.dll>

using namespace System;
using namespace System::Text;
using namespace System::Security::Cryptography;
ref class Sender
{
private:
   RSAParameters rsaPubParams;
   RSAParameters rsaPrivateParams;

public:
   Sender()
   {
      RSACryptoServiceProvider^ rsaCSP = gcnew RSACryptoServiceProvider;
      
      //Generate public and private key data.
      rsaPrivateParams = rsaCSP->ExportParameters( true );
      rsaPubParams = rsaCSP->ExportParameters( false );
   }


   property RSAParameters PublicParameters 
   {
      RSAParameters get()
      {
         return rsaPubParams;
      }

   }

   //Manually performs hash and then signs hashed value.
   array<Byte>^ HashAndSign( array<Byte>^encrypted )
   {
      RSACryptoServiceProvider^ rsaCSP = gcnew RSACryptoServiceProvider;
      SHA1Managed^ hash = gcnew SHA1Managed;
      array<Byte>^hashedData;
      rsaCSP->ImportParameters( rsaPrivateParams );
      hashedData = hash->ComputeHash( encrypted );
      return rsaCSP->SignHash( hashedData, CryptoConfig::MapNameToOID( "SHA1" ) );
   }


   //Encrypts using only the public key data.
   array<Byte>^ EncryptData( RSAParameters rsaParams, array<Byte>^toEncrypt )
   {
      RSACryptoServiceProvider^ rsaCSP = gcnew RSACryptoServiceProvider;
      rsaCSP->ImportParameters( rsaParams );
      return rsaCSP->Encrypt( toEncrypt, false );
   }

};

ref class Receiver
{
private:
   RSAParameters rsaPubParams;
   RSAParameters rsaPrivateParams;

public:
   Receiver()
   {
      RSACryptoServiceProvider^ rsaCSP = gcnew RSACryptoServiceProvider;
      
      //Generate public and private key data.
      rsaPrivateParams = rsaCSP->ExportParameters( true );
      rsaPubParams = rsaCSP->ExportParameters( false );
   }


   property RSAParameters PublicParameters 
   {
      RSAParameters get()
      {
         return rsaPubParams;
      }

   }

   //Manually performs hash and then verifies hashed value.
   //<Snippet2>
   bool VerifyHash( RSAParameters rsaParams, array<Byte>^signedData, array<Byte>^signature )
   {
      RSACryptoServiceProvider^ rsaCSP = gcnew RSACryptoServiceProvider;
      SHA1Managed^ hash = gcnew SHA1Managed;
      array<Byte>^hashedData;
      rsaCSP->ImportParameters( rsaParams );
	  bool dataOK = rsaCSP->VerifyData(signedData, CryptoConfig::MapNameToOID("SHA1"), signature);
      hashedData = hash->ComputeHash( signedData );
      return rsaCSP->VerifyHash( hashedData, CryptoConfig::MapNameToOID( "SHA1" ), signature );
   }
   //</Snippet2>


   //Decrypt using the private key data.
   void DecryptData( array<Byte>^encrypted )
   {
      array<Byte>^fromEncrypt;
      String^ roundTrip;
      ASCIIEncoding^ myAscii = gcnew ASCIIEncoding;
      RSACryptoServiceProvider^ rsaCSP = gcnew RSACryptoServiceProvider;
      rsaCSP->ImportParameters( rsaPrivateParams );
      fromEncrypt = rsaCSP->Decrypt( encrypted, false );
      roundTrip = myAscii->GetString( fromEncrypt );
      Console::WriteLine( "RoundTrip: {0}", roundTrip );
   }

};

int main()
{
   array<Byte>^toEncrypt;
   array<Byte>^encrypted;
   array<Byte>^signature;
   
   //Choose a small amount of data to encrypt.
   String^ original = "Hello";
   ASCIIEncoding^ myAscii = gcnew ASCIIEncoding;
   
   //Create a sender and receiver.
   Sender^ mySender = gcnew Sender;
   Receiver^ myReceiver = gcnew Receiver;
   
   //Convert the data string to a byte array.
   toEncrypt = myAscii->GetBytes( original );
   
   //Encrypt data using receiver's public key.
   encrypted = mySender->EncryptData( myReceiver->PublicParameters, toEncrypt );
   
   //Hash the encrypted data and generate a signature on the hash
   // using the sender's private key.
   signature = mySender->HashAndSign( encrypted );
   Console::WriteLine( "Original: {0}", original );
   
   //Verify the signature is authentic using the sender's public key.
   if ( myReceiver->VerifyHash( mySender->PublicParameters, encrypted, signature ) )
   {
      
      //Decrypt the data using the receiver's private key.
      myReceiver->DecryptData( encrypted );
   }
   else
   {
      Console::WriteLine( "Invalid signature" );
   }
}

//</snippet1>
