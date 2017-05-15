// <Snippet1>
using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

public class HelloServer : MarshalByRefObject {

    int n_called = 0;
    
    public static void Main() {

// </Snippet1>
// <Snippet2>
        // Registers the server and waits until the user hits enter.
        TcpChannel chan = new TcpChannel(8084);
        ChannelServices.RegisterChannel(chan);

        RemotingConfiguration.RegisterWellKnownServiceType(Type.GetType("HelloServer,server"), 
                                                          "SayHello", 
                                                           WellKnownObjectMode.SingleCall);
        System.Console.WriteLine("Hit <enter> to exit...");
        System.Console.ReadLine();
// </Snippet2>
// <Snippet3>    
    }


    public HelloServer() {
        Console.WriteLine("HelloServer activated");
    }


    ~HelloServer()  {
        Console.WriteLine("Object Destroyed");
    }


    public String HelloMethod(String name)  {
        // Reports that the method was called.
        Console.WriteLine();
        Console.WriteLine("Hello.HelloMethod : {0}", name);
        n_called ++;
        Console.WriteLine("The method was called {0} times.", n_called);

        // Calculates and returns the result to the client.
        return "Hi there " + name;
    }
}
// </Snippet3>