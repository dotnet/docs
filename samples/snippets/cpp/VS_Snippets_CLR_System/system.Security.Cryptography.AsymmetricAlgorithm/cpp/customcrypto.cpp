// This class creates a custom crytographic object based on the asymmetric
// algorithm by extending the abstract base class AsymmetricAlgorithm.
//<Snippet2>
#using <System.Xml.dll>
#using <System.Security.dll>

using namespace System;
using namespace System::Xml;
using namespace System::Text;
using namespace System::Security::Cryptography;
using namespace System::Reflection;

[assembly: AssemblyKeyFile("CustomCrypto.snk")];
[assembly: AssemblyVersion("1.0.0.0")];
[assembly: CLSCompliant(true)];
namespace Contoso
{
    // Define a CustomCrypto class that inherits from the AsymmetricAlgorithm
    // class.
    public ref class CustomCrypto :
        public System::Security::Cryptography::AsymmetricAlgorithm
        {
            // Declare local member variables.
        private:
            CspParameters^ cryptoServiceParameters;
            array<KeySizes^>^ customValidKeySizes;

            // Initialize a CustomCrypto with the default key size of 8.
        public:
            CustomCrypto()
            {
                customValidKeySizes = 
                    gcnew array<KeySizes^>{gcnew KeySizes(8, 64, 8)};
                this->KeySize = 8;
            }

            // Initialize a CustomCrypto with the specified key size.
        public:
            CustomCrypto(int keySize)
            {
                customValidKeySizes = 
                    gcnew array<KeySizes^>{gcnew KeySizes(8, 64, 8)};
                this->KeySize = keySize;
            }

            // Accessor function for keySizes member variable.
        public:
            property array<KeySizes^>^ LegalKeySizes
            {
                virtual array<KeySizes^>^ get() override
                {
                    return (array<KeySizes^>^)customValidKeySizes->Clone();
                }
            }

            // Modify the KeySizeValue property inherited from the Asymmetric
            // class. Prior to setting the value, ensure it falls within the
            // range identified in the local keySizes member variable.
            //<Snippet9>
        public:
            property int KeySize
            {
                virtual int get() override
                {
                    return KeySizeValue;
                }

                virtual void set(int value) override
                {
                    for (int i = 0; i < customValidKeySizes->Length; i++)
                    {
                        if (customValidKeySizes[i]->SkipSize == 0)
                        {
                            if (customValidKeySizes[i]->MinSize == value)
                            {
                                KeySizeValue = value;
                                return;
                            }
                        }
                        else
                        {
                            for (int j = customValidKeySizes[i]->MinSize;
                                j <= customValidKeySizes[i]->MaxSize;
                                j += customValidKeySizes[i]->SkipSize)
                            {
                                if (j == value)
                                {
                                    KeySizeValue = value;
                                    return;
                                }
                            }
                        }
                    }

                    // If the key does not fall within the range identified
                    // in the keySizes member variable, throw an exception.
                    throw gcnew CryptographicException("Invalid key size.");
                }
            }
            //</Snippet9>

            // Initialize the parameters with default values.
        public:
            void InitializeParameters()
            {
                cryptoServiceParameters = gcnew CspParameters();
                cryptoServiceParameters->ProviderName = "Contoso";
                cryptoServiceParameters->KeyContainerName = "SecurityBin1";
                cryptoServiceParameters->KeyNumber = 1;
                cryptoServiceParameters->ProviderType = 2;
            }

            // Parse specified xmlString for values to populate the CspParams
            //<Snippet4>
            // Expected XML schema:
            //  <CustomCryptoKeyValue>
            //      <ProviderName></ProviderName>
            //      <KeyContainerName></KeyContainerName>
            //      <KeyNumber></KeyNumber>
            //      <ProviderType></ProviderType>
            //  </CustomCryptoKeyValue>
        public:
            virtual void FromXmlString(String^ xmlString) override 
            {
                if (xmlString != nullptr)
                {
                    XmlDocument^ document = gcnew XmlDocument();
                    document->LoadXml(xmlString);
                    XmlNode^ firstNode = document->FirstChild;
                    XmlNodeList^ nodeList;

                    // Assemble parameters from values in each XML element.
                    cryptoServiceParameters = gcnew CspParameters();

                    // KeyContainerName is optional.
                    nodeList = 
                        document->GetElementsByTagName("KeyContainerName");
                    if (nodeList->Count > 0)
                    {
                        cryptoServiceParameters->KeyContainerName =
                            nodeList->Item(0)->InnerText;
                    }

                    // KeyNumber is optional.
                    nodeList = document->GetElementsByTagName("KeyNumber");
                    if (nodeList->Count > 0)
                    {
                        cryptoServiceParameters->KeyNumber =
                            Int32::Parse(nodeList->Item(0)->InnerText);
                    }

                    // ProviderName is optional.
                    nodeList = document->GetElementsByTagName("ProviderName");
                    if (nodeList->Count > 0)
                    {
                        cryptoServiceParameters->ProviderName =
                            nodeList->Item(0)->InnerText;
                    }

                    // ProviderType is optional.
                    nodeList = document->GetElementsByTagName("ProviderType");
                    if (nodeList->Count > 0)
                    {
                        cryptoServiceParameters->ProviderType =
                            Int32::Parse(nodeList->Item(0)->InnerText);
                    }
                }
                else
                {
                    throw gcnew ArgumentNullException("xmlString");
                }
            }
            //</Snippet4>

            // Create an XML string representation of the parameters in the
            // current customCrypto object.
            //<Snippet5>
        public:
            virtual String^ ToXmlString(bool includePrivateParameters) override
            {
                String^ keyContainerName = "";
                String^ keyNumber = "";
                String^ providerName = "";
                String^ providerType = "";

                if (cryptoServiceParameters != nullptr)
                {
                    keyContainerName = 
                        cryptoServiceParameters->KeyContainerName;
                    keyNumber = cryptoServiceParameters->KeyNumber.ToString();
                    providerName = cryptoServiceParameters->ProviderName;
                    providerType = 
                        cryptoServiceParameters->ProviderType.ToString();
                }

                StringBuilder^ sb = gcnew StringBuilder();
                sb->Append("<CustomCryptoKeyValue>");

                sb->Append("<KeyContainerName>");
                sb->Append(keyContainerName);
                sb->Append("</KeyContainerName>");

                sb->Append("<KeyNumber>");
                sb->Append(keyNumber);
                sb->Append("</KeyNumber>");

                sb->Append("<ProviderName>");
                sb->Append(providerName);
                sb->Append("</ProviderName>");

                sb->Append("<ProviderType>");
                sb->Append(providerType);
                sb->Append("</ProviderType>");

                sb->Append("</CustomCryptoKeyValue>");
                return(sb->ToString());
            }
            //</Snippet5>

            // Return the name for the key exchange algorithm.
            //<Snippet6>
        public:
            property String^ KeyExchangeAlgorithm 
            {
                virtual String^ get() override
                {
                    return "RSA-PKCS1-KeyEx";
                }
            }
            //</Snippet6>

            // Retrieves the name of the signature alogrithm.
            //<Snippet7>
        public:
            property String^ SignatureAlgorithm
            {
                virtual String^ get() override
                {
                    return "http://www.w3.org/2000/09/xmldsig#rsa-sha1";
                }
            }
            //</Snippet7>

            // Required member for implementing the AsymmetricAlgorithm class.
		protected:
			virtual ~CustomCrypto()
			{
			}

            // Call the Create method using the CustomCrypto assembly name.
            //<Snippet11>
            // The create function attempts to create a CustomCrypto 
            // object using the assembly name. This functionality requires 
            // modification of the machine.config file. Add the following 
            // section to the configuration element and modify the values 
            // of the cryptoClass to reflect what isinstalled 
            // in your machines GAC.
            //<mscorlib>
            //  <cryptographySettings>
            //    <cryptoNameMapping>
            //      <cryptoClasses>
            //        <cryptoClass CustomCrypto="Contoso.CustomCrypto,
            //          CustomCrypto,
            //          Culture=neutral,
            //          PublicKeyToken=fdb9f9c4851028bf,
            //          Version=1.0.1448.27640" />
            //      </cryptoClasses>
            //      <nameEntry name="Contoso.CustomCrypto" 
            //         class="CustomCrypto" />
            //      <nameEntry name="CustomCrypto" class="CustomCrypto" />
            //    </cryptoNameMapping>
            //  </cryptographySettings>
            //</mscorlib>

        public:
            static CustomCrypto^ Create() 
            {
                return Create("CustomCrypto");
            }
            //</Snippet11>

            // Create a CustomCrypto object by calling CrytoConfig's
            // CreateFromName method and casting the type to CustomCrypto.
            //<Snippet12>
            // The create function attempts to create a CustomCrypto object 
            // using the assembly name. This functionality requires 
            // modification of the machine.config file. Add the following 
            // section to the configuration element and modify the values 
            // of the cryptoClass to reflect what is installed 
            // in your machines GAC.
            //<mscorlib>
            // <cryptographySettings>
            //   <cryptoNameMapping>
            //     <cryptoClasses>
            //       <cryptoClass CustomCrypto="Contoso.CustomCrypto,
            //         CustomCrypto,
            //         Culture=neutral,
            //         PublicKeyToken=fdb9f9c4851028bf,
            //         Version=1.0.1448.27640" />
            //     </cryptoClasses>
            //     <nameEntry name="Contoso.CustomCrypto" 
            //        class="CustomCrypto" />
            //     <nameEntry name="CustomCrypto" class="CustomCrypto" />
            //    </cryptoNameMapping>
            //  </cryptographySettings>
            //</mscorlib>

        public:
            static CustomCrypto^ Create(String^ algorithmName) 
            {
                return (CustomCrypto^) 
                    CryptoConfig::CreateFromName(algorithmName);
            }
            //</Snippet12>
        };
}
//</Snippet2>
