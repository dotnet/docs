    private static void Send(RSA key, string secretMessage, out byte[] iv, out byte[] encryptedSessionKey, out byte[] encryptedMessage)
    {
        using (Aes aes = new AesCryptoServiceProvider())
        {
            iv = aes.IV;

            // Encrypt the session key
            RSAPKCS1KeyExchangeFormatter keyFormatter = new RSAPKCS1KeyExchangeFormatter(key);
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