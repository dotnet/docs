// <snippet1>

using System;
using System.Xml;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Runtime.Versioning;

[SupportedOSPlatform("windows")]
class Program
{
	static void Main(string[] args)
	{
		// Create an XmlDocument object.
		// <snippet4>
		XmlDocument xmlDoc = new XmlDocument();

		// Load an XML file into the XmlDocument object.
		try
		{
			xmlDoc.PreserveWhitespace = true;
			xmlDoc.Load("test.xml");
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
		}
		// </snippet4>
		// <snippet2>
		CspParameters cspParams = new CspParameters();
		cspParams.KeyContainerName = "XML_ENC_RSA_KEY";
		// </snippet2>

		// Get the RSA key from the key container.  This key will decrypt
		// a symmetric key that was imbedded in the XML document.
		// <snippet3>
		RSACryptoServiceProvider rsaKey = new RSACryptoServiceProvider(cspParams);
		// </snippet3>

		try
		{

			// Decrypt the elements.
			Decrypt(xmlDoc, rsaKey, "rsaKey");

			// Save the XML document.
			// <snippet8>
			xmlDoc.Save("test.xml");
			// </snippet8>

			// Display the encrypted XML to the console.
			Console.WriteLine();
			Console.WriteLine("Decrypted XML:");
			Console.WriteLine();
			Console.WriteLine(xmlDoc.OuterXml);
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
		}
		finally
		{
			// Clear the RSA key.
			rsaKey.Clear();
		}

		Console.ReadLine();
	}

	public static void Decrypt(XmlDocument Doc, RSA Alg, string KeyName)
	{
		// Check the arguments.
		if (Doc == null)
			throw new ArgumentNullException("Doc");
		if (Alg == null)
			throw new ArgumentNullException("Alg");
		if (KeyName == null)
			throw new ArgumentNullException("KeyName");
		// <snippet5>
		// Create a new EncryptedXml object.
		EncryptedXml exml = new EncryptedXml(Doc);
		// </snippet5>

		// Add a key-name mapping.
		// This method can only decrypt documents
		// that present the specified key name.
		// <snippet6>
		exml.AddKeyNameMapping(KeyName, Alg);
		// </snippet6>

		// Decrypt the element.
		// <snippet7>
		exml.DecryptDocument();
		// </snippet7>
	}
}
// </snippet1>
