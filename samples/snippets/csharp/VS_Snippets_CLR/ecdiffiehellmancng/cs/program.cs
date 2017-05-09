//<Snippet1>
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;


class Alice
{
    public static byte[] alicePublicKey;

    public static void Main(string[] args)
    {
        using (ECDiffieHellmanCng alice = new ECDiffieHellmanCng())
        {

            alice.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
            alice.HashAlgorithm = CngAlgorithm.Sha256;
            alicePublicKey = alice.PublicKey.ToByteArray();
            Bob bob = new Bob();
            CngKey k = CngKey.Import(bob.bobPublicKey, CngKeyBlobFormat.EccPublicBlob);
            byte[] aliceKey = alice.DeriveKeyMaterial(CngKey.Import(bob.bobPublicKey, CngKeyBlobFormat.EccPublicBlob));
            byte[] encryptedMessage = null;
            byte[] iv = null;
            Send(aliceKey, "Secret message", out encryptedMessage, out iv);
            bob.Receive(encryptedMessage, iv);
        }

    }

    //<Snippet2>
    private static void Send(byte[] key, string secretMessage, out byte[] encryptedMessage, out byte[] iv)
    {
        using (Aes aes = new AesCryptoServiceProvider())
        {
            aes.Key = key;
            iv = aes.IV;

            // Encrypt the message
            using (MemoryStream ciphertext = new MemoryStream())
            using (CryptoStream cs = new CryptoStream(ciphertext, aes.CreateEncryptor(), CryptoStreamMode.Write))
            {
                byte[] plaintextMessage = Encoding.UTF8.GetBytes(secretMessage);
                cs.Write(plaintextMessage, 0, plaintextMessage.Length);
                cs.Close();
                encryptedMessage = ciphertext.ToArray();
            }
        }
    }
    //</Snippet2>

}
public class Bob 
{
    public byte[] bobPublicKey;
    private byte[] bobKey;
    public Bob()
    {
        using (ECDiffieHellmanCng bob = new ECDiffieHellmanCng())
        {

            bob.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
            bob.HashAlgorithm = CngAlgorithm.Sha256;
            bobPublicKey = bob.PublicKey.ToByteArray();
            bobKey = bob.DeriveKeyMaterial(CngKey.Import(Alice.alicePublicKey, CngKeyBlobFormat.EccPublicBlob));

        }
    }

    //<Snippet3>
    public void Receive(byte[] encryptedMessage, byte[] iv)
    {

        using (Aes aes = new AesCryptoServiceProvider())
        {
            aes.Key = bobKey;
            aes.IV = iv;
            // Decrypt the message
            using (MemoryStream plaintext = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(plaintext, aes.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(encryptedMessage, 0, encryptedMessage.Length);
                    cs.Close();
                    string message = Encoding.UTF8.GetString(plaintext.ToArray());
                    Console.WriteLine(message);
                }
            }
        }
    }
    //</Snippet3>

}
//</Snippet1>