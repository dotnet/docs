using System;
using System.ServiceModel;

namespace UE.Samples
{
    class Snippets
    {
        public static void Snippet3()
        {
            // <Snippet3>
            // Open up a channel factory on a client application.
            ChannelFactory<ISayHello> factory = new ChannelFactory<ISayHello>("BasicHttpBinding_ISayHello");

            // Both of these contracts work (provided both hostnames are valid) because
            // the binding configuration is set to hostNameComparisonMode="StrongWildcard".
            
            ISayHello channel = factory.CreateChannel(new EndpointAddress("http://localhost:8000/UESamples/HelloService"));
            ISayHello channel2 = factory.CreateChannel(new EndpointAddress("http://machineName/UESamples/HelloService"));

            Console.WriteLine(channel.SayHello());
            
            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate client.");
            Console.ReadLine();
            // </Snippet3>
        }
    }
}
