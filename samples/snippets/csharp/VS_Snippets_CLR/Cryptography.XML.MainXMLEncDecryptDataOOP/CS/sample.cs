//<SNIPPET1>
using System;
using System.Xml;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;

	class Program
	{
		static void Main(string[] args)
		{

			// Create an XmlDocument object.
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
				return;
			}

			// Create a new TripleDES key. 
			TripleDESCryptoServiceProvider tDESkey = new TripleDESCryptoServiceProvider();

			// Create a new instance of the TrippleDESDocumentEncryption object
			// defined in this sample.
			TrippleDESDocumentEncryption xmlTDES = new TrippleDESDocumentEncryption(xmlDoc, tDESkey);
			
			try
			{
				// Encrypt the "creditcard" element.
				xmlTDES.Encrypt("creditcard");

				// Display the encrypted XML to the console.
				Console.WriteLine("Encrypted XML:");
				Console.WriteLine();
				Console.WriteLine(xmlTDES.Doc.OuterXml);

				// Decrypt the "creditcard" element.
				xmlTDES.Decrypt();

				// Display the encrypted XML to the console.
				Console.WriteLine();
				Console.WriteLine("Decrypted XML:");
				Console.WriteLine();
				Console.WriteLine(xmlTDES.Doc.OuterXml);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			finally
			{
				// Clear the TripleDES key.
				xmlTDES.Clear();
			}

		}

	}

class TrippleDESDocumentEncryption
{
	protected XmlDocument docValue;
	protected TripleDES algValue;

	public TrippleDESDocumentEncryption(XmlDocument Doc, TripleDES Key)
	{
		if (Doc != null)
		{
			docValue = Doc;
		}
		else
		{
			throw new ArgumentNullException("Doc");
		}

		if (Key != null)
		{

			algValue = Key;
		}
		else
		{
			throw new ArgumentNullException("Key");
		}
	}

	public XmlDocument Doc { set { docValue = value; } get { return docValue; } }
	public TripleDES Alg { set { algValue = value; } get { return algValue; } }

	public void Clear()
	{
		if (algValue != null)
		{
			algValue.Clear();
		}
		else
		{
			throw new Exception("No TripleDES key was found to clear.");
		}
	}

	public void Encrypt(string Element)
	{
		// Find the element by name and create a new
		// XmlElement object.
		XmlElement inputElement = docValue.GetElementsByTagName(Element)[0] as XmlElement;

		// If the element was not found, throw an exception.
		if (inputElement == null)
		{
			throw new Exception("The element was not found.");
		}

		// Create a new EncryptedXml object.
		EncryptedXml exml = new EncryptedXml(docValue);

		// Encrypt the element using the symmetric key.
		byte[] rgbOutput = exml.EncryptData(inputElement, algValue, false);

		// Create an EncryptedData object and populate it.
		EncryptedData ed = new EncryptedData();

		// Specify the namespace URI for XML encryption elements.
		ed.Type = EncryptedXml.XmlEncElementUrl;

		// Specify the namespace URI for the TrippleDES algorithm.
		ed.EncryptionMethod = new EncryptionMethod(EncryptedXml.XmlEncTripleDESUrl);

		// Create a CipherData element.
		ed.CipherData = new CipherData();

		// Set the CipherData element to the value of the encrypted XML element.
		ed.CipherData.CipherValue = rgbOutput;

		// Replace the plaintext XML elemnt with an EncryptedData element.
		EncryptedXml.ReplaceElement(inputElement, ed, false);
	}

	public void Decrypt()
	{

		// XmlElement object.
		XmlElement encryptedElement = docValue.GetElementsByTagName("EncryptedData")[0] as XmlElement;

		// If the EncryptedData element was not found, throw an exception.
		if (encryptedElement == null)
		{
			throw new Exception("The EncryptedData element was not found.");
		}

		// Create an EncryptedData object and populate it.
		EncryptedData ed = new EncryptedData();
		ed.LoadXml(encryptedElement);

		// Create a new EncryptedXml object.
		EncryptedXml exml = new EncryptedXml();

		// Decrypt the element using the symmetric key.
		byte[] rgbOutput = exml.DecryptData(ed, algValue);

		// Replace the encryptedData element with the plaintext XML elemnt.
		exml.ReplaceData(encryptedElement, rgbOutput);

	}

}
//</SNIPPET1>