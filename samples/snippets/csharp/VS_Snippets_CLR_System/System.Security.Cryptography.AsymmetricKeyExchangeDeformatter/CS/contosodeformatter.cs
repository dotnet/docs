// This class demonstrates how to extend the AsymmetricKeyExchangeDeformatter
// abstract class.
//<Snippet1>
using System;
using System.Security.Cryptography;

namespace Contoso
{
    public class ContosoDeformatter : AsymmetricKeyExchangeDeformatter
    {
        private RSA rsaKey;

        // Default constructor.
        public ContosoDeformatter(){}

        // Constructor with the public key to use for encryption.
        //<Snippet2>
        public ContosoDeformatter(AsymmetricAlgorithm key)
        {
            SetKey(key);
        }
        //</Snippet2>

        // Set the public key for encyption operations.
        //<Snippet5>
        public override void SetKey(AsymmetricAlgorithm key) {
            if (key != null)
            {
                rsaKey = (RSA)key;
            }
            else
            {
                throw new ArgumentNullException("key");
            }
        }
        //</Snippet5>

        // Disallow access to the parameters of the formatter.
        //<Snippet3>
        public override String Parameters 
        {
            get { return null; }
            set { ; }
        }
        //</Snippet3>

        //<Snippet4>
        // Create the encrypted key exchange data from the specified input
        // data. This method uses the RSACryptoServiceProvider only. To
        // support additional providers or provide custom decryption logic,
        // add logic to this member.
        public override byte[] DecryptKeyExchange(byte[] rgbData) {
            byte[] decryptedBytes = null;

            if (rsaKey != null)
            {
                if (rsaKey is RSACryptoServiceProvider)
                {
                    RSACryptoServiceProvider serviceProvder =
                        (RSACryptoServiceProvider)rsaKey;

                    decryptedBytes = serviceProvder.Decrypt(rgbData, true);
                }
                // Add custom decryption logic here.
            }
            else
            {
                throw new CryptographicUnexpectedOperationException(
                    "Cryptography_MissingKey");
            }

            return decryptedBytes;
        }
        //</Snippet4>
    }
}
//
// This code example produces the following output:
//
// Data to encrypt : Sample Contoso encryption application.
// Encrypted data: Khasdf-3248&$%23
// Data decrypted : Sample Contoso encryption application.
// 
// This sample completed successfully; press Enter to exit.
//</Snippet1>