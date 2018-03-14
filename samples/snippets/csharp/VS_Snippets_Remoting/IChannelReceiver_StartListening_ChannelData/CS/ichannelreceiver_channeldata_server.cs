//  System.Runtime.Remoting.Channels.IChannelReceiver
//  System.Runtime.Remoting.Channels.IChannelReceiver.ChannelData
//  System.Runtime.Remoting.Channels.IChannelReceiver.GetUrlsForUri
//  System.Runtime.Remoting.Channels.IChannelReceiver.StartListening
//  System.Runtime.Remoting.Channels.IChannelReceiver.StopListening

/*
   This example implements the 'ChannelData' property and 'GetUrlsForUri',
   'StartListening' and 'StopListening' method of 'IChannelReceiver' interface.
   It creates a server by implementing 'IChannelReceiver' interface to receive 
   request send by the client.
*/
using System;
using System.IO;
using System.Net;
using System.Threading;
using  System.Net.Sockets;
using System.Runtime.Remoting.Channels;
using System.Text.RegularExpressions;
using System.Security.Permissions;

namespace RemotingSamples 
{
   public class MyIChannelReceiverChannelDataServerClass 
   {
      [PermissionSet(SecurityAction.LinkDemand)]
      public static void Main() 
      {
         MyCustomChannel myChannel = new MyCustomChannel(8085);
         ChannelDataStore myChannelDataStore = 
            (ChannelDataStore)myChannel.ChannelData;
         Console.WriteLine("The channel URI is " + 
            myChannelDataStore.ChannelUris[0]);
         string[] myUrlArray = myChannel.GetUrlsForUri("SayHello");
         Console.WriteLine("The URL for the objectURI is " + myUrlArray[0]); 
         bool continueOption = true;
         while(continueOption)
         {
            Console.WriteLine("");
            Console.WriteLine("Select a option ..");
            Console.WriteLine(" 1 - StartListening");
            Console.WriteLine(" 2 - StopListening");   
            Console.WriteLine(" 3 - Exit");
           
            Console.Write("Option : ");
            int myOption = Int32.Parse(Console.ReadLine());
            switch(myOption)
            {
               case 1:
                  myChannel.StartListening(null);
                  break;
               case 2:
                  myChannel.StopListening(null);
                  break;
               case 3 :
                  continueOption = false;
                  break;
            }
         }
      }
   }
// <Snippet1>
   class MyCustomChannel : IChannelReceiver
   {
      private ChannelDataStore myChannelData;
      private int myChannelPriority = 25;
      // Set the 'ChannelName' to 'MyCustomChannel'.
      private string myChanneName = "tcp";
      // Implement 'ChannelName' property.
      private TcpListener myTcpListener;
      private int myPortNo;
      private bool myListening = false;
      private Thread myThread;
      public MyCustomChannel(int portNo)
      {  
         myPortNo = portNo;
         string [] myURI = new string[1];
         myURI[0] = Dns.Resolve(Dns.GetHostName()).AddressList[0] + ":" +
                                                            portNo.ToString();
         // Store the 'URI' in 'myChannelDataStore'.
         myChannelData = new ChannelDataStore(myURI);
         // Create 'myTcpListener' to listen at the 'myPortNo' port.
         myTcpListener = new TcpListener(myPortNo);
         // Create the thread 'myThread'.
         myThread = new Thread(new ThreadStart(myTcpListener.Start));
         this.StartListening(null);
      }
      public string ChannelName
      {
         get
         {
            return myChanneName;
         }
      }
      public int ChannelPriority
      {
         get
         {
            return myChannelPriority;
         }
      }
      public string Parse(string myUrl, out string objectURI)
      {
         Regex myRegex = new Regex("/",RegexOptions.RightToLeft);
         // Check for '/' in 'myUrl' from Right to left.
         Match myMatch = myRegex.Match(myUrl);
         // Get the object URI.
         objectURI = myUrl.Substring(myMatch.Index);
         // Return the channel url.
         return myUrl.Substring(0,myMatch.Index);   
      }
      // Implementation of 'IChannelReceiver' interface.
// <Snippet2>
      public object ChannelData
      {
         get
         {
            return myChannelData;
         }
      }
// </Snippet2>

// <Snippet3>
      // Create and send the object URL.
      public string[] GetUrlsForUri(string objectURI)
      {
         string[] myString = new string[1];
         myString[0] = Dns.Resolve(Dns.GetHostName()).AddressList[0]
                                                            + "/" + objectURI;
         return myString;
      }
// </Snippet3>

// <Snippet4>
      // Start listening to the port.
      public void StartListening(object data)
      {
         if(myListening == false)
         {
            myTcpListener.Start();
            myListening = true;
            Console.WriteLine("Server Started Listening !!!");
         }
      }
// </Snippet4>

// <Snippet5>
      // Stop listening to the port.
      public void StopListening(object data)
      {
         if(myListening == true)
         {
            myTcpListener.Stop();
            myListening = false;
            Console.WriteLine("Server Stopped Listening !!!");
         }
      }
// </Snippet5>
   }
// </Snippet1>
}