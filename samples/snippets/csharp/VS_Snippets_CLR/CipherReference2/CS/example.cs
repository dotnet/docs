//<SNIPPET1>
using System;
using System.Security.Cryptography.Xml;
using System.Xml;
using System.IO;

/// This sample used the GetXml method in the CipherReference class to 
/// write the XML values for the CipherReference to the console.
namespace CipherReference2
{
	class CipherReference2
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
			// Write the CipherReference value to the console.
			Console.WriteLine("Cipher Reference data: {0}", reference.GetXml().OuterXml);
		}
	}
}
//</SNIPPET1>