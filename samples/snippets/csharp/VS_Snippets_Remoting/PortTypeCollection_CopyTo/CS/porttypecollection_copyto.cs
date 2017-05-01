// System.Web.Services.Description.PortTypeCollection.CopyTo()

/*
  The following sample demonstrates the 'CopyTo()' method of the class
  'PortTypeCollection'.This sample reads the contents of a file 'MathService.wsdl'
  into a 'ServiceDescription' instance. It gets the collection of 'PortType'
  from 'ServiceDescription'. It copies the collection into an array of 'PortType' 
  and displays their names.
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
         PortTypeCollection myPortTypeCollection;

         ServiceDescription myServiceDescription = 
            ServiceDescription.Read("MathService_CS.wsdl");

         myPortTypeCollection = myServiceDescription.PortTypes;
         int noOfPortTypes = myServiceDescription.PortTypes.Count;
         Console.WriteLine("\nTotal number of PortTypes: " 
            + myServiceDescription.PortTypes.Count);

         // Copy the collection into an array.
          PortType[] myPortTypeArray = new PortType[noOfPortTypes];
          myPortTypeCollection.CopyTo(myPortTypeArray, 0);

         // Display names of all PortTypes.
          for(int i = 0; i < noOfPortTypes; i++)
             Console.WriteLine("PortType name: " + myPortTypeArray[i].Name);
          myServiceDescription.Write("MathService_New.wsdl");
// </Snippet1>
      }
      catch(Exception e)
      {
         Console.WriteLine("Exception: " + e.Message);
      }
   }
}
