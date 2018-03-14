///    Class:    System.Runtime.Remoting.Services.TrackingServices
///    Sample:    System.Runtime.Remoting.Services.TrackingServices
///    0    class - Client.cs
///    10    class - RemoteService.cs
///    20    class - Server.cs
///    30    class - TrackingHandler.cs
///    21    RegisterTrackingHandler()
///    22    RegisteredHandlers()
///    23    UnregisterTrackingHandler()

//<snippet20>
using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Services;
using System.Security.Permissions;

public class Server
{
[SecurityPermission(SecurityAction.Demand)]
    public static void Main(string[] args)
    {
        // Register the TCP channel.
        TcpChannel channel = new TcpChannel(1234);
        ChannelServices.RegisterChannel(channel);

        //<snippet21>
        // Register a tracking handler.
        ITrackingHandler handler1 = new TrackingHandler();
        TrackingServices.RegisterTrackingHandler(handler1);
        //</snippet21>

        // Register a second handler.
        ITrackingHandler handler2 = new TrackingHandler();
        TrackingServices.RegisterTrackingHandler(handler2);

        //<snippet22>
        // Get the number of currently registered handlers.
        Console.WriteLine("Registered tracking handlers: " + 
            TrackingServices.RegisteredHandlers.Length);
        //</snippet22>

        //<snippet23>
        // Remove the tracking handler from the registered handlers.
        TrackingServices.UnregisterTrackingHandler(handler2);
        //</snippet23>
        Console.WriteLine("Registered tracking handlers: " + 
            TrackingServices.RegisteredHandlers.Length);

        // Create and marshal an object for remote invocation.
        RemoteService service = new RemoteService();
        ObjRef obj = RemotingServices.Marshal(service, "TcpService");

        // Wait for the user prompt.
        Console.WriteLine("\r\nPress ENTER to unmarshal the object.");
        Console.ReadLine();

        // Unmarshal the object.
        RemotingServices.Unmarshal(obj);

        // Wait for the user prompt.
        Console.WriteLine("Press ENTER to disconnect the object.");
        Console.ReadLine();

        // Disconnect the object.
        RemotingServices.Disconnect(service);
    }
}
//</snippet20>
