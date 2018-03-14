// System.Web.Services.Description.ServiceDescriptionCollection.ServiceDescriptionCollection()
// System.Web.Services.Description.ServiceDescriptionCollection.Add()
// System.Web.Services.Description.ServiceDescriptionCollection.Item(Int32)

/* The following program demonstrates 'Constructor', 'Add' method and 
   'Item' property of 'ServiceDescriptionCollection' class. It creates an
   instance of 'ServiceDescriptionCollection' and adds  
   'ServiceDescription' objects to the collection. The Item property is used to 
   display the TargetNamespace of elements in the collection.
   
   Note: This program requires 'DataTypes_CS.wsdl' and 'MathService_CS.wsdl' 
   files to be placed in same directory as that of .exe for running.
*/
using System;
using System.Web.Services.Description;

class MyServiceDescriptionCollection
{
   public static void Main()
   {  
      try
      {
         ServiceDescription myServiceDescription1 =
             ServiceDescription.Read("DataTypes_CS.wsdl");
         ServiceDescription myServiceDescription2 = 
            ServiceDescription.Read("MathService_CS.wsdl");
// <Snippet1>
// <Snippet2>
         // Create the object of 'ServiceDescriptionCollection' class.
         ServiceDescriptionCollection myCollection = 
            new ServiceDescriptionCollection();
         // Add 'ServiceDescription' objects. 
         myCollection.Add(myServiceDescription1);
         myCollection.Add(myServiceDescription2); 
// </Snippet2>
// </Snippet1>
// <Snippet3>
         // Display element properties in collection using 'Item' property.
         for(int i=0; i<myCollection.Count; i++)
         {
            Console.WriteLine(myCollection[i].TargetNamespace);
         }
// </Snippet3>
      }
      catch(Exception e)
      {
         Console.WriteLine("The following exception was raised: {0}", e.Message);
      }
   }
}