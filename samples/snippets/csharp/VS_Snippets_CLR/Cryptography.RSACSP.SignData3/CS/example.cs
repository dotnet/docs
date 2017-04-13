//<SNIPPET1>
using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;

class RSACSPSample
{
    static void Main()
    {
        try
        {
            ASCIIEncoding ByteConverter = new ASCIIEncoding();

            // Create some bytes to be signed.
            byte[] dataBytes = ByteConverter.GetBytes("Here is some data to sign!");
   
            // Create a buffer for the memory stream.
            byte[] buffer = new byte[dataBytes.Length];

            // Create a MemoryStream.
            MemoryStream mStream = new MemoryStream(buffer);

            // Write the bytes to the stream and flush it.
            mStream.Write(dataBytes, 0, dataBytes.Length);

            mStream.Flush();

            // Create a new instance of the RSACryptoServiceProvider class 
            // and automatically create a new key-pair.
            RSACryptoServiceProvider RSAalg = new RSACryptoServiceProvider();

            // Export the key information to an RSAParameters object.
            // You must pass true to export the private key for signing.
            // However, you do not need to export the private key
            // for verification.
            RSAParameters Key = RSAalg.ExportParameters(true);

            // Hash and sign the data.
            byte[] signedData = HashAndSignBytes(mStream, Key);
           

            // Verify the data and display the result to the 
            // console.
            if(VerifySignedHash(dataBytes, signedData, Key))
            {
                Console.WriteLine("The data was verified.");
            }
            else
            {
                Console.WriteLine("The data does not match the signature.");
            } 
            
            // Close the MemoryStream.
            mStream.Close();

        }
        catch(ArgumentNullException)
        {
            Console.WriteLine("The data was not signed or verified");

        }
    }
    public static byte[] HashAndSignBytes(Stream DataStream, RSAParameters Key)
    {
        try
        { 
            // Reset the current position in the stream to 
            // the beginning of the stream (0). RSACryptoServiceProvider
            // can't verify the data unless the the stream position
            // is set to the starting position of the data.
            DataStream.Position = 0;

            // Create a new instance of RSACryptoServiceProvider using the 
            // key from RSAParameters.  
            RSACryptoServiceProvider RSAalg = new RSACryptoServiceProvider();

            RSAalg.ImportParameters(Key);

            // Hash and sign the data. Pass a new instance of SHA1CryptoServiceProvider
            // to specify the use of SHA1 for hashing.
            return RSAalg.SignData(DataStream, new SHA1CryptoServiceProvider());
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