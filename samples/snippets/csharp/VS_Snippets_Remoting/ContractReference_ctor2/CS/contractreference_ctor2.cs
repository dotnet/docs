// System.Web.Services.Discovery.ContractReference.ContractReference(string,string)
/*
  The following example demonstrates the constructor 'ContractReference(string,string)' 
  of 'ContractReference' class. In this example the 'ContractReference' class constructor
  initializes a new instance of the 'ContractReference' class using the supplied references
  to a service description and a XML Web service implementing the service description.The
  Contract reference object is added to the list of references contained within the 
  discovery document and a '.disco' file is generated for the webservice where the 
  reference tags of ContractReference are reflected.
*/
using System;
using System.Xml;
using System.IO;
using System.Web.Services.Discovery;

public class ContractReference_ctor
{
   static void Main()
   {
      try
      {
         // Get a DiscoveryDocument.
         DiscoveryDocument myDiscoveryDocument = new  DiscoveryDocument();
// <Snippet1>
         // Create a ContractReference using a service description and 
         // an XML Web service.
         ContractReference myContractReference = new ContractReference
             ("http://localhost/Service1.asmx?wsdl",
             "http://localhost/Service1.asmx");
// </Snippet1>
         SoapBinding myBinding = new SoapBinding();
         myBinding.Binding = new XmlQualifiedName("q1:Service1Soap");
         myBinding.Address = "http://localhost/service1.asmx";

         // Add myContractReference to the list of references contained 
         // in the discovery document.
         myDiscoveryDocument.References.Add(myContractReference);
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
         Console.WriteLine("Error is "+e.Message);
      }
   }
}
