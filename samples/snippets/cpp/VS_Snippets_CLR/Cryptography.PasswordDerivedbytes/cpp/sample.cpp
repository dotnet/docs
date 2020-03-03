//<SNIPPET1>
using namespace System;
using namespace System::Security::Cryptography;
using namespace System::Text;

// Generates a random salt value of the specified length.
array<Byte>^ CreateRandomSalt(int length)
{
    // Create a buffer
    array<Byte>^ randomBytes;

    if (length >= 1)
    {
        randomBytes = gcnew array <Byte>(length);
    }
    else
    {
        randomBytes = gcnew array <Byte>(1);
    }

    // Create a new RNGCryptoServiceProvider.
    RNGCryptoServiceProvider^ cryptoRNGProvider =
        gcnew RNGCryptoServiceProvider();

    // Fill the buffer with random bytes.
    cryptoRNGProvider->GetBytes(randomBytes);

    // return the bytes.
    return randomBytes;
}

// Clears the bytes in a buffer so they can't later be read from memory.
void ClearBytes(array<Byte>^ buffer)
{
    // Check arguments.
    if (buffer == nullptr)
    {
        throw gcnew ArgumentNullException("buffer");
    }

    // Set each byte in the buffer to 0.
    for (int x = 0; x <= buffer->Length - 1; x++)
    {
        buffer[x] = 0;
    }
}

int main(array<String^>^ args)
{

    // Get a password from the user.
    Console::WriteLine("Enter a password to produce a key:");

    // Security Note: Never hard-code a password within your
    // source code.  Hard-coded passwords can be retrieved
    // from a compiled assembly.
    array<Byte>^ password = Encoding::Unicode->GetBytes(Console::ReadLine());

    array<Byte>^ randomSalt = CreateRandomSalt(7);

    // Create a TripleDESCryptoServiceProvider object.
    TripleDESCryptoServiceProvider^ cryptoDESProvider =
        gcnew TripleDESCryptoServiceProvider();

    try
    {
        Console::WriteLine("Creating a key with PasswordDeriveBytes...");

        // Create a PasswordDeriveBytes object and then create
        // a TripleDES key from the password and salt.
        PasswordDeriveBytes^ passwordDeriveBytes = gcnew PasswordDeriveBytes
            (password->ToString(), randomSalt);

       // <Snippet2>
	   // Create the key and set it to the Key property
	   // of the TripleDESCryptoServiceProvider object.
        cryptoDESProvider->Key = passwordDeriveBytes->CryptDeriveKey
            ("TripleDES", "SHA1", 192, cryptoDESProvider->IV);
		//</Snippet2>
        Console::WriteLine("Operation complete.");
    }
    catch (Exception^ ex)
    {
        Console::WriteLine(ex->Message);
    }
    finally
    {
        // Clear the buffers
        ClearBytes(password);
        ClearBytes(randomSalt);

        // Clear the key.
        cryptoDESProvider->Clear();
    }

    Console::ReadLine();
}
//</SNIPPET1>
