using System;
using System.Security.Cryptography;

class RSACSPSample
{

    static void Main()
    {
        // <Snippet1>
        try
        {
            //Create a new RSACryptoServiceProvider object.
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {


                //Export the key information to an RSAParameters object.
                //Pass false to export the public key information or pass
                //true to export public and private key information.
                RSAParameters RSAParams = RSA.ExportParameters(false);
            }


        }
        catch (CryptographicException e)
        {
            //Catch this exception in case the encryption did
            //not succeed.
            Console.WriteLine(e.Message);

        }
        // </Snippet1>
    }
}