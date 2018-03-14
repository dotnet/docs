// System.Web.Services.Discovery.DiscoveryReference

/* 
   This program demonstrates 'DiscoveryReference' class. 
   DiscoveryReference class is derived in 'MyDiscoveryReferenceClass'. A
   variable of type 'MyDiscoveryReferenceClass' class is taken to demonstrate 
   members of 'MyDiscoveryReferenceClass'.
   Note : The dataservice.disco file should be copied to c:\Inetpub\wwwroot
*/

// <Snippet1>
using System;
using System.IO;
using System.Web.Services.Discovery;
using System.Net;

class MyDiscoveryDocumentClass
{
   static void Main()
   {
      try {
         DiscoveryDocument myDiscoveryDocument;
         StreamReader myStreamReader = 
             new StreamReader("c:\\Inetpub\\wwwroot\\dataservice.disco");
         FileStream myStream = new FileStream("c:\\MyDiscovery.disco",
             FileMode.OpenOrCreate);
         Console.WriteLine("Demonstrating DiscoveryReference class.");

         // Read discovery file.
         myDiscoveryDocument = DiscoveryDocument.Read(myStreamReader);

         // Create a new instance of the DiscoveryReference class.
         MyDiscoveryReferenceClass myDiscoveryReference;
         myDiscoveryReference =  new MyDiscoveryReferenceClass();

         DiscoveryClientProtocol myDiscoveryClientProtocol = 
             new DiscoveryClientProtocol();
         myDiscoveryClientProtocol.Credentials = 
             CredentialCache.DefaultCredentials;

         // Set the client protocol.
         myDiscoveryReference.ClientProtocol = myDiscoveryClientProtocol;
         
         // Read the default file name.
         Console.WriteLine("Default file name is: " 
             + myDiscoveryReference.DefaultFilename);

         // Write the document.
         myDiscoveryReference.WriteDocument(myDiscoveryDocument,myStream);

         // Read the document.
         myDiscoveryReference.ReadDocument(myStream);

         // Set the URL. 
         myDiscoveryReference.Url = "http://localhost/dataservice.disco";
         Console.WriteLine("Url is: " + myDiscoveryReference.Url);

         // Resolve the URL.
         myDiscoveryReference.Resolve();

         myStreamReader.Close();
         myStream.Close();
      }
      catch (Exception e) 
      {
         Console.WriteLine("Exception caught! - {0}", e.Message);
      }
   }
}

// Class derived from DiscoveryReference class and overriding it members.
class MyDiscoveryReferenceClass : DiscoveryReference
{
   private string myDocumentUrl;
   public override string DefaultFilename
   {
      get
      {
         return "dataservice.disco";
      }
   }

   public override object ReadDocument(Stream stream)
   {
      return stream;
   }

   public new void Resolve()
   {
      try
      {
         DiscoveryDocument myDiscoveryRefDocument;
         myDiscoveryRefDocument = base.ClientProtocol.Discover(Url);
      }
      catch (Exception e)
      {
         throw(e);
      }
   }

   protected override void Resolve(string contentType, Stream stream) {}

   public override string Url
   {
      get
      {
         return myDocumentUrl;
      }

      set
      {
         myDocumentUrl = value;
      }
   }

   public override void WriteDocument(object document, System.IO.Stream stream)
   {
      DiscoveryDocument myDiscoveryDocument = (DiscoveryDocument)document;
      myDiscoveryDocument.Write(stream);
   }
}
// </Snippet1>
