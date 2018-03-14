// <SNIPPET1>
using System;
using System.IO;
using System.Security.Cryptography;

public class StoreKey
{
	public static void Main()
	{
		// creates the CspParameters object and sets the key container name used to store the RSA key pair
		CspParameters cp = new CspParameters();
		cp.KeyContainerName = "MyKeyContainerName";

		// instantiates the rsa instance accessing the key container MyKeyContainerName
		RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(cp);
		// add the below line to delete the key entry in MyKeyContainerName
		// rsa.PersistKeyInCsp = false;

		//writes out the current key pair used in the rsa instance
		Console.WriteLine("Key is : \n" + rsa.ToXmlString(true));
	}
}
// </SNIPPET1>
