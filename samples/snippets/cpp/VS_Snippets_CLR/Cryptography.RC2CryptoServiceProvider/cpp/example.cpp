//<SNIPPET1>
using namespace System;
using namespace System::IO;
using namespace System::Text;
using namespace System::Security::Cryptography;

int main()
{
    array <Byte>^ originalBytes = 
        ASCIIEncoding::ASCII->GetBytes("Here is some data.");

    //Create a new RC2CryptoServiceProvider.
    RC2CryptoServiceProvider^ rc2Provider = 
        gcnew RC2CryptoServiceProvider();
    rc2Provider->UseSalt = true;

    rc2Provider->GenerateKey();
    rc2Provider->GenerateIV();

    //Encrypt the data.
    MemoryStream^ encryptionMemoryStream = gcnew MemoryStream();
    CryptoStream^ encryptionCryptoStream = gcnew CryptoStream(
        encryptionMemoryStream, rc2Provider->CreateEncryptor(
        rc2Provider->Key, rc2Provider->IV), CryptoStreamMode::Write);

    //Write all data to the crypto stream and flush it.
    encryptionCryptoStream->Write(originalBytes, 0, originalBytes->Length);
    encryptionCryptoStream->FlushFinalBlock();

    //Get encrypted array of bytes.
    array<Byte>^ encryptedBytes = encryptionMemoryStream->ToArray();

    //Decrypt the previously encrypted message.
    MemoryStream^ decryptionMemoryStream = 
        gcnew MemoryStream(encryptedBytes);
    CryptoStream^ decryptionCryptoStream = 
        gcnew CryptoStream(decryptionMemoryStream,
        rc2Provider->CreateDecryptor(rc2Provider->Key,rc2Provider->IV),
        CryptoStreamMode::Read);

    array<Byte>^ unencryptedBytes = 
        gcnew array<Byte>(originalBytes->Length); 

    //Read the data out of the crypto stream.
    decryptionCryptoStream->Read(unencryptedBytes, 0, 
        unencryptedBytes->Length);

    //Convert the byte array back into a string.
    String^ plainText = ASCIIEncoding::ASCII->GetString(unencryptedBytes);

    //Display the results.
    Console::WriteLine("Unencrypted text: {0}", plainText);

    Console::ReadLine();
}

//</SNIPPET1>