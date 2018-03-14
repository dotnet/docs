//<Snippet1>
using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Xml;


public class XMLdsigsample1 {

static void Main(String[] args)
{
     // Create example data to sign.
     XmlDocument document = new XmlDocument();
     XmlNode  node = document.CreateNode(XmlNodeType.Element, "", "MyElement", "samples");
     node.InnerText = "This is some text";
     document.AppendChild(node);
     Console.Error.WriteLine("Data to sign:\n" + document.OuterXml + "\n");
 
     // Create the SignedXml message.
     SignedXml signedXml = new SignedXml();
     RSA key = RSA.Create();
     signedXml.SigningKey = key;
 
     // Create a data object to hold the data to sign.
     DataObject dataObject = new DataObject();
     dataObject.Data = document.ChildNodes;
     dataObject.Id = "MyObjectId";

     // Add the data object to the signature.
     signedXml.AddObject(dataObject);
 
     // Create a reference to be able to package everything into the
     // message.
     Reference reference = new Reference();
     reference.Uri = "#MyObjectId";
 
     // Add it to the message.
     signedXml.AddReference(reference);

     // Add a KeyInfo.
     KeyInfo keyInfo = new KeyInfo();
     keyInfo.AddClause(new RSAKeyValue(key));
     signedXml.KeyInfo = keyInfo;

     // Compute the signature.
     signedXml.ComputeSignature();

     // Get the XML representation of the signature.
     XmlElement xmlSignature = signedXml.GetXml();
     Console.WriteLine(xmlSignature.OuterXml);
}

}
//</Snippet1>