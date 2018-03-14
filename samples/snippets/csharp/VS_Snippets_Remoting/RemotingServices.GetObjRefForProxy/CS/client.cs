using System;
using System.Net.Sockets;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Lifetime;
using System.Security.Permissions;
using SampleNamespace;

public class SampleClient : MarshalByRefObject {
    [SecurityPermission(SecurityAction.LinkDemand)]
    public static void Main() {
        ChannelServices.RegisterChannel(new HttpChannel(0));
        RemotingConfiguration.RegisterActivatedClientType(typeof(SampleService), "http://localhost:9000/MySampleService");
        SampleService myRemoteObject = new SampleService();
        bool result = myRemoteObject.SampleMethod();
        // System.Runtime.Remoting.RemotingServices.GetObjRefForProxy
        
        // <Snippet1>
        ObjRef objRefSample = RemotingServices.GetObjRefForProxy(myRemoteObject);
        
        Console.WriteLine("***ObjRef Details***");
        Console.WriteLine("URI:\t{0}", objRefSample.URI);
        
        object[] channelData = objRefSample.ChannelInfo.ChannelData;
        
        Console.WriteLine("Channel Info:");
        foreach(object o in channelData)
            Console.WriteLine("\t{0}", o.ToString());
        
        IEnvoyInfo envoyInfo = objRefSample.EnvoyInfo;
        
        if (envoyInfo == null) {
            Console.WriteLine("This ObjRef does not have envoy information.");
        }
        else {
            IMessageSink envoySinks = envoyInfo.EnvoySinks;
            Console.WriteLine("Envoy Sink Class: {0}", envoySinks);
        }
        
        IRemotingTypeInfo typeInfo = objRefSample.TypeInfo;
        Console.WriteLine("Remote type name: {0}", typeInfo.TypeName);
        
        Console.WriteLine("Can my object cast to a Bitmap? {0}",
            typeInfo.CanCastTo(typeof(System.Drawing.Bitmap), objRefSample));
        // </Snippet1>
    }
}
