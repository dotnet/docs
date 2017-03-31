// System.Web.Services.Discovery.ContractReference
/*
  The following example demonstrates the 'ContractReference' class .
  A new instance of 'ContractReference' class  is obtained. The
  Contract reference object is added to the list of references 
  contained within the discovery document and a '.disco' file is 
  generated for the Webservice where the reference tags of 
  ContractReference are reflected.
  */
// <Snippet1>
using System;
using System.Xml;
using System.IO;
using System.Web.Services.Discovery;

public class MyContractReference
{
   static void Main()
   {
      try
      {
         // Get a DiscoveryDocument.
         DiscoveryDocument myDiscoveryDocument = new  DiscoveryDocument();

         // Get a ContractReference.
         ContractReference myContractReference = new ContractReference();

         // Set the URL to the referenced service description.
         myContractReference.Ref = "http://localhost/service1.asmx?wsdl";

         // Set the URL for an XML Web service implementing the service
         // description.
         myContractReference.DocRef = "http://localhost/service1.asmx";
         SoapBinding myBinding = new SoapBinding();
         myBinding.Binding = new XmlQualifiedName("q1:Service1Soap");
         myBinding.Address = "http://localhost/service1.asmx";

         // Add myContractReference to the list of references contained 
         // in the discovery document.
         myDiscoveryDocument.References.Add(myContractReference); 

         // Add Binding to the references collection.
         myDiscoveryDocument.References.Add(myBinding);

         // Open or create a file for writing.
         FileStream myFileStream = new FileStream("Service1.disco",
             FileMode.OpenOrCreate, FileAccess.Write );
         StreamWriter myStreamWriter = new StreamWriter( myFileStream );

         // Write myDiscoveryDocument into the passed stream.
         myDiscoveryDocument.Write( myStreamWriter );
         Console.WriteLine("The Service1.disco is generated.");
      }
      catch(Exception e)
      {
         Console.WriteLine("Error is "+ e.Message);
      }
   }
}
// </Snippet1>
