// System.Web.Services.Description.PortTypeCollection.Item[int]
// System.Web.Services.Description.PortTypeCollection.Remove()
// System.Web.Services.Description.PortTypeCollection.Add()

/*The following sample demonstrates the indexer 'Item[int]', methods
  'Remove()' and 'Add()' of class 'PortTypeCollection'. It reads the
  contents of a file 'MathService.wsdl'into a 'ServiceDescription' instance.
  It gets the collection of 'PortType' from 'ServiceDescription' and adds
  a new PortType and writes a new web service description file into 
  'MathService_New.wsdl'.
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
         ServiceDescription myServiceDescription = 
            ServiceDescription.Read("MathService_CS.wsdl");
         PortTypeCollection myPortTypeCollection = 
            myServiceDescription.PortTypes;

         int noOfPortTypes = myServiceDescription.PortTypes.Count;
         Console.WriteLine("\nTotal number of PortTypes: " 
            + myServiceDescription.PortTypes.Count);

         // Get the first PortType in the collection.
         PortType myNewPortType = myPortTypeCollection[0];
         Console.WriteLine(
            "The PortType at index 0 is: " + myNewPortType.Name);
         Console.WriteLine("Removing the PortType " + myNewPortType.Name);

         // Remove the PortType from the collection.
         myPortTypeCollection.Remove(myNewPortType);

         // Display the number of PortTypes.
         Console.WriteLine("\nTotal number of PortTypes after removing: "
            + myServiceDescription.PortTypes.Count);

         Console.WriteLine("Adding a PortType " + myNewPortType.Name);

         // Add a new PortType from the collection.
         myPortTypeCollection.Add(myNewPortType);

         // Display the number of PortTypes after adding a port.
         Console.WriteLine("Total number of PortTypes after " +
            "adding a new port: " + myServiceDescription.PortTypes.Count);

         myServiceDescription.Write("MathService_New.wsdl");
// </Snippet3>
// </Snippet2>
// </Snippet1>
      }
      catch(Exception e)
      {
         Console.WriteLine("Exception: " + e.Message);
      }
   }
}
