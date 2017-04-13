//<snippet1>
using System;
using System.IO;
using System.Xml;
using System.Net;

public class Sample {

  public static void Main() {

    // Create the reader.
    XmlTextReader reader = new XmlTextReader("http://myServer/data/books.xml");
   
    // Create a secure resolver with default credentials.
    XmlUrlResolver resolver = new XmlUrlResolver();
    XmlSecureResolver sResolver = new XmlSecureResolver(resolver, "http://myServer/data/");
    sResolver.Credentials = CredentialCache.DefaultCredentials;

    // Use the secure resolver to resolve resources.
    reader.XmlResolver = sResolver;

    // Parse the file.
    while (reader.Read()) {
       // Do any additional processing here.
    }           
  
    // Close the reader.
    reader.Close();     
  
  }
}
//</snippet1>