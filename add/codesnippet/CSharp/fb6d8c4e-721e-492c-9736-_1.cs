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