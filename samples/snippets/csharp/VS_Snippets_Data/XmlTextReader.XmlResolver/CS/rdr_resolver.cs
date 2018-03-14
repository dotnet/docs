//<snippet1>
using System;
using System.IO;
using System.Xml;
using System.Net;

public class Sample {

  public static void Main() {

    // Create the reader.
    XmlTextReader reader = new XmlTextReader("http://myServer/data/books.xml");
   
    // Supply the credentials necessary to access the Web server.
    XmlUrlResolver resolver = new XmlUrlResolver();
    resolver.Credentials = CredentialCache.DefaultCredentials;
    reader.XmlResolver = resolver;

    // Parse the file.
    while (reader.Read()) {
       // Do any additional processing here.
    }           
  
    // Close the reader.
    reader.Close();     
  
  }
} 
//</snippet1>
