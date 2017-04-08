// System.Web.Services.Discovery.ContractReference.DefaultFileName
// System.Web.Services.Discovery.ContractReference.Url

/*
  The following example demonstrates the 'DefaultFilename' and 'Url' properties of 
  'ContractReference' class. It gets the 'DiscoveryDocument' object using the 
  'Discover' method of 'DiscoveryClientProtocol' class. It gets the 'ContractReference'
  object by using the 'References' property of 'DiscoveryDocument' object.Then it displays the
  'DefaultFileName' and 'Url' properties of 'ContractReference'.
  */

using System;
using System.Web.Services.Discovery;
using System.Xml.Schema;
using System.Collections;

public class DiscoveryDocument_Example
{
   static void Main()
   {
// <Snippet1>
// <Snippet2>
      DiscoveryClientProtocol myProtocol = new DiscoveryClientProtocol();

      // Get the DiscoveryDocument.
      DiscoveryDocument myDiscoveryDocument =
          myProtocol.Discover("http://localhost/ContractReference/test_cs.disco");
      ArrayList myArrayList = (ArrayList)myDiscoveryDocument.References;

       // Get the ContractReference.
      ContractReference myContractRefrence = (ContractReference)myArrayList[0];

      // Get the DefaultFileName associated with the .disco file.
      String myFileName = myContractRefrence.DefaultFilename;

      // Get the URL associated with the .disco file.
      String myUrl = myContractRefrence.Url;
      Console.WriteLine("The DefaulFilename is: " + myUrl);
      Console.WriteLine("The URL is: " + myUrl);
// </Snippet2>
// </Snippet1>
      }
  }
