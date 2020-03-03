
//<SNIPPET1>
using namespace System;
using namespace System::IO;
using namespace System::Text;
using namespace System::Security::Cryptography;

// Generate a key k1 with password pwd1 and salt salt1.
// Generate a key k2 with password pwd1 and salt salt1.
// Encrypt data1 with key k1 using symmetric encryption, creating edata1.
// Decrypt edata1 with key k2 using symmetric decryption, creating data2.
// data2 should equal data1.

int main()
{
   array<String^>^passwordargs = Environment::GetCommandLineArgs();
   String^ usageText = "Usage: RFC2898 <password>\nYou must specify the password for encryption.\n";

   //If no file name is specified, write usage text.
   if ( passwordargs->Length == 1 )
   {
      Console::WriteLine( usageText );
   }
   else
   {
      //<SNIPPET6>
      String^ pwd1 = passwordargs[ 1 ];
      
      array<Byte>^salt1 = gcnew array<Byte>(8);
	  RNGCryptoServiceProvider ^ rngCsp = gcnew RNGCryptoServiceProvider();
		 rngCsp->GetBytes(salt1);
      //data1 can be a string or contents of a file.
      String^ data1 = "Some test data";

      //<SNIPPET3>
      //The default iteration count is 1000 so the two methods use the same iteration count.
      int myIterations = 1000;
      //</SNIPPET6>  

      //<SNIPPET2>
      try
      {
         //<SNIPPET4>
         Rfc2898DeriveBytes ^ k1 = gcnew Rfc2898DeriveBytes( pwd1,salt1,myIterations );
         Rfc2898DeriveBytes ^ k2 = gcnew Rfc2898DeriveBytes( pwd1,salt1 );
         //</SNIPPET4>

         // Encrypt the data.
         TripleDES^ encAlg = TripleDES::Create();
         encAlg->Key = k1->GetBytes( 16 );
         MemoryStream^ encryptionStream = gcnew MemoryStream;
         CryptoStream^ encrypt = gcnew CryptoStream( encryptionStream,encAlg->CreateEncryptor(),CryptoStreamMode::Write );
         array<Byte>^utfD1 = (gcnew System::Text::UTF8Encoding( false ))->GetBytes( data1 );
         //</SNIPPET2>

         encrypt->Write( utfD1, 0, utfD1->Length );
         encrypt->FlushFinalBlock();
         encrypt->Close();
         array<Byte>^edata1 = encryptionStream->ToArray();
         k1->Reset();

         // Try to decrypt, thus showing it can be round-tripped.
         TripleDES^ decAlg = TripleDES::Create();
         decAlg->Key = k2->GetBytes( 16 );
         decAlg->IV = encAlg->IV;
         MemoryStream^ decryptionStreamBacking = gcnew MemoryStream;
         CryptoStream^ decrypt = gcnew CryptoStream( decryptionStreamBacking,decAlg->CreateDecryptor(),CryptoStreamMode::Write );

         //<SNIPPET5>
         decrypt->Write( edata1, 0, edata1->Length );
         decrypt->Flush();
         decrypt->Close();
         k2->Reset();
         //</SNIPPET5>

         String^ data2 = (gcnew UTF8Encoding( false ))->GetString( decryptionStreamBacking->ToArray() );
         if (  !data1->Equals( data2 ) )
         {
            Console::WriteLine( "Error: The two values are not equal." );
         }
         else
         {
            Console::WriteLine( "The two values are equal." );
            Console::WriteLine( "k1 iterations: {0}", k1->IterationCount );
            Console::WriteLine( "k2 iterations: {0}", k2->IterationCount );
         }
      //</SNIPPET3>
      }

      catch ( Exception^ e ) 
      {
         Console::WriteLine( "Error: ", e );
      }
   }
}
//</SNIPPET1>
