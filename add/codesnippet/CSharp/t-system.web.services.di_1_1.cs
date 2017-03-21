using System;
using System.IO;
using System.Net;
using System.Xml;
using System.Xml.Schema;
using System.Web.Services.Discovery;

public class SchemaReferenceClass
{
   public static void Main()
   {
      try
      {


         // Reference the schema document.
         string myStringUrl = "c:\\Inetpub\\wwwroot\\dataservice.xsd";
         XmlSchema myXmlSchema;

         // Create the client protocol.
         DiscoveryClientProtocol myDiscoveryClientProtocol = 
             new DiscoveryClientProtocol();
         myDiscoveryClientProtocol.Credentials = 
             CredentialCache.DefaultCredentials;
         
         //  Create a schema reference.
         SchemaReference mySchemaReferenceNoParam = new SchemaReference();
         
         SchemaReference mySchemaReference = new SchemaReference(myStringUrl);
                  
         // Set the client protocol.
         mySchemaReference.ClientProtocol = myDiscoveryClientProtocol;

         // Access the default file name associated with the schema reference.
         Console.WriteLine("Default filename is : " + 
             mySchemaReference.DefaultFilename);
         
         // Access the namespace associated with schema reference class.
         Console.WriteLine("Namespace is : " + SchemaReference.Namespace);
         
         FileStream myStream = 
             new FileStream(myStringUrl,FileMode.OpenOrCreate); 
         
         // Read the document in a stream.
         mySchemaReference.ReadDocument(myStream);
         
         // Get the schema of referenced document.
         myXmlSchema = mySchemaReference.Schema;
         
         Console.WriteLine("Reference is : " + mySchemaReference.Ref);      
         
         Console.WriteLine("Target namespace (default empty) is : " + 
             mySchemaReference.TargetNamespace);

         Console.WriteLine("URL is : " + mySchemaReference.Url);
         
         // Write the document in the stream.
         mySchemaReference.WriteDocument(myXmlSchema,myStream);

         myStream.Close();
         mySchemaReference = null;

      }
      catch (Exception e)
      {
         Console.WriteLine(e.ToString());
      }
   }
}
