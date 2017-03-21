    class CustomCryptoImpl
    {
        [STAThread]
        static void Main(string[] args)
        {
            // Construct a CustomCrypto object and initialize its
            // CspParameters.
            CustomCrypto customCrypto = new CustomCrypto();
            customCrypto.InitializeParameters();

            // Display properties of the current customCrypto object.
            Console.WriteLine("*** CustomCrypto created with default " + 
                "parameters:");
            DisplayProperties(customCrypto);

            // Release all the resources used by this instance of 
            // CustomCrytpo.
            customCrypto.Clear();

            customCrypto = new CustomCrypto(64);
            // Create new parameters and set them by using the FromXmlString
            // method.
            string parameterXml = "<CustomCryptoKeyValue>";
            parameterXml += "<ProviderName>Contoso</ProviderName>";
            parameterXml += "<KeyContainerName>SecurityBin2";
            parameterXml += "</KeyContainerName>";
            parameterXml += "<KeyNumber>1</KeyNumber>";
            parameterXml += "<ProviderType>2</ProviderType>";
            parameterXml += "</CustomCryptoKeyValue>";
            customCrypto.FromXmlString(parameterXml);

            // Display the properties of a customCrypto object created with
            // custom parameters.
            Console.WriteLine("\n*** " + 
                "CustomCrypto created with custom parameters:");
            DisplayProperties(customCrypto);

            // Create an object by using the assembly name.
            try
            {
                CustomCrypto myCryptoA = CustomCrypto.Create("CustomCrypto");
                if (myCryptoA != null)
                {
                    Console.Write("\n*** " + 
                        "Successfully created CustomCrytpo from");
                    Console.WriteLine(" the Create method.");

                    DisplayProperties(myCryptoA);
                }
                else
                {
                    Console.Write("Unable to create CustomCrytpo from ");
                    Console.WriteLine(" the Create method.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
            Console.WriteLine("This sample completed successfully; " +
                "press Enter to exit.");
            Console.ReadLine();
        }
        // Display the properties of the specified CustomCrypto object to the
        // console.
        public static void DisplayProperties(CustomCrypto customCrypto)
        {
            try
            {
                // Retrieve the class description for the customCrypto object.
                string classDescription = customCrypto.ToString();

                Console.WriteLine(classDescription);
                Console.Write("KeyExchangeAlgorithm: ");
                Console.WriteLine(customCrypto.KeyExchangeAlgorithm);
                Console.Write("SignatureAlgorithm: ");
                Console.WriteLine(customCrypto.SignatureAlgorithm);
                Console.WriteLine("KeySize: " + customCrypto.KeySize);
                Console.WriteLine("Parameters described in Xml format:");
                Console.WriteLine(customCrypto.ToXmlString(true));

                // Display the MinSize, MaxSize, and SkipSize properties of 
                // each KeySize item in the local keySizes member variable.
                KeySizes[] legalKeySizes = customCrypto.LegalKeySizes;
                if (legalKeySizes.Length > 0)
                {
                    for (int i=0; i < legalKeySizes.Length; i++)
                    {
                        Console.Write("Keysize" + i + " min, max, step: ");
                        Console.Write(legalKeySizes[i].MinSize + ", ");
                        Console.Write(legalKeySizes[i].MaxSize + ", ");
                        Console.WriteLine(legalKeySizes[i].SkipSize + ", ");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Caught unexpected exception: " + 
                    ex.ToString());
            }
        }
    }
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
// Unable to create CustomCrytpo from  the Create method
// This sample completed successfully; press Exit to continue.