using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            // <Snippet1>
            // <Snippet2>
            // Create a new reliable session object
            ReliableSessionBindingElement bindingElement = new ReliableSessionBindingElement();
            ReliableSession reliableSession = new ReliableSession(bindingElement);

            // Now you can access property values
            Console.WriteLine("Ordered: {0}", reliableSession.Ordered);
            Console.WriteLine("InactivityTimeout: {0}", reliableSession.InactivityTimeout);
            // </Snippet2>
            reliableSession.Ordered = false;
            Console.WriteLine("The new value for the Ordered property is: {0}", reliableSession.Ordered);
            // </Snippet1>
        }
    }
}
