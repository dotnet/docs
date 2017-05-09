// System.Runtime.Remoting.Channels.IChannelReceiverHook
// System.Runtime.Remoting.Channels.IChannelReceiverHook.WantsToListen
// System.Runtime.Remoting.Channels.IChannelReceiverHook.ChannelScheme

/*
   This example demonstrates the implementation of the 'ChannelScheme' and
   'WantsToListen' properties of the 'IChannelReceiverHook' interface.
   It creates  a customized channel 'MyCustomChannel' by implementing 
   'IChannelReceiverHook' interface.
*/

using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Security.Permissions;

public class IChannelReceiverHook_ChannelScheme
{
   public static void Main()
   {
      try
      {
         MyCustomChannel myCustomChannelWithPort = 
               new MyCustomChannel(8085);
         MyCustomChannel myCustomChannelNoPort = 
               new MyCustomChannel();
         Console.WriteLine("Channel Scheme of myCustomChannelWithPort : "+
               myCustomChannelWithPort.ChannelScheme);
         Console.WriteLine("Channel Scheme of myCustomChannelNoPort : " +
               myCustomChannelNoPort.ChannelScheme);
         // 'WantsToListen' is false. It is already listening.
         if (myCustomChannelWithPort.WantsToListen) 
         {
            Console.WriteLine("myCustomChannelWithPort wants to listen.");
         }
         else 
         {
            Console.WriteLine("myCustomChannelWithPort doesn't want to " +
                  "listen.");
         }
         // 'WantsToListen' is true.
         if (myCustomChannelNoPort.WantsToListen) 
         {
            Console.WriteLine("myCustomChannelNoPort wants to listen.");
         }
         else
         {
            Console.WriteLine("myCustomChannelNoPort doesn't want to " +
                  "listen.");
         }
      }
      catch(Exception e)
      {
         Console.WriteLine("Exception caught!!!");
         Console.WriteLine("Source : " + e.Source);
         Console.WriteLine("Message : " + e.Message);
      }
   }
}
// <Snippet1>
// Implementation of 'IChannelReceiverHook' interface.
[PermissionSet(SecurityAction.Demand, Name="FullTrust")]
public class MyCustomChannel : IChannelReceiverHook 
{
   private bool portSet;
   // Constructor for MyCustomChannel.
   public MyCustomChannel(int port)
   {
      portSet = true;
   }
   // Constructor for MyCustomChannel.
   public MyCustomChannel()
   {
      portSet = false;
   }
// <Snippet2>
   public bool WantsToListen
   {
      get
      {
         if (portSet)
         {
            return false;
         }
         else
         {
            return true;
         }
      }
   }
// </Snippet2>
// <Snippet3>
   private string MyChannelScheme = "http";
   public string ChannelScheme
   {
      get
      {
         return MyChannelScheme;
      }
   }
// </Snippet3>
   public IServerChannelSink ChannelSinkChain
   {
      get
      {
         // Null implementation.
         return null;
      }
   }
   public void AddHookChannelUri(string channelUri)
   {
      // Null implementation.
   }
}
// </Snippet1>