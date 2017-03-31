//<Snippet1>
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;


class Alice
{
    public static void Main(string[] args)
    {
        using (Bob bob = new Bob())
        {
            using (RSACryptoServiceProvider rsaKey = new RSACryptoServiceProvider())
            {
                // Get Bob's public key
                rsaKey.ImportCspBlob(bob.key);
                byte[] encryptedSessionKey = null;
                byte[] encryptedMessage = null;
                byte[] iv = null;
                Send(rsaKey, "Secret message", out iv, out encryptedSessionKey, out encryptedMessage);
                bob.Receive(iv, encryptedSessionKey, encryptedMessage);
            }
        }
    }

    //<Snippet2>
    private static void Send(RSA key, string secretMessage, out byte[] iv, out byte[] encryptedSessionKey, out byte[] encryptedMessage)
    {
        using (Aes aes = new AesCryptoServiceProvider())
        {
            iv = aes.IV;

            // Encrypt the session key
            RSAOAEPKeyExchangeFormatter keyFormatter = new RSAOAEPKeyExchangeFormatter(key);
            encryptedSessionKey = keyFormatter.CreateKeyExchange(aes.Key, typeof(Aes));

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
public class Bob : IDisposable
{
    public byte[] key;
    private RSACryptoServiceProvider rsaKey = new RSACryptoServiceProvider();
    public Bob()
    {
        key = rsaKey.ExportCspBlob(false);
    }
    //<Snippet3>
    public void Receive(byte[] iv, byte[] encryptedSessionKey, byte[] encryptedMessage)
    {

        using (Aes aes = new AesCryptoServiceProvider())
        {
            aes.IV = iv;

            // Decrypt the session key
            RSAOAEPKeyExchangeDeformatter keyDeformatter = new RSAOAEPKeyExchangeDeformatter(rsaKey);
            aes.Key = keyDeformatter.DecryptKeyExchange(encryptedSessionKey);

            // Decrypt the message
            using (MemoryStream plaintext = new MemoryStream())
            using (CryptoStream cs = new CryptoStream(plaintext, aes.CreateDecryptor(), CryptoStreamMode.Write))
            {
                cs.Write(encryptedMessage, 0, encryptedMessage.Length);
                cs.Close();

                string message = Encoding.UTF8.GetString(plaintext.ToArray());
                Console.WriteLine(message);
            }
        }
    }
    //</Snippet3>
    public void Dispose()
    {
        rsaKey.Dispose();
    }
}
//</Snippet1>