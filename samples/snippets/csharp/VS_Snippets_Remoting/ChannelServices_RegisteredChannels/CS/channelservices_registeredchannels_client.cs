// System.Runtime.Remoting.Channels.ChannelServices.GetUrlsForObject(MarshalByRefObject)
/*
   The following example demonstrates the method 'GetUrlsForObject' 
   of the class 'ChannelServices'. The example is just a client, it 
   locates and connects to the server, retrieves a proxy for the remote 
   object, and calls the 'HelloMethod' on the remote object, passing the 
   string 'Caveman' as a parameter. The server returns the string
   'Hi there Caveman'.  
*/
using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels.Http;
using System.Security.Permissions;

namespace RemotingSamples {
   public class MyChannelServices_Client
   {
      [PermissionSet(SecurityAction.LinkDemand)]
      public static void Main()
      {
         try
         {
            TcpChannel myTcpChannel = new TcpChannel(8084);
            ChannelServices.RegisterChannel(myTcpChannel);
            HelloServer myHelloServer = (HelloServer)Activator.GetObject(typeof
               (RemotingSamples.HelloServer), "tcp://localhost:8080/SayHello");
            if (myHelloServer == null) 
               System.Console.WriteLine("Could not locate server");
            else
            {
// <Snippet4>
               string[] myURLArray = ChannelServices.GetUrlsForObject(myHelloServer);
               Console.WriteLine("Number of URLs for the specified Object: "
                  +myURLArray.Length);
               for (int iIndex=0; iIndex<myURLArray.Length; iIndex++)
                  Console.WriteLine("URL: "+myURLArray[iIndex]);
// </Snippet4>
               Console.WriteLine(myHelloServer.HelloMethod("Caveman"));
            }
         }
         catch(Exception e)
         {
            Console.WriteLine("Exception caught!!!");
            Console.WriteLine("The source of exception: "+e.Source);
            Console.WriteLine("The Message of exception: "+e.Message);
         }      
      } 
   }
}
