using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Security.Permissions;
using SampleNamespace;

public class SampleClient {
   private const string SERVER_URL = "http://localhost:9000/MySampleService/SampleWellKnown.soap";

   [SecurityPermission(SecurityAction.LinkDemand)]
   public static void Main() {
      Snippet1();
   }

   [SecurityPermission(SecurityAction.LinkDemand)]
   private static void Snippet1() {
      
      // <Snippet1>
      Console.WriteLine("Connecting to SampleNamespace.SampleWellKnown.");
      
      SampleWellKnown proxy = 
         (SampleWellKnown)RemotingServices.Connect(typeof(SampleWellKnown), SERVER_URL);

      Console.WriteLine("Connected to SampleWellKnown");
      
      // Verifies that the object reference is to a transparent proxy.
      if (RemotingServices.IsTransparentProxy(proxy))
          Console.WriteLine("proxy is a reference to a transparent proxy.");
      else
          Console.WriteLine("proxy is not a transparent proxy.  This is unexpected.");
      
      // Calls a method on the server object.
      Console.WriteLine("proxy.Add returned {0}.", proxy.Add(2, 3));
      // </Snippet1>
   }    
}

