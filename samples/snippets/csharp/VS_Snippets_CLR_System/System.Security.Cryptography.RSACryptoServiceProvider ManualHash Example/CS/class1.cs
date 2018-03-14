//<Snippet1>
using System;
using System.Text;
using System.Security.Cryptography;

namespace RSACryptoServiceProvider_Examples
{
    class MyMainClass
    {
        static void Main()
        {
            byte[] toEncrypt;
            byte[] encrypted;
            byte[] signature;
            //Choose a small amount of data to encrypt.
            string original = "Hello";
            ASCIIEncoding myAscii = new ASCIIEncoding();

            //Create a sender and receiver.
            Sender mySender = new Sender();
            Receiver myReceiver = new Receiver();

            //Convert the data string to a byte array.
            toEncrypt = myAscii.GetBytes(original);

            //Encrypt data using receiver's public key.
            encrypted = mySender.EncryptData(myReceiver.PublicParameters, toEncrypt);

            //Hash the encrypted data and generate a signature on the hash
            // using the sender's private key.
            signature = mySender.HashAndSign(encrypted);

            Console.WriteLine("Original: {0}", original);

            //Verify the signature is authentic using the sender's public key.
            if (myReceiver.VerifyHash(mySender.PublicParameters, encrypted, signature))
            {
                //Decrypt the data using the receiver's private key.
                myReceiver.DecryptData(encrypted);
            }
            else
            {
                Console.WriteLine("Invalid signature");
            }
        }
    }

    class Sender
    {
        RSAParameters rsaPubParams;
        RSAParameters rsaPrivateParams;

        public Sender()
        {
            RSACryptoServiceProvider rsaCSP = new RSACryptoServiceProvider();

            //Generate public and private key data.
            rsaPrivateParams = rsaCSP.ExportParameters(true);
            rsaPubParams = rsaCSP.ExportParameters(false);
        }

        public RSAParameters PublicParameters
        {
            get
            {
                return rsaPubParams;
            }
        }

        //Manually performs hash and then signs hashed value.
        public byte[] HashAndSign(byte[] encrypted)
        {
            RSACryptoServiceProvider rsaCSP = new RSACryptoServiceProvider();
            SHA1Managed hash = new SHA1Managed();
            byte[] hashedData;

            rsaCSP.ImportParameters(rsaPrivateParams);

            hashedData = hash.ComputeHash(encrypted);
            return rsaCSP.SignHash(hashedData, CryptoConfig.MapNameToOID("SHA1"));
        }

        //Encrypts using only the public key data.
        public byte[] EncryptData(RSAParameters rsaParams, byte[] toEncrypt)
        {
            RSACryptoServiceProvider rsaCSP = new RSACryptoServiceProvider();

            rsaCSP.ImportParameters(rsaParams);
            return rsaCSP.Encrypt(toEncrypt, false);
        }
    }

    class Receiver
    {
        RSAParameters rsaPubParams;
        RSAParameters rsaPrivateParams;

        public Receiver()
        {
            RSACryptoServiceProvider rsaCSP = new RSACryptoServiceProvider();

            //Generate public and private key data.
            rsaPrivateParams = rsaCSP.ExportParameters(true);
            rsaPubParams = rsaCSP.ExportParameters(false);
        }

        public RSAParameters PublicParameters
        {
            get
            {
                return rsaPubParams;
            }
        }

        //Manually performs hash and then verifies hashed value.
        //<Snippet2>
        public bool VerifyHash(RSAParameters rsaParams, byte[] signedData, byte[] signature)
        {
            RSACryptoServiceProvider rsaCSP = new RSACryptoServiceProvider();
            SHA1Managed hash = new SHA1Managed();
            byte[] hashedData;

            rsaCSP.ImportParameters(rsaParams);
            bool dataOK = rsaCSP.VerifyData(signedData, CryptoConfig.MapNameToOID("SHA1"), signature);
            hashedData = hash.ComputeHash(signedData);
            return rsaCSP.VerifyHash(hashedData, CryptoConfig.MapNameToOID("SHA1"), signature);
        }
        //</Snippet2>

        //Decrypt using the private key data.
        public void DecryptData(byte[] encrypted)
        {
            byte[] fromEncrypt;
            string roundTrip;
            ASCIIEncoding myAscii = new ASCIIEncoding();
            RSACryptoServiceProvider rsaCSP = new RSACryptoServiceProvider();

            rsaCSP.ImportParameters(rsaPrivateParams);
            fromEncrypt = rsaCSP.Decrypt(encrypted, false);
            roundTrip = myAscii.GetString(fromEncrypt);

            Console.WriteLine("RoundTrip: {0}", roundTrip);
        }
    }
}
//</Snippet1>
