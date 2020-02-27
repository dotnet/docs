//<snippet1>
using namespace System;
using namespace System::Security::Cryptography;
using namespace System::Text;

class EncryptorExample
{
public:
     static void Main()
     {
         TripleDESCryptoServiceProvider^ tdesCSP = gcnew TripleDESCryptoServiceProvider();

         tdesCSP->GenerateKey();
         tdesCSP->GenerateIV();
         String^ quote =
             "Things may come to those who wait, but only the " +
             "things left by those who hustle. -- Abraham Lincoln";
         array<Byte>^ encQuote = EncryptString(tdesCSP, quote);

         Console::WriteLine("Encrypted Quote:\n");
         Console::WriteLine(Convert::ToBase64String(encQuote));

         Console::WriteLine("\nDecrypted Quote:\n");
         Console::WriteLine(DecryptBytes(tdesCSP, encQuote));
     }

     //<snippet2>
public:
     static array<Byte>^ EncryptString(SymmetricAlgorithm^ symAlg, String^ inString)
     {
         array<Byte>^ inBlock = UnicodeEncoding::Unicode->GetBytes(inString);
         ICryptoTransform^ xfrm = symAlg->CreateEncryptor();
         array<Byte>^ outBlock = xfrm->TransformFinalBlock(inBlock, 0, inBlock->Length);

         return outBlock;
     }
     //</snippet2>

     //<snippet3>
     static String^ DecryptBytes(SymmetricAlgorithm^ symAlg, array<Byte>^ inBytes)
     {
         ICryptoTransform^ xfrm = symAlg->CreateDecryptor();
         array<Byte>^ outBlock = xfrm->TransformFinalBlock(inBytes, 0, inBytes->Length);

         return UnicodeEncoding::Unicode->GetString(outBlock);
     }
     //</snippet3>
};

int main()
{
    EncryptorExample::Main();
}
//</snippet1>
