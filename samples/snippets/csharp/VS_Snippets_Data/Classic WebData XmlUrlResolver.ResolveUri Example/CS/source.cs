// <Snippet1>
using System;
using System.IO;
using System.Xml;
 
 public class Sample
 {
          
   public static void Main()
   {
       XmlUrlResolver resolver = new XmlUrlResolver();
 
       Uri baseUri = new Uri ("http://servername/tmp/test.xsl");
 
       Uri fulluri=resolver.ResolveUri(baseUri, "includefile.xsl");
 
       // Get a stream object containing the XSL file
       Stream s=(Stream)resolver.GetEntity(fulluri, null, typeof(Stream));
 
       // Read the stream object displaying the contents of the XSL file
       XmlTextReader reader = new XmlTextReader(s);
       while (reader.Read()) 
       {
          Console.WriteLine(reader.ReadOuterXml());
       } 
   }
}
    // </Snippet1>

