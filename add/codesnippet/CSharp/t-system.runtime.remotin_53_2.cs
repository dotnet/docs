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

        // Register a tracking handler.
        ITrackingHandler handler1 = new TrackingHandler();
        TrackingServices.RegisterTrackingHandler(handler1);

        // Register a second handler.
        ITrackingHandler handler2 = new TrackingHandler();
        TrackingServices.RegisterTrackingHandler(handler2);

        // Get the number of currently registered handlers.
        Console.WriteLine("Registered tracking handlers: " + 
            TrackingServices.RegisteredHandlers.Length);

        // Remove the tracking handler from the registered handlers.
        TrackingServices.UnregisterTrackingHandler(handler2);
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