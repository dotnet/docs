//<Snippet1>
using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace UE.Wfc.Samples
{
    public static class ActionMessageFilterMatching
    {
        public static void Main()
        {
            // Create several action filters.
            // <Snippet2>
            ActionMessageFilter myActFltr = new ActionMessageFilter("1st Action", "2nd Action");
            // </Snippet2>
            ActionMessageFilter yourActFltr = new ActionMessageFilter("Your Action");

            // Display the ActionMessageFilter actions.
            ReadOnlyCollection<string> results = myActFltr.Actions;

            foreach (string result in results)
            {
                System.Console.WriteLine(result);
            }

            // Create a message.
            Message message = Message.CreateMessage(MessageVersion.Soap12WSAddressing10, "myBody");

            // Test the message action against a single action filter.
            bool test1 = myActFltr.Match(message);
            bool test2 = yourActFltr.Match(message);
            System.Console.WriteLine("The result of test1 is {0}", test1);
            System.Console.WriteLine("The result of test2 is {0}", test2);
        }
    }
}
//</Snippet1>