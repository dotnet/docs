// System.Web.Services.Discovery.DiscoveryReference.ClientProtocol
// System.Web.Services.Discovery.DiscoveryReference.DefaultFilename
// System.Web.Services.Discovery.DiscoveryReference.WriteDocument(object,Stream)
// System.Web.Services.Discovery.DiscoveryReference.ReadDocument(Stream)
// System.Web.Services.Discovery.DiscoveryReference.Url
// System.Web.Services.Discovery.DiscoveryReference.Resolve()

// This program demonstrates 'ClientProtocol', 'WriteDocumant', 'Url' properties
//   and 'DefaultFilename', 'readDocument', 'Resolve' methods of 'DiscoveryReference'
//   class. DiscoveryReference class is derived in 'MyDiscoveryReferenceClass'. A
//   variable of type 'MyDiscoveryReferenceClass' class is taken to demonstrate these
//   members.
//  Note : The dataservice.disco file should be copied to Inetpub\wwwroot
//

// <Snippet1>
using System;
using System.IO;
using System.Web.Services.Discovery;
using System.Net;

class MyDiscoveryDocumentClass
{
   static void Main()
   {
      DiscoveryDocument myDiscoveryDocument;
      StreamReader myStreamReader = 
         new StreamReader("c:\\Inetpub\\wwwroot\\dataservice.disco");
      FileStream myStream = 
         new FileStream("C:\\MyDiscovery.disco",FileMode.OpenOrCreate);
      Console.WriteLine("Demonstrating Discovery Reference class.");

      // Read discovery file.
      myDiscoveryDocument = DiscoveryDocument.Read(myStreamReader);

      // Variable of type DiscoveryReference class defined.
      MyDiscoveryReferenceClass myDiscoveryReference;
      myDiscoveryReference =  new MyDiscoveryReferenceClass();

      DiscoveryClientProtocol myDiscoveryClientProtocol = 
         new DiscoveryClientProtocol();
      myDiscoveryClientProtocol.Credentials = 
         CredentialCache.DefaultCredentials;

      // Set client protocol.
      myDiscoveryReference.ClientProtocol = myDiscoveryClientProtocol;
      
      // Read the default file name.
      Console.WriteLine("Default file name is: " + myDiscoveryReference.DefaultFilename);

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
}

// Class derived from DiscoveryReference class and overriding its members.
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
