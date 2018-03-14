//<SNIPPET4>
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
//<SNIPPET3>
//<SNIPPET1>
			// Create a new CipherData object using a byte array to represent encrypted data.
			Byte[] sampledata = new byte[8];
			CipherData cd = new CipherData(sampledata);
//</SNIPPET1>
			// Create a new EncryptedData object.
			EncryptedData ed = new EncryptedData();

			//Add an encryption method to the object.
			ed.Id = "ED";
			ed.EncryptionMethod = new EncryptionMethod("http://www.w3.org/2001/04/xmlenc#aes128-cbc");
			ed.CipherData = cd;
//</SNIPPET3>
//<SNIPPET2>
			//Add key information to the object.
			KeyInfo ki = new KeyInfo();
			ki.AddClause(new KeyInfoRetrievalMethod("#EK", "http://www.w3.org/2001/04/xmlenc#EncryptedKey"));
			ed.KeyInfo = ki;
//</SNIPPET2>
			// Create new XML document and put encrypted data into it.
			XmlDocument doc = new XmlDocument();
			XmlElement encryptionPropertyElement = (XmlElement)doc.CreateElement("EncryptionProperty", EncryptedXml.XmlEncNamespaceUrl);
			EncryptionProperty ep = new EncryptionProperty(encryptionPropertyElement);
			ed.AddProperty(ep);

			// Output the resulting XML information into a file. Change the path variable to point to a directory where
			// the XML file should be written.
			string path = @"c:\test\MyTest.xml";
			File.WriteAllText(path,ed.GetXml().OuterXml);

		}
	}
}
//</SNIPPET4>