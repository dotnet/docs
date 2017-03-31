//<SNIPPET1>
using System;
using System.Security.Cryptography.Xml;
using System.Xml;
using System.IO;

/// This sample used the EncryptedData class to create a EncryptedData element
/// and write it to an XML file.
namespace EncryptedDataSample
{
	class Sample1
	{
		[STAThread]
		static void Main(string[] args)
		{
//<SNIPPET2>
			// Create a new CipherData object.
			CipherData cd = new CipherData();
			// Assign a byte array to be the CipherValue. This is a byte array representing encrypted data.
			cd.CipherValue = new byte[8];
//</SNIPPET2>
//<SNIPPET3>
			// Create a new EncryptedData object.
			EncryptedData ed = new EncryptedData();
//</SNIPPET3>
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
			string path = @"c:\test\MyTest.xml";
			File.WriteAllText(path,ed.GetXml().OuterXml);
			//Console.WriteLine(ed.GetXml().OuterXml);

		}
	}
}
//</SNIPPET1>