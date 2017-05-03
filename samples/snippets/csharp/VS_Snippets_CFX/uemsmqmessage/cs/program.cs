using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel.MsmqIntegration;
using System.Messaging;

namespace UEMsmqMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            // <Snippet1>
            MsmqMessage<string> message = new MsmqMessage<string>("Hello, world");
            // </Snippet1>

            // <Snippet2>
            MsmqMessage<string> message2 = new MsmqMessage<string>(message.Body);
            // </Snippet2>
            
            // <Snippet3>
            message.AcknowledgeType = AcknowledgeTypes.PositiveArrival;
            // </Snippet3>

            // <Snippet4>
            if (message.Acknowledgment == Acknowledgment.Receive)
                Console.WriteLine("Message sent with Receive acknowledgment");
            // </Snippet4>

            // <Snippet5>
            message.AdministrationQueue = new Uri(".\\private$\\MyAdminQueue");
            // </Snippet5>

            // <Snippet6>
            message.AppSpecific = 5;
            // </Snippet6>

            // <Snippet7>
            Console.WriteLine("Message arrived at the destination queue at {0}", message.ArrivedTime.ToString());
            // </Snippet7>

            // <Snippet8>
            if (message.Authenticated == true)
                Console.WriteLine("Message was authenticated");
            // </Snippet8>

            // <Snippet9>
            string body = message.Body;
            // </Snippet9>

            // <Snippet10>
            message.BodyType = 23;
            // </Snippet10>

            // <Snippet11>
            message.CorrelationId = "This message";
            // </Snippet11>

            // <Snippet12>
            Console.WriteLine("The destination queue is {0}", message.DestinationQueue.ToString());
            // </Snippet12>

            // <Snippet13>
            byte[] buffer = {0x10, 0x11, 0x12, 0x14};
            message.Extension = buffer;
            // </Snippet13>

            // <Snippet14>
            string MessageId = message.Id;
            // </Snippet14>

            // <Snippet15>
            message.Label = "Message1 Label";
            // </Snippet15>

            // <Snippet16>
            Console.WriteLine("The message type is {0}", message.MessageType);
            // </Snippet16>

            // <Snippet17>
            message.Priority = MessagePriority.Normal;
            // </Snippet17>

            // <Snippet18>
            message.ResponseQueue = new Uri(".\\private$\\MyResponseQueue");
            // </Snippet18>

            // <Snippet19>
            Console.WriteLine("SenderID is {0}", message.SenderId);
            // </Snippet19>

            // <Snippet20>
            Console.WriteLine("Message was sent at {0}", message.SentTime);
            // </Snippet20>

            // <Snippet21>
            message.TimeToReachQueue = new TimeSpan(0,10,0);
            // </Snippet21>
        }
    }
}
