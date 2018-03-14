
// This sample demonstrates how to implement a custom asymmetric algorithm
// inherited from the AsymmetricAlgorithm base class.
//<Snippet3>
#using <System.Xml.dll>
#using <System.Security.dll>

using namespace System;
using namespace System::Xml;
using namespace System::Text;
using namespace System::Security::Cryptography;

// Display the properties of the specified CustomCrypto object to the
// console.
static void DisplayProperties(Contoso::CustomCrypto^ customCryptoAlgorithm)
{
    // Retrieve the class description for the customCrypto object.
    //<Snippet8>
    String^ classDescription = customCryptoAlgorithm->ToString();
    //</Snippet8>

    Console::WriteLine(classDescription);
    Console::WriteLine("KeyExchangeAlgorithm: {0}",
        customCryptoAlgorithm->KeyExchangeAlgorithm);
    Console::WriteLine("SignatureAlgorithm: {0}",
        customCryptoAlgorithm->SignatureAlgorithm);
    Console::WriteLine("KeySize: {0}",
        customCryptoAlgorithm->KeySize);
    Console::WriteLine("Parameters described in Xml format:");
    Console::WriteLine(customCryptoAlgorithm->ToXmlString(true));

    // Display the MinSize, MaxSize, and SkipSize properties of
    // each KeySize item in the local keySizes member variable.
    //<Snippet10>
    array<KeySizes^>^ legalKeySizes = customCryptoAlgorithm->LegalKeySizes;
    for (int i = 0; i < legalKeySizes->Length; i++)
    {
        Console::WriteLine(
            "Keysize{0} min, max, step: {1}, {2}, {3}, ", i,
            legalKeySizes[i]->MinSize,
            legalKeySizes[i]->MaxSize,
            legalKeySizes[i]->SkipSize);
    }
    //</Snippet10>
}

[STAThread]
int main()
{
    // Construct a CustomCrypto object and initialize its
    // CspParameters.
    Contoso::CustomCrypto^ customCryptoAlgorithm = gcnew Contoso::CustomCrypto();
    customCryptoAlgorithm->InitializeParameters();

    // Display properties of the current customCrypto object.
    Console::WriteLine(
        "*** CustomCrypto created with default parameters:");
    DisplayProperties(customCryptoAlgorithm);

    // Release all the resources used by this instance of
    // CustomCrypto.
    //<Snippet1>
    customCryptoAlgorithm->Clear();
    //</Snippet1>

    customCryptoAlgorithm = gcnew Contoso::CustomCrypto(64);
    // Create new parameters and set them by using the FromXmlString
    // method.
    String^ parameterXml = "<CustomCryptoKeyValue>" +
        "<ProviderName>Contoso</ProviderName>" +
        "<KeyContainerName>SecurityBin2</KeyContainerName>" +
        "<KeyNumber>1</KeyNumber>" +
        "<ProviderType>2</ProviderType>" +
        "</CustomCryptoKeyValue>";
    customCryptoAlgorithm->FromXmlString(parameterXml);

    // Display the properties of a customCrypto object created with
    // custom parameters.
    Console::WriteLine(
        "{0}*** CustomCrypto created with custom parameters:", Environment::NewLine);
    DisplayProperties(customCryptoAlgorithm);

    // Create an object by using the assembly name.
    Contoso::CustomCrypto^ cryptoFromAssembly =
        Contoso::CustomCrypto::Create("CustomCrypto");
    if (cryptoFromAssembly != nullptr)
    {
        Console::WriteLine("{0}*** Successfully created " +
            "CustomCrypto from the Create method.", Environment::NewLine);
        DisplayProperties(cryptoFromAssembly);
    }
    else
    {
        Console::WriteLine("Unable to create CustomCrypto from " +
            "the Create method.");
    }

    Console::WriteLine(
        "This sample completed successfully; press Enter to exit.");
    Console::ReadLine();
}

//
// This sample produces the following output:
//
// *** CustomCrypto created with default parameters:
// Contoso.vbCustomCrypto
// KeyExchangeAlgorithm: RSA-PKCS1-KeyEx
// SignatureAlgorithm: http://www.w3.org/2000/09/xmldsig#rsa-sha1
// KeySize: 8
// Parameters described in Xml format:
// <CustomCryptoKeyValue><KeyContainerName>SecurityBin1</KeyContainerName>
// <KeyNumber>1</KeyNumber><ProviderName>Contoso</ProviderName>
// <ProviderType>2</ProviderType></CustomCryptoKeyValue>
// Keysize0 min, max, step: 8, 64, 8,
//
// *** CustomCrypto created with custom parameters:
// Contoso.vbCustomCrypto
// KeyExchangeAlgorithm: RSA-PKCS1-KeyEx
// SignatureAlgorithm: http://www.w3.org/2000/09/xmldsig#rsa-sha1
// KeySize: 64
// Parameters described in Xml format:
// <CustomCryptoKeyValue><KeyContainerName>SecurityBin2</KeyContainerName>
// <KeyNumber>1</KeyNumber><ProviderName>Contoso</ProviderName>
// <ProviderType>2</ProviderType></CustomCryptoKeyValue>
// Keysize0 min, max, step: 8, 64, 8,
// Unable to create CustomCrypto from the Create method
// This sample completed successfully; press Enter to exit.
//</Snippet3>
