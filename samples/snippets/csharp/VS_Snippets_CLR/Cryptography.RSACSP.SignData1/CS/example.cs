//<SNIPPET1>
using System;
using System.Security.Cryptography;
using System.Text;

class RSACSPSample
{
    static void Main()
    {
        try
        {
            // Create a UnicodeEncoder to convert between byte array and string.
            ASCIIEncoding ByteConverter = new ASCIIEncoding();

            string dataString = "Data to Sign";

            // Create byte arrays to hold original, encrypted, and decrypted data.
            byte[] originalData = ByteConverter.GetBytes(dataString);
            byte[] signedData;
            byte[] smallArray;

            // Create a new instance of the RSACryptoServiceProvider class 
            // and automatically create a new key-pair.
            RSACryptoServiceProvider RSAalg = new RSACryptoServiceProvider();

            // Export the key information to an RSAParameters object.
            // You must pass true to export the private key for signing.
            // However, you do not need to export the private key
            // for verification.
            RSAParameters Key = RSAalg.ExportParameters(true);

            // Hash and sign the data.  Start at the fifth offset
            // only use data from the next 7 bytes.
            signedData = HashAndSignBytes(originalData, Key, 5, 7 );

            // The previous method only signed one segment
            // of the array.  Create a new array for verification
            // that only holds the data that was actually signed.
            //
            // Initialize the array.
            smallArray = new byte[7];
            // Copy 7 bytes starting at the 5th index to 
            // the new array.
            Array.Copy(originalData, 5 , smallArray, 0, 7); 

            // Verify the data and display the result to the 
            // console.  
            if(VerifySignedHash(smallArray, signedData, Key))
            {
                Console.WriteLine("The data was verified.");
            }
            else
            {
                Console.WriteLine("The data does not match the signature.");
            }

        }
        catch(ArgumentNullException)
        {
            Console.WriteLine("The data was not signed or verified");

        }
    }
    public static byte[] HashAndSignBytes(byte[] DataToSign, RSAParameters Key, int Index, int Length)
    {
        try
        {   
            // Create a new instance of RSACryptoServiceProvider using the 
            // key from RSAParameters.  
            RSACryptoServiceProvider RSAalg = new RSACryptoServiceProvider();

            RSAalg.ImportParameters(Key);

            // Hash and sign the data. Pass a new instance of SHA1CryptoServiceProvider
            // to specify the use of SHA1 for hashing.
            return RSAalg.SignData(DataToSign,Index,Length, new SHA1CryptoServiceProvider());
        }
        catch(CryptographicException e)
        {
            Console.WriteLine(e.Message);

            return null;
        }
    }

    public static bool VerifySignedHash(byte[] DataToVerify, byte[] SignedData, RSAParameters Key)
    {
        try
        {
            // Create a new instance of RSACryptoServiceProvider using the 
            // key from RSAParameters.
            RSACryptoServiceProvider RSAalg = new RSACryptoServiceProvider();

            RSAalg.ImportParameters(Key);

            // Verify the data using the signature.  Pass a new instance of SHA1CryptoServiceProvider
            // to specify the use of SHA1 for hashing.
            return RSAalg.VerifyData(DataToVerify, new SHA1CryptoServiceProvider(), SignedData); 

        }
        catch(CryptographicException e)
        {
            Console.WriteLine(e.Message);

            return false;
        }
    }
}
//</SNIPPET1>