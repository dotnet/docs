// This class demonstrates how to extend the AsymmetricKeyExchangeFormatter
// abstract class.
//<Snippet1>
using System;
using System.Security.Cryptography;

namespace Contoso
{
    public class ContosoFormatter : AsymmetricKeyExchangeFormatter  
    {
        private RSA rsaKey;

        // Default constructor.
        public ContosoFormatter(){}

        // Constructor with the public key to use for encryption.
        //<Snippet2>
        public ContosoFormatter(AsymmetricAlgorithm key)
        {
            SetKey(key);
        }
        //</Snippet2>

        // Disallow access to the parameters of the formatter.
        //<Snippet3>
        public override String Parameters 
        {
            get { return null; }
        }
        //</Snippet3>

        //<Snippet4>
        // Create the encrypted key exchange data from the specified input
        // data. This method uses the RSACryptoServiceProvider only.  
        // To support additional providers or provide custom encryption logic,
        // add logic to this member.
        public override byte[] CreateKeyExchange(byte[] sourceData) 
        {
            byte[] encryptedData = null;
            if (rsaKey != null) 
            {
                if (rsaKey is RSACryptoServiceProvider) 
                {
                    encryptedData = ((RSACryptoServiceProvider) rsaKey).
                        Encrypt(sourceData, true);
                } 
                // Add additional algorithm support here.
            } 
            else 
            {
                throw new CryptographicUnexpectedOperationException(
                    "Cryptography_MissingKey");
            }

            return encryptedData;
        }
        //</Snippet4>

        // Set the public key for encyption operations.
        //<Snippet5>
        public override void SetKey(AsymmetricAlgorithm key) 
        {
            if (key != null) 
            {
                rsaKey = (RSA) key;
            }
            else
            {
                throw new ArgumentNullException("key");
            }
        }
        //</Snippet5>

        // The second parameter is not used in the current version.
        // Simply call the default CreateKeyExchange method.
        //<Snippet6>
        public override byte[] CreateKeyExchange(
            byte[] sourceData,
            Type symAlgType) 
        {
            return CreateKeyExchange(sourceData);
        }
        //</Snippet6>
    }
}
//
// This code example produces the following output:
//
// Data to encrypt : Sample Contoso encryption application.
// Encrypted data: @X&*^&F78879&F*&(*D
// Data decrypted : Sample Contoso encryption application.
// 
// This sample completed successfully; press Enter to exit.
//</Snippet1>