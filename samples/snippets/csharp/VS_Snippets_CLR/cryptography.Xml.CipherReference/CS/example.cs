//<SNIPPET1>
using System;
using System.Security.Cryptography.Xml;
using System.Xml;
using System.IO;

/// This sample used the EncryptedData class to create an encrypted data element
/// and write it to an XML file. It demonstrates the use of CipherReference.
namespace EncryptedDataSample
{
	class Sample1
	{
		[STAThread]
		static void Main(string[] args)
		{
			//Create a URI string.
			String uri = "http://www.woodgrovebank.com/document.xml";
			// Create a Base64 transform. The input content retrieved from the
			// URI should be Base64-decoded before other processing.
			Transform base64 = new XmlDsigBase64Transform();
			//Create a transform chain and add the transform to it.
			TransformChain tc = new TransformChain();
			tc.Add(base64);
			//Create <CipherReference> information.
			CipherReference reference = new CipherReference(uri, tc);

			// Create a new CipherData object using the CipherReference information.
			// Note that you cannot assign both a CipherReference and a CipherValue
			// to a CipherData object.
			CipherData cd = new CipherData(reference);

			// Create a new EncryptedData object.
			EncryptedData ed = new EncryptedData();

			//Add an encryption method to the object.
			ed.Id = "ED";
			ed.EncryptionMethod = new EncryptionMethod("http://www.w3.org/2001/04/xmlenc#aes128-cbc");
			ed.CipherData = cd;

			//Add key information to the object.
			KeyInfo ki = new KeyInfo();
			ki.AddClause(new KeyInfoRetrievalMethod("#EK", "http://www.w3.org/2001/04/xmlenc#EncryptedKey"));
			ed.KeyInfo = ki;

			// Create new XML document and put encrypted data into it.
			XmlDocument doc = new XmlDocument();
			XmlElement encryptionPropertyElement = (XmlElement)doc.CreateElement("EncryptionProperty", EncryptedXml.XmlEncNamespaceUrl);
			EncryptionProperty ep = new EncryptionProperty(encryptionPropertyElement);
			ed.AddProperty(ep);

			// Output the resulting XML information into a file.
			try
			{
				string path = @"c:\test\MyTest.xml";

				File.WriteAllText(path, ed.GetXml().OuterXml);
			}
			catch (IOException e)
			{
				Console.WriteLine("File IO error. {0}", e);
			}

		}
	}
}
//</SNIPPET1>