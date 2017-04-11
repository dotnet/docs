// This sample demonstrates how to encrypt and decrypt messages using the
// ContosoFormatter and ContosoDeformatter classes.  These classes extend
// AsymmetricKeyExchangeFormatter and AsymmetricKeyExchangeDeformatter classes
// respectfully and can be found in their class reference.
//<Snippet9>

using System;
using System.Security.Cryptography;

namespace Contoso
{
    class ContosoEncryption
    {
        [STAThread]
        static void Main(string[] args)
        {
            string dataToEncrypt = "Sample Contoso encryption application.";
            Console.WriteLine("Data to encrypt : " + dataToEncrypt);

            // Create a public key for encryption/decryption efforts.
            RSA rsa = RSA.Create();

            // Encrypt the data and display the result to the console.
            ContosoFormatter formatter = new ContosoFormatter(rsa);
            byte[] encryptedData = formatter.CreateKeyExchange(
                System.Text.Encoding.ASCII.GetBytes(dataToEncrypt));
            Console.WriteLine("Encrypted data: " + 
                System.Text.Encoding.ASCII.GetString(encryptedData));

            // Decrypt the data and display the result to the console.
            ContosoDeformatter deformatter = new ContosoDeformatter(rsa);
            byte[] decryptedData = 
                deformatter.DecryptKeyExchange(encryptedData);
            Console.WriteLine("Data decrypted : " + 
                System.Text.Encoding.ASCII.GetString(decryptedData));

            Console.WriteLine("This sample completed successfully; " +
                "press Enter to exit.");
            Console.ReadLine();
        }
    }
}
//</Snippet9>