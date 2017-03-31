// System.Runtime.Remoting.WellKnownServiceTypeEntry

/*
The following example demonstrates the 'WellKnownServiceTypeEntry' class. 
It registers a 'HttpChannel' object with the channel services. Then registers the 'HelloServer'
type as well known type with the Remoting Infrastructure at the service end . It displays the 
properties of the 'WellKnownServiceTypeEntry' object holding the values for the above well-known
type .
*/

// <Snippet1>
   using System;
   using System.Runtime.Remoting;
   using System.Runtime.Remoting.Channels;
   using System.Runtime.Remoting.Channels.Http;

   public class MyServer 
   {
      public static void Main() 
      {
         // Create a 'HttpChannel' object and register it with the 
         // channel services.
         ChannelServices.RegisterChannel(new HttpChannel(8086));
         // Record the 'HelloServer' type as 'Singleton' well-known type.
         WellKnownServiceTypeEntry myWellKnownServiceTypeEntry= 
             new WellKnownServiceTypeEntry(typeof(HelloServer),
                                           "SayHello",
                                           WellKnownObjectMode.Singleton);
         // Register the remote object as well-known type.
         RemotingConfiguration.RegisterWellKnownServiceType(
                                             myWellKnownServiceTypeEntry);
         // Retrieve object types registered on the service end 
         // as well-known types.
         WellKnownServiceTypeEntry [] myWellKnownServiceTypeEntryCollection = 
               RemotingConfiguration.GetRegisteredWellKnownServiceTypes();
         Console.WriteLine("The 'WellKnownObjectMode' of the remote object : "
                          +myWellKnownServiceTypeEntryCollection[0].Mode);
         Console.WriteLine("The 'WellKnownServiceTypeEntry' object: "+
                     myWellKnownServiceTypeEntryCollection[0].ToString());
         Console.WriteLine("Started the Server, Hit <enter> to exit...");
         Console.ReadLine();
      }
   }
// </Snippet1>
