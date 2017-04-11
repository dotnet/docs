// System.Runtime.Remoting.Channels.ChannelServices.GetChannel
// System.Runtime.Remoting.Channels.ChannelServices.GetChannelSinkProperties
/*
   This example demonstrates the usage of the properties 'GetChannel' and 
   'GetChannelSinkProperties' of the 'ChannelServices' class. It displays
   the registered channel name, priority and channelsinkproperties
   for a given proxy and executes a remote method 'HelloMethod'.
*/
using System;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Collections; 
using System.Collections.Specialized; 
using System.Security.Permissions;

namespace RemotingSamples
{
   public class MyChannelServices_Client
   {
      [PermissionSet(SecurityAction.LinkDemand)]
      public static void Main()
      {
         ListDictionary myProperties = new ListDictionary();
         myProperties.Add("port",8085);
         myProperties.Add("name","MyHttpChannel");
// <Snippet1>
         HttpChannel myClientChannel = new HttpChannel(myProperties,
            new SoapClientFormatterSinkProvider(),
            new SoapServerFormatterSinkProvider());
         ChannelServices.RegisterChannel(myClientChannel);
         // Get the registered channel. 
         Console.WriteLine("Channel Name : "+ChannelServices.GetChannel(
            myClientChannel.ChannelName).ChannelName);
         Console.WriteLine("Channel Priorty : "+ChannelServices.GetChannel(
            myClientChannel.ChannelName).ChannelPriority);
// </Snippet1>
         HelloServer myProxy = (HelloServer)Activator.GetObject(typeof(
            RemotingSamples.HelloServer), "http://localhost:8086/SayHello");
// <Snippet2>
         // Get an IDictionary of properties for a given proxy.
         IDictionary myDictionary = ChannelServices.
                  GetChannelSinkProperties(myProxy);
         ICollection myKeysCollection = myDictionary.Keys;
         object[] myKeysArray = new object[myKeysCollection.Count];
         ICollection myValuesCollection = myDictionary.Values;
         object[] myValuesArray = new object[myValuesCollection.Count];
         myKeysCollection.CopyTo(myKeysArray,0);
         myValuesCollection.CopyTo(myValuesArray,0);
         for(int iIndex=0;iIndex<myKeysArray.Length;iIndex++)
         {
            Console.WriteLine("Property Name : "+myKeysArray[iIndex]+ 
               " value : "+myValuesArray[iIndex]);
         }
// </Snippet2>
         if (myProxy == null)
            System.Console.WriteLine("Could not locate server");
         else
            Console.WriteLine(myProxy.HelloMethod("Caveman"));
      }
   }
}
  