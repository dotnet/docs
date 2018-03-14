//<snippet1>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Security::Cryptography;


class RijndaelMemoryExample
{
public:
    static array<Byte>^ encryptStringToBytes_AES(String^ plainText, array<Byte>^ Key, array<Byte>^ IV)
    {
        // Check arguments.
        if (!plainText || plainText->Length <= 0)
            throw gcnew ArgumentNullException("plainText");
        if (!Key || Key->Length <= 0)
            throw gcnew ArgumentNullException("Key");
        if (!IV  || IV->Length <= 0)
            throw gcnew ArgumentNullException("IV");

        // Declare the streams used
        // to encrypt to an in memory
        // array of bytes.
		MemoryStream^   msEncrypt;
        CryptoStream^   csEncrypt;
        StreamWriter^   swEncrypt;

        // Declare the RijndaelManaged object
        // used to encrypt the data.
        RijndaelManaged^ aesAlg;

        try
        {
            // Create a RijndaelManaged object
            // with the specified key and IV.
            aesAlg = gcnew RijndaelManaged();
			aesAlg->Padding = PaddingMode::PKCS7;
            aesAlg->Key = Key;
            aesAlg->IV = IV;

            // Create an encryptor to perform the stream transform.
            ICryptoTransform^ encryptor = aesAlg->CreateEncryptor(aesAlg->Key, aesAlg->IV);

            // Create the streams used for encryption.
            msEncrypt = gcnew MemoryStream();
			csEncrypt = gcnew CryptoStream(msEncrypt, encryptor, CryptoStreamMode::Write);
            swEncrypt = gcnew StreamWriter(csEncrypt);

            //Write all data to the stream.
            swEncrypt->Write(plainText);
			swEncrypt->Flush();
			csEncrypt->FlushFinalBlock();
			msEncrypt->Flush();
        }
        finally
        {
            // Clean things up.

            // Close the streams.
            if(swEncrypt)
                swEncrypt->Close();
            if (csEncrypt)
                csEncrypt->Close();


            // Clear the RijndaelManaged object.
            if (aesAlg)
                aesAlg->Clear();
        }

        // Return the encrypted bytes from the memory stream.
        return msEncrypt->ToArray();
    }

    static String^ decryptStringFromBytes_AES(array<Byte>^ cipherText, array<Byte>^ Key, array<Byte>^ IV)
    {
        // Check arguments.
        if (!cipherText || cipherText->Length <= 0)
            throw gcnew ArgumentNullException("cipherText");
        if (!Key || Key->Length <= 0)
            throw gcnew ArgumentNullException("Key");
        if (!IV || IV->Length <= 0)
            throw gcnew ArgumentNullException("IV");

        // TDeclare the streams used
        // to decrypt to an in memory
        // array of bytes.
        MemoryStream^ msDecrypt;
        CryptoStream^ csDecrypt;
        StreamReader^ srDecrypt;

        // Declare the RijndaelManaged object
        // used to decrypt the data.
        RijndaelManaged^ aesAlg;

        // Declare the string used to hold
        // the decrypted text.
        String^ plaintext;

        try
        {
            // Create a RijndaelManaged object
            // with the specified key and IV.
            aesAlg = gcnew RijndaelManaged();
			aesAlg->Padding = PaddingMode::PKCS7;
            aesAlg->Key = Key;
            aesAlg->IV = IV;

            // Create a decrytor to perform the stream transform.
			ICryptoTransform^ decryptor = aesAlg->CreateDecryptor(aesAlg->Key, aesAlg->IV);

            // Create the streams used for decryption.
            msDecrypt = gcnew MemoryStream(cipherText);
			csDecrypt = gcnew CryptoStream(msDecrypt, decryptor, CryptoStreamMode::Read);
            srDecrypt = gcnew StreamReader(csDecrypt);

            // Read the decrypted bytes from the decrypting stream
            // and place them in a string.
            plaintext = srDecrypt->ReadToEnd();
        }
        finally
        {
            // Clean things up.

            // Close the streams.
            if (srDecrypt)
                srDecrypt->Close();
            if (csDecrypt)
                csDecrypt->Close();
            if (msDecrypt)
                msDecrypt->Close();

            // Clear the RijndaelManaged object.
            if (aesAlg)
                aesAlg->Clear();
        }

        return plaintext;
    }
};

int main()
{
    try
    {
        String^ original = "Here is some data to encrypt!";

        // Create a new instance of the RijndaelManaged
        // class.  This generates a new key and initialization
        // vector (IV).
        RijndaelManaged^ myRijndael = gcnew RijndaelManaged();

        // Encrypt the string to an array of bytes.
		array<Byte>^ encrypted = RijndaelMemoryExample::encryptStringToBytes_AES(original, myRijndael->Key, myRijndael->IV);

        // Decrypt the bytes to a string.
        String^ roundtrip = RijndaelMemoryExample::decryptStringFromBytes_AES(encrypted, myRijndael->Key, myRijndael->IV);

        //Display the original data and the decrypted data.
		Console::WriteLine("Original:   {0}", original);
		Console::WriteLine("Round Trip: {0}", roundtrip);
    }
    catch (Exception^ e)
    {
		Console::WriteLine("Error: {0}", e->Message);
    }

	return 0;
}
// </Snippet1>

