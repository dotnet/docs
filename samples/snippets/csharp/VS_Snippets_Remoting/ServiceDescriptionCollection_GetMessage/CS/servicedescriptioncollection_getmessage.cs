// System.Web.Services.Description.ServiceDescriptionCollection.GetMessage()

/* The following program demonstrates the 'GetMessage' method 
   of 'ServiceDescriptionCollection' class. It searches for a 
   'Message' in the collection and returns the Message instance. On success,
   a message is displayed on the console.
   
   Note: This program requires 'DataTypes_CS.wsdl' and 'MathService_CS.wsdl' 
   files to be placed in same directory as that of .exe for running.
*/
using System;
using System.Xml;
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
         
         // Create the object of 'ServiceDescriptionCollection' class.
         ServiceDescriptionCollection myCollection = 
            new ServiceDescriptionCollection();

         // Add 'ServiceDescription' objects. 
         myCollection.Add(myServiceDescription1);
         myCollection.Add(myServiceDescription2);
// <Snippet1> 
         // Construct an XML qualified name.
         XmlQualifiedName myXmlQualifiedName = 
            new XmlQualifiedName("AddSoapIn", "http://tempuri2.org/");

         // Get the Message from the collection.
         Message  myMessage = myCollection.GetMessage(myXmlQualifiedName);
// </Snippet1>
         Console.WriteLine("Specified Message is a member of ServiceDescription "
                                             +"instances within the collection.");
      }
      catch(Exception e)
      {
         Console.WriteLine("The following exception was raised: {0}", e.Message);
      }
   }
}