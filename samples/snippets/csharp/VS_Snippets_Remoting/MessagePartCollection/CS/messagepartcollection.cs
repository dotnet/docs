// System.Web.Services.Description.MessagePartCollection.Item Property(Int32);
// System.Web.Services.Description.MessagePart.Message;
// System.Web.Services.Description.MessagePartCollection.CopyTo;
// System.Web.Services.Description.MessagePartCollection.Item Property (String);
// System.Web.Services.Description.MessagePartCollection.Contains;
// System.Web.Services.Description.MessagePartCollection.IndexOf;
// System.Web.Services.Description.MessagePartCollection.Remove;
// System.Web.Services.Description.MessagePartCollection;

/* The program reads a wsdl document "MathService.wsdl" and gets ServiceDescription instance.
   A MessagePartCollection instance is then retrieved from each Message and it's members are demonstrated.
*/

// <Snippet8>
using System;
using System.Web.Services.Description;
using System.Collections;
using System.Xml;

class MyClass1
{
   public static void Main()
   {
      Console.WriteLine("");
      Console.WriteLine("MessagePartCollection Sample");
      Console.WriteLine("============================");
      Console.WriteLine("");

      ServiceDescription myServiceDescription = 
         ServiceDescription.Read("MathService.wsdl");

      // Get the message collection.
      MessageCollection myMessageCollection = myServiceDescription.Messages;
      Console.WriteLine("Total Messages in the document = " + 
         myServiceDescription.Messages.Count);
      Console.WriteLine("");
      Console.WriteLine("Enumerating PartCollection for each message...");
      Console.WriteLine("");
// <Snippet1>
// <Snippet2>
      // Get the message part collection for each message.
      for(int i =0; i < myMessageCollection.Count; ++i)
      {
         Console.WriteLine("Message      : " + myMessageCollection[i].Name);

         // Get the message part collection.
         MessagePartCollection myMessagePartCollection = 
            myMessageCollection[i].Parts;

         // Display the part collection.
         for(int k = 0; k < myMessagePartCollection.Count;k++)
         {
            Console.WriteLine("\t       Part Name     : " + 
               myMessagePartCollection[k].Name);
            Console.WriteLine("\t       Message Name  : " + 
               myMessagePartCollection[k].Message.Name);
         }
         Console.WriteLine("");
      }
// </Snippet2>
// </Snippet1>
      Console.WriteLine("Displaying the array copied from the " +
         "MessagePartCollection for the message AddHttpGetIn.");
// <Snippet3>
// <Snippet4>
      Message myLocalMessage = myServiceDescription.Messages["AddHttpPostOut"];
      if (myMessageCollection.Contains(myLocalMessage))
      {
         Console.WriteLine("Message      : " + myLocalMessage.Name);

         // Get the message part collection.
         MessagePartCollection myMessagePartCollection = myLocalMessage.Parts;
         MessagePart[] myMessagePart  = 
            new MessagePart[myMessagePartCollection.Count];

         // Copy the MessagePartCollection to an array.
         myMessagePartCollection.CopyTo(myMessagePart,0);
         for(int k = 0; k < myMessagePart.Length; k++)
         {
            Console.WriteLine("\t       Part Name : " + 
               myMessagePartCollection[k].Name);
         }
         Console.WriteLine("");
      }
// </Snippet4>
// </Snippet3>

// <Snippet5>
// <Snippet6>
// <Snippet7>
      Console.WriteLine("Checking if message is AddHttpPostOut...");
      Message myMessage = myServiceDescription.Messages["AddHttpPostOut"];
      if (myMessageCollection.Contains(myMessage))
      {
         // Get the message part collection.
         MessagePartCollection myMessagePartCollection = myMessage.Parts;

         // Get the part named Body.
         MessagePart myMessagePart = myMessage.Parts["Body"];
         if (myMessagePartCollection.Contains(myMessagePart))
         {
            // Get the index of the part named Body.
            Console.WriteLine("Index of Body in MessagePart collection = " + 
               myMessagePartCollection.IndexOf(myMessagePart));
            Console.WriteLine("Deleting Body from MessagePart collection...");
            myMessagePartCollection.Remove(myMessagePart);
            if(myMessagePartCollection.IndexOf(myMessagePart)== -1)
            {
               Console.WriteLine("MessagePart Body successfully deleted " +
                  "from the message AddHttpPostOut.");
            }
         }
      }
// </Snippet7>
// </Snippet6>
// </Snippet5>
   }
}
// </Snippet8>
