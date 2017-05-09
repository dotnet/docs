// System.Web.Services.Description.PortTypeCollection

/* The following sample demonstrates the class 'PortTypeCollection'. It reads the
  contents of  WSDL document 'MathService.wsdl'into a 'ServiceDescription' instance.
  It gets the collection of 'PortType'from 'ServiceDescription'. It copies the
  collection into an array of 'PortType' and displays their names. Then it removes a
  'PortType', checks whether the collection contains the removed 'PortType'.
  It adds the same 'PortType' and writes a new web service description file into 
  'MathService_New.wsdl'.
*/

// <Snippet1>
using System;
using System.Web.Services.Description;
using System.Xml;
using System.Collections;

class MyPortTypeCollectionClass
{
   public static void Main()
   {
      try
      {
         // Read the existing Web service description file.
         ServiceDescription myServiceDescription = 
            ServiceDescription.Read("MathService_CS.wsdl");
         PortTypeCollection myPortTypeCollection = 
            myServiceDescription.PortTypes;
         int noOfPortTypes = myServiceDescription.PortTypes.Count;
         Console.WriteLine("\nTotal number of PortTypes: " 
            + myServiceDescription.PortTypes.Count);
         
         // Get the first PortType in the collection.
         PortType myNewPortType = myPortTypeCollection["MathServiceSoap"];
         int index = myPortTypeCollection.IndexOf(myNewPortType);
         Console.WriteLine("The PortType with the name " + myNewPortType.Name 
            + " is at index: " + (index+1));

         Console.WriteLine("Removing the PortType: " + myNewPortType.Name);

         // Remove the PortType from the collection.
         myPortTypeCollection.Remove(myNewPortType);
         bool bContains = myPortTypeCollection.Contains(myNewPortType);
         Console.WriteLine("The PortType with the name " + myNewPortType.Name 
            + " exists: " + bContains);

         Console.WriteLine("Total number of PortTypes after removing: "
            + myServiceDescription.PortTypes.Count);

         Console.WriteLine("Adding a PortType: " + myNewPortType.Name);

         // Add a new portType from the collection.
         myPortTypeCollection.Add(myNewPortType);

         // Display the number of portTypes after adding a port.
         Console.WriteLine("Total number of PortTypes after "
            + "adding a new port: " + myServiceDescription.PortTypes.Count);

         // List the PortTypes available in the WSDL document.
         foreach(PortType myPortType in myPortTypeCollection)
           Console.WriteLine("The PortType name is: " + myPortType.Name);
           
         myServiceDescription.Write("MathService_New.wsdl");
      }
      catch(Exception e)
      {
         Console.WriteLine("Exception: " + e.Message);
      }
   }
}
// </Snippet1>
