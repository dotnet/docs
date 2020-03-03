

// <Snippet1>
#using <System.dll>

using namespace System;
using namespace System::Security::Cryptography;
int main()
{
   try
   {
      
      //initialze the Byte arrays to the public key information.
      array<Byte>^PublicKey = {214,46,220,83,160,73,40,39,201,155,19,202,3,11,191,178,56,74,90,36,248,103,18,144,170,163,145,87,54,61,34,220,222,207,137,149,173,14,92,120,206,222,158,28,40,24,30,16,175,108,128,35,230,118,40,121,113,125,216,130,11,24,90,48,194,240,105,44,76,34,57,249,228,125,80,38,9,136,29,117,207,139,168,181,85,137,126,10,126,242,120,247,121,8,100,12,201,171,38,226,193,180,190,117,177,87,143,242,213,11,44,180,113,93,106,99,179,68,175,211,164,116,64,148,226,254,172,147};
      array<Byte>^Exponent = {1,0,1};
      
      //Values to store encrypted symmetric keys.
      array<Byte>^EncryptedSymmetricKey;
      array<Byte>^EncryptedSymmetricIV;
      
      //Create a new instance of RSACryptoServiceProvider.
      RSACryptoServiceProvider^ RSA = gcnew RSACryptoServiceProvider;
      
      //Create a new instance of RSAParameters.
      RSAParameters RSAKeyInfo;
      
      //Set RSAKeyInfo to the public key values. 
      RSAKeyInfo.Modulus = PublicKey;
      RSAKeyInfo.Exponent = Exponent;
      
      //Import key parameters into RSA.
      RSA->ImportParameters( RSAKeyInfo );
      
      //Create a new instance of the RijndaelManaged class.
      RijndaelManaged^ RM = gcnew RijndaelManaged;
      
      //Encrypt the symmetric key and IV.
      EncryptedSymmetricKey = RSA->Encrypt( RM->Key, false );
      EncryptedSymmetricIV = RSA->Encrypt( RM->IV, false );
      Console::WriteLine( "RijndaelManaged Key and IV have been encrypted with RSACryptoServiceProvider." );
   }
   catch ( CryptographicException^ e ) 
   {
      
      //Catch and display a CryptographicException  
      //to the console.
      Console::WriteLine( e->Message );
   }

}

// </Snippet1>
