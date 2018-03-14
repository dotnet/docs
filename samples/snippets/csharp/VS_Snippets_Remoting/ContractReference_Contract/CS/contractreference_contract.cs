// System.Web.Services.Discovery.ContractReference.Contract
/* 
 The following example demonstrates the 'Contract' property of the 'ContractReference'
 class.
 It creates an instance of 'DiscoveryDocument' class by reading from a disco file 
 and gets the first reference to a service description in a 'ContractReference' instance.
 Using the 'Contract' property of the 'ContractReference' instance it creates a wsdl 
 file which works as a service description file.
 */

using System;
using System.Web.Services.Protocols;
using System.Net;
using System.IO;
using System.Web.Services.Discovery;
using System.Web.Services.Description;

namespace ConsoleApplication1
{
// <Snippet1>
   class MyClass1
   {
      static void Main()
      {
         try
         {
            // Create the file stream.
            FileStream discoStream = 
                new FileStream("Service1_CS.disco",FileMode.Open);

            // Create the discovery document.
            DiscoveryDocument myDiscoveryDocument = 
                DiscoveryDocument.Read(discoStream);

            // Get the first ContractReference in the collection.
            ContractReference myContractReference =
                (ContractReference)myDiscoveryDocument.References[0];

            // Set the client protocol.
            myContractReference.ClientProtocol = new DiscoveryClientProtocol();
            myContractReference.ClientProtocol.Credentials = 
                CredentialCache.DefaultCredentials;

            // Get the service description.
            ServiceDescription myContract = myContractReference.Contract;

            // Create the service description file.
            myContract.Write("MyService1.wsdl");
            Console.WriteLine("The WSDL file created is MyService1.wsdl");

            discoStream.Close();
         }
         catch(Exception ex)
         {
            Console.WriteLine("Exception: " + ex.Message);
         }
      }
   }
// </Snippet1>
}
