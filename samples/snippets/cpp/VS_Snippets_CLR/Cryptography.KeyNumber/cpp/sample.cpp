using namespace System;
using namespace System::IO;
using namespace System::Text;
using namespace System::Security::Cryptography;

int main()
{
    //<SNIPPET1>
    // Create a new CspParameters object.
    CspParameters^ cspParams = gcnew CspParameters();

    // Specify an exchange key.
    cspParams->KeyNumber = (int) KeyNumber::Exchange;

    // Initialize the RSACryptoServiceProvider
    // with the CspParameters object.
    RSACryptoServiceProvider^ RSACSP = gcnew RSACryptoServiceProvider(cspParams);
    //</SNIPPET1>
};

