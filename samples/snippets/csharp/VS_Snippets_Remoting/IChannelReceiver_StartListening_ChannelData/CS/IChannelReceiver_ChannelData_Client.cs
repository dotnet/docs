// This program acts as a client and calls the remote method 'HelloMethod'.

using System;
using System.Net;
using System.Collections.Specialized;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Security.Permissions;

namespace RemotingSamples 
{
   public class MyIChannelReceiverChannelDataClientClass
   {
      [PermissionSet(SecurityAction.LinkDemand)]
      public static void Main()
      {
         string myChannelURL = "tcp://" + Dns.Resolve(Dns.GetHostName())
                                          .AddressList[0] + ":8085/SayHello";
         ListDictionary myListDictionary = new ListDictionary();
         myListDictionary.Add("port",8086);
         TcpChannel myCustomChannel = new TcpChannel(myListDictionary,
                                       new SoapClientFormatterSinkProvider(),
                                       new SoapServerFormatterSinkProvider());
         ChannelServices.RegisterChannel(myCustomChannel);
         try
         {
            HelloServer myHelloServer = (HelloServer)Activator.GetObject
                           (typeof(RemotingSamples.HelloServer), myChannelURL);
         if (myHelloServer == null) 
         {
            Console.WriteLine("Could not locate server.");
         }
         else 
         {
            Console.WriteLine(myHelloServer.HelloMethod("Caveman"));
         }
         }
         catch(Exception e)
         {
            Console.WriteLine("Message : " + e.Message);
         }
      }
   }
}