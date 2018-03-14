// System.Web.Services.Description.ServiceDescription.ServiceDescription()
// System.Web.Services.Description.ServiceDescription.Read(string)
// System.Web.Services.Description.ServiceDescription.Messages
// System.Web.Services.Description.ServiceDescription.Name

/* 
   The following example demonstrates the constructor 'ServiceDescription()', 
   properties 'Messages', 'Name' and 'Read'  method of 'ServiceDescription'
   class.The input to the program is a WSDL file 'MyWsdl.wsdl'.
   This program removes one message from the existing WSDL.
   A new Message is defined and added to the ServiceDescription.
   A new wsdl with modified ServiceDescription is written in 'MyOutWsdl.wsdl'.
*/
using System;
using System.Web.Services;
using System.Web.Services.Description;
using System.Xml;

namespace ServiceDescription1
{
   class MyService
   {
      static void Main()
      {
// <Snippet1>
// <Snippet2>
// <Snippet3>
// <Snippet4>

         ServiceDescription myDescription = new ServiceDescription();
         myDescription = ServiceDescription.Read("MyWsdl_CS.wsdl");
         myDescription.Name = "MyServiceDescription";
         Console.WriteLine("Name: " + myDescription.Name);
         MessageCollection myMessageCollection = myDescription.Messages;
         
         // Remove the message at index 0 from the message collection.
         myMessageCollection.Remove(myDescription.Messages[0]);
         
         // Build a new message.
         Message myMessage = new Message();
         myMessage.Name = "AddSoapIn";
         
         // Build a new MessagePart.
         MessagePart myMessagePart = new MessagePart();
         myMessagePart.Name = "parameters";
         XmlQualifiedName myXmlQualifiedName = new XmlQualifiedName("s0:Add");
         myMessagePart.Element = myXmlQualifiedName;
         
         // Add MessageParts to the message.
         myMessage.Parts.Add(myMessagePart);

         // Add the message to the ServiceDescription.
         myDescription.Messages.Add(myMessage);
         myDescription.Write("MyOutWsdl.wsdl");
// </Snippet4>
// </Snippet3>
// </Snippet2>
// </Snippet1>
      }
   }
}
