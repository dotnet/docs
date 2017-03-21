   using System;
   using System.Runtime.Remoting;
   using System.Runtime.Remoting.Channels;
   using System.Runtime.Remoting.Channels.Http;

   public class MyClient 
   {
      public static void Main()
      {
      // Create a 'HttpChannel' object and  register with channel services.
      ChannelServices.RegisterChannel(new HttpChannel());
      Console.WriteLine(" Start calling from Client One.......");
      WellKnownClientTypeEntry myWellKnownClientTypeEntry = 
                     new WellKnownClientTypeEntry(typeof(HelloServer),
                                     "http://localhost:8086/SayHello");
      myWellKnownClientTypeEntry.ApplicationUrl="http://localhost:8086/SayHello";
      RemotingConfiguration.RegisterWellKnownClientType(myWellKnownClientTypeEntry);
      // Get the proxy object for the remote object.
      HelloServer myHelloServerObject = new HelloServer();
      // Retrieve an array of object types registered on the 
      // client end as well-known types.
      WellKnownClientTypeEntry [] myWellKnownClientTypeEntryCollection = 
             RemotingConfiguration.GetRegisteredWellKnownClientTypes();
      Console.WriteLine("The Application Url to activate the Remote Object :"
           +myWellKnownClientTypeEntryCollection[0].ApplicationUrl);
      Console.WriteLine("The 'WellKnownClientTypeEntry' object :"
               +myWellKnownClientTypeEntryCollection[0].ToString());
      // Make remote method calls.
      for (int i = 0; i < 5; i++)
            Console.WriteLine(myHelloServerObject.HelloMethod(" Client One"));
      }
   }