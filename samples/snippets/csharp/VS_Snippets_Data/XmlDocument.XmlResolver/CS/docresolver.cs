// <snippet1>
using System;
using System.IO;
using System.Xml;
using System.Net;

public class Sample {

  public static void Main() {

    // Supply the credentials necessary to access the DTD file stored on the network.
    XmlUrlResolver resolver = new XmlUrlResolver();
    resolver.Credentials = CredentialCache.DefaultCredentials;

    // Create and load the XmlDocument.
    XmlDocument doc = new XmlDocument();
    doc.XmlResolver = resolver;  // Set the resolver.
    doc.Load("book5.xml");

    // Display the entity replacement text which is pulled from the DTD file.
    Console.WriteLine(doc.DocumentElement.LastChild.InnerText);
  
  }
} // End class
// </snippet1>


