// System.Web.Services.Description.Message.FindPartsByName
// System.Web.Services.Description.Message.ServiceDescription
// System.Web.Services.Description.Message.FindPartByName

/* The following program demonstrates the property ' ServiceDescription' and
   methods 'FindPartsByName','FindPartByName' of class 'Message'. The program
   reads a wsdl document "MathService.wsdl" and instantiates a 
   ServiceDescription instance from WSDL document. 
   The program invokes 'FindPartsByName' to obtain an array of MessageParts and also invokes
   'FindPartByName' to retrieve a specific 'MessagePart'.
 */
using System;
using System.Web.Services.Description;
using System.Collections;
using System.Xml;

namespace MyMessage
{
   class MyClass1
   {
      public static void Main()
      {
         try
         {  
// <Snippet2>
            ServiceDescription myServiceDescription = ServiceDescription.Read("MathService_cs.wsdl");
// <Snippet1>
            // Get message from ServiceDescription.
            Message myMessage1 = myServiceDescription.Messages["AddHttpPostIn"];
            Console.WriteLine("ServiceDescription :"+myMessage1.ServiceDescription);
// </Snippet2>
            string[] myParts = new string[2];
            myParts[0] = "a";
            myParts[1] = "b";
            MessagePart[] myMessageParts = myMessage1.FindPartsByName(myParts);
            Console.WriteLine("Results of FindPartsByName operation:");
            for(int i=0;i<myMessageParts.Length; ++i)
            {
               Console.WriteLine("Part Name: " +myMessageParts[i].Name);
               Console.WriteLine("Part Type: " +myMessageParts[i].Type);
            }
// </Snippet1>
// <Snippet3>
            // Get another message from ServiceDescription.
            Message myMessage2 = myServiceDescription.Messages["DivideHttpGetOut"];
            MessagePart myMessagePart=myMessage2.FindPartByName("Body");
            Console.WriteLine("Results of FindPartByName operation:");
            Console.WriteLine("Part Name: " +myMessagePart.Name);
            Console.WriteLine("Part Element: " +myMessagePart.Element);
// </Snippet3>
         }
         catch(Exception e)
         {
            Console.WriteLine("Exception: " + e.Message);
         }
      }
   }
}
