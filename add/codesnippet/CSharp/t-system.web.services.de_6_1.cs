using System;
using System.Xml;
using System.Web.Services.Description;

class MyServiceDescriptionCollection
{
   public static void Main()
   {
      try
      {
         // Get ServiceDescription objects.
         ServiceDescription myServiceDescription1 =
            ServiceDescription.Read("DataTypes_CS.wsdl");
         ServiceDescription myServiceDescription2 =
            ServiceDescription.Read("MathService_CS.wsdl");

         // Set the names of the ServiceDescriptions.
         myServiceDescription1.Name = "DataTypes";
         myServiceDescription2.Name = "MathService";

         // Create a ServiceDescriptionCollection.
         ServiceDescriptionCollection myServiceDescriptionCollection =
            new ServiceDescriptionCollection();

         // Add the ServiceDescriptions to the collection.
         myServiceDescriptionCollection.Add(myServiceDescription1);
         myServiceDescriptionCollection.Add(myServiceDescription2);

         // Display the elements of the collection using the indexer.
         Console.WriteLine("Elements in the collection: ");
         for(int i = 0; i < myServiceDescriptionCollection.Count; i++)
         {
            Console.WriteLine(myServiceDescriptionCollection[i].Name);
         }

         // Construct an XML qualified name.
         XmlQualifiedName myXmlQualifiedName =
            new XmlQualifiedName("MathServiceSoap", "http://tempuri2.org/");

         // Get the Binding from the collection.
         Binding myBinding =
            myServiceDescriptionCollection.GetBinding(myXmlQualifiedName);

         Console.WriteLine("Binding found in collection with name: " +
                           myBinding.ServiceDescription.Name);
      }
      catch(Exception e)
      {
         Console.WriteLine("The following exception was raised: {0}", e.Message);
      }
   }
}