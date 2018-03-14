// System.Web.Services.Description.PortTypeCollection.Contains()
// System.Web.Services.Description.PortTypeCollection.Insert()
// System.Web.Services.Description.PortTypeCollection.IndexOf()
// System.Web.Services.Description.PortTypeCollection.Item[string]

/* 
  The following sample demonstrates the methods 'IndexOf()','Insert()','Contains()' and
  indexer 'Item[string]' of class 'PortTypeCollection'. This sample reads the contents 
  of 'MathService.wsdl' into a 'ServiceDescription' instance. It gets the collection of 
  'PortType' instances from 'ServiceDescription'. It removes a 'PortType' with the name 
  'MathServiceSoap' and adds the same later. Then it checks whether the collection contains 
  the added 'PortType'.The sample writes a new web service description file 'MathService_New.wsdl'.
*/

using System;
using System.Web.Services.Description;
using System.Xml;

class MyPortTypeCollectionClass
{
   public static void Main()
   {
      try
      {
// <Snippet1>
// <Snippet2>
// <Snippet3>
// <Snippet4>
         ServiceDescription myServiceDescription = 
            ServiceDescription.Read("MathService_CS.wsdl");

         PortTypeCollection myPortTypeCollection = 
            myServiceDescription.PortTypes;
         int noOfPortTypes = myServiceDescription.PortTypes.Count;
         Console.WriteLine("\nTotal number of PortTypes: " + noOfPortTypes);

         PortType myNewPortType = myPortTypeCollection["MathServiceSoap"];

// </Snippet4>
         // Get the index in the collection.
         int index = myPortTypeCollection.IndexOf(myNewPortType);
// </Snippet3>
         Console.WriteLine("Removing the PortType named " 
            + myNewPortType.Name);

         // Remove the PortType from the collection.
         myPortTypeCollection.Remove(myNewPortType);
         noOfPortTypes = myServiceDescription.PortTypes.Count;
         Console.WriteLine("\nTotal number of PortTypes: " 
            + noOfPortTypes);
         
         // Check whether the PortType exists in the collection.
         bool bContains = myPortTypeCollection.Contains(myNewPortType);
         Console.WriteLine("Port Type'" + myNewPortType.Name + "' exists: " 
            + bContains );

         Console.WriteLine("Adding the PortType");
         // Insert a new portType at the index location.
         myPortTypeCollection.Insert(index, myNewPortType);
// </Snippet2>

         // Display the number of portTypes after adding a port.
         Console.WriteLine("Total number of PortTypes after "
            + "adding a new port: " + myServiceDescription.PortTypes.Count);

         bContains = myPortTypeCollection.Contains(myNewPortType);
         Console.WriteLine("Port Type'" + myNewPortType.Name + "' exists: " 
            + bContains );
         myServiceDescription.Write("MathService_New.wsdl");
// </Snippet1>
      }
      catch(Exception e)
      {
         Console.WriteLine("Exception: " + e.Message);
      }
   }
}
