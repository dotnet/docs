// System.Web.Services.Description.ServiceDescriptionCollection.Contains()
// System.Web.Services.Description.ServiceDescriptionCollection.IndexOf()
// System.Web.Services.Description.ServiceDescriptionCollection.Remove()

/* The following program demonstrates 'Contains', 'IndexOf' and 
   'Remove' methods of 'ServiceDescriptionCollection' class. It creates an 
   instance of 'ServiceDescriptionCollection' and adds 'ServiceDescription' 
   objects to the collection. It checks for an object of 'ServiceDescription', 
   retrieves the index of the object and removes it from the collection.
   
   Note: This program requires 'DataTypes_CS.wsdl' and 'MathService_CS.wsdl' 
   files to be placed in the same directory as that of .exe for
   running.
   
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
         ServiceDescriptionCollection myCollection = 
            new ServiceDescriptionCollection();
             
         // Add 'ServiceDescription' objects.
         myCollection.Add(myServiceDescription1);
         myCollection.Add(myServiceDescription2);

// <Snippet1>      
         // Check for 'ServiceDescription' object in the collection.
         if (myCollection.Contains(myServiceDescription2))
         { 
// <Snippet2>
// <Snippet3>
            // Get the index of 'ServiceDescription' object.
            int myIndex = myCollection.IndexOf(myServiceDescription2); 
            // Remove 'ServiceDescription' object from the collection.
            myCollection.Remove(myServiceDescription2);
            Console.WriteLine("Element at index {0} is removed ", myIndex);
// </Snippet3>
// </Snippet2>
         }
         else
         {
            Console.WriteLine("Element not found.");
         }
// </Snippet1>
      }
      catch(Exception e)
      {
         Console.WriteLine("The following exception was raised: {0}", e.Message);
      }
   }
}