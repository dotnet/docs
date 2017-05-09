// This sample demonstrates how to extend the KeyedHashAlgorithm class.
//<Snippet3>
using System;
using System.Security.Cryptography;

namespace Contoso
{
    class ContosoKeyedHash : KeyedHashAlgorithm
    {
        private KeyedHashAlgorithm keyedCrypto;

        public ContosoKeyedHash(byte[] rgbKey) 
            : this("System.Security.Cryptography.KeyedHashAlgorithm", rgbKey)
        {

        }

        public ContosoKeyedHash(String keyedHashName, byte[] rgbKey)
        {
            // Make sure we know which algorithm to use
            if (rgbKey != null) 
            {
                KeyValue = rgbKey;
                HashSizeValue = 160;
                
                // Create a KeyedHashAlgorithm encryptor
                if (keyedHashName == null) 
                {
                    //<Snippet2>
                    keyedCrypto = KeyedHashAlgorithm.Create();
                    //</Snippet2>
                } 
                else 
                {
                    //<Snippet1>
                    keyedCrypto = KeyedHashAlgorithm.Create(keyedHashName);
                    //</Snippet1>
                }
            }
            else 
            {
                throw new ArgumentNullException("rgbKey");
            }
        }

        // Override abstract methods from the HashAlgorithm class.
        public override void Initialize() {}


        //<Snippet22>
        public override byte[] Key
        {
            get
            {
                return (byte[]) keyedCrypto.Key.Clone();
            }
            set
            {
                keyedCrypto.Key = (byte[]) value.Clone();
            }
        }
        //</Snippet22>

        protected override void HashCore(
            byte[] rgbData, 
            int ibStart, 
            int cbSize)
        {

        }
        protected override byte[] HashFinal()
        {
            return new byte[0];
        }
    }
}
//</Snippet3>