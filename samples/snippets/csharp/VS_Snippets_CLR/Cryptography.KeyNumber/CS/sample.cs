using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace RC2CryptoServiceProvider_Examples
{
    class MyMainClass
    {
        public static void Main()
        {
	    //<SNIPPET1>
            // Create a new CspParameters object.
            CspParameters cspParams = new CspParameters();

            // Specify an exchange key.
            cspParams.KeyNumber = (int) KeyNumber.Exchange;

            // Initialize the RSACryptoServiceProvider  
            // with the CspParameters object.
            RSACryptoServiceProvider RSACSP = new RSACryptoServiceProvider(cspParams);
	    //</SNIPPET1>
        }
    }
}